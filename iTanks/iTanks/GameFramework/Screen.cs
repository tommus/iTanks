using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFramework
{
    public abstract class Screen
    {
        #region Fields
        protected Game game;
        #endregion
        #region Constructors
        public Screen(Game game)
        {
            this.game = game;
        }
        #endregion
        #region Abstracts to implement in derrived classes
        /// <summary>
        /// Metoda aktualizująca stan obiektów na ekranie.
        /// Odpowiada za takie funkcje jak: aktualizacja, pobranie danych I/O.
        /// </summary>
        /// <param name="DeltaTime">Informacja opisująca upływający czas.</param>
        public abstract void Update(float DeltaTime);

        /// <summary>
        /// Metoda odpowiedzialna za rysowanie obiektów na ekranie.
        /// </summary>
        /// <param name="DeltaTime">Informacja opisująca upływający czas.</param>
        public abstract void Draw(float DeltaTime);

        /// <summary>
        /// Metoda obsługująca przycisk powrotu.
        /// </summary>
        public abstract void Back();

        /// <summary>
        /// Metoda zwalnia przydzielone zasoby.
        /// </summary>
        public abstract void Dispose();
        #endregion
    }
}