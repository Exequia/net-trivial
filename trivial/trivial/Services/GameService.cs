using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trivial.Models;
using trivial.Services.Interfaces;

namespace trivial.Services
{
    public class GameService : IGameService
    {
        public List<CategoryModel> GetAllCategories()
        {
            List<CategoryModel> categories = new List<CategoryModel>();

            categories.Add(new CategoryModel {
                Id = 10,
                Name = "TV"
            });

            return categories;
        }
    }
}
