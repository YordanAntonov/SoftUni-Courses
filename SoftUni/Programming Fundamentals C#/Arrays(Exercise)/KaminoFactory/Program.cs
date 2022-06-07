using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input: array length on the first line
            // Second line until we receive "Clone them!" we have to ask for input for sequances (While loop) Split by ('!').
            //The sequance will be 0's or 1's: We need to select the one with the most 1's: if there are more sequances with the same number of 1's we need to select the one with leftmost starting sequance! if there are more than one with same starting sequance print the one with biggest sum of ones.
            //------------------------------------------------------------------------------------------------------------------
            int arrLength = int.Parse(Console.ReadLine());
            string dna = "";

            int startIndex = -1;
            int maxCount = -1;
            int bestSequenceSum = 0;
            int bestSample = 0;
            int sample = 0;
            string bestDnaSeq = "";



            while ((dna = Console.ReadLine()) != "Clone them!")
            {
                int[] dnaSequence = new int[arrLength];
                dnaSequence = dna.Split(new[]{'!'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                
                sample++;

                // Current variables for the current sequance!
                int currMaxCount = -1;
                int currStartIndex = -1;
                int currSequenceSum = 0;
                int currCount = 0;
                bool isCurrDnaBetter = false;


                for (int i = 0; i < dnaSequence.Length; i++)
                {

                    int digit = dnaSequence[i];
                    if (digit == 1)
                    {
                        currSequenceSum++;
                        currCount++;
                        if (i == dnaSequence.Length - 1)
                        {
                            if (currCount > currMaxCount)
                            {
                                //edge case
                                currMaxCount = currCount;
                                currStartIndex = (i + 1) - currMaxCount;
                            }
                        }
                    }
                    else
                    {
                        if (currCount > currMaxCount)
                        {
                            currMaxCount = currCount;
                            // Current starting index
                            currStartIndex = i - currMaxCount;
                        }
                        currCount = 0;
                    }
                }
                if (currMaxCount > maxCount)
                {
                    isCurrDnaBetter = true;
                }
                else if (currMaxCount == maxCount)
                {
                    if (currStartIndex < startIndex)
                    {
                        isCurrDnaBetter = true;
                    }
                    else if (currStartIndex == startIndex)
                    {
                        if (currSequenceSum > bestSequenceSum)
                        {
                            isCurrDnaBetter = true;
                        }
                    }
                }
                if (isCurrDnaBetter)
                {
                    maxCount = currMaxCount;
                    startIndex = currStartIndex;
                    bestSequenceSum = currSequenceSum;
                    bestSample = sample;
                    bestDnaSeq = String.Join(" ", dnaSequence);
                }
            }
            //"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}."
            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSequenceSum}.");
            Console.WriteLine(bestDnaSeq);
            //"{DNA sequence, joined by space}"





        }
    }
}
