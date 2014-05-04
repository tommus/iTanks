using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework
{
    public interface Graphics
    {
        #region Fields
        /// <summary>
        /// Parametr przechowuje szeroko�� ekranu urz�dzenia.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Parametr przechowuje po�ow� szeroko�ci ekranu urz�dzenia.
        /// </summary>
        int HalfWidth { get; }

        /// <summary>
        /// Parametr przechowuje wysoko�� ekranu urz�dzenia.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Parametr przechowuje po�ow� wysoko�ci ekranu urz�dzenia.
        /// </summary>
        int HalfHeight { get; }
        #endregion
        #region Methods
        /// <summary>
        /// Metoda tworzy obiekt typu Image z pliku.
        /// </summary>
        /// <param name="filename">�cie�ka do pliku w katalogu 'Contents'.</param>
        /// <returns>Nowy obraz.</returns>
        Image NewImage(String filename);

        /// <summary>
        /// Metoda wczytuje czcionk� z pliku.
        /// </summary>
        /// <param name="filename">�cie�ka do pliku w katalogu 'Contents'.</param>
        /// <returns>Nowy obiekt typu 'SpriteFont'.</returns>
        SpriteFont NewFont(String filename);

        /// <summary>
        /// Metoda rysuje obraz w pocz�tku uk�adu wsp�rz�dnych.
        /// </summary>
        /// <param name="image">Obraz do narysowania.</param>
        void DrawImage(Image image);

        /// <summary>
        /// Metoda rysuje obraz w okre�lonym punkcie.
        /// </summary>
        /// <param name="image">Obraz do narysowania.</param>
        /// <param name="x">Wsp�rz�dna osi X.</param>
        /// <param name="y">Wsp�rz�dna osi Y.</param>
        void DrawImage(Image image, int x, int y);

        /// <summary>
        /// Metoda rysuje obraz w okre�lonym punkcie i przezroczysto�ci.
        /// </summary>
        /// <param name="image">Obraz do narysowania.</param>
        /// <param name="x">Wsp�rz�dna osi X.</param>
        /// <param name="y">Wsp�rz�dna osi Y.</param>
        /// <param name="width">Szeroko�� obrazu.</param>
        /// <param name="height">Wysoko�� obrazu.</param>
        void DrawImage(Image image, int x, int y, int width, int height);

        /// <summary>
        /// Metoda rysuje obraz w okre�lonym punkcie i o okre�lonych parametrach.
        /// </summary>
        /// <param name="image">Obraz do narysowania.</param>
        /// <param name="x">Wsp�rz�dna osi X.</param>
        /// <param name="y">Wsp�rz�dna osi Y.</param>
        /// <param name="color">Przezroczysto�� obrazu.</param>
        void DrawImage(Image image, int x, int y, Color color);

        /// <summary>
        /// Metoda rysuje obraz w okre�lonym punkcie i o okre�lonej skali.
        /// </summary>
        /// <param name="image">obraz do narysowania.</param>
        /// <param name="x">Wsp�rz�dna osi X.</param>
        /// <param name="y">Wsp�rz�dna osi Y.</param>
        /// <param name="scaledWidth">Rozmiar docelowy szeroko�ci rysowanego obrazu</param>
        /// <param name="scaledHeight">Rozmiar docelowy wysoko�ci rysowanego obrazu</param>
        void DrawScaledImage(Image image, int x, int y, int scaledWidth, int scaledHeight);

        /// <summary>
        /// Metoda rysuje tekst w okre�lonym punkcie ekranu i o okre�lonej przezroczysto�ci.
        /// </summary>
        /// <param name="font">U�yta czcionka.</param>
        /// <param name="text">Tekst do narysowania.</param>
        /// <param name="x">Wsp�rz�dna osi X.</param>
        /// <param name="y">Wsp�rz�dna osi Y.</param>
        /// <param name="color">Przezroczysto�� obrazu.</param>
        void DrawString(SpriteFont font, String text, int x, int y, Color color);

        /// <summary>
        /// Metoda rysuje tekst w okre�lonym punkcie ekranu i o okre�lonej przezroczysto�ci.
        /// </summary>
        /// <param name="font">U�yta czcionka.</param>
        /// <param name="text">Tekst do narysowania.</param>
        /// <param name="x">Wsp�rz�dna osi X.</param>
        /// <param name="y">Wsp�rz�dna osi Y.</param>
        /// <param name="scale">Skala czcionki.</param>
        /// <param name="color">Przezroczysto�� obrazu.</param>
        void DrawString(SpriteFont font, String text, int x, int y, float scale, Color color);

        /// <summary>
        /// Metoda czy�ci ekran wypelniaj�c go kolorem.
        /// </summary>
        /// <param name="color">Kolor, jakim zamalowany zostanie ekran.</param>
        void Clear(Color color);

        /// <summary>
        /// Metoda zwalnia obiekt typu SpriteBatch.
        /// </summary>
        void Dispose();
        #endregion
    }
}