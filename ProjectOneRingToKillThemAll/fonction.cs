
#region Declaration and Initialization of variables

//enable the full screen at the beginning of the game
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

//1st music plays (ambient music menu)
/*SoundPlayer musicPlayer = new SoundPlayer("AllAdventure Meme.mp3");
musicPlayer.Load();
musicPlayer.PlayLooping();
*/
//--------------------Lists and Dictionnary for the different characters (names, PV, ATK, Spe and Spe description), the potions and the Active Burn list for the Gundalph-------------------------------------------------

//CLASSES
List<string> listCharAvailable = new List<string>
            {
                "Rawrhirrim",
                "Erwan",
                "Gymlit",
                "Degolas",
                "Gundalph",
                "Striper"
            };

//HP
Dictionary<string, int> dicHealthChar = new Dictionary<string, int>
            {
                { listCharAvailable[0], 7 },
                { listCharAvailable[1], 8 },
                { listCharAvailable[2], 10 },
                { listCharAvailable[3], 9 },
                { listCharAvailable[4], 9 },
                { listCharAvailable[5], 8 }
            };

//BASE ATK
Dictionary<string, int> dicATKChar = new Dictionary<string, int>
            {
                { listCharAvailable[0], 3 },
                { listCharAvailable[1], 1 },
                { listCharAvailable[2], 2 },
                { listCharAvailable[3], 1 },
                { listCharAvailable[4], 1 },
                { listCharAvailable[5], 2 }
            };

//SPE NAMES
Dictionary<string, string> dicSpeChar = new Dictionary<string, string>
            {
                { listCharAvailable[0], "Ring's Fury" },
                { listCharAvailable[1], "Lembus (elvish bread)" },
                { listCharAvailable[2], "Ring of Power" },
                { listCharAvailable[3], "Nuzgûl's curse" },
                { listCharAvailable[4], "BUUUURN" },
                { listCharAvailable[5], "Mines of Muria" }
            };

//POTIONS
List<string> listPotions = new List<string>
            {
                "Second Breakfast",
                "Shting (the elven short-sword)"
            };

//HALF NAMES
List<string> listHalves = new List<string>
            {
                "Muria",
                "Endwin River",
                "Meowrdor"
            };

//SPE DESCRIPTIONS
Dictionary<string, string> dicSpeDescription = new Dictionary<string, string>
            {
                {"Ring's Fury", "returns all damages suffered during the turn"},
                {"Lembus (elvish bread)", "regain 2 of Health"},
                {"Ring of Power", "lose 1 of Health but gains 1 of ATK for the turn"},
                {"Nuzgûl's curse", "steal one Health for himself from the enemy" },
                {"BUUUURN", "inflict 1 of damage during 3 turn (can be combined)" },
                {"Mines of Muria", "inflict between 0 to 4 of ATK (random)"},

            };

//for the mage's burn
List<int> allBurnActive = new List<int>();

//used to determine the current state of the game, the current turn (for burn) and for the tryCatch
int half = 1;
bool isBeginningOfNewHalf = true;
int countTurn = 1;
int errorTryCatch = 0;

//for the Player basics
string playerName = "";
int playerChoiceChar = 0;
int pvPlayer = 0;
int atkPlayer = 0;
string spePlayer = "";
string charPlayer = "";
//for the potions of the player
string playerActivePotion = "";
int playerChoicePotion = 0;
bool isShting = false;
//dealing with player's actions
int playerChoiceAction = 0;
Tuple<int, int, string> sumActionTurnPlayer = new Tuple<int, int, string>(0, 0, "");

//for the AI and its cleverness
List<string> allNameAI = new List<string>()
            {
                "Balgor",
                "Surumen",
                "Soron"
            };
string charAI = "";
int pvAI = 10;
int atkAI = 0;
string speAI = "";

Random randomAI = new Random();
int actionAI = 0;
int preferedActionAI = 0;
Tuple<int, int, string> sumActionTurnAI = new Tuple<int, int, string>(0, 0, "");
int difficultyLevelAI = 0;

int nbDefPlayerHalf = 0;
int nbATKPlayerHalf = 0;
int nbSpePlayerHalf = 0;

#endregion

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

#region Texts Beginning of the game

PrintTitle();
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.Write("                                                                                                                  Welcome in the Shire, dear adventurer ! I'm Gollurn.\n\n");

//asking the player his name
Console.WriteLine("Gollurn -- What is your name ? ");
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Cyan;
playerName = Console.ReadLine();
Console.ResetColor();
Console.Write("\n");

Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("Gollurn -- Nice to meet you, precious !");
Console.WriteLine("\n");

#endregion
