using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //We CANNOT create an Enum through Visual Studio's interface directly.
    //Instead, we need to create a class, then change the class keyword
    //to "enum". 

    public enum Race
    {
        //Single values, NO spaces, comma separated
        Orc,
        Human,
        Elf,
        Dwarf,
        Gnome,
        Halfling,
        Tiefling,
        DragonBorn
    }
}
