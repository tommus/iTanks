using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework
{
    public interface Sound
    {
        #region Methods
        /// <summary>
        /// Metoda pozwala na odtworzenie pliku d�wi�kowego z okre�lon� g�o�no�ci�.
        /// </summary>
        /// <param name="volume">G�o�no�� wyra�ona w zakresie 0.0f - 1.0f.</param>
        void Play(float volume);

        /// <summary>
        /// Metoda zwalnia przydzielone zasoby.
        /// </summary>
        void Dispose();
        #endregion
    }
}