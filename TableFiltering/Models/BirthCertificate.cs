using System.ComponentModel.DataAnnotations;

namespace TableFiltering.Models
{
    public class BirthCertificate
    {
        public Guid BirthCertificateId { get; set; }
        [Required]
        [Display(Name = "Child Name")]
        public string? Name { get; set; }
        [Display(Name = "Health ID")]
        public int Health { get; set; }
        [Display(Name = "DOB")]
        public DateTime? DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        [Display(Name = "Father")]
        public string? FatherName { get; set; }
        [Display(Name = "Mother")]
        public string? MotherName { get; set; }
        public bool Status { get; set; }
        public bool Approved { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
