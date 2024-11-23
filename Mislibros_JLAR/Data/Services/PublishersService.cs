using Mislibros_JLAR.Data.Models;
using Mislibros_JLAR.Data.ViewModels;
using Mislibros_JLAR.NewFolder;
using System;
using System.Linq;
using System.Text.RegularExpressions;

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
        public Publisher AddPublisher(PublisherVM publisher)
        {
            if(StringStartsWithNumber(publisher.Name)) throw new PublisherNameException("El nombre empieza con un numero", publisher.Name);
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherByID(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);


        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId).Select(n => new PublisherWithBooksAndAuthorsVM()
            {
                Name=n.Name,
                BookAuthors = n.Books.Select(n => new BookAuthorVM()
                {
                    BookName = n.Titulo,
                    BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();
            return _publisherData;
        }
        internal void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La editora con id: {id} no existe");
            }
        }
        private bool StringStartsWithNumber(string name)
        {
            if(Regex.IsMatch(name, @"^\d")) return true;
            return false;
        }
    }
}
