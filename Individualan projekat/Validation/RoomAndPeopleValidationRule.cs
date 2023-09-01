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
    public class RoomAndPeopleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;

            if (string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult(false, "Field cannot be empty");
            }

            string pattern = @"^\d+(\s|,|\|)?(\s|,|\|)?\d*$";

            if (!Regex.IsMatch(input, pattern))
            {
                return new ValidationResult(false, "Invalid input format");
            }
            return ValidationResult.ValidResult;
        }
    }
}
