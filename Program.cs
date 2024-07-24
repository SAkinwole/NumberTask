using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter numbers separated by spaces:");
        var input = Console.ReadLine();
        var numbers = input.Split(' ').Select(int.Parse).ToArray();
        Console.WriteLine(CanFormLargestNumber(numbers));
    }

    static string CanFormLargestNumber(int[] numbers)
    {
        if (numbers.Length < 2)
        {
            return "Not enough numbers";
        }

        Array.Sort(numbers);
        int largestNumber = numbers.Last();
        int[] remainingNumbers = numbers.Take(numbers.Length - 1).ToArray();

        if (CanSumToTarget(remainingNumbers, largestNumber))
        {
            return "Yes, a combination of numbers can sum up to the largest number.";
        }
        else
        {
            return "No, no combination of numbers can sum up to the largest number.";
        }
    }

    static bool CanSumToTarget(int[] numbers, int target)
    {
        var dp = new bool[target + 1];
        dp[0] = true;

        foreach (var num in numbers)
        {
            for (int j = target; j >= num; j--)
            {
                dp[j] = dp[j] || dp[j - num];
            }
        }

        return dp[target];
    }
}
