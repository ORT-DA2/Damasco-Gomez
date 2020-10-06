using Domain;

namespace Model.Out
{
    public class CategoryBasicInfoModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public CategoryBasicInfoModel(Category category)
         {
            this.Id = category.Id;
            this.Name = category.Name;
        }

     }
 }
 