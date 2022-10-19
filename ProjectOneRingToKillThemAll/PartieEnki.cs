
#region Functions

//return the impact of the entity on itself and on the other entity
static Tuple<int, int, string> actionPlayer(int action, string player, string potion, Dictionary<string, int> dicATKChar)
{
    int impactOnMe = 0;
    int impactOnHim = 0;
    int errorTryCatch;

    //if a potion is used 
    if (action == 4 && potion != "empty" && potion != "null")
    {
        if (potion == "Second Breakfast")
            impactOnMe += 10;
        potion = "empty";
    }
    //if the player wants to choose the potion but it has already been used
    else if (action == 4 && potion == "empty")
    {
        do
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Gollurn - The potion is empty !");
            Console.ResetColor();

            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                errorTryCatch = 0;
                action = int.Parse(Console.ReadLine());
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                errorTryCatch = 1;
                Console.ResetColor();

                //Console.WriteLine(ex.Message);
                Console.Write("Gollurn -- Pick a number precious, not a letter... ");
            }
            if ((action < 1 || action > 3) && errorTryCatch == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                errorTryCatch = 1;
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Gollurn -- Your potion is empty, just choose something else, precious ! *coughs*");
                Console.ResetColor();
            }
        }
        while (errorTryCatch == 1);
        actionPlayer(action, player, potion, dicATKChar);
    }
    //if the player wants to choose the potion but it hasn't been unlocked
    else if (action == 4 && potion == "null")
    {
        do
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Gollurn - the potion is empty");
            Console.ResetColor();

            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                errorTryCatch = 0;
                action = int.Parse(Console.ReadLine());
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                errorTryCatch = 1;
                Console.ResetColor();

                //Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("Gollurn -- Pick a number precious, not a letter... ");
                Console.ResetColor();
            }
            if ((action < 1 || action > 3) && errorTryCatch == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                errorTryCatch = 1;
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Gollurn -- Your potion is empty, just choose something else, precious ! *coughs*");
                Console.ResetColor();
            }
        }
        while (errorTryCatch == 1);
        actionPlayer(action, player, potion, dicATKChar);
    }
    else
    {
        //all effects of the actions according to the character
        switch (player)
        {
            case "Rawrhirrim":
                switch (action)
                {
                    case 1:
                        impactOnHim -= dicATKChar[player];
                        break;
                }
                break;

            case "Erwan":
                switch (action)
                {
                    case 1:
                        impactOnHim -= dicATKChar[player];
                        break;
                    case 3:
                        impactOnMe += 2;
                        break;
                }
                break;

            case "Gymlit":
                switch (action)
                {
                    case 1:
                        impactOnHim -= dicATKChar[player];
                        break;

                    case 3:
                        impactOnMe -= 1;
                        impactOnHim -= dicATKChar[player] + 1;
                        break;
                }
                break;

            case "Degolas":
                switch (action)
                {
                    case 1:
                        impactOnHim -= dicATKChar[player];
                        break;

                    case 3:
                        impactOnMe += 1;
                        impactOnHim -= 1;
                        break;
                }
                break;

            case "Gundalph":
                switch (action)
                {
                    case 1:
                        impactOnHim -= dicATKChar[player];
                        break;
                }
                break;

            case "Striper":
                switch (action)
                {
                    case 1:
                        impactOnHim -= dicATKChar[player];
                        break;

                    case 3:
                        Random critique = new Random();
                        impactOnHim -= critique.Next(0, 5);
                        break;
                }
                break;
        }
    }
    return new Tuple<int, int, string>(impactOnMe, impactOnHim, potion);
}

