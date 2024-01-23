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
        public bool IsDoneAttribute { get; set; } = false;

        public FMTag()
        {
            Child = new List<FMTag>();
        }

        public FMTag? FindTag(string tagName, bool isChildren = false)
        {
            if(Tag.Equals(tagName))
            {
                return this;
            }
            foreach(FMTag tag in Child)
            {
                var rs = tag.FindTag(tagName);
                if(rs != null)
                    return rs;
            }
            return null;
        }
    }
}
