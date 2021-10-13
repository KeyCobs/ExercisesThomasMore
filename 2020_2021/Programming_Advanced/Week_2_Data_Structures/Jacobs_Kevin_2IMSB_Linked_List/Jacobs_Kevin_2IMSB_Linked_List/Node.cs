using System;
using System.Collections.Generic;
using System.Text;

namespace Jacobs_Kevin_2IMSB_Linked_List
{
    class Node
    {
        //Public
       public string m_Data {get; set;}
       public Node m_NextNode { get; set; }

       public Node (string data)
        {
            m_Data = data;
        }
    }
}
