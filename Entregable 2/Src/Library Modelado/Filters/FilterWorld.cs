using LeerHTML;
namespace Proyecto.Filters
{
    public class FilterWorld : IFilter
    {
        public World world;
        public Tag WorldCreator(Tag tag)
        {
            
            return tag;
        }
    }
}