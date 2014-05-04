using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTanks.Game.Objects
{
    public class Tank : Bonus
    {
        #region Constructors
        public Tank(int x, int y) : base(x, y, Type.TANK)
        {
        }
        #endregion
        #region Methods
        /// <summary>
        /// Metoda odpowiedzialna za reakcj� na kolizje z obiektem.
        /// </summary>
        /// <param name="a">Obiekt, z kt�rym badane jest zachodzenie kolizji.</param>
        public override void Collision(Actor a)
        {
            base.Collision(a);

            if (a is Player)
            {
                Player player = (Player)a;
                player.Lives += 1;
            }
        }
        #endregion
    }
}