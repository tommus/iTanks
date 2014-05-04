using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GameFramework
{
    public interface Image
    {
        #region Properties
        /// <summary>
        /// Parametr przechowuje informacj� o szeroko�ci obrazu.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Parametr przechowuje informacj� o wysoko�ci obrazu.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Parametr przechowuje tekstur� obrazu.
        /// </summary>
        Texture2D Texture { get; }
        #endregion
        #region Methods
        /// <summary>
        /// Metoda zwalnia przydzielone zasoby.
        /// </summary>
        void Dispose();
        #endregion
    }
}