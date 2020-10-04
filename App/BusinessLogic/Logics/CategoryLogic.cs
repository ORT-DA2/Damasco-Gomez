using System;
using System.Collections.Generic;
using BusinessLogic.Logics;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;
using Model.Out;

namespace BusinessLogic
{
    public class CategoryLogic :  ICategoryLogic
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ITouristPointLogic touristPointLogic;
        public CategoryLogic(ICategoryRepository categoryRepository,ITouristPointLogic touristPointLogic)
        {
            this.categoryRepository = categoryRepository;
            this.touristPointLogic = touristPointLogic;
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
            return this.categoryRepository.Find(id);
        }

        public Category Add(Category Category)
        {
            var categoryAdded =  this.categoryRepository.Add(Category);
            categoryAdded.CategoryTouristPoints.ForEach(m=>m.TouristPoint = this.touristPointLogic.GetBy(m.TouristPointId));
            return Category;
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