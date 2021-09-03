using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using my_app_backend.DAO;
using my_app_backend.Models;
using my_app_backend.Models.ViewModel;

namespace my_app_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryDAO _categoryDao;

        public CategoryController(CategoryDAO categoryDao)
        {
            this._categoryDao = categoryDao;
        }
        
        [HttpGet]
        public async Task< List<Category> > All()
        {
            return await this._categoryDao.All();
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<Category> > FindById(int? id)
        {
            return id.HasValue ? await this._categoryDao.FindById(id) : NotFound();
        }
        
        [HttpPost("create")]
        public async Task< Category > Add([FromBody] CategoryVM body)
        {
            return await this._categoryDao.Create(body);
        }

        [HttpDelete("delete/{id}")]
        public async Task<Category> Delete(int id)
        {
            return await this._categoryDao.Delete(id);
        }
    }
    
}