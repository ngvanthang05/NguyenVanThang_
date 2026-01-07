using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form21 : Form
    {
        private DataGridView dgvEmployee;
        private TextBox tbId, tbName, tbAge;
        private CheckBox ckGender;
        private Button btAdd, btDelete, btExit;

        public Form21()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // 1. Cài đặt Form
            this.Text = "Quản lý nhân viên (DataGridView)";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10);

            // 2. Tạo DataGridView
            dgvEmployee = new DataGridView();
            dgvEmployee.Location = new Point(20, 20);
            dgvEmployee.Size = new Size(540, 250);
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chọn cả dòng
            dgvEmployee.AllowUserToAddRows = false; // Tắt dòng trống cuối cùng để dễ quản lý code
            dgvEmployee.ReadOnly = true; // Chỉ cho xem, muốn sửa phải dùng code

            // Thêm các cột vào lưới
            dgvEmployee.Columns.Add("colId", "Mã nhân viên");
            dgvEmployee.Columns.Add("colName", "Tên nhân viên");
            dgvEmployee.Columns.Add("colAge", "Tuổi");

            // Cột giới tính là CheckBox
            DataGridViewCheckBoxColumn colGender = new DataGridViewCheckBoxColumn();
            colGender.HeaderText = "Giới tính (Nam)";
            colGender.Name = "colGender";
            dgvEmployee.Columns.Add(colGender);

            // Chỉnh độ rộng cột cho đẹp
            dgvEmployee.Columns[0].Width = 120;
            dgvEmployee.Columns[1].Width = 200;
            dgvEmployee.Columns[2].Width = 80;
            dgvEmployee.Columns[3].Width = 100; // Cột CheckBox

            // Đăng ký sự kiện RowEnter (Khi chọn dòng)
            dgvEmployee.RowEnter += DgvEmployee_RowEnter;

            // 3. Các ô nhập liệu bên dưới
            int yInput = 300;
            Label lblId = new Label() { Text = "Mã:", Location = new Point(30, yInput), AutoSize = true };
            tbId = new TextBox() { Location = new Point(100, yInput - 3), Width = 150 };

            Label lblName = new Label() { Text = "Tên:", Location = new Point(30, yInput + 40), AutoSize = true };
            tbName = new TextBox() { Location = new Point(100, yInput + 37), Width = 250 };

            Label lblAge = new Label() { Text = "Tuổi:", Location = new Point(30, yInput + 80), AutoSize = true };
            tbAge = new TextBox() { Location = new Point(100, yInput + 77), Width = 100 };

            ckGender = new CheckBox() { Text = "Nam", Location = new Point(100, yInput + 110), AutoSize = true };

            // 4. Các nút bấm
            int yBtn = 400;
            btAdd = new Button() { Text = "Thêm", Location = new Point(250, yBtn), Size = new Size(80, 35) };
            btDelete = new Button() { Text = "Xóa", Location = new Point(350, yBtn), Size = new Size(80, 35) };
            btExit = new Button() { Text = "Thoát", Location = new Point(450, yBtn), Size = new Size(80, 35) };

            btAdd.Click += BtAdd_Click;
            btDelete.Click += BtDelete_Click;
            btExit.Click += (s, e) => { this.Close(); };

            // Thêm vào Form
            this.Controls.Add(dgvEmployee);
            this.Controls.Add(lblId); this.Controls.Add(tbId);
            this.Controls.Add(lblName); this.Controls.Add(tbName);
            this.Controls.Add(lblAge); this.Controls.Add(tbAge);
            this.Controls.Add(ckGender);
            this.Controls.Add(btAdd); this.Controls.Add(btDelete); this.Controls.Add(btExit);

            // Thêm vài dữ liệu mẫu để test
            dgvEmployee.Rows.Add("53418", "Trần Tiến", "20", true);
            dgvEmployee.Rows.Add("53416", "Nguyễn Cường", "25", false);
        }

        // --- CHỨC NĂNG 1: THÊM DÒNG MỚI ---
        private void BtAdd_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox đưa vào Grid
            dgvEmployee.Rows.Add(tbId.Text, tbName.Text, tbAge.Text, ckGender.Checked);

            // Xóa trắng ô nhập sau khi thêm
            tbId.Clear(); tbName.Clear(); tbAge.Clear(); ckGender.Checked = false;
        }

        // --- CHỨC NĂNG 2: XÓA DÒNG ĐANG CHỌN ---
        private void BtDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào đang chọn không
            if (dgvEmployee.CurrentRow != null)
            {
                int idx = dgvEmployee.CurrentCell.RowIndex;
                dgvEmployee.Rows.RemoveAt(idx);
            }
        }

        // --- CHỨC NĂNG 3: CLICK VÀO LƯỚI -> HIỆN XUỐNG TEXTBOX ---
        private void DgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;

            // Kiểm tra an toàn: Nếu idx hợp lệ và dòng đó không phải dòng trống
            if (idx >= 0 && idx < dgvEmployee.Rows.Count)
            {
                // Lấy giá trị từng cột (Cells 0, 1, 2, 3)
                // Lưu ý: Cần kiểm tra null để tránh lỗi nếu ô đó trống
                if (dgvEmployee.Rows[idx].Cells[0].Value != null)
                    tbId.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();

                if (dgvEmployee.Rows[idx].Cells[1].Value != null)
                    tbName.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();

                if (dgvEmployee.Rows[idx].Cells[2].Value != null)
                    tbAge.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();

                // Cột CheckBox (Cells[3])
                if (dgvEmployee.Rows[idx].Cells[3].Value != null)
                {
                    // Chuyển đổi giá trị về true/false
                    string val = dgvEmployee.Rows[idx].Cells[3].Value.ToString();
                    ckGender.Checked = (val.ToLower() == "true");
                }
            }
        }
    }
}