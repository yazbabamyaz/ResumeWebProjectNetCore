using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ErrrorViewModel
    {
        public List<string> Errors { get; set; } = new List<string>();//liste oluşturulmadan ekleme olmaz.
    }
}
