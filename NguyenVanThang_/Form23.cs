using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form23 : Form
    {
        private DataGridView dgvEmployee;
        private TextBox tbId, tbName, tbAge;
        private CheckBox ckGender;
        private Button btAdd, btDelete, btExit;

        // KHAI BÁO BINDINGSOURCE
        BindingSource bs = new BindingSource();
        List<Employee> lst = new List<Employee>();

        public Form23()
        {
            InitializeComponent();
            SetupUI();
            this.Load += Form23_Load;
        }

        private void SetupUI()
        {
            this.Text = "Article 22 - BindingSource";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 1. Cấu hình DataGridView
            dgvEmployee = new DataGridView();
            dgvEmployee.Location = new Point(20, 20);
            dgvEmployee.Size = new Size(540, 250);
            dgvEmployee.AutoGenerateColumns = false; // Tắt tự động sinh cột để dùng cột mình tự tạo
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // 2. Tạo cột và GẮN DỮ LIỆU (Mapping)
            // Cột 1: ID
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.HeaderText = "Mã NV";
            colId.DataPropertyName = "Id"; // [QUAN TRỌNG] Tên phải trùng y hệt bên class Employee
            colId.Width = 100;
            dgvEmployee.Columns.Add(colId);

            // Cột 2: Name
            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.HeaderText = "Tên nhân viên";
            colName.DataPropertyName = "Name"; // Map vào thuộc tính Name
            colName.Width = 200;
            dgvEmployee.Columns.Add(colName);

            // Cột 3: Age
            DataGridViewTextBoxColumn colAge = new DataGridViewTextBoxColumn();
            colAge.HeaderText = "Tuổi";
            colAge.DataPropertyName = "Age";
            colAge.Width = 80;
            dgvEmployee.Columns.Add(colAge);

            // Cột 4: Gender (CheckBox)
            DataGridViewCheckBoxColumn colGen = new DataGridViewCheckBoxColumn();
            colGen.HeaderText = "Nam?";
            colGen.DataPropertyName = "Gender";
            colGen.Width = 80;
            dgvEmployee.Columns.Add(colGen);

            // Sự kiện click vào dòng để binding ngược lại TextBox
            dgvEmployee.RowEnter += DgvEmployee_RowEnter;

            // 3. Các ô nhập liệu (Giống bài trước)
            int y = 300;
            Label l1 = new Label() { Text = "Mã:", Location = new Point(30, y), AutoSize = true };
            tbId = new TextBox() { Location = new Point(80, y - 3), Width = 100 };

            Label l2 = new Label() { Text = "Tên:", Location = new Point(200, y), AutoSize = true };
            tbName = new TextBox() { Location = new Point(250, y - 3), Width = 200 };

            Label l3 = new Label() { Text = "Tuổi:", Location = new Point(30, y + 40), AutoSize = true };
            tbAge = new TextBox() { Location = new Point(80, y + 37), Width = 100 };

            ckGender = new CheckBox() { Text = "Giới tính Nam", Location = new Point(250, y + 40), AutoSize = true };

            // 4. Các nút bấm
            btAdd = new Button() { Text = "Thêm", Location = new Point(150, 400), Size = new Size(80, 30) };
            btDelete = new Button() { Text = "Xóa", Location = new Point(250, 400), Size = new Size(80, 30) };
            btExit = new Button() { Text = "Thoát", Location = new Point(350, 400), Size = new Size(80, 30) };

            btAdd.Click += BtAdd_Click;
            btDelete.Click += BtDelete_Click;
            btExit.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] { dgvEmployee, l1, tbId, l2, tbName, l3, tbAge, ckGender, btAdd, btDelete, btExit });
        }

        // --- HÀM TẠO DỮ LIỆU GIẢ ---
        public List<Employee> GetData()
        {
            List<Employee> listEm = new List<Employee>();
            listEm.Add(new Employee() { Id = "NV01", Name = "Lê Lợi", Age = 30, Gender = true });
            listEm.Add(new Employee() { Id = "NV02", Name = "Nguyễn Trãi", Age = 28, Gender = true });
            return listEm;
        }

        // --- SỰ KIỆN LOAD: CẤU HÌNH BINDING SOURCE ---
        private void Form23_Load(object sender, EventArgs e)
        {
            lst = GetData();

            // Bước 1: Đổ list vào BindingSource
            bs.DataSource = lst;

            // Bước 2: Đổ BindingSource vào Grid
            dgvEmployee.DataSource = bs;
        }

        // --- SỰ KIỆN THÊM (Dùng BindingSource) ---
        private void BtAdd_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Id = tbId.Text;
            em.Name = tbName.Text;
            int a = 0; int.TryParse(tbAge.Text, out a); em.Age = a;
            em.Gender = ckGender.Checked;

            // Thay vì add vào list hay grid, ta add vào BindingSource
            bs.Add(em);

            // Reset ô nhập
            bs.MoveLast(); // Tự động cuộn xuống dòng cuối
        }

        // --- SỰ KIỆN XÓA (Dùng BindingSource) ---
        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow != null)
            {
                // Xóa dòng đang chọn cực nhanh
                bs.RemoveCurrent();
            }
        }

        // --- SỰ KIỆN CHỌN DÒNG (Binding ngược) ---
        private void DgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy dòng hiện tại trực tiếp từ DataGridView
            if (dgvEmployee.Rows[e.RowIndex].Cells[0].Value != null)
            {
                tbId.Text = dgvEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbName.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbAge.Text = dgvEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();

                string sGen = dgvEmployee.Rows[e.RowIndex].Cells[3].Value.ToString();
                ckGender.Checked = (sGen.ToLower() == "true");
            }
        }
    }
}