using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTanks.Game.AI;

namespace iTanks.Game.Objects
{
    public class Brick : Block
    {
        #region Constructors
        public Brick(int x, int y) : base(Type.BRICK, x, y)
        {
        }

        #endregion
        #region Methods
        /// <summary>
        /// Metoda odpowiadaj�ca za reakcj� na zderzenie z obiektem przekazanym jako parametr.
        /// </summary>
        /// <param name="a">Obiekt, z kt�rym dosz�o do zderzenia.</param>
        public override void Collision(Actor a)
        {
            if(a is Bullet)
            {
                Bullet bullet = (Bullet)a;
                bullet.Hited = type;
                ToRemove = true;
            }
        }
        #endregion
    }
}