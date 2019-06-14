using System;
using System.Collections.Generic;
using System.Media;

namespace Confusing_Hobo_Unleashed
{
    public class SoundEngine
    {
        private SoundPack soundPack;
        private static SoundPlayer gamesound;

        protected SoundEngine()
        {
            soundPack = new SoundPack();
            gamesound = new SoundPlayer();
        }

        private static SoundEngine soundEngine;

        public SoundEngine getInstance()
        {
            return soundEngine ?? (soundEngine = new SoundEngine());
        }

        public void loadSoundPack(string path)
        {
            this.soundPack = new SoundPack(path);
        }

        public void PlayMusic()
        {
            gamesound = this.soundPack.LoadSound(SoundInterface.Christmas2);//TODO Re-randomize
            gamesound.Stop();
            gamesound.PlayLooping();
        }

        public void PlaySound(SoundInterface sound)
        {
            this.soundPack.LoadSound(sound).Play();
        }
    }
}