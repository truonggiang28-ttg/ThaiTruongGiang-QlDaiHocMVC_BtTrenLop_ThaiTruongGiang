using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDaoTao.Models
{
    public class DangKy
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Sinh viên")]
        public int SinhVienId { get; set; }
        [ForeignKey("SinhVienId")]
        public SinhVien? SinhVien { get; set; }

        [Display(Name = "Lớp học phần")]
        public int LopHocPhanId { get; set; }
        [ForeignKey("LopHocPhanId")]
        public LopHocPhan? LopHocPhan { get; set; }

        [Display(Name = "Ngày đăng ký")]
        public DateTime NgayDangKy { get; set; } = DateTime.Now;
    }
}