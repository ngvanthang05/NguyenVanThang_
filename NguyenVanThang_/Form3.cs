using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;                // Thư viện quản lý file
using System.Xml.Serialization; // Thư viện XML

namespace NguyenVanThang
{
    public partial class Form3 : Form
    {
        // Đường dẫn file XML (Bạn có thể đổi ổ D thành C nếu máy không có ổ D)
        string path = @"D:\form.xml";

        public Form3()
        {
            InitializeComponent();

            // Đăng ký sự kiện
            this.Load += Form3_Load;
            this.ResizeEnd += Form3_ResizeEnd;
        }

        // --- HÀM GHI (WRITE) ---
        public void Write(InfoWindows iw)
        {
            try
            {
                XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
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

        // --- HÀM ĐỌC (READ) ---
        public InfoWindows Read()
        {
            try
            {
                if (!File.Exists(path)) return null;

                XmlSerializer reader = new XmlSerializer(typeof(InfoWindows));
                using (StreamReader file = new StreamReader(path))
                {
                    return (InfoWindows)reader.Deserialize(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file: " + ex.Message);
                return null;
            }
        }

        // Sự kiện: Kéo thả xong -> Lưu kích thước
        private void Form3_ResizeEnd(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;

            Write(iw);
            this.Text = "Đã lưu (Article 02): " + iw.Width + " - " + iw.Height;
        }

        // Sự kiện: Mở form lên -> Đọc kích thước cũ
        private void Form3_Load(object sender, EventArgs e)
        {
            InfoWindows iw = Read();
            if (iw != null)
            {
                this.Width = iw.Width;
                this.Height = iw.Height;
                this.Text = "Đã khôi phục (Article 02): " + iw.Width + " - " + iw.Height;
            }
        }
    }
}