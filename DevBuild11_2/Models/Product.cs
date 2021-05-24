using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace DevBuild11_2.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string category { get; set; }

        public override string ToString()
        {
            return $"{id} {name} {price} {category}";
        }
    }
}
