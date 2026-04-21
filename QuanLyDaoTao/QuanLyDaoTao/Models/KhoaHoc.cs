using System.ComponentModel.DataAnnotations;

namespace QuanLyDaoTao.Models
{
    public class KhoaHoc
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Tên khóa học")]
        public string TenKhoaHoc { get; set; } = null!;

        [Display(Name = "Số tín chỉ")]
        public int SoTinChi { get; set; }

        public ICollection<LopHocPhan>? CacLopHocPhan { get; set; }
    }
}