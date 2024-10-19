using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBanVeRapPhim
{
    public partial class FrmMain : Form
    {
        //khởi tạo danh sách lưu các Button được chọn 
        List<Button> danhSachGheChon = new List<Button>();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            CaiDatThongTin();
        }

        private void CaiDatThongTin()
        {
            //Cài đặt thông tin ô tổng tiền 0đ
            txtTongTien.Text = "0 VNĐ";
            //Thêm khu vực "Tp.HCM", "Đồng Nai", "Bình Dương" vào comboxbox cmbKhuVuc 
            cmbKhuVuc.Items.Add("Tp.HCM");
            cmbKhuVuc.Items.Add("Đồng Nai");
            cmbKhuVuc.Items.Add("Bình Duong");
            cmbKhuVuc.SelectedIndex = 0;
            //Thiết lập mặc định các cột Mã hóa đơn, tên khách hàng, ngày đặt, tổng tiền cho Datagridview 
            // Đặt thuộc tính AutoGenerateColumns thành false
            dgvDanhSachHoaDon.AutoGenerateColumns = false;

            // Tạo cột cho Mã hóa đơn
            DataGridViewTextBoxColumn maHoaDonColumn = new DataGridViewTextBoxColumn();
            maHoaDonColumn.Name = "MaHoaDon";
            maHoaDonColumn.HeaderText = "Mã Hóa Đơn";
            maHoaDonColumn.DataPropertyName = "MaHoaDon"; // Tên của thuộc tính trong đối tượng nguồn dữ liệu
            dgvDanhSachHoaDon.Columns.Add(maHoaDonColumn);

            // Tạo cột cho Tên khách hàng
            DataGridViewTextBoxColumn tenKhachHangColumn = new DataGridViewTextBoxColumn();
            tenKhachHangColumn.Name = "TenKhachHang";
            tenKhachHangColumn.HeaderText = "Tên Khách Hàng";
            tenKhachHangColumn.DataPropertyName = "TenKhachHang";
            dgvDanhSachHoaDon.Columns.Add(tenKhachHangColumn);

            // Tạo cột cho Ngày đặt
            DataGridViewTextBoxColumn ngayDatColumn = new DataGridViewTextBoxColumn();
            ngayDatColumn.Name = "NgayDat";
            ngayDatColumn.HeaderText = "Ngày Đặt";
            ngayDatColumn.DataPropertyName = "NgayDat";
            dgvDanhSachHoaDon.Columns.Add(ngayDatColumn);

            // Tạo cột cho Tổng tiền
            DataGridViewTextBoxColumn tongTienColumn = new DataGridViewTextBoxColumn();
            tongTienColumn.Name = "TongTien";
            tongTienColumn.HeaderText = "Tổng Tiền";
            tongTienColumn.DataPropertyName = "TongTien";
            dgvDanhSachHoaDon.Columns.Add(tongTienColumn);

            dgvDanhSachHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //cài đặt mặc định giá trị chọn là Nam cho RadioButton giới tính 
            rndNam.Checked = true;


        }

        private void BtnChonGhe_Click(object sender, EventArgs e)
        {
            //chuyển sender thành button 
            Button btnGhe = (Button)sender;
            //xác định lựa chọn: đang chọn -> màu xanh, bỏ chọn -> màu trắng 
            if (btnGhe.BackColor == Color.White)
            {
                btnGhe.BackColor = Color.LightBlue;
                danhSachGheChon.Add(btnGhe); // Thêm button đã ch?n vào danh sách
            }
            else if (btnGhe.BackColor == Color.LightBlue)
            {
                btnGhe.BackColor = Color.White;
                danhSachGheChon.Remove(btnGhe); // Xóa button d? ch?n kh? v?o danh s?ch
            }
            else
            {
                MessageBox.Show("Ghe nay da duoc mua!!!");
                return;
            }
        }

        //viết hàm tính tiền dựa vào vị trí ghế ngồi 
        private double TinhTienGhe(Button btnGhe)
        {
            int viTriGheNgoi = int.Parse(btnGhe.Text);

            if (viTriGheNgoi <= 5)
                return 3000;
            else if (viTriGheNgoi <= 10)
                return 4000;
            else if (viTriGheNgoi <= 15)
                return 5000;
            else
                return 8000;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            //duyệt danh sách ghế đã chọn và tính tiền 
            double tongTien = 0;
            foreach (Button btnGhe in danhSachGheChon)
            {
                tongTien += TinhTienGhe(btnGhe);
                //chuyển trạng thái ghế đã chọn thành màu vàng 
                btnGhe.BackColor = Color.Yellow;
            }
            //hiển thị tổng tiền 
            txtTongTien.Text = tongTien.ToString("#,##0") +" VNĐ";


            //lưu thông tin Khách hàng, hóa đơn, chi tiết hóa đơn vào cơ sở dữ liệu
            string gioiTinh = rndNam.Checked ? "Nam" : "Nữ";

            List<ChiTietHoaDon> chiTietHoaDons = new List<ChiTietHoaDon>();

            foreach (Button btnGhe in danhSachGheChon)
            {
                ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon()
                {
                    ViTriGheNgoi = btnGhe.Text,
                    GiaTien = (decimal)TinhTienGhe(btnGhe)                   
                };
                chiTietHoaDons.Add(chiTietHoaDon);
            }


            SaveData(txtTenKhachHang.Text, txtSDT.Text, gioiTinh, cmbKhuVuc.Text, DateTime.Now, (decimal)tongTien, chiTietHoaDons);


            LoadHoaDonData();

            danhSachGheChon.Clear();

            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //duyệt danh sách và hủy chọn 
            foreach (Button btnGhe in danhSachGheChon)
            {
                //chuy?n tr?ng th?i gh? d? ch?n th?nh m?u tr?ng
                btnGhe.BackColor = Color.White;
            }
            //xóa danh s?ch 
            danhSachGheChon.Clear();
            //hi?n th? t?ng ti?n v?i giá tr? 0
            txtTongTien.Text = "0 VNĐ?";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //xác nhận có thoát chương trình không? 
            DialogResult result = MessageBox.Show("Ban có muon thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //xác nhận có thoát chương trình hay không? 
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?","Xác nhận thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            // Kiểm tra kết quả người dùng chọn
            if (result == DialogResult.No)
            {
                // Hủy sự kiện đóng form
                e.Cancel = true;
            }
        }


        private void SaveData(string tenKhachHang, string sdt, string gioiTinh, string khuVuc, DateTime ngayMua, decimal tongTien, List<ChiTietHoaDon> chiTietHoaDonList)
        {
            using (var dbContext = new S4_AppBanVeEntities())
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        // 1. Thêm Khách Hàng vào cơ sở dữ liệu
                        var khachHang = new KhachHang
                        {
                            Ten = tenKhachHang,
                            SDT = sdt,
                            GioiTinh = gioiTinh,
                            KhuVuc = khuVuc
                        };
                        dbContext.KhachHang.Add(khachHang);
                        dbContext.SaveChanges(); // Lưu để lấy ID của Khách Hàng

                        // 2. Thêm Hóa Đơn vào cơ sở dữ liệu, với MaKhachHang là ID của khách hàng vừa thêm
                        var hoaDon = new HoaDon
                        {
                            MaKhachHang = khachHang.Ma, // Lấy mã khách hàng vừa tạo
                            NgayMua = ngayMua,
                            TongTien = tongTien
                        };
                        dbContext.HoaDon.Add(hoaDon);
                        dbContext.SaveChanges(); // Lưu để lấy ID của Hóa Đơn

                        // 3. Thêm các chi tiết hóa đơn vào cơ sở dữ liệu
                        foreach (var chiTiet in chiTietHoaDonList)
                        {
                            var chiTietHoaDon = new ChiTietHoaDon
                            {
                                MaHoaDon = hoaDon.Ma, // Lấy mã hóa đơn vừa tạo
                                ViTriGheNgoi = chiTiet.ViTriGheNgoi,
                                GiaTien = chiTiet.GiaTien
                            };
                            dbContext.ChiTietHoaDon.Add(chiTietHoaDon);
                        }

                        // Lưu toàn bộ chi tiết hóa đơn vào cơ sở dữ liệu
                        dbContext.SaveChanges();

                        // 4. Commit transaction để lưu toàn bộ thông tin vào cơ sở dữ liệu
                        transaction.Commit();
                        MessageBox.Show("Lưu dữ liệu thành công!");
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi, rollback transaction để hủy bỏ tất cả thay đổi
                        transaction.Rollback();
                        MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}");
                    }
                }
            }
        }


        private void LoadHoaDonData()
        {
            using (var dbContext = new S4_AppBanVeEntities())
            {
                // Truy vấn để lấy thông tin mã hóa đơn, tên khách hàng, ngày đặt, và tổng tiền
                var hoaDonList = (from hd in dbContext.HoaDon
                                  join kh in dbContext.KhachHang on hd.MaKhachHang equals kh.Ma
                                  select new
                                  {
                                      MaHoaDon = hd.Ma,
                                      TenKhachHang = kh.Ten,
                                      NgayDat = hd.NgayMua,
                                      TongTien = hd.TongTien
                                  }).ToList();

                // Gán dữ liệu cho DataGridView
                dgvDanhSachHoaDon.DataSource = hoaDonList;
            }
        }

        private void FrmMain_Load_1(object sender, EventArgs e)
        {
            LoadKhuVuc();
            LoadHoaDonData();
            LoadDanhSachGheDaBan();
        }

        private void LoadKhuVuc()
        {
            //load khuVuc từ cơ sở dữ liệu vào cmbKhuVuc
            using (var dbContext = new S4_AppBanVeEntities())
            {
                var khuVucList = dbContext.KhuVuc.Select(k => k.Ten).ToList();
                cmbKhuVuc.DataSource = khuVucList;
            }
            cmbKhuVuc.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadDanhSachGheDaBan()
        {
            using (var dbContext = new S4_AppBanVeEntities())
            {
                // Truy v?n d? l?y danh s?ch gh? đã bán
                var gheDaBanList = (from ghe in dbContext.ChiTietHoaDon
                                    select ghe.ViTriGheNgoi).ToList();

                //Kiểm tra Button ghế có nằm trong danh sách gheDaBanList chưa?
                foreach (Button btnGhe in grbViTriGheNgoi.Controls.OfType<Button>())
                {
                    if (gheDaBanList.Contains(btnGhe.Text))
                    {
                        btnGhe.Enabled = false;
                        btnGhe.BackColor = Color.Yellow;
                    }
                }
            }
        }

        private void btnThemKhuVuc_Click(object sender, EventArgs e)
        {
            //lấy danh sách các khu vực đã có 
            var khuVucList = new List<string>();
            foreach (var item in cmbKhuVuc.Items)
            {
                khuVucList.Add(item.ToString());
            }

            FrmQuanLyKhuVuc frmQuanLyKhuVuc = new FrmQuanLyKhuVuc(khuVucList);

            frmQuanLyKhuVuc.SuKienThemKhuVuc += FrmQuanLyKhuVuc_SuKienThemKhuVuc;

            frmQuanLyKhuVuc.ShowDialog();
        }

        private void FrmQuanLyKhuVuc_SuKienThemKhuVuc(object sender, EventArgs e)
        {
            LoadKhuVuc();
        }
    }
}
