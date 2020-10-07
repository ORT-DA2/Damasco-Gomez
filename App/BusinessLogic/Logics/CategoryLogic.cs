using System;
using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;
using Model.Out;

namespace BusinessLogic
{
    public class CategoryLogic :  ICategoryLogic
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ITouristPointRepository touristPointRepository;
        public CategoryLogic(ICategoryRepository categoryRepository,ITouristPointRepository touristPointRepository)
        {
            this.categoryRepository = categoryRepository;
            this.touristPointRepository = touristPointRepository;
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

        public Category Add(Category category)
        {
            Validate(category);
            category.CategoryTouristPoints.ForEach
            (
                m => m.TouristPoint = this.touristPointRepository.Find(m.TouristPointId)
            );
            Category categoryAdded =  this.categoryRepository.Add(category);
            return categoryAdded;
        }
        public Category Update(int id, Category category)
        {
            Validate(category);
            category.CategoryTouristPoints.ForEach
            (
                m => m.TouristPoint = this.touristPointRepository.Find(m.TouristPointId)
            );
            this.categoryRepository.Update(id, category);
            return category;
        }
        public void Delete(int id)
        {
            this.categoryRepository.Delete(id);
        }
        public bool Exist(Category Category)
        {
            return this.categoryRepository.ExistElement(Category);
        }
        public void Validate(Category category)
        {
            if (category == null)
            {
                throw new ArgumentException("Category is empty");
            }
        }

    }
}