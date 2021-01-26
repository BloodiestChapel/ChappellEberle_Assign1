/********************************************
 * CSCI 473 - Assignment 1 - Spring 2021    *
 *                                          *
 * Progammer: Dillon Chappell (z1761203)    *
 * Progammer: Rhianna Eberle (z1848017)     *
 * Section:   1                             *
 * Professor: Daniel Rogness                *
 * Date Due:  January 29, 2021              *
 *                                          *
 * Purpose:   Program.cs                    *
 ********************************************/

using System;
using System.IO;
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
        class Item : IComparable<Item>
        {
            public readonly uint id;       // Read only
            public string name;            // Free read/write access
            public ItemType Type;          // Free read/write access; Range is [0, 12]
            public uint ilvl;              // Free read/write access; Range is [0, MAX_ILVL] 
            public uint primary;           // Free read/write access; Range is [0, MAX_PRIMARY] 
            public uint stamina;           // Free read/write access; Range is [0, MAX_STAMINA] 
            public uint requirement;       // Free read/write access; Range is [0, MAX_LEVEL] 
            public string flavor;          // Free read/write access
                                           
            // Default Item Constructor
            public Item()
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
            public Item(string initName, ItemType initType, uint initIlvl, uint initPrimary, uint initStamina, uint initRequirement, string initFlavor)
            {
                name = initName;
                Type = initType;
                ilvl = initIlvl;
                primary = initPrimary;
                stamina = initStamina;
                requirement = initRequirement;
                flavor = initFlavor;
            }

            // Implementing IComparable interface with a CompareTo function
            public int CompareTo(Item alpha)
            {
                if(this.name == alpha.name)
                {
                    return this.name.CompareTo(this.name);
                }

                return alpha.name.CompareTo(this.name);
            }

            // Override ToString function in Item
            public override string ToString()
            {
                return this.name.ToString();
            }
        }

        // Player Class
        class Player : IComparable<Player>
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

            // Default Player Constructor
            public Player()
            {
                level = 0;
                exp = 0;
                guildID = 0;
                gear = new uint[0];
                inventory = new List<uint> {0};
            }

            // Alternate Player Constructor
            public Player(uint initLevel, uint initExp, uint initGuildID, uint[] initGear, List<uint> initInventory)
            {
                level = initLevel;
                exp = initExp;
                guildID = initGuildID;
                gear = initGear;
                inventory = initInventory;
            }

            // Equip Gear Method
            public void EquipGear(uint newGearID)
            {

            }

            // Unequip Gear Method
            public void UnequipGear(int gearSlot)
            {

            }

            // Implementing IComparable interface with a CompareTo function in Player
            public int CompareTo(Player alpha)
            {
                if (this.name == alpha.name)
                {
                    return this.name.CompareTo(this.name);
                }

                return alpha.name.CompareTo(this.name);
            }

            // Override ToString function in Player
            public override string ToString()
            {
                return this.name.ToString() 
                    + ", " + this.race.ToString() 
                    + ", " + this.guildID.ToString();
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

        // The main function's only real job is simply
        // reading the input files, then getting the ball
        // rolling on the menu-loop. My main method was
        // 63 lines of code long.
        static void Main(string[] args)
        {
            // Read File Input
            // string playerFile = System.IO.File.ReadAllText(@"C:\Users\Dillon\source\repos\ChappellEberle_Assign1\players.txt");

            // For lines in playerFile
            string line;

            StreamReader playerFile = new StreamReader(@"C:\Users\Dillon\source\repos\ChappellEberle_Assign1\players.txt");

            // For each line
            while ((line = playerFile.ReadLine()) != null)
            {
                if(lineCounter == 1)
                {
                    // Seperate each line by tabs
                    string[] playerElement = line.Split('\t');

                    Player player1 = new Player(
                        Convert.ToUInt32(playerElement[0]),                 // Player ID element
                        playerElement[1],                                   // Player Name element
                        (Race)Enum.Parse(typeof(Race), playerElement[3]),   // Player Race element
                        Convert.ToUInt32(playerElement[4]),                 // Player Level element
                        Convert.ToUInt32(playerElement[5]),                 // Player XP element
                        Convert.ToUInt32(playerElement[6]),                 // Player GuildID element
                        new uint[] {Convert.ToUInt32(playerElement[7]),     // Player Gear elements
                                    Convert.ToUInt32(playerElement[8]),
                                    Convert.ToUInt32(playerElement[9]),
                                    Convert.ToUInt32(playerElement[11]),
                                    Convert.ToUInt32(playerElement[12]),
                                    Convert.ToUInt32(playerElement[13]),
                                    Convert.ToUInt32(playerElement[14]),
                                    Convert.ToUInt32(playerElement[15]),
                                    Convert.ToUInt32(playerElement[16]),
                                    Convert.ToUInt32(playerElement[17]),
                                    Convert.ToUInt32(playerElement[18])}
                        );
                }

                if (lineCounter == 2)
                {
                    // Seperate each line by tabs
                    string[] playerElement = line.Split('\t');

            // Number 10 (All the different way to quit program)
            var exitStatements = new string[] { "10", "q", "Q", "quit", "Quit", "exit", "Exit" };

            // Users input variable
            string UInput = "";

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
                        System.Console.WriteLine("Print All Players");
                        break;

                    case "2":
                        // 2. Print All Guilds
                        System.Console.WriteLine("Print All Guilds");  
                        break;

                    case "3":
                        // 3. List All Gear
                        System.Console.WriteLine("List All Gear");  
                        break;

                    case "4":
                        // 4. Print Gear List for Player
                        System.Console.WriteLine("Print Gear List for Player");  
                        break;

                    case "5":
                        // 5. Leave Guild
                        System.Console.WriteLine("Leave Guild");
                        break;

                    case "6":
                        // 6. Join Guild
                        System.Console.WriteLine("Join Guild");
                        break;

                    case "7":
                        // 7. Equip Gear
                        System.Console.WriteLine("Equip Gear");
                        break;

                    case "8":
                        // 8. Unequip Gear
                        System.Console.WriteLine("Unequip Gear");  
                        break;

                    case "9":
                        // 9. Award Experience
                        System.Console.WriteLine("Award Experience");
                        break;

                    case "T":
                        // 9*. Don't show in menu but Icomparble
                        System.Console.WriteLine("T");
                        break;

                    case "10":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    case "q":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    case "Q":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    case "quit":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    case "Quit":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    case "exit":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    case "Exit":
                        // 10. Quit
                        System.Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    default:
                        // Invalid Input
                        System.Console.WriteLine("Invalid input. Try again...");
                        break;
                }

            } while (!exitStatements.Contains(UInput));
        }

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

        // Race Types
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
        public class Item : ICompareable 
        {
            public readonly uint id;    // Read only
            public string name;         // Free read/write access
            public ItemType Type;       // Free read/write access; Range is [0, 12]
            public uint ilvl;           // Free read/write access; Range is [0, MAX_ILVL] 
            public uint primary;        // Free read/write access; Range is [0, MAX_PRIMARY] 
            public uint stamina;        // Free read/write access; Range is [0, MAX_STAMINA] 
            public uint requirement;    // Free read/write access; Range is [0, MAX_LEVEL] 
            public string flavor;       // Free read/write access 

            // Default Item Constructor
            public Item()
            {
                this.id                 = 0;
                this.name               = "";
                this.type               = 0;
                this.ilvl               = 0;
                this.primary            = 0;
                this.stamina            = 0;
                this.requirement        = 0;
                this.flavor             = "";
            }

            // Alt Item Constructor
            public Item(uint id, string name, ItemType type, uint ilvl, uint primary, uint stamina, uint requirement, string flavor)
            {
                this.id                 = id;
                this.name               = name;
                this.type               = type;
                this.ilvl               = ilvl;
                this.primary            = primary;
                this.stamina            = stamina;
                this.requirement        = requirement;
                this.flavor             = flavor;
            }

            // ID Get
            public uint Id
            {
                // Get ID
                get { return id; }
            }

            // Name Get/Set
            public string Name
            {
                // Get name
                get { return name; }

                // Set name
                set { name = value; }
            }

            // Item Type Get/Set
            public ItemType Type
            {
                // Get item type
                get { return type; }
                set { type = value; }
            }

            // Ilvl Get/Set
            public uint Ilvl
            {
                // Get level
                get { return ilvl; }

                // Set level
                set
                {
                    if (value <= 0)
                    {
                        ilvl = 0;
                    }
                    else if (value >= MAX_ILVL)
                    {
                        ilvl = MAX_ILVL;
                    }
                    else
                    {
                        ilvl = value;
                    }
                }
            }

            // Primary Get/Set
            public uint Primary
            {
                get { return primary; }
                set
                {
                    if (value <= 0)
                    {
                        primary = 0;
                    }
                    else if (value >= MAX_PRIMARY)
                    {
                        primary = MAX_PRIMARY;
                    }
                    else
                    {
                        primary = value;
                    }
                }
            }

            // Stamina Get/Set
            public uint Stamina
            {
                get { return stamina; }
                set
                {
                    if (value <= 0)
                    {
                        stamina = 0;
                    }
                    else if (value >= MAX_STAMINA)
                    {
                        stamina = MAX_STAMINA;
                    }
                    else
                    {
                        stamina = value;
                    }
                }
            }

            // Requirement Get/Set
            public uint Requirement
            {
                get { return requirement; }
                set
                {
                    if (value <= 0)
                    {
                        requirement = 0;
                    }
                    else if (value >= MAX_LEVEL)
                    {
                        requirement = MAX_LEVEL;
                    }
                    else
                    {
                        requirement = value;
                    }
                }
            }

            // Flavor Get/Set
            public string Flavor
            {
                get { return flavor; }
                set { flavor = value; }
            }

            // CompareTo for ITEM
            public int CompareTo(Object alpha)
            {
                if (alpha == null)
                { return 1; }

                Item comp = alpha as Item;

                if (comp != null)
                    return name.CompareTo(comp.name);
                else
                    throw new ArgumentException("[Item]:CompareTo argument is not an Item.");
            }

            // ToString Override for ITEM
            public override string ToString()
            {
                return this.name;
            }
        } 

        // Player Class
        public class Player : IComparable
        {
            private readonly uint playerId;     // Player ID
            private readonly string playerName; // Player Name
            private readonly Race race;         // Player Race. int because will be indexed to enum
            private uint playerLevel;           // Player level
            private uint exp;                   // Player xp
            private uint guildID;               // Player GuildID
            private uint[] gear;                // Player gear array
            private List<uint> inventory;       // Player inventory list

            // Default Player Constructor
            public Player()
            {
                this.playerId           = 0;
                this.playerName         = "";
                this.race               = 0;
                this.playerLevel        = 0;
                this.exp                = 0;
                this.guildID            = 0;
                this.gear               = new uint[GEAR_SLOTS];
                this.inventory          = new List<uint>(new uint[MAX_INVENTORY_SIZE]);
            }

            // Alt Player Constructor
            public Player(uint playerId, string playerName, Race race, uint playerLevel, uint exp, uint guildID, uint[] gear, List<uint> inventory)
            {
                this.playerId           = playerId;
                this.playerName         = playerName;
                this.race               = race;
                this.playerLevel        = playerLevel;
                this.exp                = exp;
                this.guildID            = guildID;
                this.gear               = new uint[GEAR_SLOTS];
                this.inventory          = new List<uint>(new uint[MAX_INVENTORY_SIZE]);
            }

            // PlayerID Get
            public uint PlayerId
            {
                get { return playerId; }                
            }

            // PlayerName Get
            public string PlayerName
            {
                get { return playerName; }                
            }

            // Race Get
            public Race Race
            {
                get { return race; }                
            }

            // PlayerLevel Get/Set
            public uint PlayerLevel
            {
                get { return playerLevel; }
                set
                {
                    if (value <= 0)
                    {
                        playerLevel = 0;
                    }
                    else if (value >= MAX_LEVEL)
                    {
                        playerLevel = MAX_LEVEL;
                    }
                    else
                    {
                        playerLevel = value;
                    }
                }
            }

            // Exp Get/Set
            public uint Exp
            {
                get { return exp; }
                set
                {
                    exp += value;
                    while (exp > PlayerLevel * 1000)
                    {
                        this.PlayerLevel++;
                    }
                }
            }

            // GuildID Get/Set
            public uint GuildID
            {
                get { return guildID; }
                set { guildID = value; }
            }

            // Gear Get/Set
            public uint this[uint index]
            {
                get { return gear[index]; }
                set { gear[index] = value; }
            }

            // CompareTo fpr Player
            public int CompareTo(Object alpha)
            {
                if (alpha == null)
                { return 1; }

                Player comp = alpha as Player;

                if (comp != null)
                    return playerName.CompareTo(comp.playerName);
                else
                    throw new ArgumentException("Player]:CompareTo argument is not a Player.");
            }

            // ToString Override for Player
            public override string ToString()
            {
                return this.playerName;
            }

            // Equip Gear
            public void EquipGear(uint newGearID)
            {
                
            }

            // Uneqip Gear
            public void UnequipGear(int gearSlot)
            {

            }
        }
    }
}