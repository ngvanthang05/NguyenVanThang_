namespace NguyenVanThang
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            labelTitle = new Label();
            labelUser = new Label();
            labelPass = new Label();
            labelConfirm = new Label();
            txtUser = new TextBox();
            txtPass = new TextBox();
            txtConfirmPass = new TextBox();
            btnRegister = new Button();
            btnBack = new Button();
            picShowPass = new PictureBox();
            picShowConfirm = new PictureBox();
            labelInstruction = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picShowPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picShowConfirm).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(16, 185, 129);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(450, 80);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.Dock = DockStyle.Fill;
            labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(0, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(450, 80);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "ĐĂNG KÝ TÀI KHOẢN";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelUser
            // 
            labelUser.Font = new Font("Segoe UI", 10F);
            labelUser.Location = new Point(50, 130);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(350, 23);
            labelUser.TabIndex = 1;
            labelUser.Text = "Tên đăng nhập:";
            // 
            // labelPass
            // 
            labelPass.Font = new Font("Segoe UI", 10F);
            labelPass.Location = new Point(50, 195);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(350, 23);
            labelPass.TabIndex = 3;
            labelPass.Text = "Mật khẩu:";
            // 
            // labelConfirm
            // 
            labelConfirm.Font = new Font("Segoe UI", 10F);
            labelConfirm.Location = new Point(50, 260);
            labelConfirm.Name = "labelConfirm";
            labelConfirm.Size = new Size(350, 23);
            labelConfirm.TabIndex = 5;
            labelConfirm.Text = "Xác nhận mật khẩu:";
            // 
            // txtUser
            // 
            txtUser.BorderStyle = BorderStyle.FixedSingle;
            txtUser.Font = new Font("Segoe UI", 11F);
            txtUser.Location = new Point(50, 155);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(350, 27);
            txtUser.TabIndex = 2;
            // 
            // txtPass
            // 
            txtPass.BorderStyle = BorderStyle.FixedSingle;
            txtPass.Font = new Font("Segoe UI", 11F);
            txtPass.Location = new Point(50, 220);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(350, 27);
            txtPass.TabIndex = 4;
            txtPass.UseSystemPasswordChar = true;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPass.Font = new Font("Segoe UI", 11F);
            txtConfirmPass.Location = new Point(50, 285);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.Size = new Size(350, 27);
            txtConfirmPass.TabIndex = 6;
            txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(16, 185, 129);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(50, 340);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(350, 40);
            btnRegister.TabIndex = 9;
            btnRegister.Text = "ĐĂNG KÝ";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            btnRegister.MouseEnter += btnRegister_MouseEnter;
            btnRegister.MouseLeave += btnRegister_MouseLeave;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(107, 114, 128);
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 9F);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(50, 395);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(350, 35);
            btnBack.TabIndex = 10;
            btnBack.Text = "Quay lại đăng nhập";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            btnBack.MouseEnter += btnBack_MouseEnter;
            btnBack.MouseLeave += btnBack_MouseLeave;
            // 
            // picShowPass
            // 
            picShowPass.Cursor = Cursors.Hand;
            picShowPass.Location = new Point(0, 0);
            picShowPass.Name = "picShowPass";
            picShowPass.Size = new Size(24, 24);
            picShowPass.SizeMode = PictureBoxSizeMode.StretchImage;
            picShowPass.TabIndex = 7;
            picShowPass.TabStop = false;
            picShowPass.Click += picShowPass_Click;
            // 
            // picShowConfirm
            // 
            picShowConfirm.Cursor = Cursors.Hand;
            picShowConfirm.Location = new Point(0, 0);
            picShowConfirm.Name = "picShowConfirm";
            picShowConfirm.Size = new Size(24, 24);
            picShowConfirm.SizeMode = PictureBoxSizeMode.StretchImage;
            picShowConfirm.TabIndex = 8;
            picShowConfirm.TabStop = false;
            picShowConfirm.Click += picShowConfirm_Click;
            // 
            // labelInstruction
            // 
            labelInstruction.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelInstruction.ForeColor = Color.FromArgb(107, 114, 128);
            labelInstruction.Location = new Point(50, 95);
            labelInstruction.Name = "labelInstruction";
            labelInstruction.Size = new Size(350, 25);
            labelInstruction.TabIndex = 11;
            labelInstruction.Text = "Tạo tài khoản mới để bắt đầu sử dụng hệ thống";
            labelInstruction.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RegisterForm
            // 
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(450, 450);
            Controls.Add(labelInstruction);
            Controls.Add(panelHeader);
            Controls.Add(labelUser);
            Controls.Add(txtUser);
            Controls.Add(labelPass);
            Controls.Add(txtPass);
            Controls.Add(labelConfirm);
            Controls.Add(txtConfirmPass);
            Controls.Add(picShowPass);
            Controls.Add(picShowConfirm);
            Controls.Add(btnRegister);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký tài khoản";
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picShowPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)picShowConfirm).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelConfirm;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.PictureBox picShowPass;
        private System.Windows.Forms.PictureBox picShowConfirm;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBack;
        private Label labelInstruction;
    }
}