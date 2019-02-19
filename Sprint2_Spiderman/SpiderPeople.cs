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
            return this.Name + " has spider-based abilities \nWeb shooter with a capacity of " + this.MaxWebCount + " uses, \nCurrent web count is: " + CurrentWebCount;
        }
        public SpiderPeople()
        {
            this.WebShooterReady = false;
            this.WebCartridge = new WebCartridge();
            this.MaxWebCount = 10;
            this.CurrentWebCount = MaxWebCount;
        }
        public void WebSwing()
        {
            WebSwing(1);
        }

        public void WebSwing(int HowManyTimes)
        {
            if (WebShooterReady)
            {
                if (this.CurrentWebCount >= HowManyTimes && this.CurrentWebCount > 0)
                {
                    this.CurrentWebCount = this.CurrentWebCount - HowManyTimes;
                    Console.WriteLine(this.Name + " web slings around New York City.");
                }
                else
                    Console.WriteLine("There is not enough webbing in the cartridge");
            }

            else
                Console.WriteLine("The web shooter is not ready");

        }

        public void RefillWebShooter()
        {
            this.WebCartridge.InsertWebCartridge();
            this.CurrentWebCount = this.MaxWebCount;

        }
        public void EmptyWebShooter()
        {
                this.WebCartridge.RemoveWebCartridge();
        }

        public void WebShooterPrepared()
        {
            if (this.WebCartridge.CartridgeInstalled)
                this.WebShooterReady = true;
            else
                this.WebShooterReady = false;

        }




    }
}
