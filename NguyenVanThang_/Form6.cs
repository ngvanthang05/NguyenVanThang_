using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO; // Thư viện để ghi file

namespace NguyenVanThang
{
    public partial class Form6 : Form
    {
        // Đường dẫn file Log (Lưu ý ổ đĩa)
        string path = @"D:\Key_Logger.txt";

        public Form6()
        {
            InitializeComponent();

            // --- CẤU HÌNH QUAN TRỌNG CHO KEY LOGGER ---
            // Phải bật cái này lên thì Form mới bắt được phím khi đang chạy
            this.KeyPreview = true; //

            // Đăng ký sự kiện khi nhả phím (KeyUp)
            this.KeyUp += Form6_KeyUp;

            // --- TẠO NÚT OK (Code minh họa phần Controls) ---
            Button bt_OK = new Button();
            bt_OK.Text = "OK";
            bt_OK.Size = new Size(80, 25);
            // Neo nút vào góc dưới - phải của màn hình
            bt_OK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_OK.Location = new Point(this.ClientSize.Width - 100, this.ClientSize.Height - 50);
            bt_OK.Click += Bt_OK_Click; // Gắn sự kiện Click

            this.Controls.Add(bt_OK); // Đưa nút vào Form
        }

        // Sự kiện: Khi người dùng gõ phím
        private void Form6_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                // Mở file để ghi thêm (append = true)
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    // Ghi phím vừa bấm + dấu cách
                    sw.Write(e.KeyCode + " ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message);
            }
        }

        // Sự kiện: Khi bấm nút OK -> Đóng Form
        private void Bt_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}