using System;
//using TM.ProgrammingAdvanced;

namespace Jacobs_Kevin_2IMSB_Linked_List
{
    class Program
    {
            enum StateProgram
            {
                insert,
                print,
                delete,
                moveForward,
                moveBackward,
                exit
            }
        static void Main(string[] args)
        {
           // Console.Write(1 % 12);
            bool exit = false;
            Node node = new Node(" ");
            Linked list = new Linked(node);
            //list.Add(new Node("apple"));
            //list.Add(new Node("banana"));
            //list.Add(new Node("mango"));
            //list.Add(new Node("2"));
            //list.Add(new Node("1"));

            while (!exit)
            {
                //StateProgram myState = StateProgram.idle;
                //Console.Write("Please insert a command: ");
                string command = Console.ReadLine();
                Enum.TryParse(command.Split(" ")[0],out StateProgram myState);
                switch (myState)
                {
                    case StateProgram.insert:
                        list.Add(new Node(command.Split(" ")[1]));
                        break;
                    case StateProgram.print:
                        list.Print();
                        break;
                    case StateProgram.delete:
                        list.Delete();
                        break;
                    case StateProgram.moveForward:
                        list.MoveForward(Convert.ToUInt32(command.Split(" ")[1]));
                        break;
                    case StateProgram.moveBackward:
                        list.MoveBackwards(Convert.ToUInt32(command.Split(" ")[1]));
                        break;
                    case StateProgram.exit:
                        exit = true;
                        break;
                    default:
                        Console.Write("ERROR IN SWITCH: Your state is wrong current state is " + myState);
                        break;
                }
                Console.Write("\n");
            }

        }

    }
}
