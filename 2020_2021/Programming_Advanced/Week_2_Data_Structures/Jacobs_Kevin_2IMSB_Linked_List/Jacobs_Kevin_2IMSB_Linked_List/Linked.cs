using System;
using System.Collections.Generic;
using System.Text;

namespace Jacobs_Kevin_2IMSB_Linked_List
{
    class Linked
    {
        //public
        public Node m_FirstNode;

        public Linked(Node first)
        {
            m_FirstNode = first;
        }
        public void Print()
        {
            Node temp = m_FirstNode;
           // Console.Write("Print all Data: \n");
            while (temp != null)
            {
                Console.Write(temp.m_Data + " ");
                temp = temp.m_NextNode;
            }
            Console.WriteLine();
        }
        public void Add(Node n)
        {
            //if insert for first time
            if (m_FirstNode == null)
            {
                m_FirstNode = n;
                m_Size++;
                return;
            }
            Node temp = m_FirstNode;
            m_FirstNode = n;
            m_FirstNode.m_NextNode = temp;
            m_Size++;
        }
        public void Delete()
        {
   
            if (m_FirstNode == null)
            {
                Console.Write("There are currently 0 nodes in this list.\nPlease use the 'insert' command to fill it\n");
                return;
            }
            m_FirstNode = m_FirstNode.m_NextNode;
            m_Size--;
        }
        public void MoveBackwards(uint move)
        {
            //conditions
            bool isFirst = (m_FirstNode == null), isNext = (m_FirstNode.m_NextNode == null), isSizeDif = ((move % m_Size) == 0);
            if (isFirst || isNext || isSizeDif) return; // if next is null there is no point in rotating there is only 1 value. or if there is no different in size
            uint iter = move;
            if (m_Size < move) iter = (move % m_Size);
            Node temp = m_FirstNode;
            for (int i = 0; i < iter; i++) temp = temp.m_NextNode;
            Node insert = new Node(m_FirstNode.m_Data);
            insert.m_NextNode = temp.m_NextNode;
            temp.m_NextNode = insert;
            m_FirstNode = m_FirstNode.m_NextNode;
        }
        public void MoveForward(uint move)
        {
            //conditions
            bool isFirst = (m_FirstNode == null), isNext = (m_FirstNode.m_NextNode == null), isSizeDif = ((move % m_Size) == 0);
            if (isFirst || isNext || isSizeDif) return; // if next is null there is no point in rotating there is only 1 value. or if there is no different in size
            uint iter = move;
            if (m_Size > move)
            {
                iter = m_Size - move;
            }
            else
            {
                iter = m_Size - (move % m_Size);
            }
           
            Node temp = m_FirstNode;
            for (int i = 0; i < iter; i++) temp = temp.m_NextNode;
            Node insert = new Node(m_FirstNode.m_Data);
            insert.m_NextNode = temp.m_NextNode;
            temp.m_NextNode = insert;
            m_FirstNode = m_FirstNode.m_NextNode;
        }

        //private
        private uint m_Size = 0;
    }
}
