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
    public partial class FrmQuanLyKhuVuc : Form
    {
        //đăng ký 1 sự kiện 
        public event EventHandler SuKienThemKhuVuc;

        public FrmQuanLyKhuVuc()
        {
            InitializeComponent();
        }
        public FrmQuanLyKhuVuc(List<string> cacKhuVucDaCo)
        {
            InitializeComponent();
            //in dữ liệu cacKhuVucDaCo vào lblDanhSachKhuVuc 
            foreach (var item in cacKhuVucDaCo)
            {
                //lblDanhSachKhuVuc.Text += item.ToString() + ", ";
            }
            //đăng ky sự kiện Validating cho txtTen và txtMaSo 
            txtTen.Validating += txtTen_Validating;
            txtMaSo.Validating += txtMaSo_Validating;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //thêm tên vào bảng khuVuc trong cơ sở dữ liệu 

            using (var dbContext = new S4_AppBanVeEntities())
            {
                var khuVuc = new KhuVuc()
                {
                    Ten = txtTen.Text,
                    MaSoKhuVuc = txtMaSo.Text
                };
                dbContext.KhuVuc.Add(khuVuc);
                dbContext.SaveChanges();
            }
            //kích hoạt sự kiện SuKienThemKhuVuc và gửi thông tin txtTen 
            SuKienThemKhuVuc?.Invoke(txtTen.Text, EventArgs.Empty);
            MessageBox.Show("Đã thêm!!!");

        }

        private void FrmQuanLyKhuVuc_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra xem phím Enter có được nhấn không
            if (e.KeyCode == Keys.Enter)
            {
                // Gọi sự kiện click của nút "Thêm"
                btnThem_Click(sender, e);

                // Ngăn chặn sự kiện mặc định của phím Enter
                e.SuppressKeyPress = true;
            }
        }

        // Khởi tạo ErrorProvider
        //ErrorProvider errorProvider = new ErrorProvider();

        private void txtTen_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                errorProvider.SetError(txtTen, "Tên khu vực không được để trống.");
                e.Cancel = true;
            }
            else if (KiemTraTenVaMaSoTonTai(txtTen.Text, null))
            {
                errorProvider.SetError(txtTen, "Tên khu vực đã tồn tại.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTen, ""); // Xóa thông báo lỗi nếu hợp lệ
            }
        }


        private void txtMaSo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSo.Text))
            {
                errorProvider.SetError(txtMaSo, "Mã số không được để trống.");
                e.Cancel = true;
            }
            else if (!int.TryParse(txtMaSo.Text, out _))
            {
                errorProvider.SetError(txtMaSo, "Mã số phải là một số nguyên.");
                e.Cancel = true;
            }
            else if (KiemTraTenVaMaSoTonTai(null, txtMaSo.Text))
            {
                errorProvider.SetError(txtMaSo, "Mã số đã tồn tại.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtMaSo, ""); // Xóa thông báo lỗi nếu hợp lệ
            }
        }


        private bool KiemTraTenVaMaSoTonTai(string ten, string maSo)
        {
            using (var dbContext = new S4_AppBanVeEntities())
            {
                // Kiểm tra nếu tên hoặc mã số đã tồn tại trong bảng KhuVuc
                bool daTonTai = dbContext.KhuVuc.Any(kv => kv.Ten == ten || kv.MaSoKhuVuc == maSo);
                return daTonTai;
            }
        }
        private void BindGrid(List<KhuVuc> listKhuVuc)
        {
            dgvHienThi.Rows.Clear();
            foreach (var item in listKhuVuc)
            {
                int index = dgvHienThi.Rows.Add();
                dgvHienThi.Rows[index].Cells[0].Value = item.MaSoKhuVuc;
                dgvHienThi.Rows[index].Cells[1].Value = item.Ten;

            }
        }

        private void FrmQuanLyKhuVuc_Load(object sender, EventArgs e)
        {

        }

        private void FrmQuanLyKhuVuc_Load_1(object sender, EventArgs e)
        {
            //S4_AppBanVeEntities context = new S4_AppBanVeEntities();
            // List<KhuVuc> listKhuVuc = context.KhuVuc.ToList();
            // BindGrid(listKhuVuc);
            LoadData();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            using (var dbContext = new S4_AppBanVeEntities())
            {
                // Kiểm tra xem KhuVuc có tồn tại không
                var existingKhuVuc = dbContext.KhuVuc.FirstOrDefault(k => k.MaSoKhuVuc == txtMaSo.Text);

                if (existingKhuVuc != null)
                {
                    // Cập nhật thông tin KhuVuc hiện tại
                    existingKhuVuc.Ten = txtTen.Text;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    dbContext.SaveChanges();

                    LoadData();

                }
                else
                {
                    // Xử lý trường hợp KhuVuc không tồn tại (nếu cần)
                    MessageBox.Show("Khu vực không tồn tại.");
                }
            }


        }
        private void LoadData()
        {
            using (var dbContext = new S4_AppBanVeEntities())
            {
                var khuVucList = dbContext.KhuVuc.ToList();
                dgvHienThi.DataSource = khuVucList;
            }
        }
    }
}
