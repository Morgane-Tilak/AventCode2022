using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public static class Day1
    {
        public static void Part1(TextAsset InputTextDay1)
        {
            string[] elvesStrings = InputTextDay1.text.Split("\n\n");
            int max = elvesStrings.Select(s => s.Split("\n").Select(int.Parse).ToList().Sum()).Max();
            Debug.Log($"[{nameof(Part1)}] : {max}");
        }

        public static void Part2(TextAsset InputTextDay1)
        {
            string[] elvesStrings = InputTextDay1.text.Split("\n\n");
            int max3 = elvesStrings.Select(s => s.Split("\n").Select(int.Parse).ToList().Sum()).OrderByDescending(x => x)
                .Take(3).Sum();
            Debug.Log($"[{nameof(Part2)}] : {max3}");
        }
    }
}