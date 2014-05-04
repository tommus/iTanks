using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace GameFramework.Implementation
{
    public class WPGraphics : Graphics
    {
        #region Fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private ContentManager content;
        #endregion
        #region Properties
        /// <summary>
        /// Parametr przechowuje szeroko�� ekranu urz�dzenia.
        /// </summary>
        public int Width
        {
            get { return spriteBatch.GraphicsDevice.Viewport.Width; }
        }

        /// <summary>
        /// Parametr przechowuje po�ow� szeroko�ci ekranu urz�dzenia.
        /// </summary>
        public int HalfWidth
        {
            get { return Width / 2; }
        }

        /// <summary>
        /// Parametr przechowuje wysoko�� ekranu urz�dzenia.
        /// </summary>
        public int Height
        {
            get { return spriteBatch.GraphicsDevice.Viewport.Height; }
        }

        /// <summary>
        /// Parametr przechowuje po�ow� wysoko�ci ekranu urz�dzenia.
        /// </summary>
        public int HalfHeight
        {
            get { return Height / 2; }
        }
        #endregion
        #region Constructors
        public WPGraphics(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content)
        {
            this.graphics = graphics;
            this.spriteBatch = spriteBatch;
            this.content = content;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Metoda czy�ci ekran wypelniaj�c go kolorem.
        /// </summary>
        /// <param name="color">Kolor, jakim zamalowany zostanie ekran.</param>
        public void Clear(Color color)
        {
            spriteBatch.GraphicsDevice.Clear(color);
        }

        /// <summary>
        /// Metoda zwalnia obiekt typu SpriteBatch.
        /// </summary>
        public void Dispose()
        {
            spriteBatch.Dispose();
        }

        /// <summary>
        /// Metoda tworzy obiekt typu Image z pliku.
        /// </summary>
        /// <param name="filename">�cie�ka do pliku w katalogu 'Contents'.</param>
        /// <returns>Nowy obraz.</returns>
        public Image NewImage(String filename)
        {
            Texture2D image = content.Load<Texture2D>(filename);
            return new WPImage(image);
        }

        /// <summary>
        /// Metoda wczytuje czcionk� z pliku.
        /// </summary>
        /// <param name="filename">�cie�ka do pliku w katalogu 'Contents'.</param>
        /// <returns>Nowy obiekt typu 'SpriteFont'.</returns>
        public SpriteFont NewFont(String filename)
        {
            return content.Load<SpriteFont>(filename);
        }

        /// <summary>
        /// Metoda rysuje obraz w pocz�tku uk�adu wsp�rz�dnych.
        /// </summary>
        /// <param name="image">Obraz do narysowania.</param>
        public void DrawImage(Image image)
        {
            Texture2D texture = image.Texture;
            spriteBatch.Draw(texture, Vector2.Zero, Color.White);
        }

        /// <summary>
        /// Metoda rysuje obraz w okre�lonym punkcie i o okre�lonych parametrach.
        /// </summary>
        /// <param name="image">Obraz do narysowania.</param>
        /// <param name="x">Wsp�rz�dna osi X.</param>
        /// <param name="y">Wsp�rz�dna osi Y.</param>
        /// <param name="color">Przezroczysto�� obrazu.</param>
        public void DrawImage(Image image, int x, int y, Color color)
        {
            Texture2D texture = image.Texture;
            spriteBatch.Draw(texture, new Vector2(x, y), color);
        }

        /// <summary>
        /// Metoda rysuje obraz w okre�lonym punkcie.
        /// </summary>
        /// <param name="image">Obraz do narysowania.</param>
        /// <param name="x">Wsp�rz�dna osi X.</param>
        /// <param name="y">Wsp�rz�dna osi Y.</param>
        public void DrawImage(Image image, int x, int y)
        {
            Texture2D texture = image.Texture;
            spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
        }

        /// <summary>
        /// Metoda rysuje obraz w okre�lonym punkcie i przezroczysto�ci.
        /// </summary>
        /// <param name="image">Obraz do narysowania.</param>
        /// <param name="x">Wsp�rz�dna osi X.</param>
        /// <param name="y">Wsp�rz�dna osi Y.</param>
        /// <param name="width">Szeroko�� obrazu.</param>
        /// <param name="height">Wysoko�� obrazu.</param>
        public void DrawImage(Image image, int x, int y, int width, int height)
        {
            Texture2D texture = image.Texture;
            spriteBatch.Draw(texture, new Vector2(x, y), new Rectangle(0, 0, width, height), Color.White);
        }

        /// <summary>
        /// Metoda rysuje obraz w okre�lonym punkcie i o okre�lonej skali.
        /// </summary>
        /// <param name="image">obraz do narysowania.</param>
        /// <param name="x">Wsp�rz�dna osi X.</param>
        /// <param name="y">Wsp�rz�dna osi Y.</param>
        /// <param name="scaledWidth">Rozmiar docelowy szeroko�ci rysowanego obrazu</param>
        /// <param name="scaledHeight">Rozmiar docelowy wysoko�ci rysowanego obrazu</param>
        public void DrawScaledImage(Image image, int x, int y, int scaledWidth, int scaledHeight)
        {
            Texture2D texture = image.Texture;
            spriteBatch.Draw(texture, new Rectangle(x, y, scaledWidth, scaledHeight), null, Color.White);
        }

        /// <summary>
        /// Metoda rysuje tekst w okre�lonym punkcie ekranu i o okre�lonej przezroczysto�ci.
        /// </summary>
        /// <param name="font">U�yta czcionka.</param>
        /// <param name="text">Tekst do narysowania.</param>
        /// <param name="x">Wsp�rz�dna osi X.</param>
        /// <param name="y">Wsp�rz�dna osi Y.</param>
        /// <param name="color">Przezroczysto�� obrazu.</param>
        public void DrawString(SpriteFont font, String text, int x, int y, Color color)
        {
            spriteBatch.DrawString(font, text, new Vector2(x, y), color);
        }

        /// <summary>
        /// Metoda rysuje tekst w okre�lonym punkcie ekranu i o okre�lonej przezroczysto�ci.
        /// </summary>
        /// <param name="font">U�yta czcionka.</param>
        /// <param name="text">Tekst do narysowania.</param>
        /// <param name="x">Wsp�rz�dna osi X.</param>
        /// <param name="y">Wsp�rz�dna osi Y.</param>
        /// <param name="scale">Skala czcionki.</param>
        /// <param name="color">Przezroczysto�� obrazu.</param>
        public void DrawString(SpriteFont font, String text, int x, int y, float scale, Color color)
        {
            spriteBatch.DrawString(font, text, new Vector2(x, y), color, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
        #endregion
    }
}