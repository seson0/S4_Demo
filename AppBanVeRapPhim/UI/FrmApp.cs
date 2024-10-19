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
    public partial class FrmApp : Form
    {
        public FrmApp()
        {
            InitializeComponent();
        }

        private void menuQuanLyBanVe_Click(object sender, EventArgs e)
        {
            KhoiTaoFormCon<FrmMain>();
        }     

        private void menuQuanLyKhuVuc_Click(object sender, EventArgs e)
        {
            KhoiTaoFormCon<FrmQuanLyKhuVuc>();
        }

        private void KhoiTaoFormCon<T>()
        {
            //Nếu form T đã tồn tại thì không tạo mới
            //Nếu form T chưa tồn tại thì tạo mới
            //Form T là con của MDI (form hiện tại, this)
            Form form = MdiChildren.FirstOrDefault(f => f.GetType() == typeof(T));
            if (form == null)
            {
                form = Activator.CreateInstance(typeof(T)) as Form;
                form.MdiParent = this;
                form.Show();
            }
            form.Activate();
        }
    }
}