//Print the texts for each action
static Tuple<int, int, int, int> TextActions(int choix, string player, string playerChar, string potionPerso, List<int> allBurnActive)
{

    int nbAttaque = 0;
    int nbDefense = 0;
    int nbSpecial = 0;
    switch (choix)
    {
        case 1: //attack
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n{0} : ATTACK !", player);
            if (player != "AI")
                nbAttaque++;
            Console.ResetColor();
            break;

        case 2: //defense
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n{0} : DEFENSE", player);
            if (player != "AI")
                nbDefense++;
            Console.ResetColor();
            break;

        case 3: //special
            if (playerChar == "Gundalph" && allBurnActive.Count == 3 && player != "AI")
            {

                int errorTryCatch = 0;

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("Gollurn -- IT BURNS AAAH ! Choose something else, precious !");
                Console.ResetColor();

                do
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        errorTryCatch = 0;
                        choix = int.Parse(Console.ReadLine());
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        errorTryCatch = 1;
                        Console.ResetColor();

                        //Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("Gollurn -- Really, precious ? What is it ?");
                        Console.ResetColor();
                    }
                    if ((choix < 1 || choix > 2) && errorTryCatch == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        errorTryCatch = 1;
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Gollurn -- Give it to us raw, and wriggling !");
                        Console.ResetColor();

                    }
                } while (errorTryCatch == 1);
                TextActions(choix, player, playerChar, potionPerso, allBurnActive);
            }
            else if (playerChar == "Gundalph" && allBurnActive.Count == 3 && player == "AI")
            {
                Random randChoixAI = new Random();
                choix = randChoixAI.Next(1, 3);
                TextActions(choix, player, playerChar, potionPerso, allBurnActive);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n{0} : SPECIAL ATTACK", player);
                if (player != "AI")
                    nbSpecial++;
                Console.ResetColor();
            }

            break;

        case 4: //potion
            if (player != "AI" && (potionPerso != "empty" && potionPerso != "null"))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("{0} : -- POWER UP POTION --\n", player);

                //SFX for the power up potion
                var reader = new NAudio.Wave.Mp3FileReader("Power Up Potions.mp3");
                var waveOut = new NAudio.Wave.WaveOutEvent();
                waveOut.Init(reader);
                waveOut.Play();
                Console.ResetColor();
            }
            break;

        default:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Gollurn -- You need to choose a valid number, precious ! \n");
            Console.ResetColor();
            TextActions(choix, player, playerChar, potionPerso, allBurnActive);
            break;
    }
    return new Tuple<int, int, int, int>(nbAttaque, nbDefense, nbSpecial, choix);
}

//pause the game for n-seconds (not using Sleep())
static void Wait(float second)
{
    Task delay = Task.Delay(TimeSpan.FromSeconds(second));
    delay.Wait();
}

//return the character given the choice (int)
static string ChooseCharacter(int choix)
{
    string player = "";

    switch (choix)
    {
        case 1:
            player = "Rawrhirrim";
            break;

        case 2:
            player = "Erwan";
            break;

        case 3:
            player = "Gymlit";
            break;

        case 4:
            player = "Degolas";
            break;

        case 5:
            player = "Gundalph";
            break;

        case 6:
            player = "Striper";
            break;

        default:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Gollurn -- You need to choose a valid number, precious ! \n");
            Console.ResetColor();
            ChooseCharacter(choix);
            break;
    }

    return player;
}

//return the biggest number out of three
static int BestOutOfThree(int nb1, int nb2, int nb3)
{
    if (nb1 > nb2)
    {
        if (nb1 > nb3)
            return nb1;
        else
            return nb3;
    }
    else
    {
        if (nb2 > nb3)
            return nb2;
        else
            return nb3;
    }
}

