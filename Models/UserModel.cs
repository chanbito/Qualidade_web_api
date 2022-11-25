using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qualidade_web_api.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}