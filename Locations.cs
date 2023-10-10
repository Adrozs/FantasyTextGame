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
    }
}
