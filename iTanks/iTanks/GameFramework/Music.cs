using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework
{
    public interface Music
    {
        #region Properties
        /// <summary>
        /// Parametr zwraca 'true', je�eli w danej chwili czasu odtwarzany jest w�a�nie jaki� plik muzyczny.
        ///  W przeciwnym razie zwraca 'false'.
        /// </summary>
        Boolean IsPlaying { get; }

        /// <summary>
        /// Parametr zwraca 'true', je�eli w danej chwili czasu nie odtwarzany jest w�a�nie jaki� plik muzyczny.
        ///  W przeciwnym razie zwraca 'false'.
        /// </summary>
        Boolean IsStopped { get; }

        /// <summary>
        /// Parametr zwraca 'true', je�eli w danej chwili czasu odtwarzany jest w p�tli jaki� plik muzyczny.
        ///  W przeciwnym razie zwraca 'false'.
        /// </summary>
        Boolean IsLooping { get; }
        #endregion
        #region Methods
        /// <summary>
        /// Metoda pozwala na rozpocz�cie odtwarzania pliku muzycznego.
        /// Tylko jeden plik mo�e by� odtwarzany jednocze�nie.
        /// </summary>
        void Play();

        /// <summary>
        /// Metoda pauzuje odtwarzanie aktualnego pliku, je�eli jaki� jest odtwarzany.
        /// </summary>
        void Pause();

        /// <summary>
        /// Metoda zatrzymuje odtwarzanie pliku muzycznego.
        /// </summary>
        void Stop();

        /// <summary>
        /// Metoda ustawia odtwarzanie pliku w p�tli.
        /// </summary>
        /// <param name="looping">'true' - odtwarzaj w p�tli, 'false' - nie odtwarzaj w p�tli.</param>
        void SetLooping(Boolean looping);

        /// <summary>
        /// Ustawia g�o�no�� odtwarzania pliku.
        /// </summary>
        /// <param name="volume">Warto�� g�o�no�ci w zakresie 0.0f - 1.0f</param>
        void SetVolume(float volume);

        /// <summary>
        /// Metoda zwalnia przydzielone zasoby.
        /// </summary>
        void Dispose();
        #endregion
    }
}
