using System.Media;
using EsimeneTund;

namespace Snake.Snake;

internal class SoundPlay
{
    public class SoundManager
    {
        public void Play(string soundPath)
        {
            if (File.Exists(soundPath))
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(soundPath);
                    player.Play();
                }
                catch { }
            }
        }
    }

}
