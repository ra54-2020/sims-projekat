﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Individualan_projekat.Validation
{
    public class PhoneNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;

            if (string.IsNullOrWhiteSpace(input))
            {
                return ValidationResult.ValidResult;
            }
            string phonePattern = @"^\d{10}$";

            if (!Regex.IsMatch(input, phonePattern))
            {
                return new ValidationResult(false, "Invalid phone number format");
            }
            return ValidationResult.ValidResult;
        }
    }
}
