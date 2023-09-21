
using System.ComponentModel.DataAnnotations;

namespace ToDoAppUsingRepositoryPattern.Core.Models.UserModel.AddressModel
{
    public class UserAddress
    {

        [Required(ErrorMessage = "Street cannot be null or empty.")]
        public string Street { get; private set; }

        [Required(ErrorMessage = "City cannot be null or empty.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "City should only contain letters.")]
        public string City { get; private set; }

        [Required(ErrorMessage = "State cannot be null or empty.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "State should only contain letters.")]
        public string State { get; private set; }

        [Required(ErrorMessage = "PostalCode cannot be null or empty.")]
        [RegularExpression(@"^\+\d+$", ErrorMessage = "PostalCode should start with a plus sign (+) followed by numbers.")]
        public string PostalCode { get; private set; }

        [Required(ErrorMessage = "Country cannot be null or empty.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Country should only  symbols.")]
        public string Country { get; private set; }
      
        public UserAddress(string street, string city, string state, string postalCode, string country)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;

            ValidateInput();
        }
        private void ValidateInput()
        {
            Validator.ValidateObject(this, new ValidationContext(this), true);
        }

    }
}
