using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Media;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;

namespace ProjectOneRingToKillThemAll
{
    class Program
    {
        static void Main(string[] args)
        {

            

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            #region Player's Choice of Character

            //print all characters available with their details
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Wait(0.5f);
            Console.WriteLine("1 -- Rawrhirrim :   7 of Health,  3 of ATK, Special is 'Ring's Fury'           -> returns all damages suffered during the turn");
            Console.WriteLine("2 -- Erwan      :   8 of Health,  1 of ATK, Special is 'Lembus (elvish bread)' -> regain 2 of Health");
            Console.WriteLine("3 -- Gymlit     :   10 of Health, 2 of ATK, Special is 'Ring of Power'         -> lose 1 of Health but gains 1 of ATK for the turn");
            Console.WriteLine("4 -- Degolas    :   9 of Health,  1 of ATK, Special is 'Nuzgûl's curse'        -> steal one Health for himself from the enemy");
            Console.WriteLine("5 -- Gundalph   :   9 of Health,  1 of ATK, Special is 'BUUUURN'               -> inflict 1 of damage during 3 turn (can be combined)");
            Console.WriteLine("6 -- Striper    :   8 of Health,  2 of ATK, Special is 'Mines of Muria'        -> inflict between 0 to 4 of ATK (random)\n\n");
            Wait(0.5f);
            Console.ResetColor();

            //asking the player his choice of character
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Gollurn -- Please choose your destiny : ");
            Console.ResetColor();

            //in order to avoid a wrong character entry (a non-int) from the player
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    errorTryCatch = 0;
                    playerChoiceChar = int.Parse(Console.ReadLine());
                    Console.ResetColor();

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    errorTryCatch = 1;
                    Console.ResetColor();
                    Console.Write("\n");

                    //Console.WriteLine(ex.Message); //that's to debug
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Gollurn -- Huh, what's that, precious ? Nasty little humansies always say rubbish things. Tell us !");
                    Console.Write("Gollurn -- Please choose your destiny : ");
                    Console.ResetColor();
                }

                //in order to avoid a wrong character entry (an int out of bounds) from the player
                if ((playerChoiceChar < 1 || playerChoiceChar > 6) && errorTryCatch == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    errorTryCatch = 1;
                    Console.ResetColor();

                    Console.Write("\n");

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Gollurn -- You can't be \"nothing\", precious ! *coughs* Tell us !");
                    Console.Write("Gollurn -- Please choose your destiny : ");
                    Console.ResetColor();
                }
            }

            while (errorTryCatch == 1);

            //associate the corresponding character and its details (PV, SPE, ATK)
            charPlayer = ChooseCharacter(playerChoiceChar);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\nGollurn -- {0}, you now play as {1} !\n\n", playerName, charPlayer);
            Console.ResetColor();
            spePlayer = dicSpeChar[charPlayer];
            pvPlayer = dicHealthChar[charPlayer];
            atkPlayer = dicATKChar[charPlayer];

            #endregion

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            #region Difficulty Level of the AI

            //choice by the player
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Wait(0.5f);
            Console.WriteLine("Level of difficulty :\n");
            Console.WriteLine("1 -- Easy stroll in the Shire");         //pure random
            Console.WriteLine("2 -- You shall not pass !");             //acts accordingly the previous actions of the Player (Puddle Earth) and his character (Meowrdor)
            Console.WriteLine("3 -- RUN, YOU FOOLS");                   //A better version of "You shall not pass!" and the AI has a chance in Meowrdor 
            Wait(0.5f);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\nGollurn -- Your choice : ");
            Console.ResetColor();

