using FantasyConsoleGame.MonsterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FantasyConsoleGame.HeroClasses
{
    public class Hero
    {
        // hej adrian imorgon
        // ifall jag glömt vad jag höll på med så tänkte jag börja lägga in alla variablar in i klassen
        // tänker mig att allt bör vara public get med private set och att det sen får sina default värden
        // i constructorn

        // lägg sen in alla phrases och attack metoder som har med heron att göra längre ner i klassen så håller
        // vi allt på ett ställe

        // Monster base class
        // efter det så tänkte jag göra detsamma för monster klassen. Skapa då en monster klass bara

        // Hero and Monster sub classes
        // när allt det är klart så kan du antingen börja leka med att implementera alla 3 heros som subklasser
        // eller kanske fler monster än "monster" la alla mina idéer i notion på olika monster. Subklasser på dom också

        // Monster encounters
        // Vissa monster som är lite svårare ska bara kunna mötas i högre level så när den gör en random check för
        // vilket monster vi möter så kolla if level = x för att möta detta monster liksom ja du fattar.
        // så man inte blir mosad på första encountern liksom xD

        // More locations
        // elller utöka spelet. Tänker mig att vi ber chat gpt bara göra massa locations som den gjorde igår
        // så kör vi bara att det helt är random. Lägg int typ 20 locations till att börja med som vi slumpar fram med en metod
        // make a location class to contain all locations and their text ?

        // Camp / Tavern
        // sen kan vi ha att vid vissa specifika tillfällen händer specifika grejer.
        // Typ att var 5e location så kan man antingen slå läger typ (65% chans) och då ha 3 val
        // 1 - sova och helas litegrann men det finns risk för ett monster encounter (rätt låg % kanske 10%)
        // 2 - att jaga och då få en chans (%) att hela mycket men också chans att inte hela alls.
        // 3 - stanna uppe natten men då otroligt låg chans för monster encounter (typ 1%)
        // eller istälelt för läger så kanske man hittar en Tavern (30% chans) och då ha 3 val
        // 1 - sova och helas fullt, ingen risk för monster encounter
        // 2 - handla hos en shop keeper för coins, man ska då kunna köpa saker som
        //      - xp potion (få x antal xp) för att levla upp
        //      - dmg enhancer(?) ökar damage med x antal, kanske typ 2-5?
        //      - armour ger hero armour som är separat från health men funkar på samma sätt
        //          armour går dock ner först och kan inte replenishas
        //      - health potions
        //      dessa ska då kosta x mycket pengar styck och shopkeepern kan ha fler 
        // 3 - ?
        // och (5% chans) att inget händer
        // detta har vi då koll på med locationCounter som ska öka 1 för varje location vi går till

        // Set encounters 
        // Även andra encounters som möjligen kan hända eller ska hända vid vissa milstolpar så att säga

        // Loot system
        // vill även implementera loot system. En chans att monstrena droppar saker som coins, health potions och
        // ibland bättre svärd och grejer. Kan be chatgpt göra en lista på 10 svärd, 10 spells och 10 (vad nu shadow använder)
        // så rankar vi dom och ger dom specifik damage (weaponDmg) som då plussas ihop med (dmg) för en damage boost
        // dom kan då droppas och köpas i shoppen. Svårare monster, högre chans att droppa bättre grejer.
        // Kan säkert be chatgpt lösa drop rates procenten åt oss.

        // Level system
        // Sen också level systemet. Bara någon formula som är liksom health och dmg ökar med x varje level. Förmodligen
        // bra att det ökar exponentiellt alltså mer och mer ju högre level vi är inte bara en fast summa? men det får
        // lite playtesting avgöra. Kan börja med fast summa. 
        // får väl köra något som kolla if xp = x för vad level up nu ska vara (t.ex 100) efter varje monster encounter
        // så levlar den up level++ och sätter xp = 0 och börjar om. I framtiden kan vi öka så att varje level kräver mer
        // och mer xp om det känns som att det behövs.

        // Xp system
        // går väl hand i hand med loot och level systemen men att man får random mängd xp per dödat monster
        // beroende på vilket monster så får man mer eller mindre xp
        // kanske att man får en mindre mängd xp för varje location? men känns kanske lite onödigt

        // MAX HEALTH
        // lägg till så att det finns en variable HpMax i både Hero och Monster.
        // Ändra sen i PrintStats metoderna så att den skriver ut Hp/HpMax tex 83/100.
        // Ser 100ggr bättre och snyggare ut!


        // Hero variables
        public int Level { get; private set; }
        public int Xp { get; private set; }
        public int Coin { get; set; }
        public int Hp { get; set; }
        public int HpMax { get; set; }
        public int Armour { get; set; }
        public int Dmg { get; set; }
        public int WeaponDmg { get; set; }
        public string Weapon { get; private set; }

        // Location variables
        public string CurrentLocation { get; set; }
        public int LocationsVisited { get; set; }


        // Sets the Heros default values when spawning in
        internal Hero()
        {
            // Declare default values for the Hero

            // Level / shop values
            Level = 1;
            Xp = 0;
            Coin = 45;

            // Combat values
            Hp = 100;
            HpMax = Hp;
            Armour = 0;
            Dmg = 10;
            WeaponDmg = 0; // Adds to total damage 
            Weapon = "Sword";

            // Location values
            CurrentLocation = "forest"; // Starting location 
            LocationsVisited = 0; // Keeps track of how many locations Hero has been at - used to trigger certain events
        }


        // HERO METHODS

        // Prints all hero's stats inc level and xp
        // Put this in hero class
        public void PrintAllStats()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine();
            Console.WriteLine("{---Stats---}");
                        
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(Level);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Xp: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Xp);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Health: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Hp);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Armour: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Armour);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Damage: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Dmg);
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("------------");


            Thread.Sleep(1000); // Waits 1 second

            //Change back text color (adventure color)
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        // Prints hero's stats for the battles, only hp and dmg
        public void PrintBattleStats()
        {
            Console.Write($"You: | Health: {Hp}/{HpMax} | Damage: {Dmg} |");
            Console.BackgroundColor = ConsoleColor.Black; // Reset background color to black - needed to do this before printing new line otherwise color messes up on next row
            Console.WriteLine(); // Print new line
        }

        // Returns how big chance player has to run from an enemy based on a formula (CHANGE THIS, bad calculation)
        public int FleeChance(Monster monster)
        {
            int fleeChance = (Hp / monster.Hp) * 10;

            // If the chance to flee is more than 100, cap it at 100.
            if (fleeChance > 100)
                fleeChance = 100;

            return fleeChance;
        }

        public bool FleeAttempt(Monster monster)
        {
            // If Chance is less than FleeChance hero succeeds at escaping, so we return true
            if (Misc.Chance() < FleeChance(monster))
            {
                FleePhraseSuccess(monster); // Prints out a phrase of how hero succeeded to flee
                
                //Change back text color (adventure color)
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                
                return true; // Flee attempt succeeded
            }
            // Else if chance was more than the chance to flee, hero failed at escaping, so we return false
            else
            {
                FleePhraseFail(monster); // Prints out a phrase of how hero failed to flee
                
                //Change back text color (adventure color)
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                return false; // Flee attempt failed
            }
        }

        public int GainXp(Monster monster)
        {
            Random rnd = new Random(); // Create new random object

            int xpGained;

            int randomXp = rnd.Next(5,30); // Get a random value between 5 and 30

            int lvlDiff = Math.Abs(Level - monster.Level); // Gets the difference in level between hero and monster


            // If the level difference is x multiply xp by
            switch (lvlDiff)
            {
                case 1:
                    // If the monster is 1 level lower than you, you get 80% of the xp
                    xpGained = (int)(randomXp * 0.80);
                    Xp += xpGained; // Add xp gained to the Hero's stats

                    return xpGained;
                case 2:
                    // If the monster is 2 levels lower than you, you get 60% of the xp
                    xpGained = (int)(randomXp * 0.60);
                    Xp += xpGained; // Add xp gained to the Hero's stats

                    return xpGained;
                case 3:
                    // If the monster is 3 levels lower than you, you get 40% of the xp
                    xpGained = (int)(randomXp * 0.40);
                    Xp += xpGained; // Add xp gained to the Hero's stats

                    return xpGained;
                case 4:
                    // If the monster is 4 levels lower than you, you get 20% of the xp
                    xpGained = (int)(randomXp * 0.20); 
                    Xp += xpGained; // Add xp gained to the Hero's stats

                    return xpGained;
                default:
                    // If the enemy is the same level as you return full xp
                    xpGained = (int)(randomXp);
                    Xp += xpGained; // Add xp gained to the Hero's stats

                    return randomXp;

            }
         }

        // Caluclates the chance for Hero to succeed at attack
        public int Attack()
        {
            // Base percent chance to succeed at attack
            int baseChance = 70;

            // Save's chance to a variable so we can use it in if statement below (as to not call it again and get another value)
            int chance = Misc.Chance();

            // Hero always has base hit chance but has a possibility of gaining higher
            // if chance is more than base percentage then that becomes the hit chance
            if (chance > baseChance)
            {
                return chance;
            }
            else
            {
                return baseChance;
            }
        }


        // Returns a random successfull attack phrase
        public string AttackPhraseSuccess(Monster monster)
        {
            // Gets a random value to choose which of the 5 success phrases to return 
            Random rndAtt = new Random();

            // Array of success phrases
            string[] attackPhrase = {
                $"With a swift and precise strike, your weapon finds its mark, dealing a solid blow to the {monster.Type.ToLower()}.",
                $"Your attack lands true, causing the {monster.Type.ToLower()} to stagger back, wounded.",
                $"A resounding hit! The {monster.Type.ToLower()} reels from the impact of your hero's strike.",
                $"Your weapon slices through the air, connecting with the {monster.Type.ToLower()} and inflicting damage.",
                $"The {monster.Type.ToLower()}'s defenses crumble before your skill, and they suffer a powerful hit."
                };

            return attackPhrase[rndAtt.Next(0, 4)];
        }

        // Returns a random fail attack phrase
        public string AttackPhraseFail(Monster monster)
        {
            // Gets a random value to choose which of the 5 success phrases to return 
            Random rndAtt = new Random();

            // Array of 5 fail phrases
            string[] attackPhrase = {
                "Your attack misses its mark, leaving you vulnerable for a moment.",
                $"The {monster.Type.ToLower()} deftly evades your strike, leaving them unharmed.",
                $"Despite efforts, your attack goes wide, and the {monster.Type.ToLower()} remains unscathed.",
                $"The {monster.Type.ToLower()} skillfully parries your blow, preventing any damage.",
                $"Your attack falls short, and the {monster.Type.ToLower()} remains untouched by the assault."
                };

            return attackPhrase[rndAtt.Next(0, 4)];
        }

        // Returns a random battle victory phrase
        public void BattleWonPhrase(Monster monster)
        {
            // Gets a random value to choose which of the 4 success phrases to return
            Random rnd = new Random();

            // Array of success phrases
            string[] battleWonPhrase = {
                $"With a final, determined blow, you vanquish the monstrous {monster.Type.ToLower()}, their lifeless form crumpling to the ground.",
                $"As the dust settles, you stand victorious over the fallen {monster.Type.ToLower()}, your {Weapon.ToLower()} stained with the creature's blood.",
                $"Your relentless courage pay off as you defeat the {monster.Type.ToLower()}, a triumphant roar echoing through the battlefield.",
                $"The {monster.Type.ToLower()} lets out a final, defeated growl before succumbing to your might, leaving the {CurrentLocation} safe once more."
                };

            // Returns a random phrase from 0 to the length of the array (-1 as array.Length counts 0 as 1)
            Console.Write(battleWonPhrase[rnd.Next(0, battleWonPhrase.Length - 1)]);
            Console.BackgroundColor = ConsoleColor.Black; // Changes color back to black before new line, otherwise color bleeds to next row
            Console.WriteLine();
        }

        // Returns a random battle death phrase
        public void BattleDefeatPhrase(Monster monster)
        {
            // Gets a random value to choose which of the 4 success phrases to return
            Random rnd = new Random();

            // Array of success phrases
            string[] battleDefeatPhrase = {
                $"Despite your valiant effort, you fall in battle, your life force extinguished by the relentless {monster.Type.ToLower()}.\n",
                "You fight bravely to the end but succumb to your injuries, a somber silence falling over the battlefield.\n",
                "As the battle rages on, your strength wanes, and you collapse, your journey coming to a tragic end.\n",
                "In the face of overwhelming odds, you meet your demise, your sacrifice not in vain but a heavy loss to the realm.\n"
                };

            // Returns a random phrase from 0 to the length of the array (-1 as array.Length counts 0 as 1)
            Console.Write(battleDefeatPhrase[rnd.Next(0, battleDefeatPhrase.Length - 1)]);
            Console.BackgroundColor = ConsoleColor.Black; // Changes color back to black before new line, otherwise color bleeds to next row
            Console.WriteLine();
        }

        public void FleePhraseSuccess(Monster monster)
        {
            // Gets a random value to choose which of the 4 success phrases to return
            Random rnd = new Random();

            // Array of success phrases
            string[] fleePhraseSuccess = {
                $"With a burst of speed, you manage to break free from the battle and escape the pursuing {monster.Type.ToLower()}, leaving it behind in the dust.\n",
                $"Your quick thinking and agility pay off as you successfully evade the {monster.Type.ToLower()}, disappearing into the safety of the wilderness\n",
                $"In a desperate bid for escape, you find a hidden path and disappear into the dense underbrush, leaving the {monster.Type.ToLower()} bewildered and frustrated.\n",
                $"With a final backward glance, you dash away from the battle, leaving the {monster.Type.ToLower()} behind, unable to catch up\n"
                };

            Console.WriteLine(fleePhraseSuccess[rnd.Next(0, fleePhraseSuccess.Length - 1)]);
        }

        public void FleePhraseFail(Monster monster)
        {
            // Gets a random value to choose which of the 4 success phrases to return
            Random rnd = new Random();

            // Array of fail phrases
            string[] fleePhraseFail = {
                $"Despite your hero's best efforts, the {monster.Type.ToLower()} proves too fast and persistent, preventing their escape.\n",
                $"You attempt to flee but stumble, allowing the relentless {monster.Type.ToLower()} to catch up and continue the battle.\n",
                $"In a heart-pounding moment, your escape attempt fails, and the pursuing {monster.Type.ToLower()} corners you, ready to strike.\n",
                $"The {monster.Type.ToLower()} is unrelenting, and your desperate flee attempt ends in failure, with the creature closing in for another attack.\n"
                };

            Console.WriteLine(fleePhraseFail[rnd.Next(0,fleePhraseFail.Length - 1)]);
        }


    }
}
