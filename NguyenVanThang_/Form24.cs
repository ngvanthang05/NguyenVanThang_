using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form24 : Form
    {
        private PictureBox pbImage;
        private Button btLeft;
        private Button btRight;
        private Button btFile;

        // Khai báo biến toạ độ x, y để quản lý vị trí ảnh
        private int x = 50;
        private int y = 50;

        public Form24()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "Article 23 - Simple Game (Move Image)";
            this.Size = new Size(600, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // 2. PictureBox
            pbImage = new PictureBox();
            pbImage.Size = new Size(150, 150);
            pbImage.Location = new Point(x, y); // Đặt vị trí ban đầu
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage; // Co giãn ảnh
            pbImage.BorderStyle = BorderStyle.FixedSingle;
            pbImage.BackColor = Color.WhiteSmoke; // Màu nền cho dễ thấy nếu chưa có ảnh

            // 3. Các nút điều khiển
            int yBtn = 350;
            btLeft = new Button() { Text = "<", Location = new Point(150, yBtn), Size = new Size(50, 40) };
            btRight = new Button() { Text = ">", Location = new Point(210, yBtn), Size = new Size(50, 40) };
            btFile = new Button() { Text = "File ...", Location = new Point(350, yBtn), Size = new Size(100, 40) };

            // Gắn sự kiện
            btFile.Click += BtFile_Click;
            btLeft.Click += BtLeft_Click;
            btRight.Click += BtRight_Click;

            // Thêm vào Form
            this.Controls.Add(pbImage);
            this.Controls.Add(btLeft);
            this.Controls.Add(btRight);
            this.Controls.Add(btFile);
        }

        // --- CHỨC NĂNG 1: CHỌN ẢNH ---
        private void BtFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image";
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbImage.ImageLocation = dlg.FileName;
            }
        }

        // --- CHỨC NĂNG 2: DI CHUYỂN TRÁI ---
        private void BtLeft_Click(object sender, EventArgs e)
        {
            x -= 10; // Giảm toạ độ x để sang trái
            pbImage.Location = new Point(x, y);
        }

        // --- CHỨC NĂNG 3: DI CHUYỂN PHẢI ---
        private void BtRight_Click(object sender, EventArgs e)
        {
            x += 10; // Tăng toạ độ x để sang phải
            pbImage.Location = new Point(x, y);
        }
    }
}