using System;
using System.Collections.Generic;
using System.Media;

namespace Confusing_Hobo_Unleashed
{
    public class SoundEngine
    {
        private static readonly Dictionary<int, SoundPlayer> SoundTracks = new Dictionary<int, SoundPlayer> {{0, new SoundPlayer(@"Sound Files\Fancy.wav")}, {1, new SoundPlayer(@"Sound Files\Happy.wav")}, {2, new SoundPlayer(@"Sound Files\HappySlow.wav")}, {3, new SoundPlayer(@"Sound Files\LoopMe.wav")}, {4, new SoundPlayer(@"Sound Files\MonoTone.wav")}, {5, new SoundPlayer(@"Sound Files\Ode To Joy.wav")}, {6, new SoundPlayer(@"Sound Files\Oh Susanna.wav")}, {7, new SoundPlayer(@"Sound Files\Over The Rainbow.wav")}, {8, new SoundPlayer(@"Sound Files\Rudolf.wav")}, {9, new SoundPlayer(@"Sound Files\Untitled.wav")}};
        private static SoundPlayer _gamesound = new SoundPlayer();
        
        public void PlayMusic()
        {
            var random = new Random();
            _gamesound = SoundTracks[random.Next(SoundTracks.Count)];
            _gamesound.Stop();
            _gamesound.PlayLooping();
        }
    }
}