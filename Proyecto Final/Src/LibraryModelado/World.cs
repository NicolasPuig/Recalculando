//--------------------------------------------------------------------------------
// <copyright file="World.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System.Collections.Generic;

namespace Proyecto.LibraryModelado
{
    /// <summary>
    /// Clase responsable de crear objetos mundo.
    /// Implementa la interfaz <see cref="IComponent"/>.
    /// </summary>
    public class World : IComponent
    {
        /// <summary>
        /// Nombre del Mundo.
        /// </summary>
        private string name;

        /// <summary>
        /// Initializes a new instance of world.
        /// </summary>
        public World()
        {
            this.Name = this.name;
            this.SpaceList = new List<Space>();
        }

        /// <summary>
        /// Gets or sets del nombre del mundo.
        /// </summary>
        /// <value>String nombre del mundo.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets de la lista de espacios pertenecientes a un mundo.
        /// </summary>
        /// <value>Lista de Objetos <see cref="Space"/>.</value>
        public List<Space> SpaceList { get; }
    }
}