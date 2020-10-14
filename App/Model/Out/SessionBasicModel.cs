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
    }
}