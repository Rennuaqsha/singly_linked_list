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
            if(search(rollNo, ref previous, ref current)== false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }

        public bool search(int rollNo, ref node previous,ref node current)
        {
            previous = current;
            current = current.next;
            while ((current != null)&&(rollNo != current.rollNumber))
            {
                previous = current;
                current = current.next;
            }
            if(current == null)
                return false;
            else
                return true;
        }

        public void Traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nThe records in the list are: ");
            else
            {
                Console.WriteLine("\nThe records in the list are: ");
                node currentNode;
                for (currentNode = START; currentNode != null; 
                    currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + " " + currentNode.name + "\n");
                Console.WriteLine();
            }
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false; 
        }
    }

    class program
    {
        static void Main(String[] args)
        {
            list obj = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. view all the records in the list");
                    Console.WriteLine("4. Search for a record in the list");
                    Console.WriteLine("5. Exit");
                    Console.Write("\n Enter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;

                        case '2':
                            {
                                if(obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.WriteLine("Enter the roll number of" + "the student whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                if (obj.delnode(rollNo)== false)
                                    Console.WriteLine("\n record not found.");
                                else
                                    Console.WriteLine("\n record with roll number" +  + rollNo + "Deleted");
                            }
                            break;

                        case '3':
                            {
                                obj.Traverse();
                            }
                            break;

                        case '4':
                            {
                                if(obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                node previous, current;
                                previous = current = null;
                                Console.Write("\nEnter the roll number of the " + "Student whose record to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord Not Found");
                                else
                                {
                                    Console.WriteLine("\nrecord not found");
                                    Console.WriteLine("\nRoll number: " + current.rollNumber);
                                    Console.WriteLine("\nName:" + current.name);
                                }
                            }
                            break;

                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                                break;
                            }

                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("\nCheck for the value Entered");
                }
            }
        }
    }
}