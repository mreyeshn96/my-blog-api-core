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
    public class PostDAO
    {
        private readonly BlogDbContext _dbContext;

        public PostDAO(BlogDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        public async Task< List<Post> > All()
        {
            return await this._dbContext.Posts.ToListAsync();
        }

        public async Task< Post > FindById(int id)
        {
            return await this._dbContext.Posts.FirstAsync( (e) => e.Id == id );
        }

        public async Task<Post> Create([FromBody]PostVM post)
        {
            Post postToAdd = new Post()
            {
                UserId = post.UserId,
                Title = post.Title,
                Body = post.Body,
                CategoryId =  post.CategoryId
            };

            var newPost = await this._dbContext.Posts.AddAsync(postToAdd);
            this._dbContext.SaveChanges();
            return newPost.Entity;
        }

        public async Task<List<Post>> FindByCategory(int id)
        {
            return await this._dbContext.Posts.Where(e => e.CategoryId == id).ToListAsync();
        }
        public async Task<Post> Delete(int id)
        {
            var postToDelete = await this._dbContext.Posts.FindAsync(id);
            this._dbContext.Posts.Remove(postToDelete);
            this._dbContext.SaveChanges();
            return postToDelete;
        }

        public async Task<Post> Update(int id, PostVM postVm)
        {
            Post postToUpdate = await this._dbContext.Posts.FindAsync(id);
            postToUpdate.Title = postVm.Title ?? postToUpdate.Title;
            postToUpdate.Body = postVm.Body ?? postToUpdate.Body;
            
            this._dbContext.Posts.Update(postToUpdate);
            this._dbContext.SaveChanges();
            return postToUpdate;
        }
    }
}