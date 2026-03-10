using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Dtos.Auth
{
    public class AuthResponseDto //bu class 
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

    }
}
