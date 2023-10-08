using FantasyConsoleGame.MonsterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            Console.WriteLine($"Stats: Level: {Level} \nXp: {Xp} \nHealth: {Hp} \nArmour: {Armour} \nDamage: {Dmg}");
        }

        // Prints hero's stats for the battles, only hp and dmg
        public void PrintBattleStats()
        {

            Console.WriteLine($"Hero: Health: {Hp} Damage: {Dmg}");
        }

        // Returns how big chance player has to run from an enemy based on a formula
        public int FleeChance(Monster monster)
        {
            return Hp * Dmg / (monster.Hp * monster.Dmg) * 10;
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
        public string AttackPhraseSuccess()
        {
            // Gets a random value to choose which of the 5 success phrases to return 
            Random rndAtt = new Random();

            // Array of success phrases
            string[] attackPhrase = {
                "With a swift and precise strike, your weapon finds its mark, dealing a solid blow to the target.",
                "Your attack lands true, causing the target to stagger back, wounded.",
                "A resounding hit! The enemy reels from the impact of your hero's strike.",
                "Your weapon slices through the air, connecting with the target and inflicting damage.",
                "The enemy's defenses crumble before your skill, and they suffer a powerful hit."
                };

            return attackPhrase[rndAtt.Next(0, 4)];
        }

        // Returns a random fail attack phrase
        public string AttackPhraseFail()
        {
            // Gets a random value to choose which of the 5 success phrases to return 
            Random rndAtt = new Random();

            // Array of 5 fail phrases
            string[] attackPhrase = {
                "Your attack misses its mark, leaving them vulnerable for a moment.",
                "The enemy deftly evades your hero's strike, leaving them unharmed.",
                "Despite efforts, your attack goes wide, and the target remains unscathed.",
                "The target skillfully parries your blow, preventing any damage.",
                "Your attack falls short, and the enemy remains untouched by the assault."
                };

            return attackPhrase[rndAtt.Next(0, 4)];
        }

        // Returns a random battle victory phrase
        public string BattleWonPhrase()
        {
            // Gets a random value to choose which of the 4 success phrases to return
            Random rnd = new Random();

            // Array of success phrases
            string[] battleWonPhrase = {
                "With a final, determined blow, you vanquish the monstrous foe, their lifeless form crumpling to the ground.\n",
                $"As the dust settles, you stand victorious over the fallen beast, your {Weapon.ToLower()} stained with the creature's blood.\n",
                "Your relentless courage pay off as you defeat the monster, a triumphant roar echoing through the battlefield.\n",
                $"The monster lets out a final, defeated growl before succumbing to your might, leaving the {CurrentLocation} safe once more.\n"
                };
            
            // Returns a random phrase from 0 to the length of the array (-1 as array.Length counts 0 as 1)
            return battleWonPhrase[rnd.Next(0, battleWonPhrase.Length - 1)];
        }

        // Returns a random battle death phrase
        public string BattleDefeatPhrase()
        {
            // Gets a random value to choose which of the 4 success phrases to return
            Random rnd = new Random();

            // Array of success phrases
            string[] battleDefeatPhrase = {
                "Despite your valiant effort, you fall in battle, your life force extinguished by the relentless enemy.\n",
                "You fight bravely to the end but succumb to your injuries, a somber silence falling over the battlefield.\n",
                "As the battle rages on, your strength wanes, and you collapse, your journey coming to a tragic end.\n",
                "In the face of overwhelming odds, you meet your demise, your sacrifice not in vain but a heavy loss to the realm.\n"
                };

            // Returns a random phrase from 0 to the length of the array (-1 as array.Length counts 0 as 1)
            return battleDefeatPhrase[rnd.Next(0, battleDefeatPhrase.Length - 1)];
        }


    }
}
