namespace consApp_Timer
{

    using System;
    using System.IO;
    using System.Text.Json;
    using System.Timers;
    using System.Threading;


    public class Person
    {
        public string? Name { get; set; }   // vs. required ...
        public int? Alter { get; set; }   // property is Nullable
        public string? Stadt { get; set; }
        public string? Inst { get; set; }   // InstanceName

        public string NameAndCity()
        {
            string nameAndCity = $"{Name} ({Alter}), {Stadt}";
            return nameAndCity;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //--              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            string pathName = @"C:\temp_dev\";
            string fileName = Path.Combine(pathName, "Personendaten.json");


            Person p1 = new Person();

            p1.Inst = nameof(p1);
            p1.Name = "max";
            p1.Alter = 42;
            p1.Stadt = "MUC";

            Console.WriteLine(".. start");
            Console.WriteLine(fileName);
            Console.WriteLine(p1.NameAndCity());

            var options = new JsonSerializerOptions { WriteIndented = true };  //  JSON => 'gut lesbar, in Zeilen'
            string jsonString = JsonSerializer.Serialize(p1);     // (p1, options);
            File.WriteAllText(fileName, jsonString);

            while (true)
            {
                Thread.Sleep(5000);
                workMethod();
            }


        }

        private static void workMethod()
        {
            Console.WriteLine("..." + String.Format(DateTime.Now.ToString("HH:mm:ss tt")));
        }
    }

}
//----