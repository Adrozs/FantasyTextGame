using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame
{
    static public class Misc
    {
        // Saves audio files in variables to make code more legible
        public static string BackgroundMusic = @"C:\Users\adria\source\repos\FantasyTextGameV2\bin\SoundFiles\BackgroundMusic.wav";
        public static string BattleMusic = @"C:\Users\adria\source\repos\FantasyTextGameV2\bin\SoundFiles\BattleMusic.mp3";
        public static string DamageSFX = @"C:\Users\adria\source\repos\FantasyTextGameV2\bin\SoundFiles\Damage.wav";
        public static string SelectSFX = @"C:\Users\adria\source\repos\FantasyTextGameV2\bin\SoundFiles\Select.wav";

        // Plays audio at selected file location
        public static async Task PlayAudio(string filePath)
        {
            try
            {
                using (WaveFileReader reader = new WaveFileReader(filePath))
                {
                    using (WaveOutEvent waveOut = new WaveOutEvent())
                    {
                        waveOut.Init(reader);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            await Task.Delay(100);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while playing audio: {ex.Message}");
            }
        }

        // Used to temporarily log users inputted choices
        public static int Choice {  get; set; }

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
            int userChoice;
            bool isVaildChoice = false;

            // Continue the loop to re-promt user for input until correct value is entered
            do
            {

                string userInput = Console.ReadLine(); // Takes in users input
                Misc.PlayAudio(Misc.SelectSFX);

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
    }
}
