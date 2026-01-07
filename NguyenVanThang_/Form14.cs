using System;
using System.Collections; // Cần thư viện này để dùng ArrayList
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form14 : Form
    {
        private ComboBox cbFaculty;
        private TextBox tbDisplay;
        private Button btOK;

        public Form14()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Article 13 - ComboBox Binding";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // ComboBox
            cbFaculty = new ComboBox();
            cbFaculty.Location = new Point(50, 30);
            cbFaculty.Width = 280;
            cbFaculty.DropDownStyle = ComboBoxStyle.DropDownList;
            // Gắn sự kiện
            cbFaculty.SelectedValueChanged += Cb_Faculty_SelectedValueChanged;

            // TextBox hiển thị
            tbDisplay = new TextBox();
            tbDisplay.Location = new Point(50, 70);
            tbDisplay.Width = 280;
            tbDisplay.ReadOnly = true;

            // Nút OK
            btOK = new Button() { Text = "OK", Location = new Point(150, 120), Size = new Size(80, 30) };
            btOK.Click += BtOK_Click;

            // Sự kiện Load
            this.Load += Form14_Load;

            this.Controls.Add(cbFaculty);
            this.Controls.Add(tbDisplay);
            this.Controls.Add(btOK);
        }

        // --- HÀM TẠO DỮ LIỆU GIẢ (Giống Slide 100) ---
        public ArrayList GetData()
        {
            ArrayList lst = new ArrayList();

            // Thêm các khoa vào danh sách
            lst.Add(new Faculty("K01", "Công nghệ thông tin", 1200));
            lst.Add(new Faculty("K02", "Quản trị kinh doanh", 4200));
            lst.Add(new Faculty("K03", "Kế toán tài chính", 5200));
            lst.Add(new Faculty("K04", "Ngôn ngữ Anh", 2000));

            return lst;
        }

        // --- SỰ KIỆN LOAD FORM ---
        private void Form14_Load(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu
            ArrayList lst = GetData();

            // 2. Đổ dữ liệu vào ComboBox
            cbFaculty.DataSource = lst;

            // 3. Chọn cột nào để HIỂN THỊ lên màn hình (Người dùng nhìn thấy Tên)
            cbFaculty.DisplayMember = "Name";

            // 4. Chọn cột nào làm GIÁ TRỊ ngầm (Máy tính dùng Mã)
            // Thông thường ta set luôn ValueMember = "Id" ở đây.
            // Nhưng để giống bài học, ta sẽ set động ở bên dưới.
        }

        // --- KHI CHỌN DÒNG KHÁC (Hiển thị Mã) ---
        private void Cb_Faculty_SelectedValueChanged(object sender, EventArgs e)
        {
            // Nếu chưa có dữ liệu thì thoát để tránh lỗi
            if (cbFaculty.DataSource == null) return;

            // Bài học muốn đổi ValueMember thành "Id" để lấy Mã Khoa
            cbFaculty.ValueMember = "Id";

            string id = cbFaculty.SelectedValue.ToString();
            tbDisplay.Text = "Bạn đã chọn khoa có mã: " + id;
        }

        // --- KHI BẤM OK (Hiển thị Tên) ---
        private void BtOK_Click(object sender, EventArgs e)
        {
            // Bài học muốn đổi ValueMember thành "Name" để lấy Tên Khoa
            // (Minh họa cho việc SelectedValue phụ thuộc vào ValueMember)
            cbFaculty.ValueMember = "Name";

            string name = cbFaculty.SelectedValue.ToString();
            tbDisplay.Text = "Bạn đã chọn khoa có tên: " + name;
        }
    }
}