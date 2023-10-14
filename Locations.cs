using FantasyConsoleGame.HeroClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame
{
    static internal class Locations
    {
        // Array of 17 different locations descriptions user can encounter
        static string[] locationDescriptions =
            {
                "As you step into a once-majestic castle, you're greeted by crumbling stone walls and overgrown vines. \nSigns of its former grandeur now lost to time.",
                "You're enveloped by the cold, damp air and the flicker of torchlight, as you enter a foreboding dungeon.",
                "A dense mist hangs over you as you enter an eerie graveyard.\nTombstones stand like silent sentinels, creating an atmosphere filled with solemnity and mystery.",
                "As you enter the temple, elaborate carvings and shimmering symbols adorn its walls, \nhinting at ancient rituals of the past and the secrets they hold.",
                "You find yourself standing at the edge of a dormant volcano's crater. \n You gaze down at a sea of glowing lava far below, a breathtaking and perilous sight.",
                "You stumble upon ancient ruins. \nInside, crumbled walls and weathered artifacts tell the story of a once-great civilization, now reduced to remnants of history.",
                "Torches cast eerie shadows on the maze-like walls as you enter this this subterranean cave.",
                "Abandoned fishing nets and rods lay scattered on the sandy shore as you enter this seaside village, \nwhere the echoes of a vibrant community still linger.",
                "Upon entering a tomb, you're met with sarcophagi and walls covered in ancient runes, \npreserving the memories and mysteries of those long gone.",
                "A serene waterfall flows into a crystal-clear pool as you discover this hidden oasis, \ntucked away in a secluded glen, a tranquil and enchanting retreat.",
                "Chaos and remnants of a fierce battle greet you in this abandoned goblin campsite, \nwith crude weapons and the remains of slain creatures covering the ground.",
                "As you venture into a swamp, murky waters and twisted trees create an ominous atmosphere, \nconcealing the secrets that lie beneath the surface.",
                "Treetop dwellings and elegant bridges hint at the presence of elusive beings as you enter this enchanted grove, \nwhere nature and magic intertwine.",
                "You see sun-bleached bones and tattered flags that mark this pirate cove, \na haven for scoundrels, where tales of adventure and treachery echo in the salty breeze.",
                "Stepping onto a magical, floating island through a hidden portal, \nyou find yourself in a place suspended between the realms, where gravity defies expectation.",
                "Upon entering the cave, an eerie blue glow bathes you in an otherworldly light, \nrevealing ancient, mystical symbols on the walls, their meaning shrouded in mystery.",
                "You find yourself in a serene forest clearing, \nwith sunlight filtering through the leaves above, creating a tranquil and idyllic setting."
            };

        // Array of the 17 different locations names
        static string[] locationName =
            {
                "Abandoned castle", "Dark dungeon", "Haunted cemetery", "Mystical temple", "Volcanic crater",
                "Ancient ruins", "Underground cave", "Fishing village", "Forgotten tomb", "Hidden waterfall",
                "Goblin camp", "Treacherous swamps", "Enchanted grove", "Pirate cove", "Floating island",
                "Enchanted cave", "Forest clearing"
            };

        // Selects a random location from the locationDescription array to print out for the user
        public static string GoToNextLocation()
        {
            // Saves a random number between 0 and the amount of locations in the locationDescriptions array
            Random rnd = new Random();
            int number = rnd.Next(0, locationDescriptions.Length - 1);
            
            // Prints out the location description
            Console.WriteLine(locationDescriptions[number]);
            
            // Return the chosen locations name
            return locationName[number];
        }

        public static void TimeForRestCheck(Hero hero)
        {
            // If locations visited is divsable by 5, trigger tavern/camp method
            if (hero.LocationsVisited % 5 == 0)
            {
                if (Misc.Chance() <= 52) // 52% chance to make camp
                {
                    // Camp method
                    // Locations.GoToCamp(); // NOT IMPLEMENTED
                }
                else if (Misc.Chance() <= 98) // 46% chance to find the Town
                {
                    // Tavern method
                    Locations.GoToTown(hero);
                }
                else // 2% chance 
                {
                    // Nothing happens
                }
            }
        }

        public static void GoToTown(Hero hero)
        {
            // Variable to make sure options continue to loop until user goes to sleep
            bool dayOver = false;

            // Town & Tavern description
            Console.WriteLine("With the day's light waning, you notices a modest small town nestled nearby.");
            Console.WriteLine("As you appeoach the town a warm glow spills from the windows of an inviting tavern,  its thatched roof and welcoming hearth exuding a sense of comfort and solace.");
            Console.WriteLine("The soft glow of lanterns spills from the windows, promising a peaceful night's rest within its cozy rooms. ");
            Console.WriteLine("The laughter of patrons and the strumming of a lute drift through the door, inviting you to take respite from your journey and enjoy the company of fellow travelers. \n");
            // General store description
            Console.WriteLine("Adjacent to the tavern,  an intricately carved sign swinging gently overhead catches your attention.");
            Console.WriteLine("The sign reads \"General Store\". The scent of exotic spices and fine leather wafts from within, promising a treasure trove of goods.\n");

            // Re-promt user every time they choose to see their stats (option 3) 
            // So that they still can go between all locations
            do
            {   
                // Town square
                // Promt user with options
                Console.WriteLine("[1]: Go to the Tavern");
                Console.WriteLine("[2]: Go to the General Store");
                Console.WriteLine("[3]: (See your stats) ");

                // Ensures user chooses 1,2 or 3 and saves it in Misc.Choice
                Misc.EnsureCorrectChoice(1, 3);

                // Went inside Tavern
                if (Misc.Choice == 1) 
                {
                        // Description of tavern's inside
                        Console.WriteLine("Inside, the flickering light of candles dances on the rough-hewn walls, " +
                            "\ncasting a cozy ambiance that beckons the hero to take a seat at one of the sturdy wooden tables. ");
                        Console.WriteLine("The innkeeper gestures toward a menu. As if silently asking you what you would like to do.");
                    
                    // Re-promt user everytime they choose to see their stats
                    do
                    {
                        // Promt user with options
                        Console.WriteLine("[1]: [End day] Rest for the night (+25 HP)");
                        Console.WriteLine("[2]: [10 Coins] Purchase a beer (-5 Health, +2 Damage for 3 encounters)");
                        Console.WriteLine("[3]: Go backto the Town square");
                        Console.WriteLine("[4]: (See your stats) ");

                        // Ensures user chooses 1-4 and saves it in Misc.Choice
                        Misc.EnsureCorrectChoice(1, 4);

                        // User chose to end day and sleep
                        if (Misc.Choice == 1)
                        {
                            // If hp gained from resting goes over max hp, then just set hp to max.
                            if (hero.Hp + 25 > hero.HpMax)
                            {
                                hero.Hp = hero.HpMax;
                            }
                            // if not then just increase hp with the value
                            else
                            {
                                hero.Hp += 25; // Increase hp with 25
                            }

                            // Day is over, break out of loop and continue the rest of the code
                            dayOver = true;
                            break;
                        }
                        // User chose to buy a beer
                        else if (Misc.Choice == 2)
                        {
                            // Checks if hero has enough coin
                            if (hero.Coin >= 10)
                            {
                                hero.Coin -= 10; // Remove 10 coin
                                hero.Hp -= 5; // Decrease hp with 5
                                //hero.DmgBoost += 2; // Increase temporary damage boost //NOT IMPLEMENTED - DECREASE NEED SOMETHING TO TRACK IT SO WE CAN REMOVE IT IN X ENCOUNTERS
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough coin");
                            }
                        }
                        // User went back to town square
                        else if (Misc.Choice == 3)
                        {
                            continue; // do nothing and just continue the loop to re-promt user
                        }
                        // User chose to see their stats
                        else if (Misc.Choice == 4)
                        {
                            // Prints out hero's stats
                            hero.PrintAllStats();
                            Console.WriteLine(); // New line
                        }
                    }
                    while (Misc.Choice == 4);

                }
                // Went inside General Store
                else if (Misc.Choice == 2) 
                {
                    // Description of General Store's inside
                    //...
                    //...

                    // Re-promt user as long as they don't choose to go back to the Town square
                    do
                    {
                        // Promt user with options
                        Console.WriteLine("[1]: [15 Coins] Purchase Health Potion (+10 Health when used)");
                        Console.WriteLine("[2]: [30 Coins] Purchase Weapon (+5 Damage)");
                        Console.WriteLine("[3]: [20 Coins] Purchase Armour (???)");
                        Console.WriteLine("[4]: Go back to the Town square");
                        Console.WriteLine("[5]: (See your stats) ");

                        // Ensures user chooses 1-5 and saves it in Misc.Choice
                        Misc.EnsureCorrectChoice(1, 5);

                        // User chose to buy health potion
                        if (Misc.Choice == 1)
                        {
                            // Change so that this item no longer can be purchased. Perhaps so that It's not an option anymore
                            // And it just says "sold out" or somehting

                            hero.HealthPotions++; // Increase health potions with 1
                            hero.Coin -= 15; // Remove coins
                        }
                        // User chose to buy the weapon
                        else if (Misc.Choice == 2)
                        {
                            // Change so that this item no longer can be purchased. Perhaps so that It's not an option anymore
                            // And it just says "sold out" or somehting

                            hero.Coin -= 30; // Remove coin

                            //hero.Weapon = ??? // figure out how to implement so that the it becomes weapon
                            //hero.Dmg += hero.WeaponDmg ??

                            // THIS IS TEMPORARY JUST TO DO SOMETHING WHILE HERE UNTIL ALL FEATURES IMPLEMENTED
                            // WHEN CHANGING WEAPON IT SHOULD ADD "WeaponDmg" TO "Dmg" INSTEAD.
                            hero.Dmg += 5;
                        }
                        // User chose to buy armour
                        else if (Misc.Choice == 3)
                        {
                            // Change so that this item no longer can be purchased. Perhaps so that It's not an option anymore
                            // And it just says "sold out" or somehting

                            // Not really sure what armour should do yet..?
                            Console.WriteLine("Not implemented armour yet lmao [Coming soon]");
                        }
                        // User went back to the town square
                        else if (Misc.Choice == 4)
                        {
                            continue; // do nothing and just continue the loop to re-promt user from the town square
                        }
                        // User chose to see their stats
                        else if (Misc.Choice == 5)
                        {
                            // Prints out hero's stats
                            hero.PrintAllStats();
                            Console.WriteLine(); // New line
                        }
                    }
                    while (Misc.Choice != 4);

                }
                // Display stats
                else
                {
                    // Prints out hero's stats
                    hero.PrintAllStats();
                    Console.WriteLine(); // New line
                }
            }
            while (dayOver != true);

            // Hero goes to sleep and story can continue with more encounters

            

        }
    }
}
