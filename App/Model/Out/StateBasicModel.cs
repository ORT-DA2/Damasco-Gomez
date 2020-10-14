using Domain.Entities;

namespace Model.Out
{
    public class StateBasicModel
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public StateBasicModel(State state)
        {
            this.Id = state.Id;
            this.Name = state.Name;
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is RegionDetailModel region)
            {
                result = this.Id == region.Id ;
            }
            return result;
        }
    }
}