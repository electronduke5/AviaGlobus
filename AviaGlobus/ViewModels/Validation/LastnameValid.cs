using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AviaGlobus.ViewModels.Validation
{
    public class LastnameValid : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                ErrorMessage = "Это обязательное поле!";
                return false;
            }

            string lastName = (string)value;

            if (!Regex.IsMatch(lastName, "^[А-Яа-яёЁ]+$"))
            {
                ErrorMessage = "Фамилия должна содержать только русские символы!";
                return false;
            }
            if(lastName.Length > 30)
            {
                ErrorMessage = "Фамилия слишком длинная";
                return false;
            } 

            return true;
        }
    }
}
