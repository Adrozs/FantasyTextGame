using FantasyConsoleGame.HeroClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            // Create 2 separate AudioPlayer objects. One to handle the music and one to handle SFX. This is so that SFX and music can overlap
            AudioPlayer musicPlayer = new AudioPlayer(); 
            AudioPlayer sfxPlayer = new AudioPlayer();

            // Play battle music
            musicPlayer.PlayAudio("Battle", true);

            // Set battle mode to true
            Battle = true;

            // Initialize flee variable to false. We use this to check if flee attempt was successful to see if we end the battle
            bool flee = false;

            //Change text color to battle color
            Console.ForegroundColor = ConsoleColor.DarkRed;

            // Prints out encounter message
            Console.WriteLine($"\nA {monster.Type} appears!\n");
            Thread.Sleep(1000); // Wait 1 second

            // Battle loop
            while (Battle == true)
            {
                // Print out the hero and monsters health and damage stats

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                hero.PrintBattleStats();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                MonsterPrintStats(monster);

                // Default battle color
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.Black;

                // Give user their options and save in variable Choice whcih is stored in the misc class
                Console.WriteLine($"[1]: Attack \n[2]: Heal [amount] potions NOT IMPLEMENTED \n[3]: Flee ({hero.FleeChance(monster)}% chance)");
              
                Misc.EnsureCorrectChoice(1, 3); //Ensures user input is within selected numbers (1-3) and saves choice to Misc.Choice.
                Thread.Sleep(800); // Waits 0,8 seconds

                // Hero turn
                switch (Misc.Choice)
                {
                    // Choice [1]: Attack
                    case 1:
                        // Attack successful
                        if (hero.Attack() > Misc.Chance())
                        {
                            sfxPlayer.PlayAudio("Damage"); // Play damage sound

                            Console.WriteLine(hero.AttackPhraseSuccess(monster));

                            Console.Write($"{monster.Type} took ");
                            Console.ForegroundColor = ConsoleColor.Red; // Changes text color to highlight the damage
                            Console.Write(hero.Dmg);

                            Console.ForegroundColor = ConsoleColor.DarkRed; // Changes text color back 
                            Console.WriteLine(" damage! \n");

                            Hp -= hero.Dmg;
                            Thread.Sleep(1000); // Wait 1,5 seconds
                        }
                        // Attack failed
                        else
                        {
                            sfxPlayer.PlayAudio("Block"); // Play attack blocked sound
                           
                            Console.WriteLine(hero.AttackPhraseFail(monster) + "\n");
                            Thread.Sleep(1000); // Wait 1,5 seconds
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
                            //musicPlayer.StopAudio(); // Stops battle music from playing
                            musicPlayer.PlayAudio("LevelUp"); // Play victory sound (levelup sound temporary to test it)

                            Battle = false;

                            return false; // returns false - as in game is not over, gameOver is false.
                        }
                            
                        break;
                }

                // MONSTER TURN
                // Check if monster is alive or not. If monster is alive, continue. Else, end battle
                if (Hp > 0) 
                { 
                    Console.WriteLine($"The {monster.Type} attacks!\n");
                    Thread.Sleep(800); // Wait 0,8 seconds

                    // Monster attack succesful
                    if (HitChance > Misc.Chance())
                    {
                        sfxPlayer.PlayAudio("HeroHurt"); // Play damage sound

                        Console.WriteLine(MonsterAttackPhraseSuccess(monster));

                        Console.Write($"You took ");

                        Console.ForegroundColor = ConsoleColor.Red; // Changes text to highlight it
                        Console.Write(Dmg);
                        Console.ForegroundColor = ConsoleColor.DarkRed; // Changes text color back
                        Console.WriteLine(" damage! \n");
                     
                        hero.Hp -= Dmg;

                        Thread.Sleep(1000); // Wait 1 seconds
                    }
                    // Monster attack failed
                    else
                    {
                        sfxPlayer.PlayAudio("Block"); // Play attack blocked sound
                        Console.WriteLine(MonsterAttackPhraseFail(monster) + "\n");
                        Thread.Sleep(1000); // Wait 1 second
                    }
                }
                // Battle won
                // If monster's health is below or equal to 0, end battle
                else
                {
                    musicPlayer.PlayAudio("LevelUp"); // Play victory sound (levelup sound temporary to test it)


                    // Prints a random battle victory phrase
                    Console.ForegroundColor = ConsoleColor.Gray;
                    hero.BattleWonPhrase(monster);

                    Thread.Sleep(1500); // Waits 1,5 seconds

                    // Prints out how much xp was gained with some highlighted text
                    // GainXp calculates how much xp hero gains
                    Console.ForegroundColor = ConsoleColor.DarkYellow; // Changes text color 
                    Console.Write("You gained ");

                    Console.ForegroundColor = ConsoleColor.Yellow; // Changes text color to highlight xp
                    Console.Write(hero.GainXp(monster));

                    Console.ForegroundColor = ConsoleColor.DarkYellow; // Changes text color back
                    Console.WriteLine(" xp! \n");

                    //Change text color to adventure
                    Misc.ChangeTextColor("Adventure");

                    Thread.Sleep(2000); // Wait for audio to finnish playing

                    Battle = false; // Battle is over

                    // returns false - as in game is not over, gameOver is false.
                    return false;
                }
                // Battle lost
                // Check if  hero's hp is below 0. If it is, end battle.
                if (hero.Hp < 0)
                {
                    // Prints a random deafeat phrase
                    hero.BattleDefeatPhrase(monster);

                    Battle = false;

                    //Change text color to default
                    Misc.ChangeTextColor("Default");
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
            Console.Write($"{monster.Type}: | Health: {Hp}/{HpMax} | Damage: {Dmg} |");
            Console.BackgroundColor = ConsoleColor.Black; // Reset background color to black - needed to do this before printing new line otherwise color messes up on next row
            Console.WriteLine(); // Print new line
        }

        // Returns a random success attack phrase for the monster
        string MonsterAttackPhraseSuccess(Monster monster)
        {
            // Gets a random value to choose which of the 5 success phrases to return 
            Random rnd = new Random();

            // Array of success phrases
            string[] attackPhrase = {
                $"The {monster.Type.ToLower()}'s attack lands with brutal force, striking you and causing significant damage.",
                $"The {monster.Type.ToLower()}'s strike finds its mark, leaving you wounded and vulnerable.",
                $"With a menacing growl, the {monster.Type.ToLower()}'s claws find purchase, inflicting a painful blow on you.",
                $"The {monster.Type.ToLower()}'s attack connects, and you reel from the impact.",
                $"The {monster.Type.ToLower()}'s assault is relentless, and you are unable to evade the attack, taking damage."
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
                $"The {monster.Type.ToLower()}'s attack misses its target, leaving your hero unharmed.",
                $"You skillfully dodge the {monster.Type.ToLower()}'s strike, avoiding any damage.",
                $"The {monster.Type.ToLower()}'s attack goes wide, and you remain untouched by the assault.",
                $"Despite the {monster.Type.ToLower()}'s efforts, you manage to parry the blow, preventing any damage.",
                $"Your hero's agility and quick reflexes allow them to evade the {monster.Type.ToLower()}'s attack effortlessly."
                };

            return attackPhrase[rnd.Next(0, 4)];
        }
    }
}
