using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2_Spiderman
{
    public class PeterParker : SpiderPeople
    {
        public PeterParker() : base()
        {
            this.Name = "Peter Parker";
            this.MaxWebCount = 14;
            this.CurrentWebCount = 14;
        }
    }
}
