using System.ComponentModel.DataAnnotations;

namespace QuanLyDaoTao.Models
{
    public class GiangVien
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Họ tên giảng viên")]
        public string HoTen { get; set; } = null!;

        [EmailAddress, Display(Name = "Email liên hệ")]
        public string? Email { get; set; }

        public ICollection<LopHocPhan>? CacLopDay { get; set; }
    }
}