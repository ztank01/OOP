using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyMaKhuyenMai
{
    class Program
    {
        static void Main(string[] args)
        {
            SanPham KemDanhRang = new SanPham("Kem danh rang", 15000, "Ve Sinh");
            SanPham BanChai = new SanPham("Ban chai", 10000, "Ve Sinh");
            SanPham BanhMi = new SanPham("Banh mi", 10000, "Thuc pham");
            SanPham NuocNgot = new SanPham("Nuoc Ngot", 8000, "Thuc pham");
            SanPham DienThoai = new SanPham("Dien thoai", 3500000, "Dien tu");
            DanhSachSanPham DsQLSanPham = new DanhSachSanPham();
            KhuyenMai x = new KhuyenMaiLoaiA(2020, 12, 2, 30);
            KhuyenMai  y= new KhuyenMaiLoaiA(2020, 12, 2, 30);
            KhuyenMai z = new KhuyenMaiLoaiA(2020, 12, 2, 30);
            KemDanhRang.ThemMaKhuyenMai(x);
            KemDanhRang.ThemMaKhuyenMai(y);
            KemDanhRang.ThemMaKhuyenMai(z);
            KemDanhRang.XoaMaKhuyeMaiHetHieuLuc();
            KemDanhRang.HienThi(DsQLSanPham);
        }
    }
}
