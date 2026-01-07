using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace NguyenVanThang
{
    public partial class Form4 : Form
    {
        string path = @"D:\form_config.xml"; // Đổi tên file khác để không đè lên bài cũ

        public Form4()
        {
            InitializeComponent();

            // Đăng ký 2 sự kiện quan trọng
            this.Load += Form4_Load;           // Khi mở lên
            this.FormClosing += Form4_FormClosing; // Khi tắt đi
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
            catch (Exception ex) { MessageBox.Show("Lỗi ghi: " + ex.Message); }
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
            catch { return null; }
        }

        // 1. KHI MỞ FORM: Đọc file và khôi phục vị trí + kích thước
        private void Form4_Load(object sender, EventArgs e)
        {
            InfoWindows iw = Read();
            if (iw != null)
            {
                this.Width = iw.Width;
                this.Height = iw.Height;
                this.Location = iw.Location; // [MỚI] Khôi phục vị trí cũ
            }
        }

        // 2. KHI TẮT FORM: Lấy thông số hiện tại và Lưu lại
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            iw.Location = this.Location; // [MỚI] Lưu vị trí hiện tại

            Write(iw);
        }
    }
}