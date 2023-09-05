// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");



List<MenuEntity> menu = new List<MenuEntity>() {
        new MenuEntity {Id=1,Name="t1",ParentId=null  },
        new MenuEntity {Id=2,Name="t1.1",ParentId=1  },
        new MenuEntity {Id=3,Name="t1.2",ParentId=1  },
        new MenuEntity {Id=4,Name="t1.1.1",ParentId=2  },
        new MenuEntity {Id=5,Name="t1.1.2",ParentId=2  },
        new MenuEntity {Id=6,Name="t1.1.3",ParentId=2  },
        new MenuEntity {Id=7,Name="t1",ParentId=null  },
        new MenuEntity {Id=8,Name="t1",ParentId=7  }
        };

var c = new Class1();
var parent = c.GetParent(menu);



List<DaynamicMenu> finall = parent
    .Select(s =>
    {
        return new DaynamicMenu()
        {
            Id = s.Id,
            Name = s.Name,
            ParentId = s.ParentId,
            Child = c.FindChild(s.Id, menu)
        };

    }).ToList();
List<DaynamicMenu> finall2 = c.GenerateDynamicMenu(menu);
string json= JsonSerializer.Serialize(finall2);


Console.WriteLine(json);

Console.ReadLine();