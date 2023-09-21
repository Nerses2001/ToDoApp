using System.ComponentModel.DataAnnotations;
using System;
using ToDoAppUsingRepositoryPattern.Infrastructure.Models.UserModel.Address;
namespace ToDoAppUsingRepositoryPattern.Infrastructure.Models.UserModel
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
        public AddressModel Address { get; private set; }


        public User(int userId, string firstName, string lastName, string email, string passwordHash,
                     string phoneNumber, DateTime dateOfBirth, AddressModel address)
        {

            this.UserId = userId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PasswordHash = passwordHash;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;
            this.Address = address;
            ValidateInput();

        }

        private void ValidateInput()
        {
            Validator.ValidateObject(this, new ValidationContext(this), true);
        }

    }
}

