using AviaGlobus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AviaGlobus.ViewModels
{
    public class AddUserViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        [MaxLength(30, ErrorMessage = "Фамилия слишком длинная!")]
        [RegularExpression(@"^[А-Яа-яёЁ]+$", ErrorMessage = "Фамилия должна содержать только русские символы!")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [MaxLength(30, ErrorMessage = "Имя слишком длинное!")]
        [RegularExpression(@"^[А-Яа-яёЁ]+$", ErrorMessage = "Имя должно содержать только русские символы!")]
        public string Firstname { get; set; }

        [MaxLength(30, ErrorMessage = "Отчество слишком длинное!")]
        [RegularExpression(@"^[А-Яа-яёЁ]+$", ErrorMessage = "Отчество должно содержать только русские символы!")]
        public string? Patronymic { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [MinLength(5, ErrorMessage = "Логин должен быть более 5 символов!")]
        [MaxLength(15, ErrorMessage = "Логин слишком длинный!")]
        [RegularExpression(@"^[a-zA-Z-_.0-9]+$", ErrorMessage = "Латинские буквы, цифры и '-._'")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Обязательное поле!")]
        [MinLength(6, ErrorMessage = "Пароль должен быть более 6 символов!")]
        [MaxLength(32, ErrorMessage = "Пароль слишком длинный!")]
        [RegularExpression(@"^[a-zA-Z0-9-_!@.#$%^&*]+$", ErrorMessage = "Русские буквы не допускаются")]
        public string Password { get; set; }

        
        public int Role_ID { get; set; }

        public IEnumerable<Role> Roles { get; set; }

        public User LoggedUser { get; set; }
    }
}
