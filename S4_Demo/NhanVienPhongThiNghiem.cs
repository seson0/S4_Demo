using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Demo
{
    internal class NhanVienPhongThiNghiem : NhanVien
    {
        public double LuongTrongThang { get; set; }

        public NhanVienPhongThiNghiem(string hoTen, int namSinh, string bangCap, double luongTrongThang) : base(hoTen, namSinh, bangCap)
        {
            LuongTrongThang = luongTrongThang;
        }

        public override double TinhLuong()
        {
            return LuongTrongThang;
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine($"Lương trong tháng: {LuongTrongThang}");
        }
    }
}
