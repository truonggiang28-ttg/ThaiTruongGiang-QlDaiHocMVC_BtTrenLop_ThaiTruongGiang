using System.ComponentModel.DataAnnotations;

namespace QuanLyDaoTao.Models
{
    public class SinhVien
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Họ tên sinh viên")]
        public string HoTen { get; set; } = null!;

        [Display(Name = "Mã số sinh viên")]
        public string? MaSinhVien { get; set; }

        public ICollection<DangKy>? CacLuotDangKy { get; set; }
    }
}