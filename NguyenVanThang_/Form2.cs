using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace NguyenVanThang
{
    public partial class Form2 : Form
    {
        // Đường dẫn file lưu cấu hình
        // Lưu ý: Nếu máy không có ổ D, hãy sửa thành @"C:\form.xml" hoặc "form.xml"
        string path = @"D:\form.xml";

        public Form2()
        {
            InitializeComponent();

            this.Load += Form2_Load;
            this.ResizeEnd += Form2_ResizeEnd;
        }

        // --- HÀM 1: GHI FILE (Lưu thông tin) ---
        public void Write(InfoWindows iw)
        {
            try
            {
                XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
                // Sử dụng 'using' để file tự đóng sau khi ghi xong, tránh lỗi
                using (StreamWriter file = new StreamWriter(path))
                {
                    writer.Serialize(file, iw);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message);
            }
        }

        // --- HÀM 2: ĐỌC FILE (Khôi phục thông tin) --- [MỚI THÊM]
        public void Read()
        {
            try
            {
                // Kiểm tra xem file có tồn tại không. Nếu chưa có (lần đầu chạy) thì thoát.
                if (!File.Exists(path)) return;

                XmlSerializer reader = new XmlSerializer(typeof(InfoWindows));
                using (StreamReader file = new StreamReader(path))
                {
                    // Đọc từ XML và ép kiểu về InfoWindows
                    InfoWindows iw = (InfoWindows)reader.Deserialize(file);

                    // Áp dụng kích thước đọc được vào Form hiện tại
                    this.Width = iw.Width;
                    this.Height = iw.Height;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file: " + ex.Message);
            }
        }

        // Sự kiện: Khi người dùng kéo thả thay đổi kích thước xong -> LƯU LẠI
        private void Form2_ResizeEnd(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;

            Write(iw); // Gọi hàm Ghi

            this.Text = "Đã lưu size: " + iw.Width + " - " + iw.Height;
        }

        // Sự kiện: Khi Form vừa mở lên -> ĐỌC FILE ĐỂ KHÔI PHỤC KÍCH THƯỚC CŨ
        private void Form2_Load(object sender, EventArgs e)
        {
            Read(); // Gọi hàm Đọc
        }
    }
}