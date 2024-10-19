using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayTinhDonGian
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPhepTinh_Click(object sender, EventArgs e)
        {
            //chuyển sender về Button 
            Button btnPhepTinh = (Button)sender;
            switch (btnPhepTinh.Name)
            {
                case "btnCong":
                    txtKetQua.Text = (double.Parse(txtSoA.Text) + double.Parse(txtSoB.Text)).ToString();
                    break;
                case "btnTru":
                    txtKetQua.Text = (double.Parse(txtSoA.Text) - double.Parse(txtSoB.Text)).ToString();
                    break;
                case "btnNhan":
                    txtKetQua.Text = (double.Parse(txtSoA.Text) * double.Parse(txtSoB.Text)).ToString();
                    break;
                case "btnChia":
                    if (double.Parse(txtSoB.Text) == 0)
                    {
                        MessageBox.Show("Số bị chia phải khác 0!");
                        return;
                    }
                    txtKetQua.Text = (double.Parse(txtSoA.Text) / double.Parse(txtSoB.Text)).ToString();
                    break;
                default:
                    break;
            }

        }
    }
}
