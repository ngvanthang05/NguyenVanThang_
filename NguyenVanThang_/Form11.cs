using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form11 : Form
    {
        // Khai báo các biến logic
        private decimal workingMemory = 0; // Biến nhớ giá trị số thứ nhất
        private string opr = "";           // Biến nhớ phép toán (+, -, *, /)

        // Màn hình hiển thị
        private TextBox tbDisplay;

        public Form11()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "Article 10 - Button Calculator";
            this.Size = new Size(300, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // 2. Màn hình hiển thị (TextBox)
            tbDisplay = new TextBox();
            tbDisplay.Location = new Point(20, 20);
            tbDisplay.Size = new Size(245, 40);
            tbDisplay.Font = new Font("Segoe UI", 18, FontStyle.Bold); // Chữ to
            tbDisplay.TextAlign = HorizontalAlignment.Right; // Căn phải giống máy tính thật
            tbDisplay.ReadOnly = true; // Không cho gõ phím, chỉ bấm nút
            this.Controls.Add(tbDisplay);

            // 3. Tạo bàn phím số (0-9) và các nút chức năng
            // Sử dụng 2 mảng để vẽ vòng lặp cho nhanh
            string[] buttons = {
                "7", "8", "9", "/",
                "4", "5", "6", "*",
                "1", "2", "3", "-",
                "C", "0", "=", "+"
            };

            int x = 20, y = 80;
            int count = 0;

            foreach (string txt in buttons)
            {
                Button btn = new Button();
                btn.Text = txt;
                btn.Size = new Size(55, 55);
                btn.Location = new Point(x, y);
                btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                // Gắn sự kiện (Event) tùy theo loại nút
                if (char.IsDigit(txt[0]))
                {
                    // Nếu là số -> Gọi hàm Nhập số
                    btn.Click += Button_Number_Click;
                }
                else if (txt == "C")
                {
                    // Nút Xóa
                    btn.Click += Button_Clear_Click;
                    btn.BackColor = Color.OrangeRed;
                    btn.ForeColor = Color.White;
                }
                else if (txt == "=")
                {
                    // Nút Bằng
                    btn.Click += Button_Equals_Click;
                    btn.BackColor = Color.ForestGreen;
                    btn.ForeColor = Color.White;
                }
                else
                {
                    // Các phép toán (+, -, *, /)
                    btn.Click += Button_Op_Click;
                    btn.BackColor = Color.LightGray;
                }

                this.Controls.Add(btn);

                // Tính toán vị trí cho nút tiếp theo (xếp thành 4 cột)
                x += 65;
                count++;
                if (count % 4 == 0) // Hết 4 nút thì xuống dòng
                {
                    x = 20;
                    y += 65;
                }
            }
        }

        // --- 1. XỬ LÝ NHẬP SỐ (Giống Slide 78) ---
        private void Button_Number_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // Nối thêm số vào màn hình
            tbDisplay.Text += btn.Text;
        }

        // --- 2. XỬ LÝ PHÉP TOÁN (+, -, *, /) (Giống Slide 79 - phần btPlus) ---
        private void Button_Op_Click(object sender, EventArgs e)
        {
            if (tbDisplay.Text == "") return; // Nếu chưa có số thì không làm gì

            Button btn = (Button)sender;
            opr = btn.Text; // Lưu phép toán lại (Ví dụ: "+")

            // Lưu số hiện tại vào bộ nhớ
            workingMemory = decimal.Parse(tbDisplay.Text);

            // Xóa màn hình để chuẩn bị nhập số thứ hai
            tbDisplay.Clear();
        }

        // --- 3. XỬ LÝ TÍNH TOÁN (=) (Giống Slide 79 - phần btEquals) ---
        private void Button_Equals_Click(object sender, EventArgs e)
        {
            if (tbDisplay.Text == "") return;

            decimal secondValue = decimal.Parse(tbDisplay.Text); // Lấy số thứ hai
            decimal result = 0;

            // Thực hiện tính toán dựa trên phép toán đã lưu
            switch (opr)
            {
                case "+": result = workingMemory + secondValue; break;
                case "-": result = workingMemory - secondValue; break;
                case "*": result = workingMemory * secondValue; break;
                case "/":
                    if (secondValue != 0)
                        result = workingMemory / secondValue;
                    else
                        MessageBox.Show("Không thể chia cho 0");
                    break;
            }

            // Hiện kết quả
            tbDisplay.Text = result.ToString();

            // Reset các biến nhớ
            opr = "";
            workingMemory = 0;
        }

        // --- 4. XỬ LÝ NÚT C (Clear) ---
        private void Button_Clear_Click(object sender, EventArgs e)
        {
            tbDisplay.Clear();
            workingMemory = 0;
            opr = "";
        }
    }
}