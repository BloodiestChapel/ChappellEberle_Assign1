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
        // Needs to implenent the "IComparable" interface
        // This means we need "public int CompareTo(object alpha)"
        // to be defined. Sort by Name.
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
                                           
            // Default Constructor
            // Set All values to 0 or "".
            public void ItemConstruct()
            {
                name = "";
                Type = 0;
                ilvl = 0;
                primary = 0;
                stamina = 0;
                requirement = 0;
                flavor = "";
            }

            // Alt Constructor
            // For when you want to provide initial values
            // for all attributes
            public void ItemConstructAlt(string initName, ItemType initType, uint initIlvl, uint initPrimary, uint initStamina, uint initRequirement, string initFlavor)
            {
                name = initName;
                Type = initType;
                ilvl = initIlvl;
                primary = initPrimary;
                stamina = initStamina;
                requirement = initRequirement;
                flavor = initFlavor;
            }

        }

        // Player Class
        class Player
        {

            readonly uint id;               // Read only
            readonly string name;           // Read only
            readonly Race race;             // Read only
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

            /* Need Default and Alt Constructors
             * Default assigns 0, "", or null to all 
             * attributes.
             * Alt takes as many arguments as necessary
             * to give initial values to all attributes,
             * including an array of unsigned integers 
             * to assign to the gear attribute. */
            public void playerDefault()
            {
                level = 0;
                exp = 0;
                guildID = 0;
                gear[MAX_INVENTORY_SIZE] = 0;
                
            }

            public void playerAlt()
            {

            }
        }

        // Menu Class
        class Menu
        {
            // Menu Options
            // ------------
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

        // Overridden ToString method

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
            // Number 10 (All the different way to quit program)
            var exitStatements = new string[] { "10", "q", "Q", "quit", "Quit", "exit", "Exit" };

            string UInput = "";     //Users input variable

            // Decide what to do with input
            do
            {
                // Print out the menu
                System.Console.WriteLine("Welcome to the World of ConflictCraft: Testing Enviroment \n");
                System.Console.WriteLine("Please select an option from the list below: ");
                System.Console.WriteLine("\t 1) Print All Players ");
                System.Console.WriteLine("\t 2) Print All Guilds ");
                System.Console.WriteLine("\t 3) List all Gear ");
                System.Console.WriteLine("\t 4) Print Gear List for Player ");
                System.Console.WriteLine("\t 5) Leave Guild ");
                System.Console.WriteLine("\t 6) Join Guild ");
                System.Console.WriteLine("\t 7) Equip Gear ");
                System.Console.WriteLine("\t 8) Unequip Gear ");
                System.Console.WriteLine("\t 9) Award Experience ");
                System.Console.WriteLine("\t 10) Quit ");

                // Collects input from user
                UInput = Console.ReadLine();

                switch (UInput)
                {
                    case "1":
                        // 1. Print All Players
                        System.Console.WriteLine("1");  
                        break;

                    case "2":
                        // 2. Print All Guilds
                        System.Console.WriteLine("2");  
                        break;

                    case "3":
                        // 3. List all Gear
                        System.Console.WriteLine("3");  
                        break;

                    case "4":
                        // 4. Print Gear List for Player
                        System.Console.WriteLine("4");  
                        break;

                    case "5":
                        // 5. Leave Guild
                        System.Console.WriteLine("5");
                        break;

                    case "6":
                        // 6. Join Guild
                        System.Console.WriteLine("6");
                        break;

                    case "7":
                        // 7. Equip Gear
                        System.Console.WriteLine("7");
                        break;

                    case "8":
                        // 8. Unequip Gear
                        System.Console.WriteLine("8");  
                        break;

                    case "9":
                        // 9. Award Experience
                        System.Console.WriteLine("9");
                        break;

                    case "T":
                        // 9*. Don't show in menu but Icomparble
                        System.Console.WriteLine("T");
                        break;

                    case "10":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program");
                        break;

                    case "q":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program");
                        break;

                    case "Q":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program");
                        break;

                    case "quit":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program");
                        break;

                    case "Quit":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program");
                        break;

                    case "exit":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program");
                        break;

                    case "Exit":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program");
                        break;

                    default:
                        // Invalid Input
                        System.Console.WriteLine("Not a valid input. Try again");
                        break;
                }

            } while (!exitStatements.Contains(UInput));
        }
    }
}