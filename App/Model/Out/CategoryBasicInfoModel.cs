using System.Diagnostics.CodeAnalysis;
using Domain;

namespace Model.Out
{
    public class CategoryBasicInfoModel
    {
        [ExcludeFromCodeCoverageAttribute]
        public int Id { get; private set; }
        [ExcludeFromCodeCoverageAttribute]
        public string Name { get; private set; }
        public CategoryBasicInfoModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }

        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is CategoryBasicInfoModel category)
            {
                result = this.Id == category.Id ;
            }
            return result;
        }
    }
}
