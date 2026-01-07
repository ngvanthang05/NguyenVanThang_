using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Login : UserControl
    {
        // Khai báo các nút là PUBLIC để Form30 có thể gọi được
        public Button btTiepTuc;
        public Button btKetThuc;

        public Login()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Size = new Size(700, 450);
            this.BackColor = Color.WhiteSmoke;

            // --- GROUP 1: THÔNG TIN THÍ SINH ---
            GroupBox gbInfo = new GroupBox() { Text = "Thông tin thí sinh", Location = new Point(20, 20), Size = new Size(660, 250) };

            // Các nhãn và ô nhập
            int xLbl = 30, xTxt = 150, y = 30, gap = 40;

            gbInfo.Controls.Add(new Label() { Text = "Mã:", Location = new Point(xLbl, y), AutoSize = true });
            gbInfo.Controls.Add(new TextBox() { Location = new Point(xTxt, y - 3), Width = 150 });

            y += gap;
            gbInfo.Controls.Add(new Label() { Text = "Tên:", Location = new Point(xLbl, y), AutoSize = true });
            gbInfo.Controls.Add(new TextBox() { Location = new Point(xTxt, y - 3), Width = 300 });

            y += gap;
            gbInfo.Controls.Add(new Label() { Text = "Ngày sinh:", Location = new Point(xLbl, y), AutoSize = true });
            gbInfo.Controls.Add(new DateTimePicker() { Location = new Point(xTxt, y - 3), Width = 150, Format = DateTimePickerFormat.Short });

            y += gap;
            gbInfo.Controls.Add(new Label() { Text = "Nơi sinh:", Location = new Point(xLbl, y), AutoSize = true });
            gbInfo.Controls.Add(new TextBox() { Location = new Point(xTxt, y - 3), Width = 300 });

            y += gap;
            gbInfo.Controls.Add(new Label() { Text = "Giới tính:", Location = new Point(xLbl, y), AutoSize = true });
            ComboBox cbSex = new ComboBox() { Location = new Point(xTxt, y - 3), Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
            cbSex.Items.AddRange(new string[] { "Nam", "Nữ" });
            gbInfo.Controls.Add(cbSex);

            // --- GROUP 2: THÔNG TIN KỲ THI ---
            GroupBox gbExam = new GroupBox() { Text = "Thông tin kỳ thi", Location = new Point(20, 280), Size = new Size(660, 100) };

            gbExam.Controls.Add(new Label() { Text = "Danh sách kỳ thi:", Location = new Point(30, 40), AutoSize = true });
            ComboBox cbExam = new ComboBox() { Location = new Point(150, 37), Width = 250, Text = "Chứng chỉ tin học A tiếng Anh" };
            gbExam.Controls.Add(cbExam);

            gbExam.Controls.Add(new Label() { Text = "Số câu hỏi: 60", Location = new Point(450, 40), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) });
            gbExam.Controls.Add(new Label() { Text = "Thời gian: 120", Location = new Point(550, 40), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) });

            // --- CÁC NÚT BẤM ---
            btTiepTuc = new Button() { Text = "Tiếp tục", Location = new Point(450, 400), Size = new Size(100, 35) };
            btKetThuc = new Button() { Text = "Kết thúc", Location = new Point(570, 400), Size = new Size(100, 35) };

            // Thêm tất cả vào UserControl
            this.Controls.Add(gbInfo);
            this.Controls.Add(gbExam);
            this.Controls.Add(btTiepTuc);
            this.Controls.Add(btKetThuc);
        }
    }
}