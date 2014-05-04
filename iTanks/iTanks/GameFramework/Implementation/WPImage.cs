using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameFramework.Implementation
{
    public class WPImage : Image
    {
        #region Fields
        private Texture2D image;
        #endregion
        #region Constructors
        public WPImage(Texture2D image)
        {
            this.image = image;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Parametr przechowuje informacj� o szeroko�ci obrazu.
        /// </summary>
        public int Width
        {
            get { return image.Width; }
        }

        /// <summary>
        /// Parametr przechowuje informacj� o wysoko�ci obrazu.
        /// </summary>
        public int Height
        {
            get { return image.Height; }
        }

        /// <summary>
        /// Parametr przechowuje tekstur� obrazu.
        /// </summary>
        public Texture2D Texture
        {
            get { return image; }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Metoda zwalnia przydzielone zasoby.
        /// </summary>
        public void Dispose()
        {
            image.Dispose();
        }
        #endregion
    }
}
