using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMTool
{
    internal class FMTag
    {
        public string Tag { get; set; }
        public string? Attribute { get; set; }
        public List<FMTag> Child {get; set; }
        public FMTag Parent { get; set; }

        public FMTag()
        {
            Child = new List<FMTag>();
        }
    }
}
