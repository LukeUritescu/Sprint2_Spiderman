using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2_Spiderman
{
    public abstract class SpiderPeople
    {
        public string Name { get; protected set; }
        public int CurrentWebCount { get; protected set; }
        public WebCartridge WebCartridge { get; protected set; }
        public bool WebShooterReady { get; protected set; }
        public int MaxWebCount { get; protected set; }

        public string About()
        {
            return "";
        }
        public SpiderPeople()
        {

        }
        public void WebSwing()
        {
        }

        public void WebSwing(int HowManyTimes)
        {

        }

        public void RefillWebShooter()
        {

        }
        public void EmptyWebShooter()
        {

        }

        public void WebShooterPrepared()
        {

        }




    }
}
