using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class Day3
    {
        private static string alphabet = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static void Part1(TextAsset inputTextDay)
        {
            string[] rucksacks  = inputTextDay.text.Split("\r\n");
            int result = 0;
            foreach (string rucksack in rucksacks)
            {
                char commonItem = FindSharedItem(rucksack);
                result += alphabet.IndexOf(commonItem);
            }
            Debug.Log($"[{nameof(Part1)}] : {result}");
        }

        private static char FindSharedItem(string rucksack)
        {
            List<char> one = rucksack.Take(rucksack.Length / 2).ToList();
            List<char> two = rucksack.TakeLast(rucksack.Length / 2).ToList();
            return one.Intersect(two).First();
        }
    }
}