using System;
using System.Collections.Generic;
using System.Linq;
using TestChips;

class Program
{
    static void Main()
    {
        List<int> chips = Console.ReadLine().Split(" ").Select(Int32.Parse).ToList();
        Table table = new Table(chips);
        int steps = table.GetSteps();
        Console.WriteLine(steps);
    }
}