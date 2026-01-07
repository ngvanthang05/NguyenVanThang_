using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form17 : Form
    {
        // Khai báo các Control
        private TextBox tbName;
        private DateTimePicker dtpDob;
        private RadioButton rbNam;
        private RadioButton rbNu;
        private ComboBox cbFaculty;
        private ListBox lbTrangThai; // ListBox để hiện danh sách
        private Button btThem;
        private Button btThoat;

        // Biến đếm số thứ tự sinh viên (1, 2, 3...)
        private int stt = 0;

        public Form17()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "Quản lý sinh viên";
            this.Size = new Size(450, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // 2. Họ và tên
            Label lblName = new Label() { Text = "Họ và tên", Location = new Point(30, 30), AutoSize = true };
            tbName = new TextBox() { Location = new Point(150, 27), Width = 250 };

            // 3. Ngày sinh (DateTimePicker)
            Label lblDob = new Label() { Text = "Ngày Sinh", Location = new Point(30, 70), AutoSize = true };
            dtpDob = new DateTimePicker() { Location = new Point(150, 67), Width = 250, Format = DateTimePickerFormat.Short };

            // 4. Giới tính (GroupBox + RadioButton)
            GroupBox gbGender = new GroupBox() { Text = "Giới tính", Location = new Point(150, 100), Size = new Size(250, 60) };
            rbNam = new RadioButton() { Text = "Nam", Location = new Point(40, 25), AutoSize = true, Checked = true };
            rbNu = new RadioButton() { Text = "Nữ", Location = new Point(140, 25), AutoSize = true };
            gbGender.Controls.Add(rbNam);
            gbGender.Controls.Add(rbNu);

            // 5. Khoa (ComboBox)
            Label lblFaculty = new Label() { Text = "Khoa", Location = new Point(30, 180), AutoSize = true };
            cbFaculty = new ComboBox() { Location = new Point(150, 177), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            // Thêm dữ liệu mẫu
            cbFaculty.Items.AddRange(new string[] { "Công nghệ thông tin", "Kế toán", "Cơ khí", "Điện tử" });
            cbFaculty.SelectedIndex = 0;

            // 6. Trạng thái (ListBox)
            Label lblStatus = new Label() { Text = "Trạng thái", Location = new Point(30, 220), AutoSize = true };
            lbTrangThai = new ListBox();
            lbTrangThai.Location = new Point(150, 220);
            lbTrangThai.Width = 250;
            lbTrangThai.Height = 200;

            // 7. Các nút bấm
            btThem = new Button() { Text = "Thêm", Location = new Point(180, 440), Size = new Size(80, 35) };
            btThoat = new Button() { Text = "Thoát", Location = new Point(280, 440), Size = new Size(80, 35) };

            // Gắn sự kiện
            btThem.Click += BtThem_Click;
            btThoat.Click += (s, e) => { this.Close(); };

            // Thêm tất cả vào Form
            this.Controls.Add(lblName); this.Controls.Add(tbName);
            this.Controls.Add(lblDob); this.Controls.Add(dtpDob);
            this.Controls.Add(gbGender);
            this.Controls.Add(lblFaculty); this.Controls.Add(cbFaculty);
            this.Controls.Add(lblStatus); this.Controls.Add(lbTrangThai);
            this.Controls.Add(btThem); this.Controls.Add(btThoat);
        }

        // --- SỰ KIỆN: BẤM NÚT THÊM ---
        private void BtThem_Click(object sender, EventArgs e)
        {
            // Tăng số thứ tự
            stt++;

            // Lấy thông tin từ các Control
            string ten = tbName.Text;
            string ngaySinh = dtpDob.Value.ToShortDateString();
            string gioiTinh = rbNam.Checked ? "Nam" : "Nữ"; // Nếu rbNam chọn thì là Nam, ngược lại là Nữ
            string khoa = cbFaculty.SelectedItem.ToString();

            // Thêm từng dòng vào ListBox để giống hình mẫu
            lbTrangThai.Items.Add(stt + ". " + ten);
            lbTrangThai.Items.Add("    -Giới tính: " + gioiTinh);
            lbTrangThai.Items.Add("    -Ngày Sinh: " + ngaySinh);
            lbTrangThai.Items.Add("    -Khoa: " + khoa);

            // (Tùy chọn) Thêm dòng trống để ngăn cách cho đẹp
            lbTrangThai.Items.Add("");
        }
    }
}