//return the character of the AI and its prefered action due to its cleverness
//the first difficulty returns a random choice and no prefered action
//the second difficulty returns a choice based on the previous actions of the player (and chooses the second best character to counter the player)
//the third difficulty returns a choice based on the previous actions of the player (and chooses the best character to counter the player)
static Tuple<string, int> ChoiceCharAI(int difficultyLevelAI, string charPlayer,
int half, int nbATKPlayerHalf, int nbDefPlayerHalf,
    int nbSpePlayerHalf)
{
    string charAI = "";
    int preferedActionAI = 0;
    Random randomAI = new Random();

    do
    {
        int choixAI = randomAI.Next(1, 7);
        if (difficultyLevelAI == 2 && half != 1)
        {
            if (half == 2)
            {
                if (BestOutOfThree(nbATKPlayerHalf, nbDefPlayerHalf, nbSpePlayerHalf) == nbDefPlayerHalf && charPlayer != "Gymlit")
                {
                    charAI = "Gymlit";
                    preferedActionAI = 3;
                }
                else if (BestOutOfThree(nbATKPlayerHalf, nbDefPlayerHalf, nbSpePlayerHalf) == nbATKPlayerHalf && charPlayer != "Gundalph")
                {
                    charAI = "Gundalph";
                    preferedActionAI = 3;
                }
                else if (BestOutOfThree(nbATKPlayerHalf, nbDefPlayerHalf, nbSpePlayerHalf) == nbSpePlayerHalf && charPlayer != "Striper")
                {
                    charAI = "Striper";
                    preferedActionAI = 3;
                }
                else if (BestOutOfThree(nbATKPlayerHalf, nbDefPlayerHalf, nbSpePlayerHalf) == nbSpePlayerHalf && charPlayer == "Striper")
                {
                    charAI = "Gundalph";
                    preferedActionAI = 3;
                }
                else
                {
                    charAI = ChooseCharacter(choixAI);
                    preferedActionAI = 3;
                }
            }
            else if (half == 3)
            {
                if (BestOutOfThree(nbATKPlayerHalf, nbDefPlayerHalf, nbSpePlayerHalf) == nbDefPlayerHalf)
                {
                    preferedActionAI = 3;
                }
                else if (BestOutOfThree(nbATKPlayerHalf, nbDefPlayerHalf, nbSpePlayerHalf) == nbATKPlayerHalf)
                {
                    preferedActionAI = 2;
                }
                else if (BestOutOfThree(nbATKPlayerHalf, nbDefPlayerHalf, nbSpePlayerHalf) == nbSpePlayerHalf)
                {
                    preferedActionAI = 3;
                }

                switch (charPlayer)
                {
                    case "Erwan":
                        charAI = "Degolas";
                        break;

                    case "Rawrhirrim":
                        charAI = "Gymlit";
                        break;

                    case "Gymlit":
                        charAI = "Erwan";
                        break;

                    case "Degolas":
                        charAI = "Striper";
                        break;

                    case "Gundalph":
                        charAI = "Rawrhirrim";
                        break;

                    case "Striper":
                        charAI = "Gundalph";
                        break;
                }
            }
        }
        else if (difficultyLevelAI == 3 && half != 1)
        {
            if (half == 2)
            {
                switch (charPlayer)
                {
                    case "Erwan":
                        charAI = "Degolas";
                        break;

                    case "Rawrhirrim":
                        charAI = "Gymlit";
                        break;

                    case "Gymlit":
                        charAI = "Erwan";
                        break;

                    case "Degolas":
                        charAI = "Striper";
                        break;

                    case "Gundalph":
                        charAI = "Rawrhirrim";
                        break;

                    case "Striper":
                        charAI = "Gundalph";
                        break;
                }
            }
            else if (half == 3)
            {
                if (BestOutOfThree(nbATKPlayerHalf, nbDefPlayerHalf, nbSpePlayerHalf) == nbDefPlayerHalf)
                {
                    preferedActionAI = 3;
                }
                else if (BestOutOfThree(nbATKPlayerHalf, nbDefPlayerHalf, nbSpePlayerHalf) == nbATKPlayerHalf)
                {
                    preferedActionAI = 2;
                }
                else if (BestOutOfThree(nbATKPlayerHalf, nbDefPlayerHalf, nbSpePlayerHalf) == nbSpePlayerHalf)
                {
                    preferedActionAI = 3;
                }

                switch (charPlayer)
                {
                    case "Erwan":
                        charAI = "Gundalph";
                        break;

                    case "Rawrhirrim":
                        charAI = "Gundalph";
                        break;

                    case "Gymlit":
                        charAI = "Rawrhirrim";
                        break;

                    case "Degolas":
                        charAI = "Striper";
                        break;

                    case "Gundalph":
                        charAI = "Rawrhirrim";
                        break;

                    case "Striper":
                        charAI = "Rawrhirrim";
                        break;
                }
            }
            else
            {
                charAI = ChooseCharacter(choixAI);
            }
        }
        else
        {
            charAI = ChooseCharacter(choixAI);
            preferedActionAI = 0;
        }
    }
    while (charAI == charPlayer || (charAI == "Erwan" && charPlayer == "Degolas") || (charPlayer == "Erwan" && charAI == "Degolas"));

    return new Tuple<string, int>(charAI, preferedActionAI);
}

