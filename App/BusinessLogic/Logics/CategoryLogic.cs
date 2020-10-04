using System;
using System.Collections.Generic;
using BusinessLogic.Logics;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;

namespace BusinessLogic
{
    public class CategoryLogic :  ICategoryLogic
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

         public void Delete()
        {
            foreach(Category Category in this.categoryRepository.GetElements())
            {
                this.Delete(Category.Id);
            }
        }
        public IEnumerable<Category> GetAll()
        {
            return this.categoryRepository.GetElements();
        }
        public Category GetBy(int id)
        {
            try
            {
                return this.categoryRepository.Find(id);
            }
            catch(ArgumentException)
            {
                return null;
            }
        }

        public Category Add(Category Category)
        {
            return this.categoryRepository.Add(Category);
        }
        public void Update(int id,Category Category)
        {
            this.categoryRepository.Update(id, Category);
        }
        public void Delete(int id)
        {
            this.categoryRepository.Delete(id);
        }
        public bool Exist(Category Category)
        {
            return this.categoryRepository.ExistElement(Category);
        }

    }
}