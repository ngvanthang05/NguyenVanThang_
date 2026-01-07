namespace NguyenVanThang
{
    public class Song
    {
        public int Id { get; set; }          // Mã bài hát
        public string Name { get; set; }     // Tên bài hát
        public string Author { get; set; }   // Tác giả

        // Hàm tạo không tham số (Mặc định)
        public Song() { }

        // Hàm tạo đầy đủ để nhập nhanh dữ liệu
        public Song(int id, string name, string author)
        {
            this.Id = id;
            this.Name = name;
            this.Author = author;
        }
    }
}