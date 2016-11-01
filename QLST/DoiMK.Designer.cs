namespace QLST
{
    partial class DoiMK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiMK));
            this.lblDoiMatKhau = new DevExpress.XtraEditors.LabelControl();
            this.lblMatKhauCu = new DevExpress.XtraEditors.LabelControl();
            this.lblMatKhauMoi = new DevExpress.XtraEditors.LabelControl();
            this.lblXacNhanMatKhauMoi = new DevExpress.XtraEditors.LabelControl();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.txteMatKhauCu = new DevExpress.XtraEditors.TextEdit();
            this.txteMatKhauMoi = new DevExpress.XtraEditors.TextEdit();
            this.txteXacNhanMKMoi = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txteMatKhauCu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txteMatKhauMoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txteXacNhanMKMoi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDoiMatKhau
            // 
            this.lblDoiMatKhau.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblDoiMatKhau.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblDoiMatKhau.Location = new System.Drawing.Point(126, 12);
            this.lblDoiMatKhau.Name = "lblDoiMatKhau";
            this.lblDoiMatKhau.Size = new System.Drawing.Size(109, 19);
            this.lblDoiMatKhau.TabIndex = 0;
            this.lblDoiMatKhau.Text = "Đổi mật khẩu";
            // 
            // lblMatKhauCu
            // 
            this.lblMatKhauCu.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblMatKhauCu.Location = new System.Drawing.Point(12, 46);
            this.lblMatKhauCu.Name = "lblMatKhauCu";
            this.lblMatKhauCu.Size = new System.Drawing.Size(71, 14);
            this.lblMatKhauCu.TabIndex = 1;
            this.lblMatKhauCu.Text = "Mật khẩu cũ:";
            // 
            // lblMatKhauMoi
            // 
            this.lblMatKhauMoi.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblMatKhauMoi.Location = new System.Drawing.Point(12, 72);
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Size = new System.Drawing.Size(77, 14);
            this.lblMatKhauMoi.TabIndex = 2;
            this.lblMatKhauMoi.Text = "Mật khẩu mới:";
            // 
            // lblXacNhanMatKhauMoi
            // 
            this.lblXacNhanMatKhauMoi.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblXacNhanMatKhauMoi.Location = new System.Drawing.Point(12, 98);
            this.lblXacNhanMatKhauMoi.Name = "lblXacNhanMatKhauMoi";
            this.lblXacNhanMatKhauMoi.Size = new System.Drawing.Size(132, 14);
            this.lblXacNhanMatKhauMoi.TabIndex = 3;
            this.lblXacNhanMatKhauMoi.Text = "Xác nhận mật khẩu mới:";
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Location = new System.Drawing.Point(180, 121);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Location = new System.Drawing.Point(261, 121);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txteMatKhauCu
            // 
            this.txteMatKhauCu.Location = new System.Drawing.Point(150, 43);
            this.txteMatKhauCu.Name = "txteMatKhauCu";
            this.txteMatKhauCu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txteMatKhauCu.Properties.Appearance.Options.UseFont = true;
            this.txteMatKhauCu.Properties.PasswordChar = '*';
            this.txteMatKhauCu.Size = new System.Drawing.Size(209, 20);
            this.txteMatKhauCu.TabIndex = 0;
            // 
            // txteMatKhauMoi
            // 
            this.txteMatKhauMoi.Location = new System.Drawing.Point(150, 69);
            this.txteMatKhauMoi.Name = "txteMatKhauMoi";
            this.txteMatKhauMoi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txteMatKhauMoi.Properties.Appearance.Options.UseFont = true;
            this.txteMatKhauMoi.Properties.PasswordChar = '*';
            this.txteMatKhauMoi.Size = new System.Drawing.Size(209, 20);
            this.txteMatKhauMoi.TabIndex = 1;
            // 
            // txteXacNhanMKMoi
            // 
            this.txteXacNhanMKMoi.Location = new System.Drawing.Point(150, 95);
            this.txteXacNhanMKMoi.Name = "txteXacNhanMKMoi";
            this.txteXacNhanMKMoi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txteXacNhanMKMoi.Properties.Appearance.Options.UseFont = true;
            this.txteXacNhanMKMoi.Properties.PasswordChar = '*';
            this.txteXacNhanMKMoi.Size = new System.Drawing.Size(209, 20);
            this.txteXacNhanMKMoi.TabIndex = 2;
            this.txteXacNhanMKMoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txteXacNhanMKMoi_KeyPress);
            // 
            // DoiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 152);
            this.Controls.Add(this.txteXacNhanMKMoi);
            this.Controls.Add(this.txteMatKhauMoi);
            this.Controls.Add(this.txteMatKhauCu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.lblXacNhanMatKhauMoi);
            this.Controls.Add(this.lblMatKhauMoi);
            this.Controls.Add(this.lblMatKhauCu);
            this.Controls.Add(this.lblDoiMatKhau);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DoiMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐỔI MẬT KHẨU";
            ((System.ComponentModel.ISupportInitialize)(this.txteMatKhauCu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txteMatKhauMoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txteXacNhanMKMoi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblDoiMatKhau;
        private DevExpress.XtraEditors.LabelControl lblMatKhauCu;
        private DevExpress.XtraEditors.LabelControl lblMatKhauMoi;
        private DevExpress.XtraEditors.LabelControl lblXacNhanMatKhauMoi;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.TextEdit txteMatKhauCu;
        private DevExpress.XtraEditors.TextEdit txteMatKhauMoi;
        private DevExpress.XtraEditors.TextEdit txteXacNhanMKMoi;
    }
}