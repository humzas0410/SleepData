using System.Data;
using System.Formats.Asn1;
// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data file.");
Console.WriteLine("Enter anything else to quit");

string? resp = Console.ReadLine();

if (resp == "1")
{
    // create data file
    // ask question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = Convert.ToInt32(Console.ReadLine());
    // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    // random number generator
    Random rnd = new();
    // create file
    StreamWriter sw = new("dataDate.txt");

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12
            hours[i] = rnd.Next(4, 13);
        }
        //M/d/yyyy,#|#|#|#|#|#|#
        sw.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    // parse data file
    Console.WriteLine("Parsing data file...");

    // Read the file
    string filePath = "dataDate.txt";
    if (!File.Exists(filePath))
    {
        Console.WriteLine("Data file not found.");
        return;
    }

    string[] lines = File.ReadAllLines(filePath);

    foreach (string line in lines)
    {
    // Split the line into date and hours
        string[] parts = line.Split(',');
        string weekStartDate = parts[0];
        string[] hours = parts[1].Split('|');

    // Convert hours to integers
        int[] sleepHours = Array.ConvertAll(hours, int.Parse);

    // Calculate total and average sleep hours
        int totalHours = sleepHours.Sum();
        double averageHours = sleepHours.Average();
    }
}