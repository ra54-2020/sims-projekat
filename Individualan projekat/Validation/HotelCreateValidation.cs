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

            return ValidationResult.ValidResult;
        }
    }
}
