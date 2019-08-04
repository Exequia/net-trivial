using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trivial.Models;

namespace trivial.Services.Interfaces
{
    public interface IGameService
    {
        /// <summary>
        /// Get All categories from Data Base
        /// </summary>
        /// <returns></returns>
        List<CategoryModel> GetAllCategories();
    }
}
