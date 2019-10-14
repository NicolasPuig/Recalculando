//--------------------------------------------------------------------------------
// <copyright file="Builder.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Proyecto.LeerHTML;
using Proyecto.Common;
using Proyecto.LibraryModelado;

namespace Proyecto.StudentsCode
{
    /// <summary>
    /// Clase que implementa la interfaz IBuilder.
    /// Tiene la responsabilidad de generar los archivos 'StudentsCode.dll' y 'Common.dll'.
    /// </summary>
    public class Builder : IBuilder
    {
        private IMainViewAdapter adapter;
        Creator Creator = new Creator();
        private Space firstPage;

        /// <summary>
        /// Construye una interfaz de usuario interactiva utilizando un <see cref="IMainViewAdapter"/>.
        /// </summary>
        /// <param name="providedAdapter">Un <see cref="IMainViewAdapter"/> que permite construir una interfaz de usuario interactiva.</param>
        public void Build(IMainViewAdapter providedAdapter)
        {
            adapter = providedAdapter ?? throw new ArgumentNullException(nameof(providedAdapter));
            adapter.ToDoAfterBuild(AfterBuildShowFirstPage);
            // AfterBuild = Setup;      AfterBuild();

            const string XMLfile = @"C:\Users\nicop\OneDrive - Universidad Católica del Uruguay\Codigos\C#\Entregables\Entregable 2\Code\Entregable 2\Src\ArchivosHTML\Prueba.xml";
            List<Tag> tags = Filtro.FiltrarHTML(LeerHtml.RetornarHTML(XMLfile));

            //Se crean los objetos C#
            foreach (Tag tag in tags)
            {
                switch (tag.Nombre)
                {
                    case "World":
                        Creator.World = Creator.AddWorld(tag);
                        break;
                    case "Level":
                        Creator.Level = Creator.AddLevel(tag);
                        break;
                    case "Button":
                        Items button = Creator.AddButton(tag);
                        break;
                    case "ButtonAudio":
                        Items buttonAudio = Creator.AddButtonAudio(tag);
                        break;
                    case "Image":
                        Items image = Creator.AddImage(tag);
                        break;
                    case "DragAndDropSource":
                        Items dragAndDropSource = Creator.AddDragAndDropSource(tag);
                        break;
                    case "DragAndDropDestination":
                        Items dragAndDropDestination = Creator.AddDragAndDropDestination(tag);
                        break;
                    case "DragAndDropItem":
                        Items dragAndDropItem = Creator.AddDragAndDropItem(tag);
                        break;
                }
            }

            firstPage = Creator.World.SpaceList[0];

            //Crear los objetos Unity            
            foreach (Space level in Creator.World.SpaceList)
            {
                level.CreateUnityLevel(adapter);
            }
        }

        /// <summary>
        /// Actions
        /// </summary>
        public void AfterBuildShowFirstPage()
        {
            adapter.ChangeLayout(Layout.Vertical); 
            adapter.ShowPage(firstPage.ID);
            firstPage.ShowLevelItems(adapter);
        }
    }
}

/*
Funcionalidad de botones:

1) Un solo AddButton:
    con type = tag.Atributos.Find(delegate (Atributos atr) { return atr.Clave == "Type"; }).Valor;
    switch(type) { case "Audio": Items ab = new AudioButton() };

Ej:
    <Button Name="" Type="Audio" AudioFile="audio.wav" Width="" Height="" PositionX="" PositionY="" Color="" Image=""/>
    
    Type="Audio" -> AudioFile="audio.wav"
    Type="GoToPage" -> Page="level1"


2) Diferentes AddButton:

<ButtonAudio Name="" AudioFile="audio.wav" Width="" Height="" PositionX="" PositionY="" Color="" Image=""/>
<ButtonGoTo Name="" GoToPage="level1" Width="" Height="" PositionX="" PositionY="" Color="" Image=""/>

AddButtonAudio() {}
AddButtonGoTo() {}


3) Mas de un evento al hacer click en un boton.
------------------------------------------------------------------------------------------------------------------

Pantalla en vertical
Unity a iPhone

------------------------------------------------------------------------------------------------------------------

Version Nueva de repo
ToDoAfterBuild (obsoleto) / Action AfterBuild

------------------------------------------------------------------------------------------------------------------

Texto fijo

------------------------------------------------------------------------------------------------------------------

Borrar items al cambiar de pagina.
*/