using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form20 : Form
    {
        private TextBox tbId;
        private TextBox tbName;
        private PictureBox pbImage; // Khung ảnh
        private Button btFile;      // Nút chọn ảnh

        public Form20()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "Quản lý nhân sự (PictureBox)";
            this.Size = new Size(550, 400); // Nới rộng Form ra (550)
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // Cấu hình khoảng cách an toàn
            int labelX = 30;
            int inputX = 170; // [QUAN TRỌNG] Tăng từ 130 lên 170 để tránh bị chữ đè

            // 2. Mã nhân viên
            Label lblId = new Label() { Text = "Mã nhân viên:", Location = new Point(labelX, 30), AutoSize = true };
            tbId = new TextBox() { Location = new Point(inputX, 27), Width = 150, Text = "03152482001" };

            // 3. Tên nhân viên
            Label lblName = new Label() { Text = "Tên nhân viên:", Location = new Point(labelX, 70), AutoSize = true };
            tbName = new TextBox() { Location = new Point(inputX, 67), Width = 250, Text = "Nguyễn Văn Hùng" };

            // 4. PictureBox (Ảnh 3x4)
            Label lblImg = new Label() { Text = "Ảnh 3 x 4:", Location = new Point(labelX, 110), AutoSize = true };

            pbImage = new PictureBox();
            pbImage.Location = new Point(inputX, 110); // Căn thẳng hàng với TextBox trên
            pbImage.Size = new Size(150, 180);
            pbImage.BorderStyle = BorderStyle.FixedSingle;
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;

            // 5. Nút Chọn ảnh
            // Đẩy nút sang bên cạnh khung ảnh (170 + 150 + 20 = 340)
            btFile = new Button() { Text = "Chọn ảnh ...", Location = new Point(340, 110), Size = new Size(100, 35) };
            btFile.Click += BtFile_Click;

            // Thêm vào Form
            this.Controls.Add(lblId); this.Controls.Add(tbId);
            this.Controls.Add(lblName); this.Controls.Add(tbName);
            this.Controls.Add(lblImg); this.Controls.Add(pbImage);
            this.Controls.Add(btFile);
        }

        // --- SỰ KIỆN CHỌN ẢNH (Logic Slide 129) ---
        private void BtFile_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại mở file
            OpenFileDialog dlg = new OpenFileDialog();

            // Chỉ lọc file ảnh jpg, png
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            dlg.Title = "Open Image";

            // Nếu người dùng chọn file và bấm OK
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Cách 1: Dùng ImageLocation (Đường dẫn file) - Nhẹ, không khóa file gốc
                pbImage.ImageLocation = dlg.FileName; //

                // Cách 2: Dùng Image.FromFile (Nặng hơn, khóa file gốc)
                // pbImage.Image = Image.FromFile(dlg.FileName); 
            }
        }
    }
}