using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FantasyConsoleGame
{
    public class AudioPlayer
    {
        private string currentAudio; // Added field to track the currently playing audio file


        // Saves audio files in variables to make code more legible

        //Music
        private static string _soundDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");
        private string _introMusic = Path.Combine(_soundDirectory, "BackgroundMusic.wav");
        private string _battleMusic = Path.Combine(_soundDirectory, "BattleMusic.wav");

        private string _titleTheme = Path.Combine(_soundDirectory, "TitleTheme.wav");
        private string _journeyBegins = Path.Combine(_soundDirectory, "JourneyBegins.wav");
        private string _icyCave = Path.Combine(_soundDirectory, "TheIcyCave.wav");
        private string _battleMusic2 = Path.Combine(_soundDirectory, "PrepareForBattle.wav");
        private string _rest = Path.Combine(_soundDirectory, "Rest.wav");
        private string _unknown = Path.Combine(_soundDirectory, "ExploringUnknown.wav");
        private string _dungeon = Path.Combine(_soundDirectory, "MysteriousDungeon.wav");
        private string _battleMusic3 = Path.Combine(_soundDirectory, "DecisiveBattle.wav");
        private string _fantasy = Path.Combine(_soundDirectory, "TheFinalOfTheFantasy.wav");


        //SFX
        private string _heroHurtSFX = Path.Combine(_soundDirectory, "HeroHurtSFX.wav");
        private string _damageSFX = Path.Combine(_soundDirectory, "DamageSFX.wav");
        private string _selectSFX = Path.Combine(_soundDirectory, "SelectSFX.wav");
        private string _blockSFX = Path.Combine(_soundDirectory, "BlockSFX.wav");
        private string _LevelupSFX = Path.Combine(_soundDirectory, "LevelupSFX.wav");


        // Declares audio handling classes
        private WaveOutEvent waveOut;
        private WaveFileReader audioFile;

        // Initializes a new instance of audio player called waveOut
        public AudioPlayer()
        {
            waveOut = new WaveOutEvent();
        }


        // Plays audio at selected file location, with the option to choose to loop the audio
        public void PlayAudio(string input, bool loop = false)
        {
            // Selects which sound to play based on the input
            string sound = SoundSelector(input);

            try
            {
                // Checks if object isn't null and if audio is playing
                if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing) 
                {
                    // Stops audio, disposes of it to free memory (to not cause memory leak) and create new instance of audio object to be able to play something else
                    waveOut.Stop();
                    waveOut.Dispose();
                    waveOut = new WaveOutEvent(); // Create a new instance

                }

                // Creates a audioFile variable that is of type WaveStream, and we wrap it in a LoopStream
                // when the loop parameter is true.
                WaveStream audioFile = new AudioFileReader(sound);
               
                if (loop)
                {
                    // Wraps the audio file in a looping stream
                    audioFile = new LoopStream(audioFile); 
                }

                
                // Initialize and play audio
                waveOut.Init(audioFile);
                waveOut.Play();

                currentAudio = sound; // Sets current audio to the audio we're gonna play
                
            }
            // If we couldn't play audio, display error message
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while playing audio: {ex.Message}");
            }
        }

        // Stops audio from playing 
        public void StopAudio()
        {
            if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Stop();

                // Checks if audio file isn't null and resets the audios position
                if (audioFile != null)
                {
                    audioFile.Position = 0; 
                }
                
                currentAudio = null; // Sets current audio to null since we stopped it from playing
            }
        }

        // Returns the current audio that is playing
        public string GetCurrentPlayingAudio()
        {
            return currentAudio;
        }

        // Frees the memory from audio to not cause memory leak
        public void Dispose()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
            }
            if (audioFile != null)
            {
                audioFile.Dispose();
            }
        }

        // Returns audio file based on input
        public string SoundSelector(string input)
        {
            if (input == "Battle")
            {
                return _battleMusic;
            }
            else if (input == "Damage")
            {
                return _damageSFX;
            }
            else if(input == "Select")
            {
                return _selectSFX;
            }
            else if(input == "Intro")
            {
                return _introMusic;
            }
            else if (input == "Block")
            {
                return _blockSFX;
            }
            else if (input == "HeroHurt")
            {
                return _heroHurtSFX;
            }
            else if (input == "LevelUp")
            {
                return _LevelupSFX;
            }
            else if (input == "Theme")
            {
                return _titleTheme;
            }
            else if (input == "Journey")
            {
                return _journeyBegins;
            }
            else if (input == "Exploration1")
            {
                return _icyCave;
            }
            else if (input == "Exploration2")
            {
                return _unknown;
            }
            else if (input == "Exploration3")
            {
                return _dungeon;
            }
            else if (input == "Rest")
            {
                return _rest;
            }
            else if (input == "Battle2")
            {
                return _battleMusic2;
            }
            else if (input == "Battle3")
            {
                return _battleMusic3;
            }
            else if (input == "Fantasy")
            {
                return _fantasy;
            }

            return null;
        }

    }
}
