using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> margeList = new List<int>();
            int smallerList = Math.Min(firstList.Count, secondList.Count);

            for (int i = 0; i < smallerList; i++)
            {
                margeList.Add(firstList[i]);
                margeList.Add(secondList[i]);
            }
            if (firstList.Count > secondList.Count)
            {
                margeList.AddRange(GetRemainingElements(firstList, secondList));
            }
            else
            {
                margeList.AddRange(GetRemainingElements(secondList, firstList));
            }

            Console.WriteLine(String.Join(" ", margeList));
        }
        static List<int> GetRemainingElements(List<int> longerList, List<int> shorterList)
        {
            List<int> nums = new List<int>();
            for (int i = shorterList.Count; i < longerList.Count; i++)
            {
                nums.Add(longerList[i]);
            }
            return nums;
        }
    }
}
