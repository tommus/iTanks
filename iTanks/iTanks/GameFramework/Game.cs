using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameFramework
{
    public interface Game
    {
        #region Properties
        /// <summary>
        /// Parametr zwracaj�cy instacj� implementacji interfejsu Audio.
        /// W frameworku odpowiedzialny za �adowanie muzyki, d�wi�ku i ich�e odtwarzanie.
        /// </summary>
        Audio Audio { get; }

        /// <summary>
        /// Parametr zwracaj�cy instancj� implementacji interfejsu Graphics.
        /// W frameworku odpowiedzialny za �adowanie obraz�w i animacji oraz wy�wietlaniu ich na ekranie.
        /// </summary>
        Graphics Graphics { get; }

        /// <summary>
        /// Parametr 'Screen' - reprezentant klasy abstrakcyjnej odpowiedzialnej za wykonywanie podstawowych
        /// metod dzia�ania gry - aktualizacji, rysowania, zwalniania zasob�w i obs�ugi przycisku wstecz.
        /// </summary>
        Screen Screen { get; set; }
        #endregion
        #region Abstracts to implement in derrived classes
        /// <summary>
        /// Punkt zaczepny gry.
        /// W celu okre�lenia ekranu pocz�tkowego nale�y zaimplementowa� t� w���nie metod�.
        /// </summary>
        /// <returns></returns>
        Screen GetStartScreen();

        /// <summary>
        /// Metoda pozwala na konfiguracj� parametr�w urz�dzenia takich jak preferowana szeroko�� i wysoko�� ekranu itp.
        /// </summary>
        /// <param name="device">Urz�dzenie, kt�rego kalibracji nale�y dokona�.</param>
        void SetupDevice(GraphicsDeviceManager device);
        #endregion
    }
}