using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using FantasyConsoleGame.HeroClasses;
using FantasyConsoleGame.MonsterClasses;

namespace FantasyConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // Have to create hero as null, otherwise program wont compile cause it can't ensure that hero will be created
            Hero hero;

            // Change color
            Console.ForegroundColor = ConsoleColor.DarkGray;

            // Intro
            Console.WriteLine("(faint whisper) \"Hey...\"");
            Thread.Sleep(1500); // Waits 1,5 seconds 
            Console.WriteLine("(faint whisper) \"Hey you there\"");
            Thread.Sleep(1500); // Waits 1,5 seconds 
            Console.WriteLine("(faint whisper) \"It's time to wake up..\"");
            Thread.Sleep(2000); // Waits 2 seconds 
            Console.WriteLine("(faint whisper) \"A dangerous journey awaits you\"\n");
            Thread.Sleep(2200); // Waits 2,2 seconds 


            // Choose hero
            Console.WriteLine("Who are you?");
            Console.WriteLine("" +
                "[1]: Knight - 100 HP - 20 Armour - 5  Damage \n" +
                "[2]: Wizard - 80  HP - 0  Armour - 8  Damage \n" +
                "[3]: Shadow - 50  HP - 10 Armour - 12 Damage");

            int heroSelection = int.Parse(Console.ReadLine());

            if (heroSelection == 1) 
            {
                hero = new Knight();
            }
            else if (heroSelection == 2)
            {
                hero = new Sorcerer();
            }
            else if (heroSelection == 3) 
            {
                hero = new Shadow();
            }
            else
            {
                Console.WriteLine("Invalid choice. Default hero Knight has been chosen.");
                hero = new Knight();
            }

                
            //Change text color
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            
            // Beginning story 
            Console.WriteLine("You awaken in a serene clearing within a Forest. \n" +
                "Tall, ancient trees surround you, their leaves glistening with an otherworldly glow. \n" +
                "The air is filled with a faint, magical hum.");
            Thread.Sleep(1000); // Wait 1 second

            Console.WriteLine("\nIt seems you have no recollection of who you are or what you were doing.");
            Console.WriteLine($"You figure that you can't lay here all day. You gather yourself, pick up your {hero.Weapon} and look around.");


            // Location 1 
            Console.WriteLine("[1]: The road continues in front of you.\n" +
                "[2]: To the left you see a glen. \n" +
                "[3]: On your right there's a marsh.");

            Misc.Choice = int.Parse(Console.ReadLine());

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
                default :
                    Console.WriteLine("Invalid choice. Please choose [1], [2], [3]");
                break;
            }


            // First battle before gamplay loop starts is forced
            Monster firstMonster = new Wolf();
            firstMonster.MonsterEncounter(hero, firstMonster);

            // ??
            // After battle, if successful, add 1 to hero.LocationsVisited.
            // After a certain LocationsVisited then something specific happens like camp / tavern, boss?


            bool gameOver = false; // Initialize as false to ensure gameplay loop starts. When this is switched to false, game ends

            // Random encounters 
            // Gameplay loop
            while (gameOver == false)
            {
                // user gets choice to go left, right or forward ?
                Console.WriteLine(
                "[1]: Continue on the path in front of you.\n" +
                "[2]: Venture to the left. \n" +
                "[3]: Travel to your right");
                Misc.Choice = int.Parse(Console.ReadLine());

                // Randomize a location to go to and text comes up describing location
                // Save current location to variable - OBS!!! Not sure what I'm gonna use CurrentLocation for yet?
                hero.CurrentLocation = Locations.GoToNextLocation();

                // Checks if there should be a battle, 65% chance for it to happen.
                if (Misc.BattleChance() == true)
                {
                    // Chooses a random monster based on spawn rates
                    // Uses that monster to start an encounter
                    // Encounter returns true if hero died and false if monster died - gameplay loop continues until hero dies
                    Monster monster = Monster.MonsterSelector(hero.Level);
                    gameOver = monster.MonsterEncounter(hero, monster);
                }
                

                //OBS varför det blir error 
                // Erroret kommer när det blir en battle. Problemet är med MonsterSelector, pga att den är static
                // Visual studio sa att vi skulle implementera coden här i botten på rad 160. men det funkar inte
                // blir bara not implementedexception.
                // Måste lista ut något sätt att kunna nå MonsterSelector från program.cs för det verkar ej gå som
                // static? Kan flytta den till misc men känns fel då allt monster är i Monster klassen. Fråga GTP

                // Battle ensures.
                // if victory, continue.
                // if dead, game over.

                // and repeat until dead

                // then we can modify to add xp, loot, items, levels, tavern/camp etc.
            }



        }


       
    }
}