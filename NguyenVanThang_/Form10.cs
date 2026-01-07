using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO; // Thư viện để lưu file

namespace NguyenVanThang
{
    public partial class Form10 : Form
    {
        private TextBox tbSoX;
        private TextBox tbSoY;
        private TextBox tbKetQua; // Ô này sẽ to hơn để hiện lịch sử
        private Button btCong;
        private Button btNhan;
        private Button btLuu;     // Nút mới
        private Button btThoat;

        public Form10()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "Article 09 - Multiline Calculator";
            this.Size = new Size(500, 450); // Form to hơn Bài 9
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // 2. Nhãn và Ô nhập liệu
            Label lblX = new Label() { Text = "Số x:", Location = new Point(30, 30), AutoSize = true };
            tbSoX = new TextBox() { Location = new Point(100, 27), Width = 350 };

            Label lblY = new Label() { Text = "Số y:", Location = new Point(30, 70), AutoSize = true };
            tbSoY = new TextBox() { Location = new Point(100, 67), Width = 350 };

            Label lblKQ = new Label() { Text = "Kết quả:", Location = new Point(30, 110), AutoSize = true };

            // 3. Ô KẾT QUẢ ĐẶC BIỆT (Multiline)
            tbKetQua = new TextBox();
            tbKetQua.Location = new Point(100, 110);
            tbKetQua.Width = 350;
            tbKetQua.Height = 200; // Chiều cao lớn
            tbKetQua.Multiline = true; // Cho phép hiện nhiều dòng
            tbKetQua.ScrollBars = ScrollBars.Vertical; // Hiện thanh cuộn dọc
            tbKetQua.ReadOnly = true;  // Chỉ đọc, không cho sửa tay

            // 4. Các nút bấm (Thêm nút Lưu)
            int yBtn = 330;
            btLuu = new Button() { Text = "Lưu", Location = new Point(30, yBtn), Size = new Size(80, 35) };
            btCong = new Button() { Text = "Cộng", Location = new Point(130, yBtn), Size = new Size(80, 35) };
            btNhan = new Button() { Text = "Nhân", Location = new Point(230, yBtn), Size = new Size(80, 35) };
            btThoat = new Button() { Text = "Thoát", Location = new Point(370, yBtn), Size = new Size(80, 35) };

            // 5. Gắn sự kiện
            btCong.Click += BtCong_Click;
            btNhan.Click += BtNhan_Click;
            btLuu.Click += BtLuu_Click;
            btThoat.Click += (s, e) => { this.Close(); };

            // Thêm vào Form
            this.Controls.AddRange(new Control[] { lblX, tbSoX, lblY, tbSoY, lblKQ, tbKetQua, btLuu, btCong, btNhan, btThoat });
        }

        // --- XỬ LÝ CỘNG (Hiện lịch sử) ---
        private void BtCong_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(tbSoX.Text);
                int y = int.Parse(tbSoY.Text);
                int kq = x + y;

                // Nối thêm dòng mới vào ô kết quả (+=) thay vì xóa cũ
                tbKetQua.Text += x + " + " + y + " = " + kq + "\r\n";
            }
            catch { MessageBox.Show("Nhập số sai!"); }
        }

        // --- XỬ LÝ NHÂN ---
        private void BtNhan_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(tbSoX.Text);
                int y = int.Parse(tbSoY.Text);
                int kq = x * y;

                tbKetQua.Text += x + " * " + y + " = " + kq + "\r\n";
            }
            catch { MessageBox.Show("Nhập số sai!"); }
        }

        // --- XỬ LÝ LƯU FILE ---
        private void BtLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở file để ghi nối đuôi (append: true)
                using (StreamWriter sw = new StreamWriter(@"D:\Calculator.txt", true))
                {
                    sw.Write(tbKetQua.Text);
                }
                MessageBox.Show("Đã lưu lịch sử tính toán vào ổ D!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu file: " + ex.Message);
            }
        }
    }
}