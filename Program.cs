using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChappellEberle_Assign1
{
    class Program 
    {
        // Item Types
        public enum ItemType
        {
            Helmet,
            Neck,
            Shoulders,
            Back,
            Chest,
            Wrist,
            Gloves,
            Belt,
            Pants,
            Boots,
            Ring,
            Trinket
        };

        // Races
        public enum Race
        {
            Orc,
            Troll,
            Tauren,
            Forsaken
        };

        // Global Constants
        private static uint MAX_ILVL            = 360;
        private static uint MAX_PRIMARY         = 200;
        private static uint MAX_STAMINA         = 275;
        private static uint MAX_LEVEL           = 60;
        private static uint GEAR_SLOTS          = 14;
        private static uint MAX_INVENTORY_SIZE  = 20;


        static void Main(string[] args)
        {
        }
    }

    class Item
    {
        readonly uint id;   // Read only
        string name;        // Free read/write access
        ItemType Type;      // Free read/write access; Range is [0, 12]
        uint ilvl;          // Free read/write access; Range is [0, MAX_ILVL] 
        uint primary;       // Free read/write access; Range is [0, MAX_PRIMARY] 
        uint stamina;       // Free read/write access; Range is [0, MAX_STAMINA] 
        uint requirement;   // Free read/write access; Range is [0, MAX_LEVEL] 
        string flavor;      // Free read/write access 
    }
}