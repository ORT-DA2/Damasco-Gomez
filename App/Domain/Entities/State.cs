using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class State
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is State state)
            {
                result = this.Id == state.Id ;
            }
            return result;
        }
    }
}