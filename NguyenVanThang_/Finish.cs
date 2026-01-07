using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Finish : UserControl
    {
        // Khai báo nút PUBLIC
        public Button btKetThuc;

        public Finish()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Size = new Size(700, 450);
            this.BackColor = Color.WhiteSmoke;

            // --- GROUP 1: THÔNG TIN THÍ SINH ---
            GroupBox gbInfo = new GroupBox() { Text = "Thông tin thí sinh", Location = new Point(50, 30), Size = new Size(600, 150) };

            // Label hiển thị thông tin tĩnh (như Slide 188)
            int x = 200, y = 30, gap = 30;
            gbInfo.Controls.Add(new Label() { Text = "Mã: 0001", Location = new Point(x, y), AutoSize = true });
            y += gap;
            gbInfo.Controls.Add(new Label() { Text = "Tên: Nguyễn Văn A", Location = new Point(x, y), AutoSize = true });
            y += gap;
            gbInfo.Controls.Add(new Label() { Text = "Ngày sinh: 01/01/1996", Location = new Point(x, y), AutoSize = true });
            y += gap;
            gbInfo.Controls.Add(new Label() { Text = "Nơi sinh: TP. Hồ Chí Minh", Location = new Point(x, y), AutoSize = true });

            // --- GROUP 2: KẾT QUẢ THI ---
            GroupBox gbResult = new GroupBox() { Text = "Kết quả thi", Location = new Point(50, 200), Size = new Size(600, 150) };

            y = 30;
            gbResult.Controls.Add(new Label() { Text = "Tổng số câu hỏi: 100", Location = new Point(x, y), AutoSize = true });
            y += gap;
            gbResult.Controls.Add(new Label() { Text = "Tổng số câu trả lời: 85", Location = new Point(x, y), AutoSize = true });
            y += gap;
            gbResult.Controls.Add(new Label() { Text = "Tổng số câu trả lời đúng: 62", Location = new Point(x, y), AutoSize = true });
            y += gap;
            gbResult.Controls.Add(new Label() { Text = "Tổng số điểm đạt được: 6.2", Location = new Point(x, y), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold) });

            // --- NÚT KẾT THÚC ---
            btKetThuc = new Button() { Text = "Kết thúc", Location = new Point(550, 380), Size = new Size(100, 35) };

            this.Controls.Add(gbInfo);
            this.Controls.Add(gbResult);
            this.Controls.Add(btKetThuc);
        }
    }
}