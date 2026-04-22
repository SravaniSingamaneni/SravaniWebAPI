using FluentValidation;
using SravaniWebAPI.Models;
using System.Text.RegularExpressions;

namespace SravaniWebAPI.Validations
{
    public class CreateOrderRequestValidator : AbstractValidator<Orders>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("CustomerName is Required!");

            RuleFor(x => x.OrderCode)
                .NotEmpty().WithMessage("OrderCode is Required!");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is Required!")
                .Matches(@"^\d{10}$").WithMessage("PhoneNumber must be 10 digits!");

            RuleFor(x => x.EmailId)
                .NotEmpty().WithMessage("EmailId is Required!")
                .EmailAddress().WithMessage("Invalid email format!");

            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("PostalCode is Required!")
                .Must((request, postal) => IsValidPostalCode(request.Country, postal))
                .WithMessage("Invalid postalCode format for seleted country!");
        }
        private bool IsValidPostalCode(string country, string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode))
                return false;

            return country switch
            {
                "IN" => Regex.IsMatch(postalCode, @"^\d{6}$"),
                "US" => Regex.IsMatch(postalCode, @"^\d{5}(-\d{4})?$"),
                "CA" => Regex.IsMatch(postalCode, @"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$"),
                _ => postalCode.Length >= 3 && postalCode.Length <= 10
            };
        }
    }
}
