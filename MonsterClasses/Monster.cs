using FantasyConsoleGame.HeroClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame.MonsterClasses
{
    public class Monster
    {
        // Declare monster variables
        public string Type { get; set; }
        public int Hp { get; set; }
        public int Dmg { get; set; }
        public int HitChance { get; set; }
        public bool Battle {  get; set; } // Checks if battle is over or not


        // METHODS

        // Monster battle
        public bool MonsterEncounter(Hero hero, Monster monster)
        {
            // Change to dark red (battle color)
            Console.ForegroundColor = ConsoleColor.DarkRed;

            // Set battle mode to true
            Battle = true;

            // Prints out encounter message
            Console.WriteLine($"\nA {monster.Type} appears!\n");
            Thread.Sleep(1000); // Wait 1 second

            // Battle loop
            while (Battle == true)
            {
                // Print out the hero and monsters health and damage stats
                hero.PrintBattleStats();
                MonsterPrintStats(monster);
                Thread.Sleep(1000); // Wait 1 second

                // Give user their options and save in variable Choice whcih is stored in the misc class
                Console.WriteLine($"[1]: Attack \n[2]: Heal [amount] potions \n[3]: Flee ({hero.FleeChance(monster)}% chance) ");
                Misc.Choice = int.Parse(Console.ReadLine());

                // Hero turn
                switch (Misc.Choice)
                {
                    // Choice [1]: Attack
                    case 1:
                        // Attack successful
                        if (hero.Attack() > Misc.Chance())
                        {
                            Console.WriteLine(hero.AttackPhraseSuccess());
                            Console.WriteLine($"{monster.Type} took {hero.Dmg} damage! \n");
                            Hp -= hero.Dmg;
                            Thread.Sleep(1500); // Wait 1,5 seconds
                        }
                        // Attack failed
                        else
                        {
                            Console.WriteLine(hero.AttackPhraseFail() + "\n");
                            Thread.Sleep(1500); // Wait 1,5 seconds
                        }
                        break;

                    // Choice [2]: Heal - NOT IMPLEMENTED
                    case 2:
                        Console.WriteLine("needs to be implemented");
                        break;

                    // Choice [3]: Flee - NOT IMPLEMENTED
                    case 3:
                        Console.WriteLine("needs to be implemented");
                        break;

                    // Invalid input - NOT IMPLEMENTED
                    default:
                        Console.WriteLine("Invalid choice. Please choose[1], [2], [3]");
                        break;
                }

                // Monster turn
                // Check if monster is alive or not. If monster is alive, continue. Else, end battle
                if (Hp > 0) 
                { 
                    Console.WriteLine($"The {monster.Type} attacks!\n");
                    Thread.Sleep(1000); // Wait 1 second

                    // Monster attack succesful
                    if (HitChance > Misc.Chance())
                    {
                        Console.WriteLine(MonsterAttackPhraseSuccess(monster));
                        Console.WriteLine($"You took took {Dmg} damage! \n");
                        hero.Hp -= Dmg;
                        Thread.Sleep(1500); // Wait 1,5 seconds
                    }
                    // Monster attack failed
                    else
                    {
                        Console.WriteLine(MonsterAttackPhraseFail(monster) + "\n");
                        Thread.Sleep(1500); // Wait 1,5 seconds
                    }
                }
                // If monster's health is below or equal to 0, end battle
                else
                {
                    // Prints a random battle victory phrase
                    Console.WriteLine(hero.BattleWonPhrase());

                    Battle = false;

                    //Change text color to green (adventure color) 
                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                    // returns false - as in game is not over, gameOver is false.
                    return false;
                }

                // Check if  hero's hp is below 0. If it is, end battle.
                if (hero.Hp < 0)
                {
                    // Prints a random deafeat phrase
                    Console.WriteLine(hero.BattleDefeatPhrase);

                    Battle = false;

                    //Change text color to gray (settings color)
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    // returns true - as in gameOver is true.
                    return true;
                }

            }

            // This was needed because the code wouldn't compile since it said that not all paths returned a value
            // However if I designed the code correctly (which I think I did) the above will loop
            // until either hero or monster dies
            return false;
        }

        // Selects which monster to spawn based on the spawn rates and level requirement
        public static Monster MonsterSelector(int level)
        {
            // Set spawn value 
            int spawnValue = Misc.Chance();

            // Initialize monster object
            Monster monster;

            // Selects which monster to spawn based on the spawn rates and level requirement
            if (spawnValue < 30 && level >= 1)
            {
                monster = new Wolf();
            }
            else if (spawnValue < 50 && level >= 1)
            {
                monster = new Bear();
            }
            else if (spawnValue < 68 && level >= 1)
            {
                monster = new Skeleton();
            }
            else if (spawnValue < 75 && level >= 2)
            {
                monster = new Wisp();
            }
            else if (spawnValue < 87 && level >= 2)
            {
                monster = new Goblin();
            }
            else if (spawnValue < 95 && level >= 3)
            {
                monster = new Ogre();
            }
            else if (spawnValue >= 95 && level >= 4)
            {
                monster = new Dragon();
            }
            else
            {
                monster = new Wolf();
            }

            // Returns the chosen monster
            return monster;
        }

        // Prints monsters health and damage
        void MonsterPrintStats(Monster monster)
        {
            Console.WriteLine($"{monster.Type}: Health: {Hp} Damage: {Dmg}");
        }

        // Returns a random success attack phrase for the monster
        string MonsterAttackPhraseSuccess(Monster monster)
        {
            // Gets a random value to choose which of the 5 success phrases to return 
            Random rnd = new Random();

            // Array of success phrases
            string[] attackPhrase = {
                "The monstrous foe's attack lands with brutal force, striking you and causing significant damage.",
                "The enemy's strike finds its mark, leaving you wounded and vulnerable.",
                $"With a menacing growl, the {monster.Type}'s claws find purchase, inflicting a painful blow on you.",
                "The monstrous creature's attack connects, and you reel from the impact.",
                "The enemy's assault is relentless, and you are unable to evade the attack, taking damage."
                };

            return attackPhrase[rnd.Next(0, 4)];
        }

        // Returns a random fail attack phrase for the monster
        string MonsterAttackPhraseFail(Monster monster)
        {
            // Gets a random value to choose which of the 5 success phrases to return 
            Random rnd = new Random();

            // Array of success phrases
            string[] attackPhrase = {
                "The monstrous creature's attack misses its target, leaving your hero unharmed.",
                $"You skillfully dodge the {monster.Type}'s strike, avoiding any damage.",
                $"The {monster.Type}'s attack goes wide, and you remain untouched by the assault.",
                $"Despite the {monster.Type}'s efforts, you manage to parry the blow, preventing any damage.",
                $"Your hero's agility and quick reflexes allow them to evade the {monster.Type}'s attack effortlessly."
                };

            return attackPhrase[rnd.Next(0, 4)];
        }
    }
}
