using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using my_app_backend.Database;
using my_app_backend.Models;
using my_app_backend.Models.ViewModel;

namespace my_app_backend.DAO
{
    public class CategoryDAO
    {
        private readonly BlogDbContext _dbContext;
        
        public CategoryDAO(BlogDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        public async Task< List<Category> > All()
        {
            return await this._dbContext.Categories.ToListAsync();
        }

        public async Task<Category> FindById(int? id)
        {
            return await this._dbContext.Categories.FirstAsync( (x) => x.Id == id );
        }

        public async Task<Category> Create(CategoryVM refCategory)
        {
            Category categoryToAdd = new Category()
            {
                Name = refCategory.Name,
                CreatedAt = refCategory.CreatedAt,
                UpdatedAt = refCategory.UpdatedAt
            };

            EntityEntry<Category> resultModel = await this._dbContext.Categories.AddAsync(categoryToAdd);
            var resultSave = await this._dbContext.SaveChangesAsync();
            return resultModel.Entity;
        }

        public async Task<Category> Delete(int id)
        {
            Category categoryToDelete = await this._dbContext.Categories.FindAsync(id);
            this._dbContext.Categories.Remove(categoryToDelete);
            await this._dbContext.SaveChangesAsync();

            return categoryToDelete;
        }
    }
}