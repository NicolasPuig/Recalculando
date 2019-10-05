//--------------------------------------------------------------------------------
// <copyright file="Items.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using  System.Collections.Generic;

namespace Proyecto
{
    /// <summary>
    /// Modelo del mundo.
    /// </summary>
    public class World 
    {
        /// <summary>
        /// Nombre del World.
        /// </summary>
        private string name;

        /// <summary>
        /// Ancho del World en pixeles.
        /// </summary>
        private string width;

        /// <summary>
        /// Altura del World en pixeles.
        /// </summary>
        private string height;

        /// <summary>
        /// Lista de Levels.
        /// </summary>
        internal List<Space> spacelist = new List<Space>(); //Tipo Space

        /// <summary>
        /// Inicializa una instancia de World.
        /// </summary>
        /// <param name="Name">Nombre del World.</param>
        /// <param name="Width">Ancho del World.</param>
        /// <param name="SpaceList">Lista de Levels.</param>
        public World(string Name, string Width, string Height, List<Space> SpaceList)
        {
            this.name = Name;
            this.width = Width;
            this.height = Height;
            this.spacelist = SpaceList;
        }

        /// <summary>
        /// Gets or sets del nombre del espacio.
        /// </summary>
        /// <value>String nombre del espacio.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets del Ancho del espacio.
        /// </summary>
        /// <value>Ancho del Espacio.</value>
        public string Width { get; set; }

        /// <summary>
        /// Gets or sets de la altura del espacio.
        /// </summary>
        /// <value>Ancho del Espacio.</value>
        public string Height { get; set; }
    }
}