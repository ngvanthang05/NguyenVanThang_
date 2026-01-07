using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form12 : Form
    {
        // Khai báo biến nhớ
        private decimal memory = 0;         // Biến nhớ (M)
        private decimal workingMemory = 0;  // Biến số hạng thứ nhất
        private string opr = "";            // Biến dấu phép toán (+, -, *, /)
        private bool isNewNumber = true;    // Cờ kiểm tra xem có phải đang nhập số mới không

        private TextBox txtDisplay;

        public Form12()
        {
            InitializeComponent();
            SetupUI(); // Vẽ giao diện giống Slide 81
        }

        // --- 1. THIẾT KẾ GIAO DIỆN (Giống My Calculator - Slide 81) ---
        private void SetupUI()
        {
            this.Text = "My Calculator";
            this.Size = new Size(340, 420);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Màn hình hiển thị
            txtDisplay = new TextBox();
            txtDisplay.Location = new Point(15, 15);
            txtDisplay.Size = new Size(295, 40);
            txtDisplay.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            txtDisplay.ReadOnly = true;
            txtDisplay.BackColor = Color.White;
            txtDisplay.Text = "0";
            this.Controls.Add(txtDisplay);

            // Bảng nút (ghi chú: ô rỗng "" sẽ bị bỏ qua)
            string[,] buttons = {
        { "MC", "MR", "MS", "M+", "M-" },
        { "←", "CE", "C", "±", "√" },
        { "7", "8", "9", "/", "%" },
        { "4", "5", "6", "*", "1/x" },
        { "1", "2", "3", "-", "=" }, // '=' chỉ xuất hiện 1 lần ở đây (chiếm 2 hàng theo chiều cao)
        { "0", "", ".", "+", "" }    // '0' chỉ xuất hiện 1 lần ở cột 0 (chiếm 2 cột theo chiều rộng)
    };

            int startX = 15;
            int startY = 70;
            int btnW = 55;
            int btnH = 45;
            int gap = 5;

            for (int r = 0; r < buttons.GetLength(0); r++)
            {
                for (int c = 0; c < buttons.GetLength(1); c++)
                {
                    string label = buttons[r, c];

                    // Bỏ qua ô trống
                    if (string.IsNullOrEmpty(label)) continue;

                    Button btn = new Button();
                    btn.Text = label;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                    // Vị trí chuẩn theo lưới
                    int x = startX + c * (btnW + gap);
                    int y = startY + r * (btnH + gap);

                    // Kích thước đặc biệt cho '0' (r cuối, c = 0) -> rộng 2 cột
                    if (label == "0")
                    {
                        btn.Size = new Size(btnW * 2 + gap, btnH);
                        btn.Location = new Point(x, y);
                    }
                    // Kích thước đặc biệt cho '=' (nằm ở r = 4, c = 4) -> cao 2 hàng
                    else if (label == "=")
                    {
                        btn.Size = new Size(btnW, btnH * 2 + gap);
                        btn.Location = new Point(x, y);
                    }
                    else
                    {
                        btn.Size = new Size(btnW, btnH);
                        btn.Location = new Point(x, y);
                    }

                    // Gắn sự kiện chung
                    btn.Click += Button_Click;

                    this.Controls.Add(btn);
                }
            }
        }

        // --- 2. XỬ LÝ LOGIC CHUNG (Dựa trên Slide 84 -> 90) ---
        private void Button_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            string text = bt.Text;

            // --- NHÓM 1: NHẬP SỐ (0-9 và dấu chấm) ---
            if ((char.IsDigit(text, 0) || text == ".") && text.Length == 1)
            {
                if (isNewNumber)
                {
                    txtDisplay.Text = ""; // Nếu đang bắt đầu số mới thì xóa màn hình cũ
                    isNewNumber = false;
                }

                if (text == ".")
                {
                    // Chỉ cho nhập 1 dấu chấm
                    if (!txtDisplay.Text.Contains(".")) txtDisplay.Text += text;
                }
                else
                {
                    // Chặn số 0 ở đầu (ví dụ 0001)
                    if (txtDisplay.Text == "0" && text != ".") txtDisplay.Text = text;
                    else txtDisplay.Text += text;
                }
                return;
            }

            // --- NHÓM 2: CÁC PHÉP TOÁN CƠ BẢN (+, -, *, /) ---
            if (text == "+" || text == "-" || text == "*" || text == "/")
            {
                opr = text;
                workingMemory = decimal.Parse(txtDisplay.Text);
                isNewNumber = true; // Đánh dấu để lần sau nhập sẽ xóa màn hình
                return;
            }

            // --- NHÓM 3: TÍNH TOÁN (=) ---
            if (text == "=")
            {
                decimal secondValue = decimal.Parse(txtDisplay.Text);
                decimal result = 0;

                switch (opr)
                {
                    case "+": result = workingMemory + secondValue; break;
                    case "-": result = workingMemory - secondValue; break;
                    case "*": result = workingMemory * secondValue; break;
                    case "/":
                        if (secondValue != 0) result = workingMemory / secondValue;
                        else MessageBox.Show("Lỗi chia cho 0");
                        break;
                }

                txtDisplay.Text = result.ToString();
                workingMemory = 0; // Reset
                opr = "";
                isNewNumber = true;
                return;
            }

            // --- NHÓM 4: CÁC TÍNH NĂNG ĐẶC BIỆT ---
            if (text == "±") // Đổi dấu
            {
                decimal val = decimal.Parse(txtDisplay.Text);
                txtDisplay.Text = (-val).ToString();
            }
            else if (text == "√") // Căn bậc 2
            {
                double val = double.Parse(txtDisplay.Text);
                txtDisplay.Text = Math.Sqrt(val).ToString();
            }
            else if (text == "%") // Phần trăm
            {
                decimal val = decimal.Parse(txtDisplay.Text);
                txtDisplay.Text = (val / 100).ToString();
            }
            else if (text == "1/x") // Nghịch đảo
            {
                decimal val = decimal.Parse(txtDisplay.Text);
                if (val != 0) txtDisplay.Text = (1 / val).ToString();
            }

            // --- NHÓM 5: XÓA ---
            else if (text == "C") // Xóa tất cả
            {
                txtDisplay.Text = "0";
                workingMemory = 0;
                opr = "";
                isNewNumber = true;
            }
            else if (text == "CE") // Xóa số hiện tại
            {
                txtDisplay.Text = "0";
                isNewNumber = true;
            }
            else if (text == "←") // Backspace
            {
                if (txtDisplay.Text.Length > 0)
                {
                    txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                    if (txtDisplay.Text == "") txtDisplay.Text = "0";
                }
            }

            // --- NHÓM 6: BỘ NHỚ (M) ---
            else if (text == "MC") memory = 0;
            else if (text == "MR")
            {
                txtDisplay.Text = memory.ToString();
                isNewNumber = true;
            }
            else if (text == "MS")
            {
                memory = decimal.Parse(txtDisplay.Text);
                isNewNumber = true;
            }
            else if (text == "M+")
            {
                memory += decimal.Parse(txtDisplay.Text);
                isNewNumber = true;
            }
            else if (text == "M-")
            {
                memory -= decimal.Parse(txtDisplay.Text);
                isNewNumber = true;
            }
        }
    }
}