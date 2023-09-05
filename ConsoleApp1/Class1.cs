using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Class1
    {
        public List<MenuEntity> GetParent(List<MenuEntity> lst)
        {
            return lst.Where(s => s.ParentId == null).ToList();

        }

        public List<DaynamicMenu> FindChild(int id, List<MenuEntity> lst)
        {

            return lst.Where(s => s.ParentId == id)
                .Select(s =>
                {
                    return new DaynamicMenu()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        ParentId = s.ParentId,
                        Child = FindChild(s.Id, lst)
                    };
                }).ToList();
        }
        public List<DaynamicMenu> GenerateDynamicMenu(List<MenuEntity> lst, bool justChild = false, int? id = null)
        {
            if (!justChild)
            {
                return lst.Where(w => w.ParentId == null).Select(s =>
                {
                    return new DaynamicMenu()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        ParentId = s.ParentId,
                        Child = GenerateDynamicMenu(lst, true, s.Id)
                    };
                }).ToList();
            }
            else
            {
                return lst.Where(s => s.ParentId == id)
                                .Select(s =>
                                {
                                    return new DaynamicMenu()
                                    {
                                        Id = s.Id,
                                        Name = s.Name,
                                        ParentId = s.ParentId,
                                        Child = GenerateDynamicMenu(lst, true, s.Id)
                                    };
                                }).ToList();
            }

        }
    }
}
