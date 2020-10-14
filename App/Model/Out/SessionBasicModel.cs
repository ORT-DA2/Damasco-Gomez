using System;

namespace Model.Out
{
    public class SessionBasicModel
    {
        public Guid Token {get; set;}
        public SessionBasicModel(Guid token)
        {
            this.Token = token;
        }
        public override bool Equals(object obj)
        {
            var result = false;
            if(obj is SessionBasicModel session)
            {
                result = this.Token == session.Token ;
            }
            return result;
        }
    }
}