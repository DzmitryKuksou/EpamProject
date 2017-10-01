using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Repositories;
using BLL.Interface.Entities;
using BLL.Mappers;

namespace BLL.Interface.Services
{
    public class CategoryService:ICategoryService
    {
        private IUnitOfWork uow;
        public CategoryService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void Create(BLLCategory category)
        {
            uow.Categories.Create(CategoryMapper.GetDALEntity(category));
            uow.Commit();
        }
        public void Update(BLLCategory category)
        {
            uow.Categories.UpDate(CategoryMapper.GetDALEntity(category));
            uow.Commit();
        }
        public void Delete(int id)
        {
            uow.Categories.Delete(uow.Categories.GetById(id));
            uow.Commit();
        }
        public BLLCategory Get(int id)
        {
            return CategoryMapper.GetBLLEntity(uow.Categories.GetById(id));
        }
        public IEnumerable<BLLCategory> GetAll()
        {
            return CategoryMapper.Map(uow.Categories.GetAll());
        }
        public IEnumerable<BLLCategory> Find(string stringKey)
        {
            var categories = uow.Categories.GetAll();
            if (!ReferenceEquals(stringKey, null)) categories = categories.Where(c => c.Name.Contains(stringKey));


            return CategoryMapper.Map(categories);
        }
    }
}
