using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form9 : Form
    {
        // Khai báo các biến giao diện (Controls)
        private TextBox tbSoX;
        private TextBox tbSoY;
        private TextBox tbKetQua;
        private Button btCong;
        private Button btNhan;
        private Button btThoat;

        public Form9()
        {
            InitializeComponent();
            SetupUI(); // Hàm tự vẽ giao diện
        }

        // --- CẤU HÌNH GIAO DIỆN (Giống Slide 68 & 69) ---
        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "Calculator";
            this.Size = new Size(450, 350); // Tăng kích thước Form lên chút cho rộng
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Cấu hình Font chữ to rõ hơn một chút
            Font fontChu = new Font("Segoe UI", 10);
            this.Font = fontChu;

            // 2. Tạo các Label (Nhãn chữ)
            // Đẩy lùi xuống (Y=40) và dãn cách xa hơn
            Label lblX = new Label() { Text = "Số x:", Location = new Point(50, 40), AutoSize = true };
            Label lblY = new Label() { Text = "Số y:", Location = new Point(50, 90), AutoSize = true };
            Label lblKQ = new Label() { Text = "Kết quả:", Location = new Point(50, 140), AutoSize = true };

            // 3. Tạo các TextBox (Ô nhập liệu)
            // Đẩy sang phải (X=150) để tránh bị chữ "Kết quả" đè lên
            tbSoX = new TextBox() { Location = new Point(150, 37), Width = 200 };
            tbSoY = new TextBox() { Location = new Point(150, 87), Width = 200 };
            tbKetQua = new TextBox() { Location = new Point(150, 137), Width = 200, ReadOnly = true };

            // 4. Tạo các Button (Nút bấm)
            // Đẩy xuống dưới (Y=200)
            btCong = new Button() { Text = "Cộng", Location = new Point(50, 200), Size = new Size(90, 40) };
            btNhan = new Button() { Text = "Nhân", Location = new Point(160, 200), Size = new Size(90, 40) };
            btThoat = new Button() { Text = "Thoát", Location = new Point(270, 200), Size = new Size(90, 40) };

            // 5. Gắn sự kiện Click
            btCong.Click += BtCong_Click;
            btNhan.Click += BtNhan_Click;
            btThoat.Click += BtThoat_Click;

            // Thêm tất cả vào Form
            this.Controls.AddRange(new Control[] { lblX, lblY, lblKQ, tbSoX, tbSoY, tbKetQua, btCong, btNhan, btThoat });
        }

        // --- XỬ LÝ LOGIC (Giống Slide 70) ---

        // Nút Cộng: x + y
        private void BtCong_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(tbSoX.Text); //
                int y = int.Parse(tbSoY.Text); //
                int kq = x + y;
                tbKetQua.Text = kq.ToString();
            }
            catch { MessageBox.Show("Vui lòng nhập số hợp lệ!"); }
        }

        // Nút Nhân: x * y
        private void BtNhan_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(tbSoX.Text);
                int y = int.Parse(tbSoY.Text);
                int kq = x * y;
                tbKetQua.Text = kq.ToString();
            }
            catch { MessageBox.Show("Vui lòng nhập số hợp lệ!"); }
        }

        // Nút Thoát: Đóng Form
        private void BtThoat_Click(object sender, EventArgs e)
        {
            this.Close(); //
        }
    }
}