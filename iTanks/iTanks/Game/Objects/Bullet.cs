using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework;
using iTanks.Game.AI;

namespace iTanks.Game.Objects
{
    public class Bullet : Actor
    {
        #region Fields
        private Image up, down, left, right;
        private int direction;
        private float speed;
        private Sound steel;
        private Sound brick;
        private Actor owner;
        #endregion
        #region Properties
        /// <summary>
        /// Parametr przechowuje informacj� o w�a�cicielu pocisku.
        /// </summary>
        public Actor Owner 
        {
            get { return owner; }
        }

        /// <summary>
        /// Parametr przechowuje informacje o obiekcie, kt�ry zosta� trafiony przez pocisk.
        /// </summary>
        public int Hited { get; set; }
        #endregion
        #region Constructors
        public Bullet(int x, int y, int direction, Actor owner, float speed) : base(Block.Type.BULLET, x, y)
        {
            Hited = 0;
            up = Assets.Blocks[Block.Type.BULLET];
            down = Assets.Blocks[Block.Type.BULLET + 1];
            left = Assets.Blocks[Block.Type.BULLET + 2];
            right = Assets.Blocks[Block.Type.BULLET + 3];
            this.speed = speed;
            this.direction = direction;
            this.owner = owner;
            if(direction == Direction.UP || direction == Direction.DOWN)
            {
                width = up.Width;
                height = up.Height;
            }
            else
            {
                width = left.Width;
                height = left.Height;
            }

            steel = Assets.Steel;
            brick = Assets.BrickSound;
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
            int delta = (int)Math.Round(speed * DeltaTime / 10);
            switch(direction)
            {
                case Direction.UP:
                    y -= delta;
                    break;
                case Direction.DOWN:
                    y += delta;
                    break;
                case Direction.LEFT:
                    x -= delta;
                    break;
                case Direction.RIGHT:
                    x += delta;
                    break;
            }
        }

        /// <summary>
        /// Metoda odpowiedzialna za rysowanie obiekt�w na ekranie.
        /// </summary>
        /// <param name="DeltaTime">Informacja o up�ywaj�cym czasie.</param>
        public override void Draw(Graphics graphics)
        {
            switch (direction)
            {
                case Direction.UP:
                    graphics.DrawImage(up, x, y);
                    break;
                case Direction.DOWN:
                    graphics.DrawImage(down, x, y);
                    break;
                case Direction.LEFT:
                    graphics.DrawImage(left, x, y);
                    break;
                case Direction.RIGHT:
                    graphics.DrawImage(right, x, y);
                    break;
            }
        }

        /// <summary>
        /// Metoda odtwarza d�wi�k uderzenia pocisku w ceg��.
        /// </summary>
        public void PlayBrick()
        {
            brick.Play(1.0f);
        }

        /// <summary>
        /// Metoda odtwarza d�wi�k uderzenia pocisku w stal.
        /// </summary>
        public void PlaySteel()
        {
            steel.Play(1.0f);
        }

        /// <summary>
        /// Metoda odpowiadaj�ca za reakcj� na zderzenie z obiektem przekazanym jako parametr.
        /// </summary>
        /// <param name="a">Obiekt, z kt�rym dosz�o do zderzenia.</param>
        public override void Collision(Actor a)
        {
            if (a is Brick || a is Stone || a is Enemy || a is Bullet || a is Eagle)
            {
                ToRemove = true;

                if(!(a is Enemy) || (a is Enemy && owner is Player))
                    Level.Instance.AddExplosion(new Explosion(x - 12, y - 12));
            }

            if(a is Player && !(owner is Player))
            {
                ToRemove = true;
                Level.Instance.AddExplosion(new Explosion(x - 12, y - 12));
            }
        }
        #endregion
    }
}