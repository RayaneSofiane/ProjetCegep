using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCegep.Controler
{
    public class CegepControler
    {
        private static CegepControler instance;

        public static CegepControler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CegepControler();
                }
                return instance;
            }
        }
    }
}
