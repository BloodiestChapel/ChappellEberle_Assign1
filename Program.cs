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


        // Item Class
        class Item
        {
            public readonly uint id;       // Read only
            public string name;            // Free read/write access
            public ItemType Type;          // Free read/write access; Range is [0, 12]
            public uint ilvl;              // Free read/write access; Range is [0, MAX_ILVL] 
            public uint primary;           // Free read/write access; Range is [0, MAX_PRIMARY] 
            public uint stamina;           // Free read/write access; Range is [0, MAX_STAMINA] 
            public uint requirement;       // Free read/write access; Range is [0, MAX_LEVEL] 
            public string flavor;          // Free read/write access 
        }

        // Player Class
        class Player
        {

            readonly uint id;               // Read only
            readonly string name;           // Read only
            readonly Racial race;           // Read only
            uint level;                     // Free read/write access; Range is [0, MAX_LEVEL]

            uint exp;                      /* Read access & write access but the write access
                                            * should instead increment the value of exp by...
                                            * value. If this should make the exp value exceed
                                            * the required experience for this player to
                                            * increase their level (but not exceed MAX_LEVEL),
                                            * it should do as such. */

            uint guildID;                   // Free read/write access

            uint[] gear;                   /* Instead of a Property, you should create an 
                                            * Indexer to allow access to gear. 
                                            * NOTE: You don't have to define this as an array. 
                                            * You may use whatever Collection you feel is most
                                            * appropriate/convenient. */

            List<uint> inventory;           // Will not have a corresponding Property.
        }

        // Menu Class
        class Menu
        {
            // Ten options for Player
            // ----------------------
            // 1. Print All Players

            // 2. Print All Guilds

            // 3. Print All Gear

            // 4. Print Gear List for Player

            // 5. Leave Guild

            // 6. Join Guild

            // 7. Equip Gear

            // 8. Unequip Gear

            // 9. Award Experience

            // 10. Quit (Triggered by entering "10", "q", "Q",
            //           "quit", "Quit", "exit", or "Exit")

            // 11. IComparable Testing Method (Not shown in menu,
            //                             but accessed with "T")
        }

        // Equip Gear Method
        public void EquipGear(uint newGearID)
        {

        }

        // Unequip Gear Method
        public void UnequipGear(int gearSlot)
        {

        }

        static void Main(string[] args)
        {
        }
    }
}