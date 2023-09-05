using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MenuEntity
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }

    }

    public class DaynamicMenu
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public List<DaynamicMenu> Child { get; set; }
    }
}
