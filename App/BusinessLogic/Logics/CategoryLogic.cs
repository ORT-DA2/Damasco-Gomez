using System.Collections.Generic;
using BusinessLogicInterface;
using DataAccessInterface.Repositories;
using Domain;
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
            if (category.CategoryTouristPoints != null)
            {
                category.CategoryTouristPoints.ForEach
                (
                    m => m.TouristPoint = this.touristPointRepository.Find(m.TouristPointId)
                );
            }
            Category categoryAdded =  this.categoryRepository.Add(category);
            return categoryAdded;
        }
        public Category Update(int id, Category category)
        {
            Category categoryBd = this.categoryRepository.Find(id);
            if (category.CategoryTouristPoints != null)
            {
                category.CategoryTouristPoints.ForEach
                (
                    m => m.TouristPoint = this.touristPointRepository.Find(m.TouristPointId)
                );
                categoryBd.CategoryTouristPoints.RemoveAll(x => x.CategoryId == categoryBd.Id);
                categoryBd.CategoryTouristPoints = category.CategoryTouristPoints;
            }
            categoryBd.Update(category);
            this.categoryRepository.Update(id, categoryBd);
            return categoryBd;
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