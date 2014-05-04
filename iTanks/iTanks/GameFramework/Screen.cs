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
        /// Metoda aktualizuj�ca stan obiekt�w na ekranie.
        /// Odpowiada za takie funkcje jak: aktualizacja, pobranie danych I/O.
        /// </summary>
        /// <param name="DeltaTime">Informacja opisuj�ca up�ywaj�cy czas.</param>
        public abstract void Update(float DeltaTime);

        /// <summary>
        /// Metoda odpowiedzialna za rysowanie obiekt�w na ekranie.
        /// </summary>
        /// <param name="DeltaTime">Informacja opisuj�ca up�ywaj�cy czas.</param>
        public abstract void Draw(float DeltaTime);

        /// <summary>
        /// Metoda obs�uguj�ca przycisk powrotu.
        /// </summary>
        public abstract void Back();

        /// <summary>
        /// Metoda zwalnia przydzielone zasoby.
        /// </summary>
        public abstract void Dispose();
        #endregion
    }
}