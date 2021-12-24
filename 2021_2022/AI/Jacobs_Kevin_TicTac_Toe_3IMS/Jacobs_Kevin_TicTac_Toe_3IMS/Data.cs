using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jacobs_Kevin_TicTac_Toe_3IMS
{
    internal class Data
    {

            public Data(int p)
            {
                pos = p;
                dataSet = new List<int>();
            }
            public int pos { get; set; }
            public List<int> dataSet;
        
    }
}
