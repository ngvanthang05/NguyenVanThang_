namespace NguyenVanThang
{
    // Class mô tả thông tin một Khoa
    public class Faculty
    {
        public string Id { get; set; }       // Mã khoa (Ví dụ: K01)
        public string Name { get; set; }     // Tên khoa (Ví dụ: CNTT)
        public int Quantity { get; set; }    // Số lượng sinh viên

        // Hàm tạo (Constructor) để nhập nhanh dữ liệu
        public Faculty(string id, string name, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Quantity = quantity;
        }

        // Constructor mặc định
        public Faculty() { }
    }
}