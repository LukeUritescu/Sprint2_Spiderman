using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2_Spiderman
{
    public class WebCartridge
    {
        public bool CartridgeInstalled;

        public string About()
        {
            if (CartridgeInstalled)
                return "Web Cartridge is inserted";
            else
                return "Web cartridge is not inserted";
        }

        public WebCartridge()
        {
            CartridgeInstalled = false;
        }

        public void InsertWebCartridge()
        {
            CartridgeInstalled = true;
        }

        public void RemoveWebCartridge()
        {
            CartridgeInstalled = false;
        }
    }
}
