using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form18 : Form
    {
        private ListBox lbSong;
        private ListBox lbFavorite;
        private Button btSelect;      // >
        private Button btDeselect;    // <
        private Button btSelectAll;   // >>
        private Button btDeselectAll; // <<

        public Form18()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "Article 17 - Music Selector";
            this.Size = new Size(550, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // 2. ListBox Trái (Danh sách bài hát)
            Label lblSong = new Label() { Text = "Danh sách bài hát", Location = new Point(20, 20), AutoSize = true };
            lbSong = new ListBox() { Location = new Point(20, 50), Size = new Size(200, 250) };
            // Thêm dữ liệu mẫu giống Slide 116
            lbSong.Items.AddRange(new string[] {
                "Giấc mơ Chapi",
                "Đôi mắt Pleiku",
                "Em Muốn Sống Bên Anh Trọn Đời",
                "H'Zen Lên Rẫy",
                "Ly Cà Phê Ban Mê",
                "Đi tìm lời ru mặt trời"
            });
            // Sự kiện Double Click
            lbSong.MouseDoubleClick += LbSong_MouseDoubleClick;

            // 3. ListBox Phải (Bài hát ưa thích)
            Label lblFav = new Label() { Text = "Danh sách bài hát ưa thích", Location = new Point(300, 20), AutoSize = true };
            lbFavorite = new ListBox() { Location = new Point(300, 50), Size = new Size(200, 250) };
            lbFavorite.MouseDoubleClick += LbFavorite_MouseDoubleClick;

            // 4. Các nút điều khiển ở giữa
            int yCenter = 100;
            btSelect = new Button() { Text = ">", Location = new Point(235, yCenter), Size = new Size(50, 30) };
            btSelectAll = new Button() { Text = ">>", Location = new Point(235, yCenter + 40), Size = new Size(50, 30) };
            btDeselect = new Button() { Text = "<", Location = new Point(235, yCenter + 80), Size = new Size(50, 30) };
            btDeselectAll = new Button() { Text = "<<", Location = new Point(235, yCenter + 120), Size = new Size(50, 30) };

            // Gắn sự kiện Click
            btSelect.Click += BtSelect_Click;
            btSelectAll.Click += BtSelectAll_Click;
            btDeselect.Click += BtDeselect_Click;
            btDeselectAll.Click += BtDeselectAll_Click;

            // Thêm vào Form
            this.Controls.AddRange(new Control[] { lblSong, lbSong, lblFav, lbFavorite, btSelect, btSelectAll, btDeselect, btDeselectAll });
        }

        // --- XỬ LÝ 1: CHUYỂN 1 BÀI TỪ TRÁI QUA PHẢI (>) ---
        private void BtSelect_Click(object sender, EventArgs e)
        {
            if (lbSong.SelectedIndex != -1) // Phải có bài đang chọn
            {
                string song = lbSong.SelectedItem.ToString();
                lbFavorite.Items.Add(song);          // Thêm sang phải
                lbSong.Items.RemoveAt(lbSong.SelectedIndex); // Xóa bên trái
            }
        }

        // --- XỬ LÝ 2: CHUYỂN TẤT CẢ TỪ TRÁI QUA PHẢI (>>) ---
        private void BtSelectAll_Click(object sender, EventArgs e)
        {
            // Cách an toàn nhất: Copy hết sang rồi xóa gốc
            lbFavorite.Items.AddRange(lbSong.Items);
            lbSong.Items.Clear();
        }

        // --- XỬ LÝ 3: CHUYỂN 1 BÀI TỪ PHẢI VỀ TRÁI (<) ---
        private void BtDeselect_Click(object sender, EventArgs e)
        {
            if (lbFavorite.SelectedIndex != -1)
            {
                string song = lbFavorite.SelectedItem.ToString();
                lbSong.Items.Add(song);              // Trả về bên trái
                lbFavorite.Items.RemoveAt(lbFavorite.SelectedIndex); // Xóa bên phải
            }
        }

        // --- XỬ LÝ 4: CHUYỂN TẤT CẢ TỪ PHẢI VỀ TRÁI (<<) ---
        private void BtDeselectAll_Click(object sender, EventArgs e)
        {
            lbSong.Items.AddRange(lbFavorite.Items);
            lbFavorite.Items.Clear();
        }

        // --- XỬ LÝ 5: DOUBLE CLICK ĐỂ CHỌN NHANH ---
        private void LbSong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbSong.IndexFromPoint(e.Location); // Lấy vị trí chuột
            if (index != ListBox.NoMatches)
            {
                string song = lbSong.Items[index].ToString();
                lbFavorite.Items.Add(song);
                lbSong.Items.RemoveAt(index);
            }
        }

        private void LbFavorite_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbFavorite.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                string song = lbFavorite.Items[index].ToString();
                lbSong.Items.Add(song);
                lbFavorite.Items.RemoveAt(index);
            }
        }
    }
}