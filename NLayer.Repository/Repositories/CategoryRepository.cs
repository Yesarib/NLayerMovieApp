﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithMovieAsync(int categoryId)
        {
#pragma warning disable CS8603 // Olası null başvuru dönüşü.
            return await _context.Categories.Include(x => x.Movies).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
#pragma warning restore CS8603 // Olası null başvuru dönüşü.
        }
    }
}
