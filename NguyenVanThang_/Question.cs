using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Question : UserControl
    {
        // Khai báo nút PUBLIC
        public Button btQuayLai;
        public Button btNopBai;
        // public Button btTiepTuc; // (Tùy chọn nếu muốn làm nhiều câu hỏi)

        public Question()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Size = new Size(700, 450);
            this.BackColor = Color.WhiteSmoke;

            // --- PHẦN TRÊN: INFO TÓM TẮT ---
            Panel pnlTop = new Panel() { Dock = DockStyle.Top, Height = 60, BackColor = Color.White };
            pnlTop.Controls.Add(new Label() { Text = "Mã: 1", Location = new Point(50, 20), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) });
            pnlTop.Controls.Add(new Label() { Text = "Tên: Nguyễn Anh Tú", Location = new Point(250, 20), AutoSize = true, Font = new Font("Segoe UI", 9, FontStyle.Bold) });
            pnlTop.Controls.Add(new Label() { Text = "Ngày sinh: 10/10/1994", Location = new Point(500, 20), AutoSize = true });

            // --- GROUP CÂU HỎI ---
            GroupBox gbQ = new GroupBox() { Text = "Câu hỏi", Location = new Point(20, 80), Size = new Size(660, 100) };
            gbQ.Controls.Add(new Label()
            {
                Text = "Một cộng một bằng bao nhiêu?",
                Location = new Point(50, 40),
                AutoSize = true,
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            });

            // --- GROUP TRẢ LỜI ---
            GroupBox gbA = new GroupBox() { Text = "Câu trả lời", Location = new Point(20, 200), Size = new Size(660, 180) };

            gbA.Controls.Add(new RadioButton() { Text = "Hai", Location = new Point(50, 30), Checked = true });
            gbA.Controls.Add(new RadioButton() { Text = "Bốn", Location = new Point(50, 70) });
            gbA.Controls.Add(new RadioButton() { Text = "Năm", Location = new Point(50, 110) });
            gbA.Controls.Add(new RadioButton() { Text = "Ba", Location = new Point(50, 150) });

            // --- CÁC NÚT BẤM ---
            btQuayLai = new Button() { Text = "Quay lại", Location = new Point(330, 400), Size = new Size(100, 35) };
            Button btTiep = new Button() { Text = "Tiếp tục", Location = new Point(450, 400), Size = new Size(100, 35) };
            btNopBai = new Button() { Text = "Nộp bài", Location = new Point(570, 400), Size = new Size(100, 35) };

            this.Controls.Add(pnlTop);
            this.Controls.Add(gbQ);
            this.Controls.Add(gbA);
            this.Controls.Add(btQuayLai);
            this.Controls.Add(btTiep);
            this.Controls.Add(btNopBai);
        }
    }
}