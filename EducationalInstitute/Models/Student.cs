using System.ComponentModel.DataAnnotations;

namespace EducationalInstitute.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3,ErrorMessage ="FirstName field value is not valid")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Last Name field value is not valid")]
        public string LastName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Father Name field value is not valid")]
        public string FatherName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mother Name field value is not valid")]
        public string MotherName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "You must provide a date of birth")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage ="Class Name is Requried")]
        public int ClassID { get; set; }
        [Required(ErrorMessage = "Section Name is Requried")]
        public int SectionId { get; set; }
        [Required]
        public double TotalFees { get; set; }

        public int? TeacherId { get; set; }
        [Required]
        public string Address {  get; set; }

        public char? IsActive { get; set; }
        [StringLength(100)]
        public string? CreatedBy { get; set; }
        [StringLength(100)]
        public string? UpdatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public SClass? SClass { get; set; } = null!;
        public Section? Section { get; set; } = null!;

        public Teacher? Teacher { get; set; }
    }
}
