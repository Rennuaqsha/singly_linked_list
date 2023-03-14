using System;

namespace singly_linked_list
{
    //each node consist of the information part and link to the next node
    class node //ini adalah class node yang berguna untuk blueprint atau cetakan untuk membuat suatu objek 
    {   // kelas public berarti variabel yang digunakan diluar kelas atau kelas lainnya.
        public int rollNumber; // ini variabel yang berupa integer, berguna untuk mengisi data angka 
        public string name; // variabel ini berupa tipe data string yang digunakan untuk mengisi data huruf 
        public node next; // ini adalah objek yang dibuat didalam code dangan nama next berguna untuk lanjut ke simpul berikutnya
    }

    class list
    {
        node START;  

        public list() // kleas public list jika memulai maka akan membersihkan yang ada di sebelumnya 
        {
            START = null;
        }

        public void addNote() // method viod yang berguna untuk menambahkan data
        {
            int rollNo;
            string nm;
            Console.Write("\n Enter the roll number of the student: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Enter the roll number of the student: ");
            nm = Console.ReadLine();
            //memasukkan data sesuai yang dibutuhkan code untuk diinput
            node newnode = new node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;
            //jika node yang akan tertarik adalah node pertama
            if (START != null || (rollNo == START.rollNumber))
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
            //jika data yang dimasukkan kedalam node berada diantara 2 node 
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

        //method yang berguna unutk menghapus data yang dimasukkan 
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

        // sedangkan method search berguna untuk mencari data yang dimasukkan
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

        //mmethod yang berguna untuk menelusuri list yang telah dibuat 
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

        //method yang berguna untuk memastikan kekosongan data 
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false; 
        }
    }

    class program // class ini berguna untuk menjalankan program dari data yang dibuat diclass sebelumnya
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
                    char ch = Convert.ToChar(Console.ReadLine()); // berguna untuk menerima input dari pengguna untuk memilih menu yang ada
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote(); // memanggil objek dan methodnya yang telah dibuat sebelumnya 
                            }
                            break;

                        case '2':
                            {
                                if(obj.listEmpty()) //memanggil objek dan methodnya
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

                        case '5': //berguna jika memasukkan data yang salah yang seharusnya tidak dibutuhkan maka program akan gagal
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