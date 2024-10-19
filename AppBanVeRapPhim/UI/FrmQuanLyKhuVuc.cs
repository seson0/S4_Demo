using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppBanVeRapPhim.BLL;
using AppBanVeRapPhim.DAL;

namespace AppBanVeRapPhim
{
    public partial class FrmQuanLyKhuVuc : Form
    {
        private readonly KhuVucBLL khuVucBLL = new KhuVucBLL();


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
                lblDanhSachKhuVuc.Text += item.ToString() + ", ";
            }
            //đăng ky sự kiện Validating cho txtTen và txtMaSo 
            txtTen.Validating += txtTen_Validating;
            txtMaSo.Validating += txtMaSo_Validating;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            /*using (var dbContext = new S4_AppBanVeEntities())
            {
                // Kiểm tra nếu khu vực đã tồn tại (theo tên hoặc mã số khu vực)
                bool khuVucTonTai = dbContext.KhuVuc
                    .Any(kv => kv.Ten == txtTen.Text || kv.MaSoKhuVuc == txtMaSo.Text);

                if (khuVucTonTai)
                {
                    // Hiển thị thông báo nếu khu vực đã tồn tại
                    MessageBox.Show("Tên hoặc mã số khu vực đã tồn tại. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Ngừng thực thi nếu khu vực đã tồn tại
                }

                // Nếu khu vực chưa tồn tại, thêm vào cơ sở dữ liệu
                var khuVuc = new KhuVuc()
                {
                    Ten = txtTen.Text,
                    MaSoKhuVuc = txtMaSo.Text
                };
                dbContext.KhuVuc.Add(khuVuc);
                dbContext.SaveChanges();
            }

            // Kích hoạt sự kiện SuKienThemKhuVuc và gửi thông tin txtTen 
            SuKienThemKhuVuc?.Invoke(txtTen.Text, EventArgs.Empty);
            MessageBox.Show("Đã thêm khu vực thành công!");

            // Cập nhật lại danh sách Khu vực
            LoadLai();*/
            try
            {
                //var regex = new System.Text.RegularExpressions.Regex(@"[^a-zA-Z0-9\sÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂÂÊÔưăâêô]");
                // Kiểm tra mã định danh chỉ chứa số
                if (!int.TryParse(txtMaSo.Text, out _))
                {
                    MessageBox.Show("Mã định danh phải là số. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (int.TryParse(txtTen.Text, out _))
                {
                    MessageBox.Show("Tên khu vực không được là kiểu số. Vui lòng nhập tên hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               /* if (regex.IsMatch(txtTen.Text))
                {
                    MessageBox.Show("Tên khu vực không được chứa ký tự đặc biệt. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra ký tự đặc biệt trong mã định danh
                if (regex.IsMatch(txtMaSo.Text))
                {
                    MessageBox.Show("Mã định danh không được chứa ký tự đặc biệt. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/
                // Gọi phương thức thêm từ KhuVucBLL
                khuVucBLL.ThemKhuVuc(txtMaSo.Text, txtTen.Text);

                // Cập nhật lại danh sách khu vực trên DataGridView
                LoadLai();

                MessageBox.Show("Đã thêm khu vực thành công!");

                // Reset lại các trường sau khi thêm
                ResetFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void FrmQuanLyKhuVuc_Load(object sender, EventArgs e)
        {
            // Hiển thị danh sách khu vực thông qua mô hình 3 lớp 
            /*var danhSachKhuVuc = khuVucBLL.LayDanhSachKhuVuc();
            dgvKhuVuc.Rows.Clear();
            foreach (var khuVuc in danhSachKhuVuc)
            {
                dgvKhuVuc.Rows.Add(khuVuc.Ma, khuVuc.MaSoKhuVuc, khuVuc.Ten);
            }*/
            // Vô hiệu hóa nút Sửa khi form được load
            LoadLai();
        }

        private void LoadLai()
        {
            btnSua.Enabled = false;

            // Hiển thị danh sách khu vực thông qua mô hình 3 lớp 
            var danhSachKhuVuc = khuVucBLL.LayDanhSachKhuVuc();
            dgvKhuVuc.Rows.Clear();
            foreach (var khuVuc in danhSachKhuVuc)
            {
                dgvKhuVuc.Rows.Add(khuVuc.Ma, khuVuc.MaSoKhuVuc, khuVuc.Ten);
            }
        }

        private void dgvKhuVuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow row = dgvKhuVuc.Rows[e.RowIndex];

                // Gán giá trị vào các TextBox
                txtTen.Text = row.Cells[2].Value.ToString();
                txtMaSo.Text = row.Cells[1].Value.ToString();

                // Bật nút Sửa
                btnSua.Enabled = true;

                // Đặt nút Thêm về trạng thái không hoạt động (nếu cần)
                btnThem.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            /*using (var dbContext = new S4_AppBanVeEntities())
            {

                string makv = txtMaSo.Text;
                // Tìm đối tượng khu vực theo MaSoKhuVuc
                var khuVuc = dbContext.KhuVuc.FirstOrDefault(s => s.MaSoKhuVuc == makv);
               // var khuVuc = dbContext.KhuVuc.FirstOrDefault(kv => kv.MaSoKhuVuc == txtMaSo.Text);
                if (khuVuc != null)
                {
                    
                    // Cập nhật tên khu vực
                    khuVuc.Ten = txtTen.Text;
                    khuVuc.MaSoKhuVuc = txtMaSo.Text;   

                    // Lưu thay đổi
                    dbContext.SaveChanges();

                    // Gọi LoadLai() để cập nhật lại DataGridView
                    ResetFields();
                    LoadLai();

                    MessageBox.Show("Đã sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Khu vực không tồn tại.");
                }
            }

            // Tắt nút Sửa sau khi hoàn thành
            btnSua.Enabled = false;
            btnThem.Enabled = true; // Bật lại nút Thêm*/
            try
            {
               // var regex = new System.Text.RegularExpressions.Regex(@"[^a-zA-Z0-9\s]");
                if (dgvKhuVuc.CurrentRow != null)
                {
                    // Kiểm tra mã định danh chỉ chứa số
                    if (!int.TryParse(txtMaSo.Text, out _))
                    {
                        MessageBox.Show("Mã định danh phải là số. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (int.TryParse(txtTen.Text, out _))
                    {
                        MessageBox.Show("Tên khu vực không được là kiểu số. Vui lòng nhập tên hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                 /*   if (regex.IsMatch(txtTen.Text))
                    {
                        MessageBox.Show("Tên khu vực không được chứa ký tự đặc biệt. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra ký tự đặc biệt trong mã định danh
                    if (regex.IsMatch(txtMaSo.Text))
                    {
                        MessageBox.Show("Mã định danh không được chứa ký tự đặc biệt. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }*/

                    // Lấy mã khu vực từ hàng được chọn trong DataGridView
                    int maKhuVuc = Convert.ToInt32(dgvKhuVuc.CurrentRow.Cells[0].Value);

                    // Gọi phương thức sửa từ KhuVucBLL
                    khuVucBLL.SuaKhuVuc(maKhuVuc, txtMaSo.Text, txtTen.Text);

                    // Cập nhật lại danh sách khu vực trên DataGridView
                    LoadLai();

                    MessageBox.Show("Đã sửa khu vực thành công!");

                    // Reset lại các trường sau khi sửa
                    ResetFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFields()
        {
            // Xóa nội dung trong các TextBox
            txtTen.Text = "";
            txtMaSo.Text = "";

            // Vô hiệu hóa nút Sửa và bật lại nút Thêm
            btnSua.Enabled = false;
            btnThem.Enabled = true;

            // Đặt lại focus vào TextBox Tên khu vực nếu cần
            txtTen.Focus();

            // Xóa thông báo lỗi của ErrorProvider (nếu có)
            errorProvider.SetError(txtTen, "");
            errorProvider.SetError(txtMaSo, "");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            /*using (var dbContext = new S4_AppBanVeEntities())
            {
                // Tìm đối tượng khu vực theo MaSoKhuVuc
                var khuVuc = dbContext.KhuVuc.FirstOrDefault(kv => kv.MaSoKhuVuc == txtMaSo.Text);
                if (khuVuc != null)
                {
                    // Xóa khu vực
                    dbContext.KhuVuc.Remove(khuVuc);
                    dbContext.SaveChanges();
                    LoadLai();

                    MessageBox.Show("Đã xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Khu vực không tồn tại.");
                }
            }

            // Cập nhật lại danh sách Khu vực
            

            // Tắt nút Sửa sau khi hoàn thành
            btnSua.Enabled = false;
            btnThem.Enabled = true; // Bật lại nút Thêm*/
            try
            {
                if (dgvKhuVuc.CurrentRow != null)
                {
                    // Lấy mã khu vực từ hàng được chọn trong DataGridView
                    int maKhuVuc = Convert.ToInt32(dgvKhuVuc.CurrentRow.Cells[0].Value);

                    // Xác nhận trước khi xóa
                    var result = MessageBox.Show("Bạn có chắc muốn xóa khu vực này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // Gọi phương thức xóa từ KhuVucBLL
                        khuVucBLL.XoaKhuVuc(maKhuVuc);

                        // Cập nhật lại danh sách khu vực trên DataGridView
                        LoadLai();

                        MessageBox.Show("Đã xóa khu vực thành công!");

                        // Reset lại các trường sau khi xóa
                        ResetFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
