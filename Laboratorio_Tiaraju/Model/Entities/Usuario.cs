using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_Tiaraju.Model.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            
        }
        public Usuario(string userName, string password, Department? departments)
        {
            UserName = userName;
            Password = password;
            Departments = departments;
            IsActive = true;
        }

        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;       
        public Department? Departments { get; set; }
        public bool IsActive { get; set; }
    }
}
