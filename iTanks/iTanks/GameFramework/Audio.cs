using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework
{
    public interface Audio
    {
        /// <summary>
        /// Metoda tworzy instancj� klasy WPMusic, pozwalaj�c na odtwarzanie pliku.
        /// </summary>
        /// <param name="filename">�cie�ka do pliku muzycznego w katalogu 'Contents'</param>
        /// <returns></returns>
        Music NewMusic(String filename);

        /// <summary>
        /// Metoda tworzy instancj� klasy WPSound, pozwalaj�c na odtwarzanie pliku.
        /// </summary>
        /// <param name="filename">�cie�ka do pliku muzycznego w katalofu 'Contents'.</param>
        /// <returns></returns>
        Sound NewSound(String filename);
    }
}
