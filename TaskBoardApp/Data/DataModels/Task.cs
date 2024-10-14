using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Data.DataConstants.DataConstants;

namespace TaskBoardApp.Data.DataModels
{
    [Comment("Task of the board")]
    public class Task
    {
        [Key]
        [Comment("Task identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TaskTitleMaxLength)]
        [Comment("Task title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(TaskDescrMaxLength)]
        [Comment("Task description")]
        public string Description { get; set; } = string.Empty;

        [Comment("When the task was created")]
        public DateTime CreatedOn { get; set; }

        [Comment("Board identifier")]
        public int BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        public Board? Board { get; set; }

        [Required]
        [Comment("Owner identifier")]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;
    }
}

//•	Id – a unique integer, Primary Key
//•	Title – a string with min length 5 and max length 70 (required)
//•	Description – a string with min length 10 and max length 1000 (required)
//•	CreatedOn – date and time
//•	BoardId – an integer
//•	Board – a Board object
//•	OwnerId – an integer (required)
//•	Owner – an IdentityUser object
