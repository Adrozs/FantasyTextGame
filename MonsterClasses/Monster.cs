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
        public int Level { get; set; }
        public int Hp { get; set; }
        public int HpMax { get; set; }
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

            // Initialize flee variable to false. We use this to check if flee attempt was successful to see if we end the battle
            bool flee = false;

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
                Console.WriteLine($"[1]: Attack \n[2]: Heal [amount] potions NOT IMPLEMENTED \n[3]: Flee ({hero.FleeChance(monster)}% chance)");
              
                Misc.EnsureCorrectChoice(1, 3); //Ensures user input is within selected numbers (1-3) and saves choice to Misc.Choice.

                // Hero turn
                switch (Misc.Choice)
                {
                    // Choice [1]: Attack
                    case 1:
                        // Attack successful
                        if (hero.Attack() > Misc.Chance())
                        {
                            Console.WriteLine(hero.AttackPhraseSuccess(monster));
                            Console.WriteLine($"{monster.Type} took {hero.Dmg} damage! \n");
                            Hp -= hero.Dmg;
                            Thread.Sleep(1500); // Wait 1,5 seconds
                        }
                        // Attack failed
                        else
                        {
                            Console.WriteLine(hero.AttackPhraseFail(monster) + "\n");
                            Thread.Sleep(1500); // Wait 1,5 seconds
                        }
                        break;

                    // Choice [2]: Heal - NOT IMPLEMENTED
                    case 2:
                        Console.WriteLine("needs to be implemented");
                        break;

                    // Choice [3]: Flee 
                    case 3:
                        // Returns true or false if you managed to escape the battle or not. Based on the FleeChance() calculation.
                        flee = hero.FleeAttempt(monster);
                        
                        // If we managed to flee, turn battle to false and return false
                        if (flee == true)
                        {
                            Battle = false;

                            return false; // returns false - as in game is not over, gameOver is false.
                        }
                            
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
                // Battle won
                // If monster's health is below or equal to 0, end battle
                else
                {
                    // Prints a random battle victory phrase
                    Console.WriteLine(hero.BattleWonPhrase(monster));

                    Console.WriteLine($"You gained {hero.GainXp(monster)} xp!");


                    Battle = false;

                    //Change text color to green (adventure color) 
                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                    // returns false - as in game is not over, gameOver is false.
                    return false;
                }
                // Battle lost
                // Check if  hero's hp is below 0. If it is, end battle.
                if (hero.Hp < 0)
                {
                    // Prints a random deafeat phrase
                    Console.WriteLine(hero.BattleDefeatPhrase(monster));

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
        public static Monster MonsterSelector(int heroLevel)
        {
            // Set spawn value 
            int spawnValue = Misc.Chance();

            // Initialize monster object
            Monster monster;

            // Selects which monster to spawn based on the spawn rates and level requirement
            if (spawnValue < 30 && heroLevel >= 1)
            {
                monster = new Wolf();
            }
            else if (spawnValue < 50 && heroLevel >= 1)
            {
                monster = new Bear();
            }
            else if (spawnValue < 68 && heroLevel >= 1)
            {
                monster = new Skeleton();
            }
            else if (spawnValue < 75 && heroLevel >= 2)
            {
                monster = new Wisp();
            }
            else if (spawnValue < 87 && heroLevel >= 2)
            {
                monster = new Goblin();
            }
            else if (spawnValue < 95 && heroLevel >= 3)
            {
                monster = new Ogre();
            }
            else if (spawnValue >= 95 && heroLevel >= 4)
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
            Console.WriteLine($"{monster.Type}: Health: {Hp}/{HpMax} Damage: {Dmg}");
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
                $"You skillfully dodge the {monster.Type.ToLower()}'s strike, avoiding any damage.",
                $"The {monster.Type.ToLower()}'s attack goes wide, and you remain untouched by the assault.",
                $"Despite the {monster.Type.ToLower()}'s efforts, you manage to parry the blow, preventing any damage.",
                $"Your hero's agility and quick reflexes allow them to evade the {monster.Type.ToLower()}'s attack effortlessly."
                };

            return attackPhrase[rnd.Next(0, 4)];
        }
    }
}
