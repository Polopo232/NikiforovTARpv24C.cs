using System.Media;
using System.IO;

namespace EsimeneTund
{
    internal class SoundPlay
    {
        public void Play(string soundPath)
        {
            if (!File.Exists(soundPath)) return;

            try
            {
                using SoundPlayer player = new SoundPlayer(soundPath);
                player.Play();
            }
            catch
            {
                // Игнорируем ошибки
            }
        }
    }
}