//Return the potion chosen by the Player
static string ChoosePotion(int choix)
{
    string potion = "";

    switch (choix)
    {
        case 1:
            potion = "Second Breakfast";
            break;

        case 2:
            potion = "Shting (the elven short-sword)";
            break;

        default:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Gollurn -- You need to choose a valid number, precious ! \n");
            Console.ResetColor();
            ChoosePotion(choix);
            break;
    }

    return potion;
}

//return a number knowing that one must have biggest probabilities to appear
static int FakeRandom(int numberToFake)
{
    int retour = 0;
    Random randomAI = new Random();
    int choix = randomAI.Next(1, 6);

    if (choix == 4 || choix == 5)
        retour = numberToFake;
    else
        retour = choix;

    return retour;
}


//Print the visual for the halves
static void PrintHalf(string half)
{
    Wait(0.5f);
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("         +----------------------+");
    Console.WriteLine("                 {0}", half);
    Console.WriteLine("         +----------------------+\n\n");
    Console.ResetColor();
}

//Print the main title
static void PrintTitle()
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("\n");
    Console.WriteLine("                                       ██████  ███    ██ ███████     ██████  ██ ███    ██  ██████      ████████  ██████      ██   ██ ██ ██      ██          ████████ ██   ██ ███████ ███    ███      █████  ██      ██      ");
    Console.WriteLine("                                      ██    ██ ████   ██ ██          ██   ██ ██ ████   ██ ██              ██    ██    ██     ██  ██  ██ ██      ██             ██    ██   ██ ██      ████  ████     ██   ██ ██      ██      ");
    Console.WriteLine("                                      ██    ██ ██ ██  ██ █████       ██████  ██ ██ ██  ██ ██   ███        ██    ██    ██     █████   ██ ██      ██             ██    ███████ █████   ██ ████ ██     ███████ ██      ██      ");
    Console.WriteLine("                                      ██    ██ ██  ██ ██ ██          ██   ██ ██ ██  ██ ██ ██    ██        ██    ██    ██     ██  ██  ██ ██      ██             ██    ██   ██ ██      ██  ██  ██     ██   ██ ██      ██      ");
    Console.WriteLine("                                       ██████  ██   ████ ███████     ██   ██ ██ ██   ████  ██████         ██     ██████      ██   ██ ██ ███████ ███████        ██    ██   ██ ███████ ██      ██     ██   ██ ███████ ███████ ");
    Console.WriteLine("\n");
    Console.ResetColor();
    Console.Write("\n\n");
}

