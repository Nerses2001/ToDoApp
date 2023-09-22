using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ToDoAppUsingRepositoryPattern.Core.Models.UserModel
{
    internal class UserTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required(ErrorMessage = "Task name is required.")]
        public string TaskName { get; private set; }
        [Required(ErrorMessage = "Task description is required.")]
        public string TaskDescription { get; private set; }

        [Required(ErrorMessage = "Task due date is required.")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; private set; }

        [Required(ErrorMessage = "Task status is required.")]
        public UserTaskStatus Status { get; private set; }
        
        [Required(ErrorMessage = "Task name is required.")]

        [ForeignKey("UserId")]
        public int UserId { get; private set; }
        public User? User { get; set; }

        public UserTask(string taskName, string taskDescription, DateTime dueDate,
            UserTaskStatus status, int userId)
        {
            this.TaskName = taskName;
            this.TaskDescription = taskDescription; 
            this.DueDate = dueDate;
            this.Status = status;
            this.UserId = userId;
            



            ValidateInput();
        }

        private void ValidateInput()
        {
            Validator.ValidateObject(this, new ValidationContext(this), true);
        }
    }
}
