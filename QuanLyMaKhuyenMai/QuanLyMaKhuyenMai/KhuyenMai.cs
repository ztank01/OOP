using System;
using System.Collections.Generic;
using System.Linq;
namespace QuanLyMaKhuyenMai
{
    abstract class KhuyenMai
    {
        protected DateTime ngayTao;
        protected DateTime ngayHetHan;
        public string maKhuyenMai;
        public bool ConHieuLuc()
        {
            return (DateTime.Compare(ngayHetHan.Date, DateTime.Now.Date) == 1);
        }
        public abstract void HienThi();
        public abstract double SuDung(double gia);
        public abstract bool ThoaDieuKien(DanhSachSanPham Ds);

    }
    class KhuyenMaiLoaiA : KhuyenMai
    {
        private static int soMa = 1;
        public double PhanTramGiam { get; }
        public KhuyenMaiLoaiA(int y, int m, int d, double phantramgiam)
        {
            this.ngayTao = DateTime.Now;
            this.ngayHetHan = new DateTime(y, m, d);
            this.PhanTramGiam = phantramgiam;
            if (soMa > 99)
            {
                Console.WriteLine("Het ma, khong the tao.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                this.maKhuyenMai ="A"+ string.Format("{0,2:00}", soMa);
                soMa++;
            }
        }
        public override double SuDung(double gia)
        {
            return gia - gia * (PhanTramGiam / 100);
        }
        public override bool ThoaDieuKien(DanhSachSanPham Ds)
        {
            return true;
        }
        public override void HienThi()
        {
            Console.WriteLine("MaKhuyenMai: {0}", this.maKhuyenMai);
            Console.WriteLine("Tac dung: Giam {0}% gia cua san pham", this.PhanTramGiam);
            Console.WriteLine();
        }

    }
    class KhuyenMaiLoaiB : KhuyenMai
    {
        public string DichVuTangkem { get; set; }
        private Random rand = new Random();
        private static bool[] KiemTra = new bool[9000];
        private static int count = 0;
        private List<string> DsDvtangkem;
        public KhuyenMaiLoaiB(int y, int m, int d,int SoDv)
        {
            this.ngayTao = DateTime.Now;
            this.ngayHetHan = new DateTime(y, m, d);
            this.DsDvtangkem = new List<string>();
            if (count > 9000)
            {
                Console.WriteLine("Het ma khuyen mai");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                bool flag = false;
                do
                {
                    int temp = rand.Next(1000, 10000);
                    if (KiemTra[temp - 1000] == false)
                    {
                        maKhuyenMai = "B" + temp.ToString();
                        KiemTra[temp - 1000] = true;
                        count++;
                        flag = KiemTra[temp - 1000];
                    }
                } while (!flag);
            }
            Console.WriteLine(string.Format("Moi nhap {0} dich vu cho ma khuyen mai " 
                                                    + this.maKhuyenMai,SoDv));
            NhapDsDichVu(SoDv);
        }
        public void NhapDsDichVu(int n)
        {
            for(int i=0; i<n; i++)
            {
                DichVuTangkem = Console.ReadLine();
                this.DsDvtangkem.Add(DichVuTangkem);
            }
        }
        public override double SuDung(double gia)
        {
            return gia;
        }
        public static void init()
        {
            for (int i = 0; i < 9000; i++)
            {
                KiemTra[i] = false;
            }
        }
        public override bool ThoaDieuKien(DanhSachSanPham Ds)
        {
            return true;
        }
        public override void HienThi()
        {
            Console.WriteLine("MaKhuyenMai: {0}", this.maKhuyenMai);
            Console.WriteLine("Cac dich vu tang kem: ");
            foreach (string x in this.DsDvtangkem)
                Console.WriteLine(x);
            Console.WriteLine();
        }
    }
    class KhuyenMaiLoaiC : KhuyenMai
    {
        private static int count = 1;
        private List<SanPham> DsSpMuaKem;
        private double PhanTramGiam;
        private int SoSpTrongDs;
        public KhuyenMaiLoaiC(int y, int m, int d, double phantramgiam, int soSpYeuCau)
        {
            this.ngayTao = DateTime.Now;
            this.ngayHetHan = new DateTime(y, m, d);
            this.PhanTramGiam = phantramgiam;
            this.DsSpMuaKem = new List<SanPham>();
            this.SoSpTrongDs = soSpYeuCau;           
            if (count > 9999)
            {
                Console.WriteLine("Het ma, khong the tao.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                this.maKhuyenMai = "C"+string.Format("{0,4:0000}", count);
                count++;
            }
        }
        public void NhapDsSpMuaKem(DanhSachSanPham Ds)
        {
            Console.WriteLine(string.Format("Moi nhap {0} san pham cho ma khuyen mai "
                                                    + this.maKhuyenMai, this.SoSpTrongDs));
            for (int i = 0; i < this.SoSpTrongDs; i++)
            {
                Console.WriteLine(string.Format("Nhap ma san pham thu {0}", i + 1));
                string ma = Console.ReadLine();
                SanPham temp=Ds.TimSanPham(ma);
                while(temp==null)
                {
                    Console.WriteLine("Khong co san pham nay! Moi nhap lai:");
                    ma = Console.ReadLine();
                    temp = Ds.TimSanPham(ma);
                }    
                temp.ThemMaKhuyenMai(this);
                this.DsSpMuaKem.Add(temp);
            }
        }
        public override bool ThoaDieuKien(DanhSachSanPham Ds)
        {
            int c = 0;
            foreach (SanPham x in this.DsSpMuaKem)
                foreach (SanPham y in Ds.DsSanPham)
                    if (x.MaSanPham == y.MaSanPham)
                        c++;
            if (c == this.SoSpTrongDs)
                return true;
            else
                return false;
        }
        public override double SuDung(double gia)
        {
            return gia - gia * (PhanTramGiam / 100);
        }
        public override void HienThi()
        {
            Console.WriteLine("MaKhuyenMai: {0}", this.maKhuyenMai);
            Console.WriteLine("Danh sach san pham duoc khuyen mai khi mua cung voi nhau : ");
            foreach (SanPham x in DsSpMuaKem)
                Console.Write(x.TenSanPham + "  ");
            Console.WriteLine();
            Console.WriteLine("Tac dung: Giam {0}% gia cua san pham", this.PhanTramGiam);
            Console.WriteLine();
        }
    }

}



