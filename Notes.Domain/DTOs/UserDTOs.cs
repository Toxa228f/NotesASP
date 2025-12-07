using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Domain.DTOs
{
    public class UserDTOs
    {
        public class UserRegisterDto
        {
            [Required]
            [StringLength(32, ErrorMessage = "Максимальная длина 32 символа")]
            [MinLength(3,ErrorMessage = "Логин должен содержать не менее 3 символов")]
            public string Login { get; set; }

            [Required]
            [StringLength(32, ErrorMessage = "Максимальная длина 32 символа")]
            [MinLength(4, ErrorMessage = "Пароль должен содержать не менее 4 символов")]
            public string Password { get; set; }
        }

        public class UserLoginDto
        {
            [Required]
            public string Login { get; set; }

            [Required]
            public string Password { get; set; }
        }

        public class UserUpdateDto
        {
            [Required]
            public string Login { get; set; }
        }

        public class UserResponseDto
        {
            public Guid Id { get; set; }
            public string Login { get; set; }
        }
    }
}
