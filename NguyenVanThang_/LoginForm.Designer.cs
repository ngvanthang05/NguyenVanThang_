namespace NguyenVanThang
{
    partial class LoginForm
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
            txtUser = new TextBox();
            txtPass = new TextBox();
            btnLogin = new Button();
            btnForgotPassword = new Button();
            btnRegister = new Button();
            picShowPass = new PictureBox();
            labelWelcome = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picShowPass).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(59, 130, 246);
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
            labelTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelUser
            // 
            labelUser.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelUser.Location = new Point(50, 140);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(350, 23);
            labelUser.TabIndex = 1;
            labelUser.Text = "Tên đăng nhập:";
            // 
            // labelPass
            // 
            labelPass.Font = new Font("Segoe UI", 10F);
            labelPass.Location = new Point(50, 205);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(350, 23);
            labelPass.TabIndex = 3;
            labelPass.Text = "Mật khẩu:";
            // 
            // txtUser
            // 
            txtUser.BorderStyle = BorderStyle.FixedSingle;
            txtUser.Font = new Font("Segoe UI", 11F);
            txtUser.Location = new Point(50, 165);
            txtUser.Margin = new Padding(3, 10, 3, 3);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(350, 27);
            txtUser.TabIndex = 2;
            // 
            // txtPass
            // 
            txtPass.BorderStyle = BorderStyle.FixedSingle;
            txtPass.Font = new Font("Segoe UI", 11F);
            txtPass.Location = new Point(50, 230);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(350, 27);
            txtPass.TabIndex = 4;
            txtPass.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(59, 130, 246);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 290);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(350, 40);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            btnLogin.MouseEnter += btnLogin_MouseEnter;
            btnLogin.MouseLeave += btnLogin_MouseLeave;
            // 
            // btnForgotPassword
            // 
            btnForgotPassword.BackColor = Color.Transparent;
            btnForgotPassword.Cursor = Cursors.Hand;
            btnForgotPassword.FlatAppearance.BorderSize = 0;
            btnForgotPassword.FlatStyle = FlatStyle.Flat;
            btnForgotPassword.Font = new Font("Segoe UI", 9F);
            btnForgotPassword.ForeColor = Color.FromArgb(59, 130, 246);
            btnForgotPassword.Location = new Point(50, 345);
            btnForgotPassword.Name = "btnForgotPassword";
            btnForgotPassword.Size = new Size(150, 30);
            btnForgotPassword.TabIndex = 7;
            btnForgotPassword.Text = "Quên mật khẩu?";
            btnForgotPassword.UseVisualStyleBackColor = false;
            btnForgotPassword.Click += btnForgotPassword_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Transparent;
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 9F);
            btnRegister.ForeColor = Color.FromArgb(59, 130, 246);
            btnRegister.Location = new Point(250, 345);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 30);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Đăng ký tài khoản";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // picShowPass
            // 
            picShowPass.Cursor = Cursors.Hand;
            picShowPass.Location = new Point(0, 0);
            picShowPass.Name = "picShowPass";
            picShowPass.Size = new Size(24, 24);
            picShowPass.SizeMode = PictureBoxSizeMode.StretchImage;
            picShowPass.TabIndex = 5;
            picShowPass.TabStop = false;
            picShowPass.Click += picShowPass_Click;
            // 
            // labelWelcome
            // 
            labelWelcome.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelWelcome.ForeColor = Color.FromArgb(107, 114, 128);
            labelWelcome.Location = new Point(50, 100);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(350, 25);
            labelWelcome.TabIndex = 9;
            labelWelcome.Text = "Chào mừng bạn quay trở lại";
            labelWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(450, 400);
            Controls.Add(labelWelcome);
            Controls.Add(panelHeader);
            Controls.Add(labelUser);
            Controls.Add(txtUser);
            Controls.Add(labelPass);
            Controls.Add(txtPass);
            Controls.Add(picShowPass);
            Controls.Add(btnLogin);
            Controls.Add(btnForgotPassword);
            Controls.Add(btnRegister);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống";
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picShowPass).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnForgotPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.PictureBox picShowPass;
        private Label labelWelcome;
    }
}