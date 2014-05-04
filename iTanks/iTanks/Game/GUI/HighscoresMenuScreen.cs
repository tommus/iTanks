using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameFramework;
using Microsoft.Xna.Framework.Input.Touch;

namespace iTanks.Game.GUI
{
    class HighscoresMenuScreen : Screen
    {
        #region Fields
        private Boolean atExit;
        private Button ResetButton;
        private Button ExitButton;
        #endregion
        #region Constructors
        public HighscoresMenuScreen(global::GameFramework.Game game) : base(game)
        {
            atExit = false;

            Graphics graphics = game.Graphics;
            
            int posX = graphics.HalfWidth - (Assets.ButtonBackground.Width / 2);
            int posY = graphics.HalfHeight - (Assets.ButtonBackground.Height + 10);
            ResetButton = new Button(Assets.ButtonBackground, Assets.ResetText, posX, posY);

            posY += Assets.ButtonBackground.Height + 20;
            ExitButton = new Button(Assets.ButtonBackground, Assets.ExitText, posX, posY);
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
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample sample = TouchPanel.ReadGesture();
                if (sample.GestureType == GestureType.Tap)
                {
                    int posX = (int)sample.Position.X;
                    int posY = (int)sample.Position.Y;

                    if(ExitButton.Intersects(posX, posY))
                    {
                        Back();
                    }
                    if (ResetButton.Intersects(posX, posY))
                    {
                        Highscores.Reset();
                    }
                }
            }
        }

        /// <summary>
        /// Metoda odpowiedzialna za rysowanie obiekt�w na ekranie.
        /// </summary>
        /// <param name="DeltaTime">Informacja o up�ywaj�cym czasie.</param>
        public override void Draw(float DeltaTime)
        {
            Graphics graphics = game.Graphics;

            int posX = ResetButton.Bounds.X - 20;
            int posY = ResetButton.Bounds.Y - 20;
            int width = ResetButton.Bounds.Width + 40;
            int height = ResetButton.Bounds.Height + ExitButton.Bounds.Height + 60;

            graphics.DrawImage(Assets.BrickBackground, posX, posY, width, height);
            ResetButton.Draw(graphics);
            ExitButton.Draw(graphics);
        }

        /// <summary>
        /// Metoda obs�uguj�ca przycisk powrotu.
        /// </summary>
        public override void Back()
        {
            TouchPanel.EnabledGestures = GestureType.Tap | GestureType.Hold;
            atExit = true;
        }

        /// <summary>
        /// Metoda zwalniaj�ca przydzielone zasoby.
        /// </summary>
        public override void Dispose()
        {
        }

        /// <summary>
        /// Metoda zwraca informacj�, czy nale�y wyj�� z menu wynik�w.
        /// </summary>
        /// <returns>'true' - je�eli nale�y wyj��, 'false' - je�eli nale�y pozosta�.</returns>
        public Boolean AtExit()
        {
            Boolean temp = atExit;
            atExit = false;
            return !temp;
        }
        #endregion
    }
}