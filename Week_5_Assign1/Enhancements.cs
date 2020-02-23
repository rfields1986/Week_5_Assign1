using System;
using System.Collections.Generic;
using System.IO;

namespace Week_5_Assign
{
    class Enhancements : Ticket
    {
        public string software { get; set; }
        public double cost { get; set; }
        public string reason { get; set; }
        public double estimate { get; set; }

        public void ReadTicketFile()
        {


            string file = "../../Files/Enhancements.csv";
            StreamReader rd = new StreamReader(file);
            string line = rd.ReadLine();
            string[] header = line.Split(',');
            if (rd.EndOfStream)
            {
                Console.Clear();
                Console.WriteLine("Enhancement Ticket File\n");
                Console.WriteLine("No Tickets In This File");
                Console.ReadKey();
            }

            while (!rd.EndOfStream)
            {
                Console.WriteLine("Enhancement Ticket File\n");
                string line1 = rd.ReadLine();
                string[] body = line1.Split(',');
                for (int i = 0; i < body.Length; i++)
                {
                    Console.Write("{0,-20}", header[i]);
                    Console.WriteLine(body[i]);

                }
                Console.WriteLine("\n");




            }
            Console.WriteLine("Press Enter To Return To The Main Menu");
            Console.ReadKey();
            rd.Close();
        }
        public void CreateNewTicket()
        {

            string file = "../../Files/Enhancements.csv";
            StreamWriter rd1 = new StreamWriter(file, append: true);
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
            Console.WriteLine("What software is this enhancement related to?");
            software = Console.ReadLine();
            Console.Clear();
            double costTemp;
            Console.WriteLine("What is the estimated cost of the enhancement?");
            Double.TryParse(Console.ReadLine(), out costTemp);
            cost = costTemp;
            Console.Clear();
            Console.WriteLine("What is the reason for the enhancement?");
            reason = Console.ReadLine();
            Console.Clear();
            double estimateTemp;
            Console.WriteLine("What is the estimated cost of the enhancement?");
            Double.TryParse(Console.ReadLine(), out estimateTemp);
            estimate = estimateTemp;
            rd1.WriteLine($"{ticketID},{ticketSummary},{ticketStatus},{ticketPriority},{submitedBy},{assignedTo},{watchedBy},{software},{cost},{reason},{estimate}");
            rd1.Close();
            Console.WriteLine("Press Enter To Return To The Main Menu");
            Console.ReadKey();

        }

    }
}
