using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class WorkDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public string ProjectName { get; set; }
        public bool ProjectStatus { get; set; }
        public bool ProjectAward { get; set; }
    }
}
