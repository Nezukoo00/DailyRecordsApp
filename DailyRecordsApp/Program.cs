using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyRecordsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new RecordManager();
            while (true)
            {
                Console.WriteLine("1. View Records");
                Console.WriteLine("2. Add Record");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewRecords(manager);
                        break;
                    case "2":
                        AddRecord(manager);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void ViewRecords(RecordManager manager)
        {
            var records = manager.GetRecords();
            foreach (var record in records)
            {
                Console.WriteLine($"Id: {record.Id}, Content: {record.Content}, Date: {record.Date}");
            }
        }

        static void AddRecord(RecordManager manager)
        {
            Console.Write("Enter record content: ");
            var content = Console.ReadLine();
            var record = manager.CreateRecord(content);
            Console.WriteLine($"Record added: Id: {record.Id}, Content: {record.Content}, Date: {record.Date}");
        }
    }
}
