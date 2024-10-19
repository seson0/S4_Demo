using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_Demo
{
    internal class NhaKhoaHoc : NhaQuanLy
    {
        // tạo thuộc tính SoBaiBao
        public int SoBaiBao { get; set; }

        public NhaKhoaHoc(string hoTen, int namSinh, string bangCap, string chucVu, int soNgayCong, double bacLuong, int soBaiBao) : base(hoTen, namSinh, bangCap, chucVu, soNgayCong, bacLuong)
        {
            SoBaiBao = soBaiBao;
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine($"Số bài báo: {SoBaiBao}");
        }

    }
}
