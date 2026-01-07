using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form26 : Form
    {
        private PictureBox pbBall;

        // [SỬA LỖI] Chỉ định rõ đây là Timer của Windows Forms
        private System.Windows.Forms.Timer tmGame;

        private int xBall = 0;
        private int yBall = 0;
        private int xDelta = 5;
        private int yDelta = 5;

        public Form26()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Article 25 - Bouncing Ball Game";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;

            // Tạo quả bóng
            pbBall = new PictureBox();
            pbBall.Size = new Size(50, 50);
            pbBall.Location = new Point(xBall, yBall);
            pbBall.SizeMode = PictureBoxSizeMode.StretchImage;

            // Vẽ bóng đỏ
            pbBall.Paint += (s, e) => {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(Brushes.Red, 0, 0, pbBall.Width - 1, pbBall.Height - 1);
            };

            // [SỬA LỖI] Khởi tạo Timer cụ thể
            tmGame = new System.Windows.Forms.Timer();
            tmGame.Interval = 20;
            tmGame.Tick += TmGame_Tick;

            tmGame.Start();

            this.Controls.Add(pbBall);
        }

        private void TmGame_Tick(object sender, EventArgs e)
        {
            // Cập nhật toạ độ
            xBall += xDelta;
            yBall += yDelta;

            // Va chạm chiều ngang
            if (xBall > this.ClientSize.Width - pbBall.Width || xBall <= 0)
            {
                xDelta = -xDelta;
            }

            // Va chạm chiều dọc
            if (yBall > this.ClientSize.Height - pbBall.Height || yBall <= 0)
            {
                yDelta = -yDelta;
            }

            pbBall.Location = new Point(xBall, yBall);
        }
    }
}