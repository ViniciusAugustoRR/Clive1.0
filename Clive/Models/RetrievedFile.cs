using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clive.Models
{
    public class RetrievedFile
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string extension { get; set; }
        public DateTime createdOn { get; set; }
        public string icon { get; set; }
        public bool isSelected { get; set; }
    }
}
