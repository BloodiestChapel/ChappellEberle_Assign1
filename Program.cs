/***********************************************
 * CSCI 473 - Assignment 1 - Spring 2021       *
 *                                             *
 * Progammer: Dillon Chappell (z1761203)       *
 *            Rhianna Eberle (z1848017)        *
 *            Karen Astorga-Rollins (z1761117) *
 * Section:   1                                *
 * Professor: Daniel Rogness                   *
 * Date Due:  January 29, 2021                 *
 *                                             *
 * Purpose:   Program.cs                       *
 ***********************************************/

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
        public static void Main(string[] args)
        {
            // Read File Input for each file
            StreamReader playerFile = new StreamReader(@"players.txt");
            StreamReader guildFile = new StreamReader(@"guilds.txt");
            StreamReader itemFile = new StreamReader(@"equipment.txt");

            // For lines in playerFile
            string playerLine;
            string guildLine;
            string itemLine;

            // List of players
            List<Player> playerList = new List<Player>();
            List<Item> itemList = new List<Item>();

            // Store guilds in dict
            Dictionary<uint, string> guildDict = new Dictionary<uint, string>();

            // Guilds File Reading
            while ((guildLine = guildFile.ReadLine()) != null)
            {
                string[] guildElement = guildLine.Split('\t');

                guildDict.Add(
                    Convert.ToUInt32(guildElement[0]),
                    guildElement[1]
                    );
            }

            // Items File Reading
            while ((itemLine = itemFile.ReadLine()) != null)
            {
                string[] itemElement = itemLine.Split('\t');

                itemList.Add(
                        new Item(
                        Convert.ToUInt32(itemElement[0]),                       // Item ID element
                        itemElement[1],                                         // Item Name element
                        (ItemType)Enum.Parse(typeof(ItemType), itemElement[2]), // Item Type element
                        Convert.ToUInt32(itemElement[3]),                       // Item iLvl element
                        Convert.ToUInt32(itemElement[4]),                       // Item Primary element
                        Convert.ToUInt32(itemElement[5]),                       // Item Stamina element
                        Convert.ToUInt32(itemElement[6]),                       // Item Requirement element
                        itemElement[7]                                          // Item flavor element
                        )
                    );
            }

            // Player File Reading
            while ((playerLine = playerFile.ReadLine()) != null)
            {
                string[] playerElement = playerLine.Split('\t');

                // For each line
                playerList.Add(
                        new Player(
                        Convert.ToUInt32(playerElement[0]),                 // Player ID element
                        playerElement[1],                                   // Player Name element
                        (Race)Enum.Parse(typeof(Race), playerElement[2]),   // Player Race element
                        Convert.ToUInt32(playerElement[3]),                 // Player Level element
                        Convert.ToUInt32(playerElement[4]),                 // Player XP element
                        Convert.ToUInt32(playerElement[5]),                 // Player GuildID element
                        new uint[] {                                        // Player Gear elements
                            Convert.ToUInt32(playerElement[6]),             
                            Convert.ToUInt32(playerElement[7]),
                            Convert.ToUInt32(playerElement[8]),
                            Convert.ToUInt32(playerElement[9]),
                            Convert.ToUInt32(playerElement[10]),
                            Convert.ToUInt32(playerElement[11]),
                            Convert.ToUInt32(playerElement[12]),
                            Convert.ToUInt32(playerElement[13]),
                            Convert.ToUInt32(playerElement[14]),
                            Convert.ToUInt32(playerElement[15]),
                            Convert.ToUInt32(playerElement[16]),
                            Convert.ToUInt32(playerElement[17]),
                            Convert.ToUInt32(playerElement[18]),
                            Convert.ToUInt32(playerElement[19])
                            }
                        )
                    );
            }

            // Number 10 (All the different way to quit program)
            var exitStatements = new string[] { "10", "q", "Q", "quit", "Quit", "exit", "Exit" };

            // Users input variable
            string UInput;

            // Test guildDict
            //foreach (KeyValuePair<uint, string> guild in guildDict)
            //{
            //    Console.WriteLine(guild.Value);          
            //}


            // Decide what to do with input
            do
            {
                // Print out the menu
                Console.WriteLine("Welcome to the World of ConflictCraft: Testing Enviroment \n");
                Console.WriteLine("Please select an option from the list below: ");
                Console.WriteLine("\t 1) Print All Players ");
                Console.WriteLine("\t 2) Print All Guilds ");
                Console.WriteLine("\t 3) List all Gear ");
                Console.WriteLine("\t 4) Print Gear List for Player ");
                Console.WriteLine("\t 5) Leave Guild ");
                Console.WriteLine("\t 6) Join Guild ");
                Console.WriteLine("\t 7) Equip Gear ");
                Console.WriteLine("\t 8) Unequip Gear ");
                Console.WriteLine("\t 9) Award Experience ");
                Console.WriteLine("\t 10) Quit ");

                // Collects input from user
                UInput = Console.ReadLine();

                switch (UInput)
                {
                    case "1":
                        // 1. Print All Players
                        Console.WriteLine("Print All Players");

                        // Print out name property of all players
                        foreach (Player currPlayer in playerList)
                        {
                            Console.WriteLine(currPlayer.ToString());
                        }

                        break;

                    case "2":
                        // 2. Print All Guilds
                        Console.WriteLine("Print All Guilds");

                        // Print out each guild name
                        foreach(KeyValuePair<uint, string> element in guildDict)
                            {
                            Console.WriteLine("{0}", element.Value);
                            }

                        break;

                    case "3":
                        // 3. List All Gear
                        Console.WriteLine("List All Gear");

                        // Print out name property of all items
                        foreach (Item currItem in itemList)
                        {
                            Console.WriteLine(currItem.ToString());
                        }

                        break;

                    case "4":
                        // 4. Print Gear List for Player
                        Console.WriteLine("Print Gear List for Player");
                        Console.Write("Enter the player name:\t");

                        string case4Input = Console.ReadLine();

                        // Print gear for player
                        foreach(Player player in playerList.Where(x => x.PlayerName == case4Input))
                        {
                            uint gearItem;
                            foreach (uint item in player.Gear)
                            {
                                gearItem = player.Gear[item];
                                Console.WriteLine(gearItem);
                            }
                        }

                        break;

                    case "5":
                        // 5. Leave Guild
                        Console.WriteLine("Leave Guild");
                        Console.Write("Enter the player name:\t");

                        string case5Input = Console.ReadLine();

                        //bool playerExists = playerList.Any(x => x.PlayerName == case5Input);

                        foreach (var player in playerList.Where(x => x.PlayerName == case5Input))
                        {
                            player.GuildID = 0;
                        }

                        Console.WriteLine("{0} has left their guild.", case5Input);

                        break;

                    case "6":
                        // 6. Join Guild
                        Console.WriteLine("Join Guild");

                        // Which player?
                        Console.Write("Enter the player name:\t");
                        string case6Input = Console.ReadLine();

                        // Which guild?
                        Console.Write("Enter the guild name:\t");
                        string givenGuild = Console.ReadLine();

                        // Check each guild's name and if it matches input,
                        // set the player's guild to the given input
                        foreach (KeyValuePair<uint, string> guild in guildDict)
                        {
                            if (guild.Value == givenGuild)
                            {
                                foreach (var player in playerList.Where(x => x.PlayerName == case6Input))
                                {
                                    player.GuildID = Convert.ToUInt32(guild.Key);
                                    Console.WriteLine("{0} joined {1}", case6Input, givenGuild);
                                }
                            }
                        }

                        break;

                    case "7":
                        // 7. Equip Gear
                        Console.WriteLine("Equip Gear");
                        break;

                    case "8":
                        // 8. Unequip Gear
                        Console.WriteLine("Unequip Gear");  
                        break;

                    case "9":
                        // 9. Award Experience
                        Console.WriteLine("Award Experience");

                        // Which player?
                        Console.Write("Enter the player name:\t");
                        string currPlayerName = Console.ReadLine();

                        // Give experience amount
                        Console.Write("Enter the amount of experience to award:\t");
                        uint expAward = Convert.ToUInt32(Console.ReadLine());

                        // If the player exists
                        foreach (Player player in playerList.Where(x => x.PlayerName == currPlayerName))
                        {
                            // Currently calculating incorrectly
                            player.LevelUp(expAward);
                        }

                        break;

                    case "T":
                        // T. Don't show in menu but IComparable
                        Console.WriteLine("T");
                        break;

                    case "10":
                        // 10. Quit
                        Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    case "q":
                        // 10. Quit
                        Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    case "Q":
                        // 10. Quit
                        Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    case "quit":
                        // 10. Quit
                        Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    case "Quit":
                        // 10. Quit
                        Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    case "exit":
                        // 10. Quit
                        Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    case "Exit":
                        // 10. Quit
                        Console.WriteLine("Closing Program...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    default:
                        // Invalid Input
                        Console.WriteLine("Invalid input. Try again...");
                        break;
                }

            } while (!exitStatements.Contains(UInput));
            
            /*
             * For debugging...
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
            */
        }
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

    // Item Class
    public class Item : IComparable
    {
        // Constants
        private static uint MAX_ILVL = 360;
        private static uint MAX_PRIMARY = 200;
        private static uint MAX_STAMINA = 275;
        private static uint MAX_LEVEL = 60;

        public readonly uint id;    // Read only
        public string name;         // Free read/write access
        public ItemType type;       // Free read/write access; Range is [0, 12]
        public uint ilvl;           // Free read/write access; Range is [0, MAX_ILVL] 
        public uint primary;        // Free read/write access; Range is [0, MAX_PRIMARY] 
        public uint stamina;        // Free read/write access; Range is [0, MAX_STAMINA] 
        public uint requirement;    // Free read/write access; Range is [0, MAX_LEVEL] 
        public string flavor;       // Free read/write access 

        // Default Item Constructor
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

        // Alt Item Constructor
        public Item(uint id, string name, ItemType Type, uint ilvl, uint primary, uint stamina, uint requirement, string flavor)
        {
            this.id = id;
            this.name = name;
            this.type = Type;
            this.ilvl = ilvl;
            this.primary = primary;
            this.stamina = stamina;
            this.requirement = requirement;
            this.flavor = flavor;
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
            string output = String.Format(
                "({0}) {1} |{2}| --{3}-- \n\t{4} \n",
                this.Type,
                this.Name,
                this.Ilvl,
                this.Requirement,
                this.Flavor
                );
            return output;
        }
    }

    // Player Class
    public class Player : IComparable
    {
        // Constants
        private static uint MAX_LEVEL = 60;
        private static uint GEAR_SLOTS = 14;
        private static uint MAX_INVENTORY_SIZE = 20;

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
            this.playerId = 0;
            this.playerName = "";
            this.race = 0;
            this.playerLevel = 0;
            this.exp = 0;
            this.guildID = 0;
            this.gear = new uint[GEAR_SLOTS];
            this.inventory = new List<uint>(new uint[MAX_INVENTORY_SIZE]);
        }

        // Alt Player Constructor
        public Player(uint playerId, string playerName, Race race, uint playerLevel, uint exp, uint guildID, uint[] gear)
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
        // Not functioning properly
        //public uint this[uint index]
        //{
        //    get { return gear[index]; }
        //    set { gear[index] = value; }
        //}
        public uint[] Gear
        {
            get { return gear; }
            set { gear = value; }
        }

        // CompareTo for Player
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

        // ToGuildName function
        //public string ToGuildName()
        //{
        //    string guildName = guildDict[this.GuildID];
        //    return guildName;
        //}

        // ToString Override for Player
        public override string ToString()
        {
            //foreach (KeyValuePair<uint, string> guild in guildDict)
            //{
            //    Console.WriteLine(guild.Value);
            //}
 
            string output = String.Format(
            "Name: {0, -17} Race: {1, -12} Level: {2, -6} Guild: {3, -15}",
            this.PlayerName,
            this.Race,
            this.PlayerLevel,
            this.GuildID
            );

            return output;
        }

        // Equip Gear
        public void EquipGear(uint newGearID)
        {
            // Get player name
            string playerName = this.PlayerName;

            // Get item name
            //string itemName = this.Item.Name;

            // Attempt to have player equip item


        }

        // Uneqip Gear
        public void UnequipGear(int gearSlot)
        {

        }

        // LevelUp
        public void LevelUp(uint expAward)
        {
            //xpThreshold = current level * 1000
            uint expthresh = this.PlayerLevel * 1000;

            uint currEXP = 0;

            currEXP += expAward;
            if(currEXP >= expthresh)
            {
                this.PlayerLevel++;
            }


            //this.playerLevel = 13;

        }
    }
}