//Print the endgame's texts
static Tuple<int, bool> EndGame(int pvPlayer, int pvAI, int half, string[] args)
{

    bool isOkayToProceedNextWave = false;

    if (pvPlayer <= 0 && pvAI > 0)
    {

        /*SoundPlayer musicPlayer = new SoundPlayer("Lost Time.wav");
        musicPlayer.Load();
        musicPlayer.PlayLooping();
        */
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Gollurn -- NooOoo ! You has lost it, precious ! *coughs*\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("(Press any key to continue...)");
        Console.ResetColor();
        Console.ReadKey();
        Console.WriteLine("");
        Console.Clear();

        //CREDITS
        Credits();
        Console.ReadKey();
        Console.WriteLine("");
        Console.Clear();
        PlayAgain(args);

    }
    else if (pvAI <= 0 && pvPlayer > 0 && half < 3)
    {

        //SHOWING TEXT
        if (half == 1) //to the 2nd half
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Now you are out of the Muria. You are tired, but the way still is so long...");
            Console.WriteLine("You cross the Latlarien forest, where elves help you to rest.");
            Console.WriteLine("");
            Wait(0.5f);
            Console.WriteLine("Before continuing your journey, they offer you a gift:");
            Console.WriteLine("a potion to help you when you think that all hope is gone.");
            Console.WriteLine("");
            Wait(0.5f);
            Console.ResetColor();
        }
        else if (half == 2) //to the last half
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("Surumen is defeated. He doesn't have any power now.");
            Console.WriteLine("So you let him behind you and continue your way along the river.");
            Console.WriteLine("");
            Wait(0.5f);
            Console.WriteLine("After a litle forest, you arrive to the foggy mountains.");
            Console.WriteLine("You follow Gollurn accross this labyrinth and find the dead's swamp.");
            Console.WriteLine("It's stinking moldy corps and the pressure of the ring makes you feeling like followwing the deads ...");
            Console.WriteLine("");
            Wait(0.5f);
            Console.WriteLine("...but you resist and pass this.");
            Console.WriteLine("");
            Wait(0.5f);
            Console.WriteLine("This is harder and harder to continue because the closer your are to the Meowrdur, the heavier is the ring...");
            Console.WriteLine("");
            Wait(0.5f);
            Console.WriteLine("You are now very close to the Meowrdor so you decide to rest before the last fight.");
            Console.WriteLine("");
            Wait(0.5f);
            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("\n(Press any key to continue...)");
        Console.ResetColor();
        Console.ReadKey();
        Console.WriteLine("");
        Console.Clear();

        PrintTitle();

        half++;
        isOkayToProceedNextWave = true;
        Console.ResetColor();

    }
    else if (pvAI <= 0 && pvPlayer <= 0)
    {

        /*SoundPlayer musicPlayer = new SoundPlayer("Lost Time.wav");
        musicPlayer.Load();
        musicPlayer.PlayLooping();
        */
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Gollurn -- They both died, isn't it, my sweet ? Now what can we do for the precious ?...\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("(Press any key to continue...)");
        Console.ResetColor();
        Console.ReadKey();
        Console.WriteLine("");
        Console.Clear();

        //CREDITS
        Credits();
        Console.ReadKey();
        Console.WriteLine("");
        Console.Clear();
        PlayAgain(args);
    }
    else if (pvAI <= 0 && pvPlayer > 0 && half == 3)
    {

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("(Press any key to continue...)");
        Console.ResetColor();

        Console.ReadKey();
        Console.WriteLine("");
        Console.Clear();

        /*SoundPlayer musicPlayer = new SoundPlayer("Epic Unease.wav");
        musicPlayer.Load();
        musicPlayer.PlayLooping();
        */
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n");
        Console.Write("\n");
        Console.Write("\n");
        Console.WriteLine("                                                                                  ██    ██ ██  ██████ ████████  ██████  ██████  ██    ██ ");
        Console.WriteLine("                                                                                  ██    ██ ██ ██         ██    ██    ██ ██   ██  ██  ██  ");
        Console.WriteLine("                                                                                  ██    ██ ██ ██         ██    ██    ██ ██████    ████   ");
        Console.WriteLine("                                                                                   ██  ██  ██ ██         ██    ██    ██ ██   ██    ██    ");
        Console.WriteLine("                                                                                    ████   ██  ██████    ██     ██████  ██   ██    ██    ");
        Console.ResetColor();

        //TEXT IF THE PLAYER WINS EVERYTHING

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("");
        Console.WriteLine("");
        Wait(1);
        Console.WriteLine("WHOUUUAAAA you win the fight against the great lord !!! Congratulations !!!");
        Wait(0.5f);
        Console.WriteLine("Now you run as fast as possible to the heart of the Mount Doom to destroy the precious !");
        Wait(0.5f);
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("(Press any key to continue...)");
        Console.ResetColor();
        Console.ReadKey();
        Console.WriteLine("");
        Console.Clear();

        //CREDITS
        Credits();
        Console.ReadKey();
        Console.WriteLine("");
        Console.Clear();
        PlayAgain(args);

    }
    return new Tuple<int, bool>(half, isOkayToProceedNextWave);
}

