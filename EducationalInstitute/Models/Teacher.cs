using System.ComponentModel.DataAnnotations;

namespace EducationalInstitute.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "FirstName field value is not valid")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "LastName field value is not valid")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Father Name field value is not valid")]
        public string FatherName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mother Name field value is not valid")]
        public string MotherName { get; set; }
        [Required(ErrorMessage = "You must provide a date of birth")]
        public DateTime DOB {  get; set; }
        [Required(ErrorMessage = "You must provide a qualification")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "You must provide a subject expert")]
        public string SubjectExpert { get; set; }
        [Required(ErrorMessage = "You must provide a Salary")]
        public decimal Salary { get; set; }
        [Required(ErrorMessage = "You must provide a Designation")]
        public string Designation { get; set; }

        public char IsActive { get; set; }
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [StringLength(100)]
        public string? UpdatedBy { get; set;}

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set;}

        public ICollection<Student>? Students { get; set; } = null!;

    }
}
