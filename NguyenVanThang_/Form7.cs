using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form7 : Form
    {
        // Khai báo nút bấm
        private Button bt_OK;

        public Form7()
        {
            InitializeComponent();

            // --- TẠO NÚT BẰNG CODE (Dynamic Control) ---
            this.bt_OK = new Button();

            // Thiết lập vị trí: Neo vào góc dưới bên phải
            this.bt_OK.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.bt_OK.Location = new Point(this.ClientSize.Width - 100, this.ClientSize.Height - 50);

            // Thiết lập thuộc tính nút
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new Size(80, 25);
            this.bt_OK.TabIndex = 0;
            this.bt_OK.Text = "OK";

            // Gắn sự kiện Click
            this.bt_OK.Click += new EventHandler(this.bt_OK_Click);

            // Thêm nút vào Form
            this.Controls.Add(this.bt_OK);
        }

        // Sự kiện: Khi bấm nút OK
        private void bt_OK_Click(object sender, EventArgs e)
        {
            // Thay đổi tiêu đề Form
            this.Text = "Article for Button";

            // Thay đổi kích thước Form thành 500x500
            this.Size = new Size(500, 500);

            // (Tùy chọn) Hiện thông báo để dễ nhận biết
            MessageBox.Show("Đã thay đổi kích thước Form thành 500x500!");
        }
    }
}