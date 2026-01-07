using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form28 : Form
    {
        // --- PHẦN 1: KHAI BÁO BIẾN ---
        private System.Windows.Forms.Timer tmGame;

        // Quả trứng (từ Bài 27)
        private PictureBox pbEgg;
        private int xEgg = 300;
        private int yEgg = 0;
        private int yDeltaEgg = 5;

        // Chiếc rổ (MỚI - Bài 28)
        private PictureBox pbBasket;
        private int xBasket = 300;
        private int yBasket = 500; // Vị trí sát đáy
        private int xDeltaBasket = 30; // Tốc độ di chuyển của rổ

        public Form28()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "Article 27 - Catch Egg Game (Move Basket)";
            this.Size = new Size(800, 600); // Tăng kích thước form cho rộng rãi
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightSkyBlue; // Thêm màu nền cho đẹp
            this.DoubleBuffered = true;

            // QUAN TRỌNG: Để Form nhận được sự kiện bàn phím, phải bật KeyPreview
            this.KeyPreview = true;
            this.KeyDown += Form28_KeyDown; // Gắn sự kiện phím

            // 2. Timer
            tmGame = new System.Windows.Forms.Timer();
            tmGame.Interval = 20;
            tmGame.Tick += TmGame_Tick;

            // 3. Tạo Quả Trứng
            pbEgg = new PictureBox();
            pbEgg.Size = new Size(50, 70);
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.BackColor = Color.Transparent;
            pbEgg.Location = new Point(xEgg, yEgg);
            try { pbEgg.ImageLocation = "Images/egg_gold.png"; } catch { } // Load ảnh trứng

            // 4. Tạo Chiếc Rổ (MỚI)
            // Tính toán vị trí Y để rổ nằm sát đáy
            yBasket = this.ClientSize.Height - 100;

            pbBasket = new PictureBox();
            pbBasket.Size = new Size(100, 100);
            pbBasket.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBasket.BackColor = Color.Transparent;
            pbBasket.Location = new Point(xBasket, yBasket);

            // Load ảnh rổ
            try
            {
                pbBasket.ImageLocation = "Images/basket.png";
            }
            catch
            {
                // Nếu chưa có ảnh, vẽ tạm hình chữ nhật màu nâu
                pbBasket.Paint += (s, e) => { e.Graphics.FillRectangle(Brushes.SaddleBrown, 0, 0, 100, 100); };
            }

            // Thêm Controls
            this.Controls.Add(pbEgg);
            this.Controls.Add(pbBasket);

            tmGame.Start();
        }

        // --- XỬ LÝ PHÍM BẤM (DI CHUYỂN RỔ) ---
        private void Form28_KeyDown(object sender, KeyEventArgs e)
        {
            // Phím Mũi tên Phải (Right Arrow) - KeyValue 39
            if (e.KeyValue == 39)
            {
                // Kiểm tra biên phải để không chạy ra ngoài màn hình
                if (xBasket < this.ClientSize.Width - pbBasket.Width)
                {
                    xBasket += xDeltaBasket;
                }
            }

            // Phím Mũi tên Trái (Left Arrow) - KeyValue 37
            if (e.KeyValue == 37)
            {
                // Kiểm tra biên trái (lớn hơn 0)
                if (xBasket > 0)
                {
                    xBasket -= xDeltaBasket;
                }
            }

            // Cập nhật vị trí rổ
            pbBasket.Location = new Point(xBasket, yBasket);
        }

        // --- XỬ LÝ GAME LOOP (TRỨNG RƠI) ---
        private void TmGame_Tick(object sender, EventArgs e)
        {
            yEgg += yDeltaEgg;

            // Kiểm tra trứng chạm đất (Game Over)
            if (yEgg > this.ClientSize.Height - pbEgg.Height)
            {
                pbEgg.ImageLocation = "Images/egg_gold_broken.png"; // Ảnh vỡ
                tmGame.Stop();
                MessageBox.Show("Rớt rồi! Game Over.");
                return;
            }

            // Cập nhật vị trí trứng
            pbEgg.Location = new Point(xEgg, yEgg);
        }
    }
}