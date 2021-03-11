using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestingGuid.Models
{
    public class Testing
    {
        [Key]
        public int EID { get; set; }
        public int MID { get; set; }

        public string Name { get; set; }


    }
}
