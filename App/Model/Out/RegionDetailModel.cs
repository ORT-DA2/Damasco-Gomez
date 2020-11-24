using Domain;

namespace Model.Out
{
    public class RegionDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RegionDetailModel(Region region)
        {
            if (region != null)
            {
                this.Id = region.Id;
                this.Name = region.Name;
            }
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is RegionDetailModel region)
            {
                result = this.Id == region.Id;
            }
            return result;
        }
    }
}