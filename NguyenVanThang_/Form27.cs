using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form27 : Form
    {
        private PictureBox pbEgg;
        // Timer của Windows Forms
        private System.Windows.Forms.Timer tmEgg;

        private int xEgg = 300;
        private int yEgg = 0;
        private int yDelta = 5;

        public Form27()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Article 26 - Catch Egg (Falling Logic)";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;

            // 1. Timer
            tmEgg = new System.Windows.Forms.Timer();
            tmEgg.Interval = 20;
            tmEgg.Tick += TmEgg_Tick;

            // 2. PictureBox
            pbEgg = new PictureBox();
            pbEgg.Size = new Size(50, 70); // Kích thước trứng
            pbEgg.Location = new Point(xEgg, yEgg);
            pbEgg.BackColor = Color.Transparent;
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage; // Co giãn ảnh cho vừa khung

            // [THAY ĐỔI QUAN TRỌNG] 
            // Đặt ảnh ban đầu là trứng nguyên
            // Đường dẫn "../../" có nghĩa là đi ngược lên 2 cấp thư mục từ nơi file .exe chạy (bin/Debug)
            try
            {
                pbEgg.ImageLocation = "Images/egg_gold.png";
            }
            catch
            {
                MessageBox.Show("Không tìm thấy ảnh! Hãy kiểm tra lại thư mục Images.");
            }

            // [ĐÃ XÓA] Đoạn code pbEgg.Paint tự vẽ màu vàng ở bài trước đã bị xóa.

            this.Controls.Add(pbEgg);
            tmEgg.Start();
        }

        private void TmEgg_Tick(object sender, EventArgs e)
        {
            yEgg += yDelta;

            // Kiểm tra chạm đất
            if (yEgg > this.ClientSize.Height - pbEgg.Height)
            {
                // [THAY ĐỔI QUAN TRỌNG]
                // Đổi sang ảnh trứng vỡ khi chạm đất
                pbEgg.ImageLocation = "Images/egg_gold_broken.png";

                tmEgg.Stop();
                MessageBox.Show("Oop! Trứng vỡ rồi!");

                // (Tùy chọn) Reset để chơi lại
                // yEgg = 0; pbEgg.ImageLocation = "../../Images/egg_gold.png"; tmEgg.Start();
                return;
            }

            pbEgg.Location = new Point(xEgg, yEgg);
        }
    }
}