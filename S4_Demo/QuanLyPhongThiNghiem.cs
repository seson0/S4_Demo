using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Demo
{
    internal class QuanLyPhongThiNghiem
    {
        private List<NhanVien> danhSachNhanVien;

        public QuanLyPhongThiNghiem()
        {
            danhSachNhanVien = new List<NhanVien>();
        }

        // Phương thức nhập thông tin nhân viên
        public void NhapThongTin()
        {
            while (true)
            {
                Console.WriteLine("Chọn loại nhân viên để nhập (1. Nhà khoa học, 2. Nhà quản lý, 3. Nhân viên phòng thí nghiệm, 0. Thoát): ");
                int luaChon = int.Parse(Console.ReadLine());

                if (luaChon == 0)
                    break;

                Console.Write("Họ tên: ");
                string hoTen = Console.ReadLine();

                Console.Write("Năm sinh: ");
                int namSinh = int.Parse(Console.ReadLine());

                Console.Write("Bằng cấp: ");
                string bangCap = Console.ReadLine();

                switch (luaChon)
                {
                    case 1:
                        // Nhập thông tin nhà khoa học
                        Console.Write("Chức vụ: ");
                        string chucVuNKH = Console.ReadLine();

                        Console.Write("Số bài báo đã công bố: ");
                        int soBaiBao = int.Parse(Console.ReadLine());

                        Console.Write("Số ngày công trong tháng: ");
                        int soNgayCongNKH = int.Parse(Console.ReadLine());

                        Console.Write("Bậc lương: ");
                        double bacLuongNKH = double.Parse(Console.ReadLine());

                        danhSachNhanVien.Add(new NhaKhoaHoc(hoTen, namSinh, bangCap, chucVuNKH, soNgayCongNKH, bacLuongNKH, soBaiBao));
                        break;

                    case 2:
                        // Nhập thông tin nhà quản lý
                        Console.Write("Chức vụ: ");
                        string chucVuNQL = Console.ReadLine();

                        Console.Write("Số ngày công trong tháng: ");
                        int soNgayCongNQL = int.Parse(Console.ReadLine());

                        Console.Write("Bậc lương: ");
                        double bacLuongNQL = double.Parse(Console.ReadLine());

                        danhSachNhanVien.Add(new NhaQuanLy(hoTen, namSinh, bangCap, chucVuNQL, soNgayCongNQL, bacLuongNQL));
                        break;

                    case 3:
                        // Nhập thông tin nhân viên phòng thí nghiệm
                        Console.Write("Lương trong tháng: ");
                        double luongThang = double.Parse(Console.ReadLine());

                        danhSachNhanVien.Add(new NhanVienPhongThiNghiem(hoTen, namSinh, bangCap, luongThang));
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            }
        }

        // Phương thức xuất thông tin tất cả nhân viên
        public void XuatDanhSachNhanVien()
        {
            Console.WriteLine("Danh sách nhân viên:");
            foreach (var nv in danhSachNhanVien)
            {
                nv.XuatThongTin();
                Console.WriteLine(); // Dòng trống để phân biệt giữa các nhân viên
            }
        }

        // Phương thức tính tổng lương
        public double TinhTongLuong()
        {
            double tongLuong = 0;
            foreach (var nv in danhSachNhanVien)
            {
                tongLuong += nv.TinhLuong();
            }
            return tongLuong;
        }
    }
}
