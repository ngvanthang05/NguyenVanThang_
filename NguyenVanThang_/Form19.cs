using System;
using System.Collections; // Cần thư viện này cho ArrayList
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form19 : Form
    {
        private ListBox lbSong;
        private ListBox lbFavorite;
        private Button btSelect;
        private Label lblGuide;

        // Danh sách gốc (Lưu biến toàn cục để dễ xử lý)
        ArrayList listSong = new ArrayList();

        public Form19()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Article 18 - ListBox Object Binding";
            this.Size = new Size(550, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // 1. ListBox Trái (Danh sách bài hát - Bound Data)
            Label lblLeft = new Label() { Text = "Danh sách bài hát (Object)", Location = new Point(20, 20), AutoSize = true };
            lbSong = new ListBox() { Location = new Point(20, 50), Size = new Size(200, 250) };

            // 2. ListBox Phải (Danh sách yêu thích - String)
            Label lblRight = new Label() { Text = "Danh sách bài hát ưa thích", Location = new Point(300, 20), AutoSize = true };
            lbFavorite = new ListBox() { Location = new Point(300, 50), Size = new Size(220, 250) };

            // 3. Nút Chọn
            btSelect = new Button() { Text = ">", Location = new Point(235, 150), Size = new Size(50, 40) };
            btSelect.Click += BtSelect_Click;

            // 4. Sự kiện Load để nạp dữ liệu
            this.Load += Form19_Load;

            this.Controls.Add(lblLeft); this.Controls.Add(lbSong);
            this.Controls.Add(lblRight); this.Controls.Add(lbFavorite);
            this.Controls.Add(btSelect);
        }

        // --- HÀM TẠO DỮ LIỆU GIẢ (Giống Slide 123) ---
        private ArrayList GetData()
        {
            ArrayList lst = new ArrayList();
            lst.Add(new Song(53418, "Giấc mơ Chapi", "Trần Tiến"));
            lst.Add(new Song(52616, "Đôi mắt Pleiku", "Nguyễn Cường"));
            lst.Add(new Song(51172, "Em Muốn Sống Bên Anh Trọn Đời", "Nguyễn Cường"));
            lst.Add(new Song(52300, "Ly Cà Phê Ban Mê", "Nguyễn Cường"));
            return lst;
        }

        // --- SỰ KIỆN LOAD FORM ---
        private void Form19_Load(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu
            listSong = GetData();

            // 2. Đổ vào ListBox
            lbSong.DataSource = listSong;

            // 3. Chọn cột hiển thị (Chỉ hiện Tên bài hát)
            lbSong.DisplayMember = "Name";

            // (Tùy chọn) Giá trị ngầm là Id
            lbSong.ValueMember = "Id";
        }

        // --- SỰ KIỆN CHỌN (>) ---
        private void BtSelect_Click(object sender, EventArgs e)
        {
            // Lấy đối tượng đang chọn (Ép kiểu về Song)
            Song song = (Song)lbSong.SelectedItem;

            // Tạo chuỗi hiển thị đầy đủ thông tin
            string id = song.Id.ToString();
            string name = song.Name;
            string author = song.Author;

            // Thêm vào danh sách bên phải (Dạng chuỗi)
            string displayString = id + " - " + name + " - " + author;
            lbFavorite.Items.Add(displayString);
        }
    }
}