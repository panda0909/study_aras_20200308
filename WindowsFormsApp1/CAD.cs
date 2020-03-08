using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class CAD
    {
        public string item_number { set; get; }
        public string name { set; get; }
        public string native_file { set; get; }

        public List<CAD> Structure { set; get; } = new List<CAD>();

    }
}
