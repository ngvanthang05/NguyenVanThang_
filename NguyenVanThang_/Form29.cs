using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form29 : Form
    {
        private PictureBox pbBasket;
        private PictureBox pbEgg;
        private PictureBox pbChicken;
        private Label lblScore;
        private Button btReplay; // [MỚI] Nút chơi lại

        private System.Windows.Forms.Timer tmEgg;
        private System.Windows.Forms.Timer tmChicken;

        private int score = 0;

        // Toạ độ & Tốc độ
        private int xBasket = 300;
        private int yBasket = 500;
        private int xDeltaBasket = 30;

        private int xChicken = 300;
        private int yChicken = 10;
        private int xDeltaChicken = 5;

        private int xEgg = 300;
        private int yEgg = 10;
        private int yDeltaEgg = 8;

        public Form29()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Game Hứng Trứng (Full Version)";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightCyan;
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.KeyDown += Form29_KeyDown;

            // 1. Label Điểm số (Chuyển xuống góc dưới phải)
            lblScore = new Label();
            lblScore.Text = "Score: 0";
            lblScore.Font = new Font("Arial", 18, FontStyle.Bold);
            lblScore.ForeColor = Color.Red;
            lblScore.AutoSize = true;
            // Đặt vị trí ở góc dưới phải (Khoảng toạ độ 650, 500)
            lblScore.Location = new Point(this.ClientSize.Width - 150, this.ClientSize.Height - 50);
            // Neo để khi resize form nó vẫn nằm góc đó
            lblScore.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.Controls.Add(lblScore);

            // 2. Timer
            tmEgg = new System.Windows.Forms.Timer();
            tmEgg.Interval = 30;
            tmEgg.Tick += TmEgg_Tick;

            tmChicken = new System.Windows.Forms.Timer();
            tmChicken.Interval = 20;
            tmChicken.Tick += TmChicken_Tick;

            // 3. Tạo Quả Trứng (QUAN TRỌNG: Add trứng TRƯỚC gà)
            pbEgg = new PictureBox();
            pbEgg.Size = new Size(30, 40); // Nhỏ hơn chút để dễ nấp sau gà
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.BackColor = Color.Transparent;
            try { pbEgg.ImageLocation = "Images/egg_gold.png"; } catch { pbEgg.BackColor = Color.Gold; }
            this.Controls.Add(pbEgg);

            // 4. Tạo Con Gà
            pbChicken = new PictureBox();
            pbChicken.Size = new Size(100, 100);
            pbChicken.Location = new Point(xChicken, yChicken);
            pbChicken.SizeMode = PictureBoxSizeMode.StretchImage;
            pbChicken.BackColor = Color.Transparent;
            try { pbChicken.ImageLocation = "Images/chicken.png"; } catch { pbChicken.BackColor = Color.Yellow; }
            this.Controls.Add(pbChicken);

            // 5. Tạo Cái Rổ
            yBasket = this.ClientSize.Height - 120;
            pbBasket = new PictureBox();
            pbBasket.Size = new Size(120, 80);
            pbBasket.Location = new Point(xBasket, yBasket);
            pbBasket.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBasket.BackColor = Color.Transparent;
            try { pbBasket.ImageLocation = "Images/basket.png"; } catch { pbBasket.BackColor = Color.Brown; }
            this.Controls.Add(pbBasket);

            // 6. [MỚI] Nút Chơi Lại (Ban đầu ẩn đi)
            btReplay = new Button();
            btReplay.Text = "CHƠI LẠI";
            btReplay.Size = new Size(150, 50);
            btReplay.Font = new Font("Arial", 14, FontStyle.Bold);
            btReplay.Location = new Point((this.ClientSize.Width - 150) / 2, (this.ClientSize.Height - 50) / 2); // Giữa màn hình
            btReplay.BackColor = Color.OrangeRed;
            btReplay.ForeColor = Color.White;
            btReplay.Visible = false; // Ẩn đi
            btReplay.Click += BtReplay_Click;
            this.Controls.Add(btReplay);

            // Bắt đầu game
            ResetGame();
        }

        // --- HÀM KHỞI ĐỘNG / RESET GAME ---
        private void ResetGame()
        {
            score = 0;
            lblScore.Text = "Score: 0";

            // Đưa trứng về trạng thái ảnh nguyên vẹn
            try { pbEgg.ImageLocation = "Images/egg_gold.png"; } catch { }

            ResetEggToChicken();

            btReplay.Visible = false; // Ẩn nút chơi lại
            tmEgg.Start();
            tmChicken.Start();
            this.Focus(); // Để bắt sự kiện bàn phím ngay
        }

        private void TmChicken_Tick(object sender, EventArgs e)
        {
            xChicken += xDeltaChicken;
            if (xChicken > this.ClientSize.Width - pbChicken.Width || xChicken <= 0)
                xDeltaChicken = -xDeltaChicken;

            pbChicken.Location = new Point(xChicken, yChicken);

            // [QUAN TRỌNG] Luôn giữ gà ở lớp trên cùng để che trứng
            pbChicken.BringToFront();
            // Giữ nút Replay (nếu hiện) ở trên gà luôn
            if (btReplay.Visible) btReplay.BringToFront();
        }

        private void TmEgg_Tick(object sender, EventArgs e)
        {
            yEgg += yDeltaEgg;
            pbEgg.Location = new Point(xEgg, yEgg);

            // Xử lý Hứng Trứng
            if (pbEgg.Bounds.IntersectsWith(pbBasket.Bounds))
            {
                score++;
                lblScore.Text = "Score: " + score;
                ResetEggToChicken();
                return;
            }

            // Xử lý Chạm Đất (Game Over)
            if (yEgg > this.ClientSize.Height - pbEgg.Height)
            {
                try { pbEgg.ImageLocation = "Images/egg_gold_broken.png"; } catch { }

                tmEgg.Stop();
                tmChicken.Stop();

                // Hiện nút chơi lại
                btReplay.Visible = true;
                btReplay.BringToFront();

                // (Không hiện MessageBox nữa để đỡ phiền, dùng nút Chơi lại thôi)
            }
        }

        private void ResetEggToChicken()
        {
            // Để trứng nằm chính giữa con gà theo chiều ngang
            xEgg = pbChicken.Location.X + (pbChicken.Width - pbEgg.Width) / 2;

            // [QUAN TRỌNG] Để Y của trứng bằng Y của gà -> Trứng sẽ nằm TRONG vùng ảnh của gà
            // Vì gà được BringToFront nên gà sẽ CHE KHUẤT trứng
            yEgg = pbChicken.Location.Y + 20;

            pbEgg.Location = new Point(xEgg, yEgg);

            // Đẩy trứng xuống lớp dưới cùng cho chắc chắn
            pbEgg.SendToBack();
        }

        private void Form29_KeyDown(object sender, KeyEventArgs e)
        {
            if (tmEgg.Enabled == false) return; // Game over thì không cho di chuyển rổ

            if (e.KeyValue == 39 && xBasket < this.ClientSize.Width - pbBasket.Width)
                xBasket += xDeltaBasket;
            else if (e.KeyValue == 37 && xBasket > 0)
                xBasket -= xDeltaBasket;

            pbBasket.Location = new Point(xBasket, yBasket);
        }

        // Sự kiện bấm nút Chơi Lại
        private void BtReplay_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}