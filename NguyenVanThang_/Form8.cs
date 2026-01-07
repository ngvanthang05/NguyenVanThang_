using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form8 : Form
    {
        private Label lblYear;
        private TextBox tbYear;
        private Label lblPhone;
        private TextBox tbPhone;

        public Form8()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "Article 07 - Textbox Events";
            this.Size = new Size(450, 250); // Nới rộng Form ra chút (450)
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // BIẾN QUAN TRỌNG: Vị trí X của các ô nhập liệu
            // Mình tăng từ 150 lên 180 để tránh bị chữ "Phone Number" che khuất
            int viTriNhapLieu = 180;

            // --- DÒNG 1: YEAR ---
            lblYear = new Label();
            lblYear.Text = "Year (Năm):";
            lblYear.Location = new Point(30, 40);
            lblYear.AutoSize = true;

            tbYear = new TextBox();
            tbYear.Name = "tbYear";
            tbYear.Location = new Point(viTriNhapLieu, 37); // Dùng vị trí mới
            tbYear.Size = new Size(180, 25);
            tbYear.KeyPress += tbYear_KeyPress;
            tbYear.Validating += tbYear_Validating;

            // --- DÒNG 2: PHONE NUMBER ---
            lblPhone = new Label();
            lblPhone.Text = "Phone Number:";
            lblPhone.Location = new Point(30, 90);
            lblPhone.AutoSize = true;

            tbPhone = new TextBox();
            tbPhone.Name = "tbPhone";
            tbPhone.Location = new Point(viTriNhapLieu, 87); // Dùng vị trí mới -> Thẳng hàng
            tbPhone.Size = new Size(180, 25);
            tbPhone.KeyPress += tbYear_KeyPress;

            // --- DÒNG HƯỚNG DẪN ---
            Label lblHint = new Label();
            lblHint.Text = "* Chỉ nhập số, Năm <= 2000";
            lblHint.ForeColor = Color.Gray;
            lblHint.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblHint.Location = new Point(viTriNhapLieu, 120); // Thẳng hàng với TextBox
            lblHint.AutoSize = true;

            // Thêm vào Form
            this.Controls.Add(lblYear);
            this.Controls.Add(tbYear);
            this.Controls.Add(lblPhone);
            this.Controls.Add(tbPhone);
            this.Controls.Add(lblHint);
        }

        // Sự kiện chặn chữ
        private void tbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Sự kiện kiểm tra năm
        private void tbYear_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbYear.Text)) return;

            try
            {
                int year = int.Parse(tbYear.Text);
                if (year > 2000)
                {
                    MessageBox.Show("Năm không được lớn hơn 2000!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    tbYear.SelectAll();
                }
            }
            catch
            {
                e.Cancel = true;
            }
        }
    }
}