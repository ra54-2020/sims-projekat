﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Individualan_projekat.Validation
{
    public class RequiredFieldValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty((value ?? "").ToString()))
            {
                return new ValidationResult(false, "This must be filled!");
            }

            return ValidationResult.ValidResult;
        }
    }
}
