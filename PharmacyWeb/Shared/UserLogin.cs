using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWeb.Shared
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Поле 'имя пользователя' не можем быть пустым")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Поле 'пароль' не можем быть пустым")]
        public string Password { get; set; }
    }
}
