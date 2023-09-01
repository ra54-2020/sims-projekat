using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Individualan_projekat.Validation
{ /*
    public class HotelCreateValidation: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string Code = value as string;
            if (string.IsNullOrEmpty(Code))
            {
                return new ValidationResult(false, "Field cannot be empty");
            }
            string pattern = @"^(?:[A-Z][a-zA-Z]*\s?)*$";

            if (!Regex.IsMatch(Code, pattern))
            {
                return new ValidationResult(false, "Error");
            }
            if (Code.Equals("null", StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult(false, "Invalid input.");
            }

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

            string ConstructionYear = value as string;
            if (string.IsNullOrEmpty(ConstructionYear))
            {
                return new ValidationResult(false, "Field cannot be empty");
            }
            string pattern2 = @"^\d{4}$";
            if (!Regex.IsMatch(ConstructionYear, pattern2))
            {
                return new ValidationResult(false, "Invalid year format. Please use YYYY format.");
            }
            if (ConstructionYear.Equals("null", StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult(false, "Invalid input");
            }

            string StarsNumber = value as string;
            if (string.IsNullOrEmpty(StarsNumber))
            {
                return new ValidationResult(false, "Field cannot be empty");
            }
            string pattern3 = @"^[1-5]$";
            if (!Regex.IsMatch(StarsNumber, pattern3))
            {
                return new ValidationResult(false, "Invalid star rating. Please enter a number between 1 and 5");
            }
            if (StarsNumber.Equals("null", StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult(false, "Invalid input.");
            }

            string OwnerJmbg = value as string;
            if (string.IsNullOrEmpty(OwnerJmbg))
            {
                return new ValidationResult(false, "Field cannot be empty");
            }
            string pattern4 = @"^\d{13}$";
            if (!Regex.IsMatch(OwnerJmbg, pattern4))
            {
                return new ValidationResult(false, "Invalid JMBG format. It must consist of 13 digits");
            }
            if (OwnerJmbg.Equals("null", StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult(false, "Invalid input.");
            }
            return ValidationResult.ValidResult;
        }
    }*/
}
