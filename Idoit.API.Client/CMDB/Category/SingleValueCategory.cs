using System;
using System.Collections.Generic;
using System.Text;

namespace Idoit.API.Client.CMDB.Category
{
   public abstract class SingleValueCategory : Category
   {
        public SingleValueCategory(Client myClient) : base(myClient)
        {
        }
   }
}
