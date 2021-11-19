using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyMaKhuyenMai
{
    class SanPham
    {
        public static int dem = 0;
        public int  MaSanPham{get; }
        public string TenSanPham { get; }
        public double GiaGoc { get; }
        public List<KhuyenMai> DsMaKhuyenMai;
        public string LoaiSanPham { get; }
        public SanPham(string ten, double gia, string loai)
        {
            this.MaSanPham = dem;
            this.TenSanPham = ten;
            this.GiaGoc = gia;
            this.LoaiSanPham = loai;
            this.DsMaKhuyenMai = new List<KhuyenMai>();
            dem++;
        }
        public void HienThi(DanhSachSanPham Ds)
        {
            Console.Write(this.TenSanPham + "   ");
            Console.Write(this.SuDungMaKhuyenMai(Ds) + "  ");
            foreach (KhuyenMai x in this.DsMaKhuyenMai)
                x.HienThi();
            Console.WriteLine();
        }
        public double SuDungMaKhuyenMai(DanhSachSanPham Ds)
        {
            double giaGiam = GiaGoc;
            foreach (KhuyenMai x in this.DsMaKhuyenMai)
                if (x.ThoaDieuKien(Ds))
                    giaGiam = x.SuDung(giaGiam);
            return giaGiam;
        }
        public void ThemMaKhuyenMai(KhuyenMai x)
        {
            this.DsMaKhuyenMai.Add(x);
        }
        public void XoaMaKhuyeMaiHetHieuLuc()
        {
            int length = DsMaKhuyenMai.Count;
            int i = 0;
            while(i<length)
            {
                if (!DsMaKhuyenMai[i].ConHieuLuc())
                {
                    DsMaKhuyenMai.RemoveAt(i);
                    length = DsMaKhuyenMai.Count;
                    i = 0;
                }
                else
                    i++;
            }
            Console.WriteLine("Da xoa");
        }
        public void HienThiTatCaMaKhuyenMai()
        {
            this.DsMaKhuyenMai.ForEach(x => x.HienThi());
        }
        public int SoLuongKhuyenMaiConHieuLuc()
        {
            int c = 0;
            foreach (KhuyenMai x in this.DsMaKhuyenMai)
                if (x.ConHieuLuc())
                    c++;
            return c;
        }
        public bool CoKhuyenMaiLoai(string a)
        {
            foreach (KhuyenMai x in this.DsMaKhuyenMai)
                if (x.maKhuyenMai.Contains(a))
                    return true;
            return false;
        }

    }
}