            //in order to avoid a wrong difficulty entry (a non-int) from the player
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    errorTryCatch = 0;
                    difficultyLevelAI = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    errorTryCatch = 1;
                    //Console.WriteLine(ex.Message); //That is for debug
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Gollurn -- No, no, no... You can't fool us ! We knows you has it, precious. Tell us, tell us the level !\n");
                    Console.Write("Gollurn -- Your choice : ");
                    Console.ResetColor();
                }
                //in order to avoid a wrong difficulty entry (an int out of bounds) from the player
                if ((difficultyLevelAI < 1 || difficultyLevelAI > 3) && errorTryCatch == 0)
                {

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    errorTryCatch = 1;
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Gollurn -- Fool of a Took ! Choose or walk away, precious !\n");
                    Console.Write("Gollurn -- Your choice : ");
                    Console.ResetColor();
                }
            }
            while (errorTryCatch == 1);
            Console.WriteLine("\n");
            Wait(0.5f);
            Console.WriteLine();
            #endregion

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            #region Story texts before Half 1

            //FIRST HISTORY TEXT
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You have been invited to Rivandel, a well known elvish place, to discuss about the futur of Puddle Earth.");
            Console.WriteLine("Indeed, the strongest weapons of our all time ennemy has been found and we now all need to gather & agree on what we should do next !");
            Console.WriteLine("");
            Wait(0.5f);
            Console.WriteLine("That's why you chose to accept this invitation and see this wary matter with your own eyes !");
            Console.WriteLine("");
            Wait(0.5f);
            Console.WriteLine("In your journey, you pass through Izengarden, Surumen's homeland.");
            Console.WriteLine("All is destroyed, the young trees and the oldest ones too have peerished...");
            Console.WriteLine("");
            Wait(0.5f);
            Console.WriteLine("The sadness grows inside your heart and now you are sure of Surumen's betrail !");
            Console.WriteLine("You aim to avenge all that have died & travel as fast as you can to let your allies know of the situation. That is how the company was born.");
            Console.WriteLine("");
            Wait(0.5f);
            Console.WriteLine("During the council, it has been shown that we effectively are in possession of The one Ring of Power...");
            Console.WriteLine("... and it has been decided to destroy it, for destroying it will also be the Lord of Darkness's demise.");
            Console.WriteLine("");
            Wait(0.5f);
            Console.WriteLine("You travel very discretly and have found yourself ahead of the \"Mines of Muria\", an ancient dwarf place, now filled with evil creatures of all kinds.");
            Console.WriteLine("After a few days into the mines, one of your friends (a clumsy Took) dropped heavy items on the ground -- which awoke a Balgor...");
            Console.WriteLine("... a very ancient creature of past ages...");
            Console.WriteLine("");
            Wait(0.5f);

            //to let the player read to his own rythm
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("(Press any key to continue...)");
            Console.ResetColor();

            Console.ReadKey();
            Console.WriteLine("");
            Console.Clear();

            PrintTitle();

            #endregion

            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            #region Game Loop
            while (pvPlayer > 0 && pvAI > 0)
            {
                #region Texts and choice of AI character at the start of a new half
                if (isBeginningOfNewHalf)
                {

                    PrintHalf(listHalves[half - 1]);
                    Wait(0.5f);

                    //reinitialisation of the burn effect (non-cumulable over the different halves)
                    allBurnActive.Clear();

                    //choice of the AI character
                    Tuple<string, int> choixcharAI = new Tuple<string, int>("", 0);
                    choixcharAI = ChoiceCharAI(difficultyLevelAI, charPlayer, half, nbATKPlayerHalf, nbDefPlayerHalf, nbSpePlayerHalf);
                    charAI = choixcharAI.Item1;
                    preferedActionAI = choixcharAI.Item2;

                    speAI = dicSpeChar[charAI];
                    pvAI = dicHealthChar[charAI];
                    atkAI = dicATKChar[charAI];

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Gollurn -- You are going to fight a {0} (SPE : {1}), controled by a {2} (I hope you like things crispy).\n\n", charAI, dicSpeDescription[speAI], allNameAI[half - 1]);
                    Console.ResetColor();
                    #endregion

                    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                    #region Halves Music

                    if (half == 1)
                    {
                        /*SoundPlayer boss = new SoundPlayer("Boss.wav");
                        boss.Load();
                        boss.PlayLooping();
                        */
                    }
                    else if (half == 2)
                    {
                        /*SoundPlayer dungeonBoss = new SoundPlayer("Dungeon Boss.wav");
                        dungeonBoss.Load();
                        dungeonBoss.PlayLooping();
                        */

                    }
                    else if (half == 3)
                    {
                        /*SoundPlayer noiseAttack = new SoundPlayer("Noise Attack.wav");
                        noiseAttack.Load();
                        noiseAttack.PlayLooping();
                        */
                        pvPlayer = dicHealthChar[charPlayer];
                    }

                    #endregion

                    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                    #region Choice of the potion during the second half and Texts of half 2
                    if (half == 2)
                    {
                        Wait(0.5f);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Gollurn -- A brilliant victory that was, precious ! But it looks like you just killed the big boss's pet. Quick ! You find some potions on the ground - your pocketsies are full but can still take one (because we said so). Choose wisely !");
                        Console.WriteLine("Gollurn -- Of course, you can keep the potion for later, don't have to use it all if you don't need to just yet. We are no monsters you know !\n");
                        Console.ResetColor();

                        Console.WriteLine("\n");
                        Wait(0.5f);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("Available potions :\n\n");

                        //print available potions
                        Console.WriteLine("1 -- Second Breakfast : give you back all of your health !\n");
                        Console.WriteLine("2 -- Shting (the elven short-sword) : attack 2 points !\n");
                        Wait(0.5f);
                        Console.ResetColor();

                        //choice of potion
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("Your choice : ");
                        Console.ResetColor();

                        //in order to avoid a wrong potion entry (a non-int) from the player
                        do
                        {
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                errorTryCatch = 0;
                                playerChoicePotion = int.Parse(Console.ReadLine());
                                Console.ResetColor();
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                errorTryCatch = 1;
                                Console.ResetColor();

                                //console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("Gollurn -- AAAAAAH ! *coughs* \n");
                                Console.Write("Your choice : ");
                                Console.ResetColor();
                            }

                            //in order to avoid a wrong potion entry (an int out of bounds) from the player
                            if ((playerChoicePotion < 1 || playerChoicePotion > 2) && errorTryCatch == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                errorTryCatch = 1;
                                Console.ResetColor();

                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("Gollurn -- You..don't want a potion, precious ? Rubbish little humansies again... if you don't choose, we takes it! \n");
                                Console.Write("Your choice : ");
                                Console.ResetColor();
                            }
                        }
                        while (errorTryCatch == 1);

                        Console.WriteLine("\n");
                        //update of the potion
                        playerActivePotion = ChoosePotion(playerChoicePotion);
                        listPotions.Remove(ChoosePotion(playerChoicePotion));

                        //story of half 2
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("");
                        Console.WriteLine("{0} wants to follow the Endwin river but a white magician appears ! :o", playerName);
                        Console.WriteLine("");
                        Wait(0.5f);
                        Console.WriteLine("Surumen : \"You little fool... what were you thinking by doing this quest which don't concern you at all !\"");
                        Console.WriteLine("Surumen : \"Give it to me. It would be wise, my friend.\"");
                        Console.WriteLine("");
                        Wait(0.5f);
                        Console.WriteLine("{0} : \"Never ! I know you have betrayed us to serve your own purpose !\"", playerName);
                        Console.WriteLine("{0} : \"I saw what you have done along your territory, you have gone out of the right way a long time ago now.\"", playerName);
                        Console.WriteLine("{0} : \"Let me do what you'll never be able to do !\"", playerName);
                        Console.WriteLine("");
                        Wait(0.5f);
                        Console.WriteLine("Surumen : \"No one can be against the lord of drakness and his will.\"");
                        Console.WriteLine("Surumen : \"And it's way so fool now I'm with him !\"");
                        Console.WriteLine("");
                        Wait(0.5f);
                        Console.WriteLine("Surumen : \"Now you will taste a little piece of this great power and die !!!\"");
                        Console.WriteLine("");
                        Wait(0.5f);
                        Console.ResetColor();

                        //to let the player read to his own rythm
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("(Press any key to continue...)");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.WriteLine();
                    }

                    //used for the damages of Shting
                    if (playerActivePotion == "Shting (the elven short-sword)")
                        isShting = true;

                    isBeginningOfNewHalf = false;
                }
                #endregion

                //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                #region Player and AI's details
                //AI's name choice
                string nameAI = allNameAI[half - 1];

                Wait(0.5f);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("    {0} [{1}] |  {2} [{3}]", nameAI, charAI, playerName, charPlayer);
                Console.WriteLine("    {0} PV, {1}  ATK | {2} PV, {3} ATK", pvAI, atkAI, pvPlayer, atkPlayer);
                Console.WriteLine("    SPE : {0} |  SPE : {1}\n\n", speAI, spePlayer);
                Console.Write("\n");

                #endregion

                #region Player and AI's choices of action

                //player choice
                Wait(0.5f);
                Console.WriteLine("Choose an action :");
                Console.WriteLine("1 - Attack the enemy !");
                Console.WriteLine("2 - Defend yourself from evil !");
                Console.ResetColor();
                Wait(0.5f);

                //to avoid the cumulation of over 3 active burn, we restrict the use of the special of Gundalph
                if (charPlayer == "Gundalph" && allBurnActive.Count == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Gollurn -- You're too hot, precious ! Do something else !");
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("3 - {0}", spePlayer);
                    Console.ResetColor();
                }

                //printing the options for potions if it still exists
                if (half >= 2 && playerActivePotion != "null" && playerActivePotion != "empty")
                {
                    Wait(0.5f);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("4 - {0}", playerActivePotion);
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\nGollurn - Your choice : ");
                Console.ResetColor();

                //in order to avoid a wrong action entry (a non-int) from the player
                do
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        errorTryCatch = 0;
                        playerChoiceAction = int.Parse(Console.ReadLine());
                        Console.WriteLine("\n");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        errorTryCatch = 1;
                        Console.ResetColor();

                        //console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Gollurn -- My precious must be deaf (or not know how to read). Try again ! \n");
                        Console.Write("Gollurn - Your choice : ");
                        Console.ResetColor();
                    }


                    //in order to avoid a wrong action entry (an int out of bounds) from the player
                    if ((playerChoiceAction < 1 || (playerChoiceAction > 3 && (playerActivePotion == "null" || playerActivePotion == "empty")) || playerChoiceAction > 4 || (playerChoiceAction == 4 && half == 1)) && errorTryCatch == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        errorTryCatch = 1;
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("*coughs* Semwise Gamgeet -- PO-TAY-TOES ! Boil 'em, mash 'em, stick 'em in a stew (can they hear us, precious ?)... Lovely big golden chips with a nice piece of fried fish.");
                        Console.WriteLine("Gollurn -- Keep your nasty little chips & tell us !\n");
                        Console.Write("Gollurn - Your choice : ");
                        Console.ResetColor();
                    }
                }
                while (errorTryCatch == 1);
                Console.WriteLine("\n");
                //AI choice of action if the difficulty chosen is over 1 and the half over 1
                Wait(0.5f);
                if (preferedActionAI == 1)
                {
                    actionAI = FakeRandom(1);
                }
                else if (preferedActionAI == 2)
                {
                    actionAI = FakeRandom(2);
                }
                else if (preferedActionAI == 3)
                {
                    actionAI = FakeRandom(3);
                }
                else
                {
                    actionAI = randomAI.Next(1, 4);
                }

                Random choixRand = new Random();

                //AI choice of action and character for the third difficulty 
                if (choixRand.Next(0, 4) < 3 && half == 3 && difficultyLevelAI == 3)
                {
                    if (playerChoiceAction == 2 && charPlayer != "Gundalph")
                    {
                        if (charAI == "Gundalph" && allBurnActive.Count != 3)
                            actionAI = 3;
                        else
                            actionAI = 1;
                    }
                    else if (playerChoiceAction == 2 && charPlayer == "Gundalph")
                    {
                        actionAI = 2;
                    }
                    else
                    {
                        switch (charPlayer)
                        {
                            case "Erwan":
                                if (allBurnActive.Count != 3)
                                    actionAI = 3;
                                else
                                    actionAI = 1;
                                break;

                            case "Rawrhirrim":
                                actionAI = 2;
                                break;

                            case "Gymlit":
                                if (playerChoiceAction == 1)
                                    actionAI = 1;
                                else
                                    actionAI = 3;
                                break;

                            case "Degolas":
                                if (playerChoiceAction == 1)
                                    actionAI = 3;
                                else
                                    actionAI = 1;
                                break;

                            case "Gundalph":
                                if (allBurnActive.Count == 3)
                                    actionAI = 3;
                                else
                                    actionAI = 1;
                                break;

                            case "Striper":
                                if (playerChoiceAction == 1)
                                    actionAI = 1;
                                else
                                    actionAI = 3;
                                break;
                        }
                    }

                }

                //for the special attack when AI is a Gundalph (no cumulation over 3)
                if (charAI == "Gundalph" && allBurnActive.Count == 3)
                    actionAI = randomAI.Next(1, 3);

                #endregion

                //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                #region Player and AI's effective actions
                Tuple<int, int, int, int> nbActionPlayer = new Tuple<int, int, int, int>(0, 0, 0, 0);
                Tuple<int, int, int, int> nbActionAI = new Tuple<int, int, int, int>(0, 0, 0, 0);

                //printing the player's action to the screen
                Console.WriteLine();
                nbActionPlayer = TextActions(playerChoiceAction, playerName, playerActivePotion, charPlayer, allBurnActive);

                //used for cleverness of the AI
                nbATKPlayerHalf += nbActionPlayer.Item1;
                nbDefPlayerHalf += nbActionPlayer.Item2;
                nbSpePlayerHalf += nbActionPlayer.Item3;

                playerChoiceAction = nbActionPlayer.Item4;

                //SFX for the player
                if (playerChoiceAction == 3)
                {

                    var reader = new NAudio.Wave.Mp3FileReader("Epic Special Attack Player.mp3");   //ready for lecture
                    var waveOut = new NAudio.Wave.WaveOutEvent();
                    waveOut.Init(reader);                                                           //init of the reader
                    waveOut.Play();                                                                 //play the sound

                }

                Wait(1);

                //printing the AI's action to the screen
                nbActionAI = TextActions(actionAI, "AI", playerActivePotion, charAI, allBurnActive);
                actionAI = nbActionAI.Item4;

                //SFX for the AI
                if (actionAI == 3)
                {
                    var reader = new NAudio.Wave.Mp3FileReader("IA Hit Impact.mp3");
                    var waveOut = new NAudio.Wave.WaveOutEvent();
                    waveOut.Init(reader);
                    waveOut.Play();

                }

                //will be used to sum every action on the two entities
                int finalImpactOnAI = 0;
                int finalImpactOnPlayer = 0;

                //holds first the impact of the Player's action on himself and second on the AI
                sumActionTurnPlayer = actionPlayer(playerChoiceAction, charPlayer, playerActivePotion, dicATKChar);
                //holds first the impact of AI's action on itself and second on the Player
                sumActionTurnAI = actionPlayer(actionAI, charAI, playerActivePotion, dicATKChar);

                //we recover the state of the potion at the 2nd and 3rd half
                if (half >= 2)
                {
                    playerActivePotion = sumActionTurnPlayer.Item3;
                }

                //the final impact on each entity
                finalImpactOnPlayer += sumActionTurnPlayer.Item1 + sumActionTurnAI.Item2;
                finalImpactOnAI += sumActionTurnPlayer.Item2 + sumActionTurnAI.Item1;

                #endregion

                //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                #region Defense vs Ring of Power
                //when Ring of Power is used, it can pierce through defenses
                if ((playerChoiceAction == 2) && (charAI == "Gymlit" && actionAI == 3))
                {
                    finalImpactOnPlayer += 1;
                }
                if ((actionAI == 2) && (charPlayer == "Gymlit" && playerChoiceAction == 3))
                {
                    finalImpactOnAI += 1;
                }

                #endregion

                //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                #region BUUUURN

                //we remove the oldest burn (if its 3 turns is over)
                if ((allBurnActive.Count >= 1) && (allBurnActive[0] + 3 == countTurn))
                    allBurnActive.RemoveAt(0);

                //we add the damages to the burned entity and add new burns (if wanted)
                if (charAI == "Gundalph")
                {

                    if (actionAI == 3)
                        allBurnActive.Add(countTurn);
                    finalImpactOnPlayer -= allBurnActive.Count;

                }
                if (charPlayer == "Gundalph")
                {

                    if (playerChoiceAction == 3 && allBurnActive.Count != 3)
                        allBurnActive.Add(countTurn);
                    finalImpactOnAI -= allBurnActive.Count;
                }

                #endregion

                //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                #region Ring's Fury

                //if Ring's Fury is used, the entity returns all damages to the ennemy
                if ((playerChoiceAction == 3 && charPlayer == "Rawrhirrim"))
                {
                    finalImpactOnAI += sumActionTurnAI.Item2;
                    finalImpactOnAI -= allBurnActive.Count;
                }
                if ((actionAI == 3 && charAI == "Rawrhirrim"))
                {
                    finalImpactOnPlayer += sumActionTurnPlayer.Item2;
                    finalImpactOnPlayer -= allBurnActive.Count;
                }


                if (playerChoiceAction == 2 && actionAI != 3)
                    finalImpactOnPlayer = 0;
                if (actionAI == 2 && playerChoiceAction != 3)
                    finalImpactOnAI = 0;

                #endregion

                //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                #region Defense (except if Ring of Power is used)

                if ((playerChoiceAction == 2) && (actionAI == 3) && (charAI != "Gymlit"))
                    finalImpactOnPlayer = 0;
                if ((actionAI == 2) && (playerChoiceAction == 3) && (charPlayer != "Gymlit"))
                    finalImpactOnAI = 0;

                //if shting is used, we pierce through the defense
                if (playerChoiceAction == 4 && isShting)
                {
                    finalImpactOnAI -= 2;
                    isShting = false;
                }

                #endregion

                //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                //we update the healths
                pvAI += finalImpactOnAI; //add -10 to cheat
                pvPlayer += finalImpactOnPlayer;

                //without going further than the limit set at the beginning
                if (pvAI > dicHealthChar[charAI])
                    pvAI = dicHealthChar[charAI];
                if (pvPlayer > dicHealthChar[charPlayer])
                    pvPlayer = dicHealthChar[charPlayer];

                countTurn++;

                //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                #region Possible ending
                //to avoid displaying negative values
                if (pvPlayer < 0)
                    pvPlayer = 0;
                if (pvAI < 0)
                    pvAI = 0;

                //if one of the health is down to 0, we print the final messages 
                if (pvAI * pvPlayer == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Wait(0.5f);
                    Console.WriteLine("    {0} [{1}] |  {2} [{3}]", nameAI, charAI, playerName, charPlayer);
                    Console.WriteLine("    {0} PV, {1}  ATK | {2} PV, {3} ATK", pvAI, atkAI, pvPlayer, atkPlayer);
                    Wait(0.5f);
                    Console.ResetColor();

                    Tuple<int, bool> tupleEnd = new Tuple<int, bool>(0, false);
                    tupleEnd = EndGame(pvPlayer, pvAI, half, args);

                    half = tupleEnd.Item1;
                    isBeginningOfNewHalf = tupleEnd.Item2;

                    //if the player won and wants/can proceed to the next half
                    if (isBeginningOfNewHalf)
                        pvAI = 20;

                }
                #endregion
            }
            #endregion





        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}
