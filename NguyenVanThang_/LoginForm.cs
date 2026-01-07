using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class LoginForm : Form
    {
        // Biến này được để public static để RegisterForm có thể truy cập và thêm dữ liệu vào
        public static Dictionary<string, string> accounts = new Dictionary<string, string>()
        {
            { "admin", "123" } // Tài khoản mặc định
        };

        private Image eyeIcon;
        private Image eyeOffIcon;

        public LoginForm()
        {
            InitializeComponent();
            ApplyModernStyle();
            LoadIcons();
        }

        private void ApplyModernStyle()
        {
            // Form styling
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Padding = new Padding(20);

            // Panel styling
            panelHeader.BackColor = Color.FromArgb(59, 130, 246);
            labelTitle.ForeColor = Color.White;
            labelTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);

            // Input field styling
            txtUser.BackColor = Color.White;
            txtUser.BorderStyle = BorderStyle.FixedSingle;
            txtUser.Font = new Font("Segoe UI", 10);

            txtPass.BackColor = Color.White;
            txtPass.BorderStyle = BorderStyle.FixedSingle;
            txtPass.Font = new Font("Segoe UI", 10);

            // Button styling
            btnLogin.BackColor = Color.FromArgb(59, 130, 246);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLogin.Cursor = Cursors.Hand;

            // Link buttons
            btnForgotPassword.FlatStyle = FlatStyle.Flat;
            btnForgotPassword.FlatAppearance.BorderSize = 0;
            btnForgotPassword.BackColor = Color.Transparent;
            btnForgotPassword.ForeColor = Color.FromArgb(59, 130, 246);
            btnForgotPassword.Cursor = Cursors.Hand;

            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.BackColor = Color.Transparent;
            btnRegister.ForeColor = Color.FromArgb(59, 130, 246);
            btnRegister.Cursor = Cursors.Hand;
        }

        private void LoadIcons()
        {
            string path = Application.StartupPath;
            try
            {
                // Đảm bảo bạn đã copy file eye.png và eye-off.png vào thư mục bin/Debug/...
                if (File.Exists(Path.Combine(path, "eye.png")))
                    eyeIcon = Image.FromFile(Path.Combine(path, "eye.png"));

                if (File.Exists(Path.Combine(path, "eye-off.png")))
                    eyeOffIcon = Image.FromFile(Path.Combine(path, "eye-off.png"));

                if (eyeOffIcon != null)
                {
                    picShowPass.Image = eyeOffIcon;
                    // Position eye icon
                    picShowPass.Parent = txtPass;
                    picShowPass.Location = new Point(txtPass.Width - picShowPass.Width - 10,
                                                   (txtPass.Height - picShowPass.Height) / 2);
                    picShowPass.BringToFront();
                }
                else
                {
                    picShowPass.Visible = false;
                }
            }
            catch (Exception)
            {
                picShowPass.Visible = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trong Dictionary chung
            if ((accounts.ContainsKey(user) && accounts[user] == pass))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- PHẦN CODE MỚI ---
                this.Hide(); // Ẩn form đăng nhập
                MenuForm menu = new MenuForm(user); // Truyền tên user vào menu
                menu.ShowDialog(); // Hiện menu (chờ đến khi menu đóng)
                this.Show(); // Khi menu đóng (Logout), hiện lại form đăng nhập
                             // ---------------------
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Ẩn form Login để chuyển sang Register
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            // Khi RegisterForm đóng lại, hiện lại form Login
            this.Show();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản trị viên để reset mật khẩu!", "Quên mật khẩu",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picShowPass_Click(object sender, EventArgs e)
        {
            if (eyeIcon == null || eyeOffIcon == null) return;

            if (txtPass.UseSystemPasswordChar)
            {
                txtPass.UseSystemPasswordChar = false;
                picShowPass.Image = eyeIcon;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                picShowPass.Image = eyeOffIcon;
            }
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(37, 99, 235);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(59, 130, 246);
        }
    }
}