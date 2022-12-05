using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class Day3
    {
        private static string alphabet = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static void Part1(TextAsset inputText)
        {
            string[] rucksacks = inputText.text.Split("\r\n");
            int result = 0;
            foreach (string rucksack in rucksacks)
            {
                result += FindSharedItem(rucksack);
            }

            Debug.Log($"[{nameof(Part1)}] : {result}");
        }

        private static int FindSharedItem(string rucksack)
        {
            List<char> one = rucksack.Take(rucksack.Length / 2).ToList();
            List<char> two = rucksack.TakeLast(rucksack.Length / 2).ToList();
            char commonItem = one.Intersect(two).First();
            return alphabet.IndexOf(commonItem);
        }

        public static void Part2(TextAsset inputText)
        {
            List<string> rucksacks = inputText.text.Split("\r\n").ToList();

            int result = 0;

            for (int i = 0; i < rucksacks.Count; i += 3)
            {
                result += FindCommonItemInto3Bags(
                    new List<string>() {rucksacks[i], rucksacks[i + 1], rucksacks[i + 2]}
                );
            }
            Debug.Log($"[{nameof(Part2)}] : {result}");
        }

        private static int FindCommonItemInto3Bags(List<string> bags)
        {
            char commonItem = bags[0].Intersect(bags[1].Intersect(bags[2])).First();
            return alphabet.IndexOf(commonItem);
        }
    }
}