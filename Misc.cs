using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame
{
    static public class Misc
    {

        // Used to temporarily log users inputted choices
        public static int Choice { get; set; }

        private static string _currentColor = "Default";
        private static string _previousColor { get; set; }

        // Returns a random value between 0-100
        public static int Chance()
        {
            Random rnd = new Random();

            return rnd.Next(0, 100);
        }

        // Chooses randomly if there should be a battle. 65% chance for it to become a battle
        public static bool BattleChance()
        {
            if (Chance() < 65)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        // Ensures that the user's input is within the range of the 2 entered values
        public static void EnsureCorrectChoice(int minValue, int maxValue)
        {
            // Create new instance of audio player to play select sounds when choosing things
            AudioPlayer audioPlayer = new AudioPlayer();

            int userChoice;
            bool isVaildChoice = false;

            // Continue the loop to re-promt user for input until correct value is entered
            do
            {

                string userInput = Console.ReadLine(); // Takes in users input
                audioPlayer.PlayAudio("Select"); // Plays select audio

                if (int.TryParse(userInput, out userChoice))
                {
                    // If user's choice is within the range of the avalible options. Set value to choice and exit the loop
                    if (userChoice >= minValue && userChoice <= maxValue)
                    {
                        isVaildChoice = true; // Choice is valid, exit the loop
                        Choice = userChoice;
                    }
                    // If user's choice is not within the range of the avalible options. Re-promt user and continue the loop.
                    else
                    {
                        Console.WriteLine($"Invalid choice. Please enter a number between [{minValue}] and [{maxValue}].");
                    }
                }
                // If user didn't enter a number at all re-promt user for a number
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number");
                }
            }
            while (isVaildChoice == false);
        }

        // Sets text color to chosen mode
        public static void ChangeTextColor(string color)
        {
            // Sets previous color to the current color before saving the new color below
            _previousColor = _currentColor; 

            if (color == "Adventure" || color == "Green")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.Black;

                _currentColor = "Adventure"; // Keeps track of which the current color is
            }
            else if (color == "Battle" || color == "Red")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.Black;

                _currentColor = "Battle"; // Keeps track of which the current color is
            }
            else if (color == "Default" || color == "Gray")
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;

                _currentColor = "Default"; // Keeps track of which the current color is
            }
            // Highlights
            else if (color == "Xp")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkYellow;

                _currentColor = "Xp"; // Keeps track of which the current color is
            }
            else if (color == "Damage")
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkRed;

                _currentColor = "Damage"; // Keeps track of which the current color is
            }
            else if (color == "Highlight")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.BackgroundColor = ConsoleColor.Black;

                _currentColor = "Highlight"; // Keeps track of which the current color is
            }
            else if (color == "BattleHighlightMonster")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkRed;

                _currentColor = "BattleHighlightMonster"; // Keeps track of which the current color is
            }
            else if (color == "BattleHighlightHero")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkCyan;

                _currentColor = "BattleHighlightHero"; // Keeps track of which the current color is
            }

        }
        
        //// Changes the text to the last used text color
        //public static void ChangeTextToPrevColor()
        //{
        //    ChangeTextColor(_previousColor);
        //}
    }
}
