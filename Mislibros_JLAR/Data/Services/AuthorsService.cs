using Mislibros_JLAR.Data.Models;
using Mislibros_JLAR.Data.ViewModels;
using System;

namespace Mislibros_JLAR.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }
        //Metodo que nos permite agregar un nuevo autor en BD
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName,
                
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
    }
}
