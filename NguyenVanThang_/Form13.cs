using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form13 : Form
    {
        // Khai báo các Control
        private ComboBox cbFaculty;
        private TextBox tbDisplay;
        private Button btOK;
        private Button btClear; // Nút xóa (như trong hình Slide 95)
        private Label lblGuide;

        public Form13()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "ComboBox Article";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // 2. ComboBox (Danh sách khoa)
            cbFaculty = new ComboBox();
            cbFaculty.Location = new Point(50, 30);
            cbFaculty.Width = 280;
            cbFaculty.DropDownStyle = ComboBoxStyle.DropDownList; // Chỉ cho chọn, không cho gõ linh tinh

            // Thêm dữ liệu vào ComboBox (Giống Slide 95)
            string[] cacKhoa = {
                "Công nghệ thông tin",
                "Ngoại ngữ",
                "Quản trị kinh doanh",
                "Cơ khí",
                "Điện",
                "Cơ khí động lực"
            };
            cbFaculty.Items.AddRange(cacKhoa);

            // Gắn sự kiện khi chọn dòng khác
            cbFaculty.SelectedIndexChanged += Cb_Faculty_SelectedIndexChanged;

            // 3. TextBox hiển thị kết quả
            tbDisplay = new TextBox();
            tbDisplay.Location = new Point(50, 70);
            tbDisplay.Width = 280;
            tbDisplay.Height = 80;
            tbDisplay.Multiline = true; // Cho phép hiện nhiều dòng
            tbDisplay.ReadOnly = true;  // Chỉ đọc

            // 4. Các nút bấm (Clear và OK)
            btClear = new Button() { Text = "Clear", Location = new Point(110, 160), Size = new Size(80, 30) };
            btOK = new Button() { Text = "OK", Location = new Point(200, 160), Size = new Size(80, 30) };

            // Gắn sự kiện Click
            btOK.Click += BtOK_Click;
            btClear.Click += (s, e) => { tbDisplay.Clear(); }; // Sự kiện xóa nhanh

            // 5. Sự kiện Load Form (Để chọn mặc định)
            this.Load += Form13_Load;

            // Thêm vào Form
            this.Controls.Add(cbFaculty);
            this.Controls.Add(tbDisplay);
            this.Controls.Add(btClear);
            this.Controls.Add(btOK);
        }

        // --- SỰ KIỆN 1: KHI FORM VỪA CHẠY ---
        private void Form13_Load(object sender, EventArgs e)
        {
            // Tự động chọn dòng thứ 3 (Index = 2) là "Quản trị kinh doanh"
            cbFaculty.SelectedIndex = 2;
        }

        // --- SỰ KIỆN 2: KHI NGƯỜI DÙNG CHỌN MỤC KHÁC ---
        private void Cb_Faculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbFaculty.SelectedIndex;
            int thuTuNguoiDung = index + 1;
            tbDisplay.Text = "Bạn đã chọn khoa thứ: " + thuTuNguoiDung.ToString();
        }

        // --- SỰ KIỆN 3: KHI BẤM NÚT OK ---
        private void BtOK_Click(object sender, EventArgs e)
        {
            // Lấy nội dung chữ của mục đang chọn
            string item = cbFaculty.SelectedItem.ToString();
            tbDisplay.Text = "Bạn là sinh viên khoa : " + item;
        }
    }
}