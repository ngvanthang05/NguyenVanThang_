using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form16 : Form
    {
        private DateTimePicker dtpDate;
        private Button btOK;
        private Label lblHuongDan;

        public Form16()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "Article 15 - DateTimePicker";
            this.Size = new Size(400, 200);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // 2. DateTimePicker
            dtpDate = new DateTimePicker();
            dtpDate.Location = new Point(50, 50);
            dtpDate.Width = 280;
            // Định dạng hiển thị ngày tháng tùy chỉnh (dd/MM/yyyy) cho dễ nhìn
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd/MM/yyyy";

            // Gắn sự kiện khi thay đổi ngày
            dtpDate.ValueChanged += DtpDate_ValueChanged;

            // 3. Button OK
            btOK = new Button() { Text = "OK", Location = new Point(150, 100), Size = new Size(80, 30) };
            btOK.Click += BtOK_Click;

            // 4. Label hướng dẫn (Thêm vào để bạn dễ hiểu logic)
            lblHuongDan = new Label();
            lblHuongDan.Text = "Hãy chọn ngày hoặc bấm OK để xem Tiêu đề Form thay đổi.";
            lblHuongDan.Location = new Point(20, 10);
            lblHuongDan.AutoSize = true;
            lblHuongDan.ForeColor = Color.Blue;

            // Thêm vào Form
            this.Controls.Add(dtpDate);
            this.Controls.Add(btOK);
            this.Controls.Add(lblHuongDan);
        }

        // --- SỰ KIỆN 1: KHI CHỌN NGÀY KHÁC ---
        private void DtpDate_ValueChanged(object sender, EventArgs e)
        {
            // Lấy ngày tháng năm (Short Date: dd/MM/yyyy)
            this.Text = "Short Date: " + dtpDate.Value.ToShortDateString();
        }

        // --- SỰ KIỆN 2: KHI BẤM OK ---
        private void BtOK_Click(object sender, EventArgs e)
        {
            // Lấy ngày tháng đầy đủ (Long Date: Thứ, ngày, tháng, năm...)
            this.Text = "Long Date: " + dtpDate.Value.ToLongDateString();
        }
    }
}