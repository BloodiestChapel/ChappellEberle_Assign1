/********************************************************************
 CSCI 473 - Assignment 1 - Spring 2021
 
 Progammer: Dillon Chappell (z1761203)
 Progammer: Rhianna Eberle (z1848017)
 Section:   1
 Professor: Daniel Rogness
 Date Due:  January 29, 2021
 
 Purpose:   Program.cs
 *********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChappellEberle_Assign1
{
	 class Program
    {
    	static void Main(string[] args)
        {
            var exitStatements = new string[] { "10", "q", "Q", "quit", "Quit", "exit", "Exit" }; //Number 10 (All the different way to quit program)
            string UInput = "";           //Users input variable
            do
            {
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

                UInput = Console.ReadLine(); //collects input from user

                switch (UInput)
                {
                    case "1":
                        System.Console.WriteLine("1");   //1) Print All Players
                        break;
                    case "2":
                        System.Console.WriteLine("2");   //2)  Print All Guilds
                        break;
                    case "3":
                        System.Console.WriteLine("3");   //3)  List all Gear
                        break;
                    case "4":
                        System.Console.WriteLine("4");   //4)   Print Gear List for Player
                        break;
                    case "5":
                        System.Console.WriteLine("5");   //5)   Leave Guild
                        break;
                    case "6":
                        System.Console.WriteLine("6");   //6)   Join Guild
                        break;
                    case "7":
                        System.Console.WriteLine("7");   //7)   Equip Gear
                        break;
                    case "8":
                        System.Console.WriteLine("8");   //8)   Unequip Gear
                        break;
                    case "9":
                        System.Console.WriteLine("9");   //9)   Award Experience
                        break;
                    case "T":
                        System.Console.WriteLine("T");   //Dont show in menu but Icomparble
                        break;
                    case "10":                   
                        System.Console.WriteLine("Closing Program");     //10)  Quit
                        break;
                    case "q":
                        System.Console.WriteLine("Closing Program");     //10)  Quit
                        break;
                    case "Q":
                        System.Console.WriteLine("Closing Program");    //10)   Quit
                        break;
                    case "quit":
                        System.Console.WriteLine("Closing Program");   //10)   Quit
                        break;
                    case "Quit":
                        System.Console.WriteLine("Closing Program");  //10)   Quit
                        break;
                    case "exit":
                        System.Console.WriteLine("Closing Program");  //10)  Quit
                        break;
                    case "Exit":
                        System.Console.WriteLine("Closing Program");   //10)  Quit
                        break;
                    default:
                        System.Console.WriteLine("Not a valid input. Try again");  //When user puts an input that isnt on the list
                        break;
                }  //switch
                
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

        public enum Race      //race type
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
            public readonly uint id;       // Read only
            public string name;            // Free read/write access
            public ItemType Type;          // Free read/write access; Range is [0, 12]
            public uint ilvl;              // Free read/write access; Range is [0, MAX_ILVL] 
            public uint primary;           // Free read/write access; Range is [0, MAX_PRIMARY] 
            public uint stamina;           // Free read/write access; Range is [0, MAX_STAMINA] 
            public uint requirement;       // Free read/write access; Range is [0, MAX_LEVEL] 
            public string flavor;          // Free read/write access 
        }
            public uint Id
            {
                get { return id; }   //return id
            }

            public string Name
            {
                get { return name; }    //get name 
                set { name = value; }
            }

            public ItemType Type
            {
                get { return type; }    //get item type
                set { type = value; }
            }

            public uint Ilvl
            {
                get { return ilvl; }   //get level

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

            public string Flavor
            {
                get { return flavor; }
                set { flavor = value; }
            }

            public Item()
            {
                this.id = 0;
                this.name = "";
                this.type = 0;
                this.ilvl = 0;
                this.primary = 0;
                this.stamina = 0;
                this.requirement = 0;
                this.flavor = "";
            }

            public Item(uint id, string name, ItemType type, uint ilvl, uint primary, uint stamina, uint requirement, string flavor)
            {
                this.id = id;
                this.name = name;
                this.type = type;
                this.ilvl = ilvl;
                this.primary = primary;
                this.stamina = stamina;
                this.requirement = requirement;
                this.flavor = flavor;
            }

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

            public override string ToString()
            {
                return this.name;
            }
        } 

        public class Player : IComparable
        {
            private readonly uint playerId; //Player ID
            private readonly string playerName; //Player Name
            private readonly Race race; //Player Race. int because will be indexed to enum
            private uint playerLevel; //Player level
            private uint exp; //player xp
            private uint guildID; //Player GuildID
            private uint[] gear; //Player gear array
            private List<uint> inventory; //Player inventory list

            public uint PlayerId
            {
                get { return playerId; }                
            }

            public string PlayerName
            {
                get { return playerName; }                
            }

            public Race Race
            {
                get { return race; }                
            }

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

            public uint GuildID
            {
                get { return guildID; }
                set { guildID = value; }
            }
            public uint this[uint index]
            {
                get { return gear[index]; }
                set { gear[index] = value; }
            }

            public int CompareTo(Object alpha)
            {
                if (alpha == null)
                { return 1; }

                Player comp = alpha as Player;

                if (comp != null)
                    return playerName.CompareTo(comp.playerName);
                else
                    throw new ArgumentException("[Item]:CompareTo argument is not an Item.");
            }

            public override string ToString()
            {
                return this.playerName;
            }

            public void EquipGear(uint newGearID)
            {
                
            }

            public void UnequipGear(int gearSlot)
            {

            }

            public Player()
            {
                this.playerId = 0;
                this.playerName = "";
                this.race = 0;
                this.playerLevel = 0;
                this.exp = 0;
                this.guildID = 0;
                this.gear = new uint[GEAR_SLOTS]; 
                this.inventory = new List<uint>(new uint[MAX_INVENTORY_SIZE]); 
            }

            public Player(uint playerId, string playerName, Race race, uint playerLevel, uint exp, uint guildID, uint[] gear, List<uint> inventory)
            {
                this.playerId = playerId;
                this.playerName = playerName;
                this.race = race;
                this.playerLevel = playerLevel;
                this.exp = exp;
                this.guildID = guildID;
                this.gear = new uint[GEAR_SLOTS]; 
                this.inventory = new List<uint>(new uint[MAX_INVENTORY_SIZE]); 
            }
            
        }

    }
}
