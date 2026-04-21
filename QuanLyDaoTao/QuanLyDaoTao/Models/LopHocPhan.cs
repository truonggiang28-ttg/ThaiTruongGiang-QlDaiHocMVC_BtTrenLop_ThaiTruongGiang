using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDaoTao.Models
{
    public class LopHocPhan
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Mã lớp")]
        public string MaLop { get; set; } = null!; // VD: TH01

        [Display(Name = "Khóa học")]
        public int KhoaHocId { get; set; }
        [ForeignKey("KhoaHocId")]
        public KhoaHoc? KhoaHoc { get; set; }

        [Display(Name = "Giảng viên")]
        public int GiangVienId { get; set; }
        [ForeignKey("GiangVienId")]
        public GiangVien? GiangVien { get; set; }

        public ICollection<DangKy>? CacSinhVienDangKy { get; set; }
    }
}