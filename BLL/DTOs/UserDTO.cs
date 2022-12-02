using System.ComponentModel.DataAnnotations;

namespace todoTask.BLL
{
    public class UserDTO
    {
        
        public long Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? Name { get; set; }
        [Required]
        [RegularExpression("^\\(?([0-9]{3})\\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
        public string? Phone { get; set; }
    }
}
