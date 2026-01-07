using System;
using System.Drawing;
using System.Drawing.Drawing2D; // Thư viện để vẽ hình tròn
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class MenuForm : Form
    {
        public MenuForm(string username = "Admin")
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(username))
            {
                this.Text = "Xin chào " + username + " - Danh sách bài tập";
            }
            else
            {
                this.Text = "Menu - Danh sách bài tập";
            }

            Tao30Nut();
        }

        void Tao30Nut()
        {
            flowLayoutPanel1.Controls.Clear();

            for (int i = 1; i <= 30; i++)
            {
                Button btn = new Button();

                // 1. CHỈNH MÀU CAM
                btn.BackColor = Color.Orange;
                btn.ForeColor = Color.White; // Chữ màu trắng cho nổi bật trên nền cam

                // 2. CHỈNH KÍCH THƯỚC VUÔNG (để cắt thành hình tròn)
                btn.Size = new Size(80, 80); // Tăng kích thước lên một chút cho đẹp

                btn.Text = "Bài " + i;
                btn.Margin = new Padding(15); // Tăng khoảng cách giữa các nút
                btn.Tag = i;
                btn.Cursor = Cursors.Hand;

                // 3. LOẠI BỎ VIỀN NỔI (để nút trông phẳng đẹp hơn)
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;

                // 4. CẮT HÌNH TRÒN (Kỹ thuật dùng GraphicsPath)
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, btn.Width, btn.Height);
                btn.Region = new Region(path);

                btn.Click += Btn_Click;

                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int baiSo = (int)btn.Tag;

            switch (baiSo)
            {
                case 1: new Form1().ShowDialog(); break;
                case 2: new Form2().ShowDialog(); break;
                case 3: new Form3().ShowDialog(); break;
                case 4: new Form4().ShowDialog(); break;

                case 6: new Form6().ShowDialog(); break;
                case 7: new Form7().ShowDialog(); break;
                case 8: new Form8().ShowDialog(); break;
                case 9: new Form9().ShowDialog(); break;
                case 10: new Form10().ShowDialog(); break;
                case 11: new Form11().ShowDialog(); break;
                case 12: new Form12().ShowDialog(); break;
                case 13: new Form13().ShowDialog(); break;
                case 14: new Form14().ShowDialog(); break;
                case 15: new Form15().ShowDialog(); break;
                case 16: new Form16().ShowDialog(); break;
                case 17: new Form17().ShowDialog(); break;
                case 18: new Form18().ShowDialog(); break;
                case 19: new Form19().ShowDialog(); break;
                case 20: new Form20().ShowDialog(); break;
                case 21: new Form21().ShowDialog(); break;
                case 22: new Form22().ShowDialog(); break;
                case 23: new Form23().ShowDialog(); break;
                case 24: new Form24().ShowDialog(); break;
                case 25: new Form25().ShowDialog(); break;
                case 26: new Form26().ShowDialog(); break;
                case 27: new Form27().ShowDialog(); break;
                case 28: new Form28().ShowDialog(); break;
                case 29: new Form29().ShowDialog(); break;
                case 30: new Form30().ShowDialog(); break;

                default:
                    MessageBox.Show("Chức năng bài " + baiSo + " đang được phát triển!", "Thông báo");
                    break;
            }
        }
    }
}