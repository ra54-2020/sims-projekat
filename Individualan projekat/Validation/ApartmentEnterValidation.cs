using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Individualan_projekat.Validation
{
    /*{
    public class ApartmentEnterValidation: ValidationRule
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string NameA = value as string;
            if (string.IsNullOrEmpty(NameA))
            {
                return new ValidationResult(false, "Field cannot be empty");
            }
            string pattern1 = @"^[a-zA-Z]+$";
            if (!Regex.IsMatch(NameA, pattern1))
            {
                return new ValidationResult(false, "Only letters available");
            }
            if (NameA.Equals("null", StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult(false, "Invalid input.");
            }

            int RoomNumber;
            if (string.IsNullOrEmpty(value as string))
            {
                return new ValidationResult(false, "Field cannot be empty");
            }
            if (!int.TryParse(value as string, out RoomNumber))
            {
                return new ValidationResult(false, "Invalid input. Please enter a valid number.");
            }
            if (RoomNumber < 1 || RoomNumber > 100)
            {
                return new ValidationResult(false, "Number of rooms must be between 1 and 100.");
            }
            if (RoomNumber == 0)
            {
                return new ValidationResult(false, "Invalid input");
            }

            int MaxGuestNumber;
            if (string.IsNullOrEmpty(value as string))
            {
                return new ValidationResult(false, "Field cannot be empty");
            }
            if (!int.TryParse(value as string, out MaxGuestNumber))
            {
                return new ValidationResult(false, "Invalid input. Please enter a valid number.");
            }
            if (MaxGuestNumber < 1 || MaxGuestNumber > 10)
            {
                return new ValidationResult(false, "Number of guests must be between 1 and 10.");
            }
            if (RoomNumber == 0)
            {
                return new ValidationResult(false, "Invalid input");
            }

            string Description = value as string;
            if (string.IsNullOrEmpty(Description))
            {
                return ValidationResult.ValidResult;
            }
            return ValidationResult.ValidResult;
        }
    }*/
}
