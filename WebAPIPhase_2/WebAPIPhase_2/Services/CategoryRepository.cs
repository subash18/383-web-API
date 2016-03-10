using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIPhase_2.Models;

namespace WebAPIPhase_2.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private WebAPIPhase_2Context db = new WebAPIPhase_2Context();

        public IEnumerable<Category> GetCategory()
        {
            return db.Category;

        }

        public Category GetCategory(int id) {

            var category = db.Category.Find(id);

            return category;
        }

        public Category GetCategory(string name)
        {

            var category = db.Category.Where(c => c.CategoryName == name).FirstOrDefault(); 

            return category;
        }
    }
}