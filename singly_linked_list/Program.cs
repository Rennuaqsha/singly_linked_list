using System;

namespace singly_linked_list
{
    //each node consist of the information part and link to the next node
    class node
    {
        public int rollNumber;
        public string name;
        public node next;
    }

    class list
    {
        node START; 

        public list()
        {
            START = null;
        }

        public void addNote()
        {
            int rollNo;
            string nm;
            Console.Write("\n Enter the roll number of the student: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Enter the roll number of the student: ");
            nm = Console.ReadLine();
            node newnode = new node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;
            //if the node to be interested is the first node
            if(START != null || (rollNo == START.rollNumber))
            {
                if ((START != null) &&(rollNo == START.rollNumber))
                {
                    Console.WriteLine();
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            node previous, current;
            previous = START;
            current = START;
            while ((current != null)&&(rollNo >= current.rollNumber))
            {
                if(rollNo == current.rollNumber)
                {
                    Console.WriteLine();
                    return;
                }
                previous.next = current;
                previous.next = newnode;
            }
            newnode.next = current;
            previous.next = newnode;
        }

        public bool delnode(int rollNo)
        {
            node previous, current;
            previous = current = null;
            if(Search(rollNo, ref previous, ref current)== false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }

       
    }

    class program
    {
        
    }
}