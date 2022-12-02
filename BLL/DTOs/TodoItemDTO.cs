using System.ComponentModel.DataAnnotations;

namespace todoTask.BLL
{
    public class TodoItemDTO
    {
        public long Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string? Name { get; set; }
        [RegularExpression("/^\\d+$/")]
        public long? UserID { get; set; }
        public bool IsComplete { get; set; }
    }
}
