using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Demo
{
    internal abstract class NhanVien
    {
        public string HoTen { get; set; }
        public int NamSinh { get; set; }
        public string BangCap { get; set; }

        public NhanVien(string hoTen, int namSinh, string bangCap)
        {
            HoTen = hoTen;
            NamSinh = namSinh;
            BangCap = bangCap;
        }

        // Phương thức ảo để tính lương
        public abstract double TinhLuong();

        // Phương thức xuất thông tin nhân viên
        public virtual void XuatThongTin()
        {
            Console.WriteLine($"Họ tên: {HoTen}, Năm sinh: {NamSinh}, Bằng cấp: {BangCap}");
        }
    }
}
