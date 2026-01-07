using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form15 : Form
    {
        // Khai báo các Control
        private TextBox tbName;
        private RadioButton rbNam;
        private RadioButton rbNu;
        private CheckBox cbDiscount;
        private TextBox tbDiscount;
        private TextBox tbResult;
        private Button btTinhTien;
        private Button btThoat;

        public Form15()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "Article 14 - RadioButton & CheckBox";
            this.Size = new Size(400, 480); // Tăng chiều cao Form lên chút
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // 2. Nhập tên
            // Label cho rõ ràng
            Label lblName = new Label() { Text = "Họ tên:", Location = new Point(30, 30), AutoSize = true };
            tbName = new TextBox() { Location = new Point(100, 27), Width = 250, Text = "Nguyễn Văn A" };

            // 3. GroupBox Giới tính
            GroupBox gbGender = new GroupBox() { Text = "Giới tính", Location = new Point(30, 70), Size = new Size(320, 80) };

            rbNam = new RadioButton() { Text = "Nam", Location = new Point(50, 30), Checked = true, AutoSize = true };
            rbNu = new RadioButton() { Text = "Nữ", Location = new Point(180, 30), AutoSize = true };

            gbGender.Controls.Add(rbNam);
            gbGender.Controls.Add(rbNu);

            // 4. CheckBox Giảm giá và Ô nhập số %
            // Đẩy xuống Y=170
            cbDiscount = new CheckBox() { Text = "Giảm giá (%)", Location = new Point(30, 170), AutoSize = true };
            cbDiscount.CheckedChanged += CbDiscount_CheckedChanged;

            // [SỬA LỖI] Đẩy ô nhập sang phải (X=160) để không bị chữ che
            tbDiscount = new TextBox() { Location = new Point(160, 167), Width = 100, Text = "0" };
            tbDiscount.Enabled = false;

            // 5. Ô kết quả
            // [SỬA LỖI] Đẩy xuống dưới (Y=220) cho thoáng
            tbResult = new TextBox();
            tbResult.Location = new Point(30, 220);
            tbResult.Size = new Size(320, 100);
            tbResult.Multiline = true;
            tbResult.ReadOnly = true;

            // 6. Các nút bấm
            // Đẩy xuống theo (Y=340)
            btTinhTien = new Button() { Text = "Tính tiền", Location = new Point(130, 340), Size = new Size(100, 40) };
            btThoat = new Button() { Text = "Thoát", Location = new Point(250, 340), Size = new Size(100, 40) };

            btTinhTien.Click += BtTinhTien_Click;
            btThoat.Click += (s, e) => { this.Close(); };

            // Thêm vào Form
            this.Controls.Add(lblName); // Thêm label tên cho đẹp
            this.Controls.Add(tbName);
            this.Controls.Add(gbGender);
            this.Controls.Add(cbDiscount);
            this.Controls.Add(tbDiscount);
            this.Controls.Add(tbResult);
            this.Controls.Add(btTinhTien);
            this.Controls.Add(btThoat);
        }

        // --- SỰ KIỆN 1: BẬT/TẮT Ô NHẬP GIẢM GIÁ ---
        private void CbDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDiscount.Checked == true)
            {
                tbDiscount.Enabled = true;  // Cho phép nhập
                tbDiscount.Focus();         // Đặt chuột vào đó luôn
            }
            else
            {
                tbDiscount.Enabled = false; // Khóa lại
                tbDiscount.Text = "0";      // Reset về 0
            }
        }

        // --- SỰ KIỆN 2: TÍNH TIỀN ---
        private void BtTinhTien_Click(object sender, EventArgs e)
        {
            string msg = "";

            // Xử lý xưng hô dựa trên RadioButton
            if (rbNam.Checked) msg = "Ông ";
            else msg = "Bà ";

            // Xử lý giảm giá
            int disc = 0;
            if (cbDiscount.Checked)
            {
                // Cố gắng lấy số từ ô nhập, nếu lỗi thì tính là 0
                int.TryParse(tbDiscount.Text, out disc);
            }

            // Hiển thị kết quả
            tbResult.Text = msg + tbName.Text + " được giảm " + disc + "%";
        }
    }
}