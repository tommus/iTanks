using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;

namespace iTanks.Game
{
    public class Tutorial4Screen : Screen
    {
        #region Fields
        private Button LeftArrow;
        private Button RightArrow;
        private String[] text = { "star enhance your cannon\n\n",
                                    "tank adds you one life\n\n",
                                    "shield protects your tank\n", "for 30 seconds\n\n",
                                    "ship allows you to ride\n", "through water for 30 seconds\n\n",
                                    "shovel protects your eagle\n", "for 30 seconds\n\n",
                                    "granade destroys all tanks\n", "spawned on map\n\n",
                                    "time stops all enemy tanks\n", "for 30 seconds" };
        private int slideY;
        private int maxSlide;
        #endregion
        #region Constructors
        public Tutorial4Screen(global::GameFramework.Game game)
            : base(game)
        {
            slideY = 120;
            maxSlide = 543;

            Graphics graphics = game.Graphics;

            int posX = 0;
            int posY = graphics.HalfHeight - (Assets.ArrowLeft.Height / 2);
            LeftArrow = new Button(Assets.ArrowLeft, Assets.ArrowLeft, posX, posY);
            posX = graphics.Width - Assets.ArrowRight.Width;
            RightArrow = new Button(Assets.ArrowRight, Assets.ArrowRight, posX, posY);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Metoda aktualizująca stan obiektów na ekranie.
        /// Odpowiada za takie funkcje jak: aktualizacja, pobranie danych I/O.
        /// </summary>
        /// <param name="DeltaTime">Informacja opisująca upływający czas.</param>
        public override void Update(float DeltaTime)
        {
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample sample = TouchPanel.ReadGesture();
                if (sample.GestureType == GestureType.Tap)
                {
                    int posX = (int)sample.Position.X;
                    int posY = (int)sample.Position.Y;

                    if (LeftArrow.Intersects(posX, posY))
                    {
                        Back();
                    }
                    if (RightArrow.Intersects(posX, posY))
                    {
                        game.Screen = new Tutorial5Screen(game);
                    }
                }
                if (sample.GestureType == GestureType.VerticalDrag)
                {
                    int newY = slideY + (int)sample.Delta.Y;

                    if(newY >= (120 - maxSlide) && newY <= 120)
                    {
                        slideY = newY;
                    }
                }
            }
        }

        /// <summary>
        /// Metoda odpowiedzialna za rysowanie obiektów na ekranie.
        /// </summary>
        /// <param name="DeltaTime">Informacja o upływającym czasie.</param>
        public override void Draw(float DeltaTime)
        {
            Graphics graphics = game.Graphics;

            int posX = graphics.HalfWidth - (Assets.BonusesText.Width / 2);

            for (int i = 0; i < text.Length; ++i)
            {
                int sumY = 0;
                for (int j = 0; j < i; ++j)
                {
                    sumY += (int)(Assets.BrickFont.MeasureString(text[j]).Y);
                }
                int possX = graphics.HalfWidth - (int)(Assets.BrickFont.MeasureString(text[i]).X / 2);
                int posY = slideY + sumY;
                graphics.DrawString(Assets.BrickFont, text[i], possX, posY, Color.White);
            }

            graphics.DrawImage(Assets.TutorialBorder);

            if(slideY >= 119)
            {
                String txt = "slide up";
                int possX = graphics.HalfWidth - (int)(Assets.BrickFont.MeasureString(txt).X /2);
                int posY = graphics.Height - 80;
                graphics.DrawString(Assets.BrickFont, txt, possX + 40, posY, 0.6f, Color.White);
            }

            graphics.DrawScaledImage(Assets.BlackBox, LeftArrow.Bounds.X, LeftArrow.Bounds.Y, LeftArrow.Bounds.Width, LeftArrow.Bounds.Height);
            LeftArrow.Draw(graphics);

            graphics.DrawScaledImage(Assets.BlackBox, RightArrow.Bounds.X, RightArrow.Bounds.Y, RightArrow.Bounds.Width, RightArrow.Bounds.Height);
            RightArrow.Draw(graphics);

            graphics.DrawScaledImage(Assets.BlackBox, posX - 10, 20, Assets.BonusesText.Width + 20, Assets.BonusesText.Height);
            graphics.DrawImage(Assets.BonusesText, posX, 20);
        }

        /// <summary>
        /// Metoda obsługująca przycisk powrotu.
        /// </summary>
        public override void Back()
        {
            game.Screen = new Tutorial3Screen(game);
        }

        /// <summary>
        /// Metoda zwalniająca przydzielone zasoby.
        /// </summary>
        public override void Dispose()
        {
        }
        #endregion
    }
}