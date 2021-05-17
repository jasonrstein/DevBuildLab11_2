using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuild11_2.Models
{
    public class User
    { 
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string gender { get; set; }
        public string origin { get; set; }
    }
}
