using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyMaKhuyenMai
{
    class DanhSachSanPham
    {
        public List<SanPham> DsSanPham;
        public delegate bool SoSanh(SanPham x, string s);
        public DanhSachSanPham()
        {
            this.DsSanPham = new List<SanPham>();
        }
        public void ThemSanPham(SanPham x)
        {
            this.DsSanPham.Add(x);
        }
        public void TimKiemPhanTu(double min, double max,DanhSachSanPham Ds)
        {
            foreach (SanPham x in this.DsSanPham)
                if (x.SuDungMaKhuyenMai(Ds) <= max && x.SuDungMaKhuyenMai(Ds) >= min)
                    x.HienThi(this);
        }
        public void XuatDanhSachChuaMaKhuyenMaiLoai()
        {
            Console.WriteLine("Nhap so loai ma khuyen mai");
            int c = int.Parse(Console.ReadLine());
            for (int i= 0; i < c; i++)
            {
                Console.WriteLine("Nhap loai khuyen mai");
                string a = Console.ReadLine();
                foreach (SanPham x in this.DsSanPham)
                    if (x.CoKhuyenMaiLoai(a))
                        x.HienThi(this);
            }
        }      
        public void SapXepTheoSoLuongKhuyenMaiGiamDan()
        {
            this.DsSanPham.Sort((x1, x2) =>
            {
                int soLuong1 = x1.SoLuongKhuyenMaiConHieuLuc();
                int soLuong2 = x2.SoLuongKhuyenMaiConHieuLuc();
                if (soLuong1 > soLuong2)
                    return -1;
                else
                    if (soLuong1 < soLuong2)
                    return 1;
                else
                    return 0;

            });
            foreach (SanPham x in this.DsSanPham)
                x.HienThi(this);
        }
        public void HienThiKhuyenMai(string s, SoSanh c)
        {
            foreach (SanPham x in this.DsSanPham)
                if (c(x, s))
                    x.HienThiTatCaMaKhuyenMai();
        }
        public bool SoSanhTheoTen(SanPham x, string s)
        {
            return x.TenSanPham.Contains(s);
        }
        public bool SoSanhTheoMa(SanPham x, string s)
        {
            int kw = int.Parse(s);
            return x.MaSanPham == kw;
        }
        public SanPham TimSanPham(string ma)
        {
            int temp = int.Parse(ma);
            foreach (SanPham x in this.DsSanPham)
                if(x.MaSanPham == temp)
                    return x;
            return null;
        }
        public void ThanhToan(DanhSachSanPham Ds)
        {
            double ThanhTien = 0;
            foreach (SanPham x in this.DsSanPham)
                    ThanhTien += x.SuDungMaKhuyenMai(Ds);
            Console.WriteLine("Thanh tien: {0}", ThanhTien);
        }
    }
}