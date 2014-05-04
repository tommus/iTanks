using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameFramework.Implementation
{
    public abstract class WPGame : Microsoft.Xna.Framework.Game, GameFramework.Game
    {
        #region Fields
        /// <summary>
        /// Parametr 'Screen' - reprezentant klasy abstrakcyjnej odpowiedzialnej za wykonywanie podstawowych
        /// metod dzia�ania gry - aktualizacji, rysowania, zwalniania zasob�w i obs�ugi przycisku wstecz.
        /// </summary>
        public Screen Screen { get; set; }

        protected GraphicsDeviceManager device;
        protected SpriteBatch spriteBatch;

        protected Audio audio;
        protected Graphics graphics;
        #endregion
        #region Properties
        /// <summary>
        /// Parametr zwracaj�cy instacj� implementacji interfejsu Audio.
        /// W frameworku odpowiedzialny za �adowanie muzyki, d�wi�ku i ich�e odtwarzanie.
        /// </summary>
        public Audio Audio
        {
            get { return audio; }
        }

        /// <summary>
        /// Parametr zwracaj�cy instancj� implementacji interfejsu Graphics.
        /// W frameworku odpowiedzialny za �adowanie obraz�w i animacji oraz wy�wietlaniu ich na ekranie.
        /// </summary>
        public Graphics Graphics
        {
            get { return graphics; }
        }
        #endregion
        #region Constructors
        protected WPGame()
        {
            device = new GraphicsDeviceManager(this);
            SetupDevice(device);

            Content.RootDirectory = "Content";

            TargetElapsedTime = TimeSpan.FromTicks(333333);
            InactiveSleepTime = TimeSpan.FromSeconds(1);
            audio = new WPAudio(Content);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Metoda inicjuj�ca podstawowe parametry XNA.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();   
        }

        /// <summary>
        /// Metoda wczytuj�ca zasoby do pami�ci programu.
        /// Wykorzystuje abstrakcyjn� metod� 'GetStartScreen'.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics = new WPGraphics(device, spriteBatch, Content);

            Screen = GetStartScreen();
        }

        /// <summary>
        /// Metoda zwalniaj�ca przydzielane zasoby.
        /// </summary>
        protected override void UnloadContent()
        {
            graphics.Dispose();
            Screen.Dispose();
        }

        /// <summary>
        /// Metoda aktualizuj�ca stan obiekt�w na ekranie.
        /// Odpowiada za takie funkcje jak: aktualizacja, pobranie danych I/O.
        /// </summary>
        /// <param name="gameTime">Zrzut informacji opisuj�cych up�ywaj�cy czas.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Screen.Back();

            base.Update(gameTime);
            Screen.Update(gameTime.ElapsedGameTime.Milliseconds);
        }

        /// <summary>
        /// Metoda odpowiedzialna za rysowanie obiekt�w na ekranie.
        /// </summary>
        /// <param name="gameTime">Zrzut informacji opisuj�cych up�ywaj�cy czas.</param>
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            graphics.Clear(Color.Black);
            spriteBatch.Begin();
            Screen.Draw(gameTime.ElapsedGameTime.Milliseconds);
            spriteBatch.End();
        }
        #endregion
        #region To Implement in derrived class
        /// <summary>
        /// Punkt zaczepny gry.
        /// W celu okre�lenia ekranu pocz�tkowego nale�y zaimplementowa� t� w���nie metod�.
        /// </summary>
        /// <returns></returns>
        public abstract Screen GetStartScreen();

        /// <summary>
        /// Metoda pozwala na konfiguracj� parametr�w urz�dzenia takich jak preferowana szeroko�� i wysoko�� ekranu itp.
        /// </summary>
        /// <param name="device">Urz�dzenie, kt�rego kalibracji nale�y dokona�.</param>
        public abstract void SetupDevice(GraphicsDeviceManager device);
        #endregion
    }
}