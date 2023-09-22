using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ExperienceDto
    {
        public int Id { get; set; }
        public string ExperienceName { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
