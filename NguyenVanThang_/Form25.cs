using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form25 : Form
    {
        private Label lblDisplay;
        private Button btStart;
        private Button btStop;

        // [SỬA LỖI] Chỉ định rõ đây là Timer của Windows Forms
        private System.Windows.Forms.Timer tmStopwatch;

        private int second = 0;

        public Form25()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Article 24 - Timer";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            lblDisplay = new Label();
            lblDisplay.Text = "00:00";
            lblDisplay.Location = new Point(50, 30); // Đẩy lên cao chút (Y=30)

            // [SỬA LỖI] Tăng chiều cao từ 50 lên 80
            lblDisplay.Size = new Size(280, 80);

            lblDisplay.Font = new Font("Segoe UI", 30, FontStyle.Bold);
            lblDisplay.TextAlign = ContentAlignment.MiddleCenter;

            btStart = new Button() { Text = "Start", Location = new Point(80, 130), Size = new Size(100, 40) };
            btStop = new Button() { Text = "Stop", Location = new Point(200, 130), Size = new Size(100, 40) };

            tmStopwatch = new System.Windows.Forms.Timer();

            btStart.Click += BtStart_Click;
            btStop.Click += BtStop_Click;
            tmStopwatch.Tick += TmStopwatch_Tick;

            this.Controls.Add(lblDisplay);
            this.Controls.Add(btStart);
            this.Controls.Add(btStop);
        }

        private void BtStart_Click(object sender, EventArgs e)
        {
            tmStopwatch.Interval = 1000;
            tmStopwatch.Start();
        }

        private void BtStop_Click(object sender, EventArgs e)
        {
            tmStopwatch.Stop();
        }

        private void TmStopwatch_Tick(object sender, EventArgs e)
        {
            second++;
            // Format mm:ss cho đẹp
            TimeSpan time = TimeSpan.FromSeconds(second);
            lblDisplay.Text = time.ToString(@"mm\:ss");
        }
    }
}