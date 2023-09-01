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
    public class StringValidationRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;

            if (string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult(false, "Field cannot be empty");
            }

            if (!Regex.IsMatch(input, "^[a-zA-Z]+$"))
            {
                return new ValidationResult(false, "Field requires only letters");
            }

            return ValidationResult.ValidResult;
        }
    }
}
