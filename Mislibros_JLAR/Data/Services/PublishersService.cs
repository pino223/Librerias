using Mislibros_JLAR.Data.Models;
using Mislibros_JLAR.Data.ViewModels;

namespace Mislibros_JLAR.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService (AppDbContext context)
        {
            _context = context;
        }
        //Metodo que nos permite agregar una nueva Editora a la BD
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
    }
}
