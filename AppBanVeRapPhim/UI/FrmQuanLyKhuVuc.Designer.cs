namespace AppBanVeRapPhim
{
    partial class FrmQuanLyKhuVuc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaSo = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblDanhSachKhuVuc = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvKhuVuc = new System.Windows.Forms.DataGridView();
            this.colMaSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaDinhDanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhuVuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuVuc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý khu vực";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên";
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(175, 70);
            this.txtTen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(311, 29);
            this.txtTen.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã số";
            // 
            // txtMaSo
            // 
            this.txtMaSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSo.Location = new System.Drawing.Point(175, 103);
            this.txtMaSo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaSo.Name = "txtMaSo";
            this.txtMaSo.Size = new System.Drawing.Size(311, 29);
            this.txtMaSo.TabIndex = 2;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(71, 163);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 40);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(395, 163);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(90, 40);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblDanhSachKhuVuc
            // 
            this.lblDanhSachKhuVuc.AutoSize = true;
            this.lblDanhSachKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhSachKhuVuc.Location = new System.Drawing.Point(67, 212);
            this.lblDanhSachKhuVuc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDanhSachKhuVuc.Name = "lblDanhSachKhuVuc";
            this.lblDanhSachKhuVuc.Size = new System.Drawing.Size(30, 24);
            this.lblDanhSachKhuVuc.TabIndex = 0;
            this.lblDanhSachKhuVuc.Text = "....";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dgvKhuVuc
            // 
            this.dgvKhuVuc.AllowUserToAddRows = false;
            this.dgvKhuVuc.AllowUserToDeleteRows = false;
            this.dgvKhuVuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhuVuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuVuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSo,
            this.colMaDinhDanh,
            this.colTenKhuVuc});
            this.dgvKhuVuc.Location = new System.Drawing.Point(71, 274);
            this.dgvKhuVuc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvKhuVuc.Name = "dgvKhuVuc";
            this.dgvKhuVuc.ReadOnly = true;
            this.dgvKhuVuc.RowHeadersWidth = 62;
            this.dgvKhuVuc.RowTemplate.Height = 28;
            this.dgvKhuVuc.Size = new System.Drawing.Size(413, 187);
            this.dgvKhuVuc.TabIndex = 5;
            this.dgvKhuVuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhuVuc_CellClick);
            // 
            // colMaSo
            // 
            this.colMaSo.HeaderText = "Mã khu vực";
            this.colMaSo.MinimumWidth = 8;
            this.colMaSo.Name = "colMaSo";
            this.colMaSo.ReadOnly = true;
            // 
            // colMaDinhDanh
            // 
            this.colMaDinhDanh.HeaderText = "Mã định danh";
            this.colMaDinhDanh.MinimumWidth = 8;
            this.colMaDinhDanh.Name = "colMaDinhDanh";
            this.colMaDinhDanh.ReadOnly = true;
            // 
            // colTenKhuVuc
            // 
            this.colTenKhuVuc.HeaderText = "Tên khu vực";
            this.colTenKhuVuc.MinimumWidth = 8;
            this.colTenKhuVuc.Name = "colTenKhuVuc";
            this.colTenKhuVuc.ReadOnly = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(175, 163);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(84, 40);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(282, 165);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(84, 40);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // FrmQuanLyKhuVuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 469);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.dgvKhuVuc);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtMaSo);
            this.Controls.Add(this.lblDanhSachKhuVuc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmQuanLyKhuVuc";
            this.Text = "FrmQuanLyKhuVuc";
            this.Load += new System.EventHandler(this.FrmQuanLyKhuVuc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmQuanLyKhuVuc_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuVuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaSo;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblDanhSachKhuVuc;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridView dgvKhuVuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDinhDanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKhuVuc;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
    }
}