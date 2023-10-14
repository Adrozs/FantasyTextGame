using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using FantasyConsoleGame.HeroClasses;
using FantasyConsoleGame.MonsterClasses;
using NAudio.Wave;

namespace FantasyConsoleGame
{

    internal class Program
    {

        static void Main(string[] args)
        {

            // Create a audioPlayer to handle sounds and music
            AudioPlayer audioPlayer = new AudioPlayer();

            // Have to create hero as null, otherwise program wont compile cause it can't ensure that hero will be created
            Hero hero;

            // Change color
            Console.ForegroundColor = ConsoleColor.DarkGray;

            // Intro (COMMENTED TO SKIP WHEN TESTING)
            //Console.WriteLine("(faint whisper) \"Hey...\"");
            //Thread.Sleep(2000); // Waits 2 seconds 
            //Console.WriteLine("(faint whisper) \"Hey you there\"");
            //Thread.Sleep(2100); // Waits 2,1 seconds 
            //Console.WriteLine("(faint whisper) \"It's time to wake up..\"");
            //Thread.Sleep(2200); // Waits 2,2 seconds 
            //Console.WriteLine("(faint whisper) \"A dangerous journey awaits you\"\n");

            //Thread.Sleep(1000); // Waits 1 second

            // Play intro background music
            audioPlayer.PlayAudio("Intro");

            Thread.Sleep(1500); // Waits 1,5 seconds 


            // Choose hero
            Console.WriteLine("Who are you?");
            Console.WriteLine(
                "[1]: Knight - 100 HP - 20 Armour - 5  Damage \n" +
                "[2]: Wizard - 80  HP - 0  Armour - 8  Damage \n" +
                "[3]: Shadow - 50  HP - 10 Armour - 12 Damage");

            // Ensures user enters a value between the two values 1-3. And saves user input to Misc.Choice 
            Misc.EnsureCorrectChoice(1, 3);

            if (Misc.Choice == 1) 
            {
                hero = new Knight();
            }
            else if (Misc.Choice == 2)
            {
                hero = new Sorcerer();
            }
            else if (Misc.Choice == 3)  
            {
                hero = new Shadow();
            }
            // Need an else at the bottom cause otherwise it complains that hero not guaranteed to not be null
            else 
            {
                hero = new Knight();
            }
                
            //Change text color
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            
            // Beginning story 
            Console.WriteLine(
                "You awaken in a serene clearing within a Forest. \n" +
                "Tall, ancient trees surround you, their leaves glistening with an otherworldly glow. \n" +
                "The air is filled with a faint, magical hum.");
            Thread.Sleep(1000); // Wait 1 second

            Console.WriteLine("\nIt seems you have no recollection of who you are or what you were doing.");
            Console.WriteLine($"You figure that you can't lay here all day. You gather yourself, pick up your {hero.Weapon.ToLower()} and look around.");


            // Location 1 
            Console.WriteLine(
                "[1]: The road continues in front of you.\n" +
                "[2]: To the left you see a glen. \n" +
                "[3]: On your right there's a marsh.");

            // Ensures user enters a value between the two values 1-3. And saves user input to Misc.Choice 
            Misc.EnsureCorrectChoice(1, 3);

            // Print continuation of the story depending on the users input and change location
            switch (Misc.Choice)
            {
                case 1:
                    Console.WriteLine("You decide to follow the well-trodden forest road that meanders deeper into the woods. \nThe path is dappled with sunlight, and the distant sound of a flowing river can be heard.");
                    hero.CurrentLocation = "forestRoad";
                    break;
                case 2:
                    Console.WriteLine("Venturing to the left, you enter the Whispering Glen. Tall, slender trees line the path, \ntheir leaves whispering ancient secrets. Mysterious mist hangs low, and the atmosphere is tinged with a sense of mystery.");
                    hero.CurrentLocation = "glen";
                    break;
                case 3:
                    Console.WriteLine("You choose to go right, towards the Misty Marsh. " +
                        "\nThis area is shrouded in a dense, eerie fog that conceals what lies within. \nThe ground is damp and squelchy, and strange, glowing plants illuminate the way.");
                    hero.CurrentLocation = "marsh";
                    break;
            }

            // Initialize as false to ensure gameplay loop starts. When this is switched to false, game ends
            bool gameOver = false; 

            // First battle before gamplay loop starts is forced
            Monster firstMonster = new Wolf();

            audioPlayer.StopAudio(); // Stops background music from playing so battle music can start

            //
            gameOver = firstMonster.MonsterEncounter(hero, firstMonster);

            // Player didn't die in first battle play background music 
            if (gameOver == false)
                audioPlayer.PlayAudio("Journey", true);

            // Gameplay loop
            while (gameOver == false)
            {


                // Checks if hero's been at enough locations (5) for a rest event to trigger (tavern/camp)
                Locations.TimeForRestCheck(hero);
                
                //ADDING THIS FOR GAMEPLAY TESTING REASONS - FORCES TOWN ENCOUNTER ON 1ST LOOP
                hero.LocationsVisited = 5;

                


                // Loop this until user chooses something else than option 4
                do
                {
                    // user gets choice to go left, right or forward ?
                    Console.WriteLine(
                    "[1]: Continue on the path in front of you.\n" +
                    "[2]: Venture to the left. \n" +
                    "[3]: Travel to your right \n" +
                    "[4]: (See your stats) ");

                    // Ensures user enters a value between the two values 1-4. 
                    // Saves user input to Misc.Choice as well
                    Misc.EnsureCorrectChoice(1, 4);

                    // If user chooses option 4, print out all their stats
                    if (Misc.Choice == 4)
                    {
                        hero.PrintAllStats();
                    }

                } while (Misc.Choice == 4);

                // Randomize a location to go to and text comes up describing location
                // Save current location to variable - OBS!!! Not sure what I'm gonna use CurrentLocation for yet?
                hero.CurrentLocation = Locations.GoToNextLocation();
                hero.LocationsVisited++; 

                // Checks if there should be a battle, 65% chance for it to happen.
                if (Misc.BattleChance() == true)
                {
                    audioPlayer.StopAudio();

                    // Chooses a random monster based on spawn rates
                    // Uses that monster to start an encounter
                    // Encounter returns true if hero died and false if monster died - gameplay loop continues until hero dies
                    Monster monster = Monster.MonsterSelector(hero.Level);
                    gameOver = monster.MonsterEncounter(hero, monster);

                    // Player didn't die in battle, play background music again and repeat gameplay loop
                    if (gameOver == false)
                        audioPlayer.PlayAudio("Journey", true);
                    // Else if Player did die in battle
                    else if (gameOver == true)
                    {
                        Console.WriteLine("YOU DIED\n");
                        Console.WriteLine("-GAME OVER SCREEN NOT IMPLEMENTED. \nTURN OFF GAME AND RE-OPEN TO PLAY AGAIN-");
                        
                        // Need to implement game over text.
                        // Thinking just text that come out 1 sentence at a time with Thread.wait in between.
                        // something something your heroic journet come to an end, the evil won something something
                        // and dramatic music
                    }

                    // LevelUp() method HERE after battle
                    // Call LevelUp method - should check if xp > required xp for next level 
                    // Add method that checks if xp is more than level requirement and then LevelUp() which increases 
                    // stats and removes how much that level required from hero.Xp (NOT RESET IT)


                }
                // If BattleChance() was false and no battle occured - high chance() to spawn a chest
                
                else
                {
                    // "You found a chest" it contained [random] amount of coins!
                    // So that the hero can earn money to shop for new gear

                    // not implemented yet, just continue in code for now
                    continue;
                }


                // Add xp, loot, items, levels, tavern/camp etc later.
            }



        }       
    }
}