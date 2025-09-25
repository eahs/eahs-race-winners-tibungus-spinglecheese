using System;
using System.Threading.Tasks;

namespace RaceWinners;
//maybe ts will work
public class Program
{
    static async Task Main(string[] args)
    {
        DataService ds = new DataService(); // Make a new object to get the race data

        // Asynchronously retrieve the group (class) data
        var data = await ds.GetGroupRanksAsync(); // Get the race results (list of classes with ranks)

        for (int i = 0; i < data.Count; i++) // Loop through each class
        {
            // Combine the ranks to print as a list
            var ranks = String.Join(", ", data[i].Ranks); // Turn ranks into a string

            Console.WriteLine($"{data[i].Name} - [{ranks}]"); // Print class name and ranks
        }

        //get the averages from each group
        var aWinner = false;
        var bWinner = false;
        var cWinner = false;
        var dWinner = false;

        for (int i = 0; i < data.Count; i++) // Loop through each class
        {
            var average = 0.0;
            foreach (int j in data[i].Ranks) // Add up all the ranks
            {
                average += j;
            }
            Console.WriteLine($"{data[i].Name} Average: {average / data[i].Ranks.Count} "); // Print average
        }

        //determine which group has the lowest average
        var aAverage = 0.0;
        foreach (int v in data[0].Ranks)
        {
            aAverage += v;
        }
        aAverage = aAverage / data[0].Ranks.Count;

        var bAverage = 0.0;
        foreach (int v in data[1].Ranks)
        {
            bAverage += v;
        }
        bAverage = bAverage / data[1].Ranks.Count;

        var cAverage = 0.0;
        foreach (int v in data[2].Ranks)
        {
            cAverage += v;
        }
        cAverage = cAverage / data[2].Ranks.Count;

        var dAverage = 0.0;
        foreach (int v in data[3].Ranks)
        {
            dAverage += v;
        }
        dAverage = dAverage / data[3].Ranks.Count;

        var lowestAverage = Math.Min(Math.Min(aAverage, bAverage), Math.Min(cAverage, dAverage)); // Get the lowest of the four averages

        //set the winner variables to true for the group with the lowest average
        if (lowestAverage == aAverage)
        {
            aWinner = true;
        }
        else if (lowestAverage == bAverage)
        {
            bWinner = true;
        }
        else if (lowestAverage == cAverage)
        {
            cWinner = true;
        }
        else if (lowestAverage == dAverage)
        {
            dWinner = true;
        }

        //print the winner
        if (aWinner)
        {
            Console.WriteLine($"Class A is the overall winner with an average of {aAverage}");
        }
        else if (bWinner)
        {
            Console.WriteLine($"Class B is the overall winner with an average of {bAverage}");
        }
        else if (cWinner)
        {
            Console.WriteLine($"Class C is the overall winner with an average of {cAverage}");
        }
        else if (dWinner)
        {
            Console.WriteLine($"Class D is the overall winner with an average of {dAverage}");
        }

        //use the group with the lowest average as a length for how long the other groups should be
        var length = 0;
        if (aWinner)
        {
            length = data[0].Ranks.Count; // Use Class A's length
        }
        else if (bWinner)
        {
            length = data[1].Ranks.Count; // Use Class B's length
        }
        else if (cWinner)
        {
            length = data[2].Ranks.Count; // Use Class C's length
        }
        else if (dWinner)
        {
            length = data[3].Ranks.Count; // Use Class D's length
        }

        //redo the averages for each group but only use the length determined by the winning group
        aAverage = 0.0;
        for (int i = 0; i < length; i++)
        {
            aAverage += data[0].Ranks[i]; // Add values up to the shared length
        }
        aAverage = aAverage / length;

        bAverage = 0.0;
        for (int i = 0; i < length; i++)
        {
            bAverage += data[1].Ranks[i];
        }
        bAverage = bAverage / length;

        cAverage = 0.0;
        for (int i = 0; i < length; i++)
        {
            cAverage += data[2].Ranks[i];
        }
        cAverage = cAverage / length;

        dAverage = 0.0;
        int dCount = Math.Min(length, data[3].Ranks.Count);
        for (int i = 0; i < dCount; i++)
        {
            dAverage += data[3].Ranks[i];
        }
        dAverage = dAverage / length; 


        Console.WriteLine("Averages recalculated using the length of the winning group:"); 

        //print the new averages
        Console.WriteLine($"Class A New Average: {aAverage}");
        Console.WriteLine($"Class B New Average: {bAverage}");
        Console.WriteLine($"Class C New Average: {cAverage}");
        Console.WriteLine($"Class D New Average: {dAverage}");

        //determine the new winner
        lowestAverage = Math.Min(Math.Min(aAverage, bAverage), Math.Min(cAverage, dAverage)); // Re-check lowest average

        aWinner = false;
        bWinner = false;
        cWinner = false;
        dWinner = false;

        if (lowestAverage == aAverage)
        {
            aWinner = true;
        }
        else if (lowestAverage == bAverage)
        {
            bWinner = true;
        }
        else if (lowestAverage == cAverage)
        {
            cWinner = true;
        }
        else if (lowestAverage == dAverage)
        {
            dWinner = true;
        }

        //print the new winner
        if (aWinner)
        {
            Console.WriteLine($"Class A is the overall winner with a new average of {aAverage}");
        }
        else if (bWinner)
        {
            Console.WriteLine($"Class B is the overall winner with a new average of {bAverage}");
        }
        else if (cWinner)
        {
            Console.WriteLine($"Class C is the overall winner with a new average of {cAverage}");
        }
        else if (dWinner)
        {
            Console.WriteLine($"Class D is the overall winner with a new average of {dAverage}");
        }
    }
}
