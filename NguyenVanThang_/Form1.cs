using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // KẾT NỐI SỰ KIỆN (Quan trọng)
            // Phải có 2 dòng này thì code bên dưới mới chạy được
            this.Load += Form1_Load;
            this.ResizeEnd += Form1_ResizeEnd;
        }

        // Sự kiện khi người dùng thay đổi kích thước form xong
        void Form1_ResizeEnd(object sender, System.EventArgs e)
        {
            int width = this.Size.Width;   // Lấy chiều rộng
            int height = this.Size.Height; // Lấy chiều cao

            // Hiển thị lên tiêu đề Form: "Rộng - Cao"
            this.Text = width.ToString() + " - " + height.ToString();
        }

        // Sự kiện khi Form vừa hiện lên
        void Form1_Load(object sender, System.EventArgs e)
        {
            int width = this.Size.Width;
            int height = this.Size.Height;

            // Hiển thị kích thước mặc định ngay khi mở
            this.Text = width.ToString() + " - " + height.ToString();
        }
    }
}