using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập encoding của console sang UTF-8
            Console.OutputEncoding = Encoding.UTF8;
            // tạo ngẫu nhiên 1 số có 3 chữ số từ 100 đến 999

            QuanLyPhongThiNghiem qlPhongThiNghiem = new QuanLyPhongThiNghiem();

            // Nhập thông tin nhân viên
            qlPhongThiNghiem.NhapThongTin();

            // Xuất thông tin nhân viên
            qlPhongThiNghiem.XuatDanhSachNhanVien();

            // Tính và hiển thị tổng lương
            double tongLuong = qlPhongThiNghiem.TinhTongLuong();
            Console.WriteLine($"Tổng lương đã chi trả: {tongLuong}");


            Console.ReadLine();
        }
    }
}
