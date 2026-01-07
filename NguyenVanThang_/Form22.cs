using System;
using System.Collections.Generic; // Thư viện cho List<>
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form22 : Form
    {
        private DataGridView dgvEmployee;
        private TextBox tbId, tbName, tbAge;
        private CheckBox ckGender;
        private Button btAdd, btDelete, btExit;

        // DANH SÁCH DỮ LIỆU CHÍNH (Quản lý ngầm)
        List<Employee> lst = new List<Employee>();

        public Form22()
        {
            InitializeComponent();
            SetupUI();

            // Đăng ký sự kiện Load để nạp dữ liệu
            this.Load += Form22_Load;
        }

        // --- CẤU HÌNH GIAO DIỆN (Giống bài 21) ---
        private void SetupUI()
        {
            this.Text = "Article 21 - DataGridView List Binding";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // DataGridView
            dgvEmployee = new DataGridView();
            dgvEmployee.Location = new Point(20, 20);
            dgvEmployee.Size = new Size(540, 250);
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.ReadOnly = true;

            // Tạo cột thủ công
            dgvEmployee.Columns.Add("colId", "Mã NV");
            dgvEmployee.Columns.Add("colName", "Tên NV");
            dgvEmployee.Columns.Add("colAge", "Tuổi");
            DataGridViewCheckBoxColumn colGen = new DataGridViewCheckBoxColumn();
            colGen.HeaderText = "Nam?";
            dgvEmployee.Columns.Add(colGen);

            // Sự kiện click vào dòng
            dgvEmployee.RowEnter += DgvEmployee_RowEnter;

            // Input Controls
            int y = 300;
            Label l1 = new Label() { Text = "Mã:", Location = new Point(30, y), AutoSize = true };
            tbId = new TextBox() { Location = new Point(80, y - 3), Width = 100 };

            Label l2 = new Label() { Text = "Tên:", Location = new Point(200, y), AutoSize = true };
            tbName = new TextBox() { Location = new Point(250, y - 3), Width = 200 };

            Label l3 = new Label() { Text = "Tuổi:", Location = new Point(30, y + 40), AutoSize = true };
            tbAge = new TextBox() { Location = new Point(80, y + 37), Width = 100 };

            ckGender = new CheckBox() { Text = "Giới tính Nam", Location = new Point(250, y + 40), AutoSize = true };

            // Buttons
            btAdd = new Button() { Text = "Thêm", Location = new Point(150, 400), Size = new Size(80, 30) };
            btDelete = new Button() { Text = "Xóa", Location = new Point(250, 400), Size = new Size(80, 30) };
            btExit = new Button() { Text = "Thoát", Location = new Point(350, 400), Size = new Size(80, 30) };

            btAdd.Click += BtAdd_Click;
            btDelete.Click += BtDelete_Click;
            btExit.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] { dgvEmployee, l1, tbId, l2, tbName, l3, tbAge, ckGender, btAdd, btDelete, btExit });
        }

        // --- HÀM TẠO DỮ LIỆU GIẢ (Giống Slide 141) ---
        public List<Employee> GetData()
        {
            List<Employee> listEm = new List<Employee>();
            listEm.Add(new Employee() { Id = "53418", Name = "Trần Tiến", Age = 20, Gender = true });
            listEm.Add(new Employee() { Id = "53416", Name = "Nguyễn Cường", Age = 25, Gender = false });
            listEm.Add(new Employee() { Id = "53417", Name = "Nguyễn Hào", Age = 23, Gender = true });
            return listEm;
        }

        // --- SỰ KIỆN LOAD FORM: Đổ dữ liệu từ List vào Grid ---
        private void Form22_Load(object sender, EventArgs e)
        {
            lst = GetData(); // 1. Lấy dữ liệu nguồn

            // 2. Duyệt List và thêm vào Grid
            foreach (Employee em in lst)
            {
                dgvEmployee.Rows.Add(em.Id, em.Name, em.Age, em.Gender);
            }
        }

        // --- SỰ KIỆN THÊM ---
        private void BtAdd_Click(object sender, EventArgs e)
        {
            // 1. Tạo đối tượng mới
            Employee em = new Employee();
            em.Id = tbId.Text;
            em.Name = tbName.Text;
            int a = 0; int.TryParse(tbAge.Text, out a); em.Age = a;
            em.Gender = ckGender.Checked;

            // 2. Thêm vào List (Quản lý ngầm)
            lst.Add(em);

            // 3. Thêm vào Grid (Hiển thị)
            dgvEmployee.Rows.Add(em.Id, em.Name, em.Age, em.Gender);
        }

        // --- SỰ KIỆN XÓA ---
        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow == null) return;

            int idx = dgvEmployee.CurrentCell.RowIndex;

            // 1. Xóa trong List trước
            lst.RemoveAt(idx);

            // 2. Xóa trên Grid sau
            dgvEmployee.Rows.RemoveAt(idx);
        }

        // --- SỰ KIỆN CHỌN DÒNG ---
        private void DgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0 && idx < dgvEmployee.Rows.Count)
            {
                // Lấy dữ liệu trực tiếp từ Grid hiển thị lên TextBox
                tbId.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();
                tbName.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();
                tbAge.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();

                string sGen = dgvEmployee.Rows[idx].Cells[3].Value.ToString();
                ckGender.Checked = bool.Parse(sGen);
            }
        }
    }
}