using Domain;

namespace Model.Out
{
    public class CategoryBasicInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryBasicInfoModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }
    }
}
