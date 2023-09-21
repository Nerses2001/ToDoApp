using System.ComponentModel.DataAnnotations;
using ToDoAppUsingRepositoryPattern.Core.Models.UserModel.AddressModel;
namespace ToDoAppUsingRepositoryPattern.Core.Models.UserModel
{
    public class User
    {
        public int Id { get; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; private set; }

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

        [Required(ErrorMessage = "Address is required.")]
        public UserAddress Address { get; private set; }


        public User(int userId, string firstName, string lastName, string email, string passwordHash,
                     string phoneNumber, DateTime dateOfBirth, UserAddress address)
        {

            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Address = address;
            ValidateInput();

        }

        private void ValidateInput()
        {
            Validator.ValidateObject(this, new ValidationContext(this), true);
        }

    }
}

