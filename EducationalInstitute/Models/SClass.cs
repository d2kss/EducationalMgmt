using System.ComponentModel.DataAnnotations;

namespace EducationalInstitute.Models
{
    public class SClass
    {
        [Key]
        public int ClassId { get; set; }

        [Required(ErrorMessage ="Class Name is required")]
        [StringLength(100,ErrorMessage ="Class Name length must between less than or equal to 100 chracters")]
        public string ClassName { get; set; }

        public char? IsActive { get; set; } = 'Y';
        [StringLength(100)]
        public string? CreatedBy { get; set; } = "Admin";
        [StringLength(100)]
        public string? UpdatedBy { get; set; } = "Admin";

        public DateTime? CreatedDate { get; set; }=DateTime.Now;

        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public ICollection<Fees>? Fees { get; set; } = null!;

        public ICollection<Student>? Students { get; set; } = null!;

        public ICollection<Subject>? Subjects { get; set; }

        public ICollection<Exam>? Exam { get; set; }

    }
}