//restart the game if the player wants
static void PlayAgain(string[] args)
{
    string playAgain;
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("Gollurn -- Would you like to go back to the Shire or leave Puddle Earth ? (yes/no)");
    Console.ResetColor();
    playAgain = Console.ReadLine();
    Console.Write("\n");

    Console.ForegroundColor = ConsoleColor.Cyan;
    if (playAgain == "yes")
    {
        Console.Clear();
        Main(args);
    }
    else if (playAgain == "no")
    {
        Environment.Exit(0);
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Gollurn -- No precious ! Not like that ! Please enter again. *coughs*");
        Console.ResetColor();
        PlayAgain(args);
    }
}

//Print the credits
static void Credits()
{

    //CREDITS
    Console.Write("\n");
    Console.Write("\n");
    Console.Write("\n");
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("                                                                                   ██████ ██████  ███████ ██████  ██ ████████ ███████ ");
    Console.WriteLine("                                                                                  ██      ██   ██ ██      ██   ██ ██    ██    ██      ");
    Console.WriteLine("                                                                                  ██      ██████  █████   ██   ██ ██    ██    ███████ ");
    Console.WriteLine("                                                                                  ██      ██   ██ ██      ██   ██ ██    ██         ██ ");
    Console.WriteLine("                                                                                   ██████ ██   ██ ███████ ██████  ██    ██    ███████ \n\n");
    Console.ResetColor();

    Console.WriteLine("                                                                                  Lead Gameplay Programmer : Enki Bachelier");
    Console.WriteLine("                                                                                  Gameplay Programmers : Thibault Vincent & Diane Aveillan");
    Console.WriteLine("                                                                                  Sound Designer : Diane Aveillan");
    Console.WriteLine("                                                                                  Narrative Designers : Thibault Vincent & Diane Aveillan");

    Console.WriteLine("                                                                                  QA Testers (bug fixes) by :");
    Console.WriteLine("                                                                                  Enki Bachelier | Thibault Vincent | Diane Aveillan");

    Console.WriteLine("                                                                                  SOUND :\n");

    Console.WriteLine("                                                                                  I/ SOUND BACKGROUND");

    Console.WriteLine("                                                                                  \"Adventure Meme\"" + " Kevin MacLeod - incompetech.com");
    Console.WriteLine("                                                                                  \"Noise Attack\" Kevin MacLeod - incompetech.com");
    Console.WriteLine("                                                                                  \"8bit Dungeon Boss\" Kevin MacLeod(incompetech.com");
    Console.WriteLine("                                                                                  \"Video Dungeon Boss\" Kevin MacLeod(incompetech.com");
    Console.WriteLine("                                                                                  Licensed under Creative Commons: By Attribution 4.0 License");
    Console.WriteLine("                                                                                  http://creativecommons.org/licenses/by/4.0/");

    Console.WriteLine("                                                                                  II/ SFX");

    Console.WriteLine("                                                                                  https://freesound.org/people/ethanchase7744/sounds/439538/");
    Console.WriteLine("                                                                                  https://freesound.org/people/Eponn/sounds/547042/");
    Console.WriteLine("                                                                                  https://freesound.org/people/Cloud-10/sounds/647977/");

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("                                                                                      (Press any key to continue...)");
    Console.ResetColor();
    Console.Write("\n");
}
#endregion