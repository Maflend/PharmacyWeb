using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWeb.Shared
{
    public class UserRegister
    {
        [Required(ErrorMessage = "Поле 'имя пользователя' не должно быть пустым"), StringLength(40, MinimumLength = 5, ErrorMessage = "Длина имени пользователя должна быть от 5 до 40 символов")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Поле 'пароль' не должно быть пустым"), StringLength(30,MinimumLength = 8, ErrorMessage = "Длина пароля должна быть от 8 до 30 символов")]
        public string Password { get; set; }
    }
}
