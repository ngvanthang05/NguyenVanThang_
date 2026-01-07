using System;
using System.Drawing;
using System.Windows.Forms;

namespace NguyenVanThang
{
    public partial class Form30 : Form
    {
        // Khai báo 3 UserControl
        private Login ucLogin;
        private Question ucQuestion;
        private Finish ucFinish;

        public Form30()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Chương trình thi trắc nghiệm (UserControl)";
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Khởi tạo các UC
            ucLogin = new Login();
            ucQuestion = new Question();
            ucFinish = new Finish();

            // Đặt vị trí cho các UC (chồng lên nhau tại gốc 0,0)
            ucLogin.Location = new Point(0, 0);
            ucQuestion.Location = new Point(0, 0);
            ucFinish.Location = new Point(0, 0);

            // Gắn sự kiện chuyển trang cho các nút TRONG UserControl
            // Lưu ý: Các nút bên trong UC phải được set property Modifiers = Public thì ở đây mới thấy
            ucLogin.btTiepTuc.Click += (s, e) => SwitchScreen(ucLogin, ucQuestion);

            ucQuestion.btQuayLai.Click += (s, e) => SwitchScreen(ucQuestion, ucLogin);
            ucQuestion.btNopBai.Click += (s, e) => SwitchScreen(ucQuestion, ucFinish);

            ucFinish.btKetThuc.Click += (s, e) => this.Close();

            // Mặc định add màn hình Login vào trước
            this.Controls.Add(ucLogin);
        }

        // Hàm chuyển đổi màn hình (Remove cái cũ, Add cái mới)
        private void SwitchScreen(UserControl fromUC, UserControl toUC)
        {
            this.Controls.Remove(fromUC);
            this.Controls.Add(toUC);
        }
    }
}