using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2_Spiderman
{
    public class Spiderman_Otto_Octavius : PeterParker
    {
        public bool SpiderBots { get; protected set; }

        public Spiderman_Otto_Octavius() : base()
        {
            this.Name = "Otto Octavius";
            this.MaxWebCount = 20;
            this.CurrentWebCount = MaxWebCount;
        }

        public string DeploySpiderBots()
        {
            if(this.SpiderBots)
                return this.Name + " throws out some spider bots.";
            else
                return "The spider bots are not readyy";   
        }

        public void BuildSpiderBots()
        {
            this.SpiderBots = true;
        }

        public void DestroySpiderBots()
        {
            this.SpiderBots = false;
        }
    }
}
