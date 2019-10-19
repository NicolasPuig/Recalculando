using Proyecto.LeerHTML;
using Proyecto.LibraryModelado;

namespace Proyecto.Factory.CSharp
{
    /// <summary>
    ///  Esta clase es la responsable de crear objetos Items. 
    /// Utiliza la interfaz IFactoryComponent.
    /// </summary>
    public class FactoryItem : IFactoryComponent
    {
        private FactoryButton factoryButton;
        private FactoryImage factoryImage;
        private FactoryDraggableItem factoryDraggableItem;
        private FactoryDragContainer factoryDragContainer;

        /// <summary>
        /// Se sobreescribe el método de la clase IFactoryComponent
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>IComponent</returns>
        public override IComponent MakeComponent(Tag tag)
        {
            switch (tag.Nombre)
            {
                case "Button":
                    IComponent button = factoryButton.MakeComponent(tag);
                    return button;

                case "Image":
                    IComponent image = factoryImage.MakeComponent(tag);
                    return image;

                case "DraggableItem":
                    IComponent draggableItem = factoryDraggableItem.MakeComponent(tag);
                    return draggableItem;

                case "DragContainer":
                    IComponent dragContainer = factoryDragContainer.MakeComponent(tag);
                    return dragContainer;

                default: throw new System.Exception($"Invalid Tag Name {tag.Nombre}");
            }
        }
    }
}