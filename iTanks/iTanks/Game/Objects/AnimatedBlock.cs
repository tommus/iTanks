using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework;
using Microsoft.Xna.Framework;

namespace iTanks.Game.Objects
{
    public class AnimatedBlock : Actor
    {
        #region Fields
        protected Animation animation;
        #endregion
        #region Constructors
        public AnimatedBlock(int type, int x, int y) : base(type, x, y)
        {
            animation = Assets.Animations[type];

            width = animation.Image.Width;
            height = animation.Image.Height;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Metoda aktualizuj�ca stan obiekt�w na ekranie.
        /// Odpowiada za takie funkcje jak: aktualizacja, pobranie danych I/O.
        /// </summary>
        /// <param name="DeltaTime">Informacja opisuj�ca up�ywaj�cy czas.</param>
        public override void Update(float DeltaTime)
        {
            animation.Update(DeltaTime);
        }

        /// <summary>
        /// Metoda odpowiedzialna za rysowanie obiekt�w na ekranie.
        /// </summary>
        /// <param name="DeltaTime">Informacja o up�ywaj�cym czasie.</param>
        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(animation.Image, x, y, width, height);
        }
        #endregion
    }
}