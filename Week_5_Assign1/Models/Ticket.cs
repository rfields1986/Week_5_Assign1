using System;
using System.Collections.Generic;
using System.IO;

namespace Week_5_Assign1.Models
{
    public abstract class Ticket
    {
        public string ticketID { get; set; }
        public string ticketSummary { get; set; }
        public string ticketStatus { get; set; }
        public string ticketPriority { get; set; }
        public string submitedBy { get; set; }
        public string assignedTo { get; set; }
        public string watchedBy { get; set; }

        public Ticket()
        {



            ticketID = "";
            ticketSummary = "";
            ticketStatus = "";
            ticketPriority = "";
            submitedBy = "";
            assignedTo = "";
            watchedBy = "";

        }
        public int IDCount()
        {
            string file0 = "../../Files/Tickets.csv";
            string file1 = "../../Files/Enhancements.csv";
            string file2 = "../../Files/Tasks.csv";

            List<string> idCount = new List<string>();

            StreamReader enhanceID = new StreamReader(file0);
            StreamReader taskID = new StreamReader(file1);
            StreamReader bugID = new StreamReader(file2);
            while (!enhanceID.EndOfStream & !taskID.EndOfStream & !bugID.EndOfStream)
            {
                if (!enhanceID.EndOfStream)
                {
                    string readoutHeader = enhanceID.ReadLine();
                    string line = enhanceID.ReadLine();
                    string[] lineSplit = line.Split(',');
                    idCount.Add(lineSplit[0]);
                }
                else if (!taskID.EndOfStream)
                {
                    string readoutHeader = taskID.ReadLine();
                    string line = taskID.ReadLine();
                    string[] lineSplit = line.Split(',');
                    idCount.Add(lineSplit[0]);
                }
                else if (!bugID.EndOfStream)
                {
                    string readoutHeader = bugID.ReadLine();
                    string line = bugID.ReadLine();
                    string[] lineSplit = line.Split(',');
                    idCount.Add(lineSplit[0]);
                }
                else
                {
                    enhanceID.Close();
                    taskID.Close();
                    bugID.Close();
                }

            }
            return idCount.Count + 1;



        }//still working on the code not called in the program
        public void ReadAllTickets()
        {
            int drop = 0;
            do
            {

                if (drop == 0)
                {

                    string file = "../../Files/Tickets.csv";
                    StreamReader rd = new StreamReader(file);
                    string line = rd.ReadLine();
                    string[] header = line.Split(',');
                    if (rd.EndOfStream)
                    {
                        Console.Clear();
                        Console.WriteLine("Bug/Defect Ticket File\n");
                        Console.WriteLine("No Tickets In This File\n");
                        
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Bug/Defect Ticket File\n");
                        while (!rd.EndOfStream)
                        {

                            string line1 = rd.ReadLine();
                            string[] body = line1.Split(',');
                            for (int i = 0; i < body.Length; i++)
                            {
                                Console.Write("{0,-20}", header[i]);
                                Console.WriteLine(body[i]);

                            }
                            Console.WriteLine("\n");




                        }
                    }
                    Console.WriteLine("Press Enter To See Enhancement Tickets");
                    Console.ReadKey();
                    rd.Close();
                    drop++;

                }
                else if (drop == 1)
                {

                    string file = "../../Files/Enhancements.csv";
                    StreamReader rd = new StreamReader(file);
                    string line = rd.ReadLine();
                    string[] header = line.Split(',');
                    if (rd.EndOfStream)
                    {
                        Console.Clear();
                        Console.WriteLine("Enhancement Ticket File\n");
                        Console.WriteLine("No Tickets In This File\n");
                        
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Enhancement Ticket File\n");
                        while (!rd.EndOfStream)
                        {

                            string line1 = rd.ReadLine();
                            string[] body = line1.Split(',');
                            for (int i = 0; i < body.Length; i++)
                            {
                                Console.Write("{0,-20}", header[i]);
                                Console.WriteLine(body[i]);

                            }
                            Console.WriteLine("\n");




                        }
                    }
                    Console.WriteLine("Press Enter To See Task Tickets");
                    Console.ReadKey();
                    rd.Close();
                    drop++;



                }
                else if (drop == 2)
                {

                    string file = "../../Files/Tasks.csv";
                    StreamReader rd = new StreamReader(file);
                    string line = rd.ReadLine();
                    string[] header = line.Split(',');
                    if (rd.EndOfStream)
                    {
                        Console.Clear();
                        Console.WriteLine("Task Ticket File\n");
                        Console.WriteLine("No Tickets In This File\n");
                        
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Task Ticket File\n");
                        while (!rd.EndOfStream)
                        {

                            string line1 = rd.ReadLine();
                            string[] body = line1.Split(',');
                            for (int i = 0; i < body.Length; i++)
                            {
                                Console.Write("{0,-20}", header[i]);
                                Console.WriteLine(body[i]);

                            }
                            Console.WriteLine("\n");




                        }
                    }
                    Console.WriteLine("Press Enter To Return To The Main Menu");
                    Console.ReadKey();
                    rd.Close();
                    drop++;



                }
            } while (drop < 3);


        }
        public virtual void CreateNewTicket()
        {

            string file = "../../Files/Tickets.csv";
            StreamWriter rd1 = new StreamWriter(file, append: true);
            Console.Clear();
            Console.WriteLine("Please Enter A New Ticket Number");
            ticketID = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter a summary of the issue?");
            ticketSummary = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("What the status of this ticket?");
            ticketStatus = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter a priority: High, Medium, or Low?");
            ticketPriority = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("What is your name?");
            submitedBy = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Who is the ticket assigned too?");
            assignedTo = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Who will be watching this ticket? Seperate multiple watchers with \"|\"");
            watchedBy = Console.ReadLine();
            Console.Clear();
            rd1.WriteLine($"{ticketID},{ticketSummary},{ticketStatus},{ticketPriority},{submitedBy},{assignedTo},{watchedBy}");
            rd1.Close();
            Console.WriteLine("Press Enter To Return To The Main Menu");
            Console.ReadKey();

        }



    }
}
