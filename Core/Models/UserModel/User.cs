using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ToDoAppUsingRepositoryPattern.Core.Models.UserModel
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First name should only contain letters.")]
        public string FirstName { get; private set; }

        [Required(ErrorMessage = "Last name is required.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last name should only contain letters.")]
        public string LastName { get; private set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; private set; }

        [Required(ErrorMessage = "Password hash is required.")]
        public string PasswordHash { get; private set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone number should only contain digits.")]
        public string PhoneNumber { get; private set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; private set; }

        [Required(ErrorMessage = "Street cannot be null or empty.")]
        public string Street { get; private set; }

        [Required(ErrorMessage = "City cannot be null or empty.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "City should only contain letters.")]
        public string City { get; private set; }

        [Required(ErrorMessage = "State cannot be null or empty.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "State should only contain letters.")]
        public string State { get; private set; }

        [Required(ErrorMessage = "PostalCode cannot be null or empty.")]
        [RegularExpression(@"^\+\d+$", ErrorMessage = "PostalCode should start with a plus sign (+) followed by numbers.")]
        public string PostalCode { get; private set; }

        [Required(ErrorMessage = "Country cannot be null or empty.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Country should only  symbols.")]
        public string Country { get; private set; }

        internal ICollection<UserTask> UserTasks { get; private set; }

        public User(string firstName, string lastName, string email, string passwordHash,
                     string phoneNumber, DateTime dateOfBirth, string street, string city, string state, string postalCode, string country)
        {

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PasswordHash = passwordHash;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
            this.Street = street;
            this.City = city;
            this.State = state;
            this.PostalCode = postalCode;
            this.Country = country;
            this.UserTasks = new List<UserTask>();
            ValidateInput();

        }

        private void ValidateInput()
        {
            Validator.ValidateObject(this, new ValidationContext(this), true);
        }

    }
}

