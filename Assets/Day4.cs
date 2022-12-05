using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class Day4
    {
        public static void Part1(TextAsset InputText)
        {
            string[] pairs = InputText.text.Split("\r\n");
            int result = 0;
            foreach (string pair in pairs)
            {
                if (OneRangeIsFullyContainTheOther(pair))
                    result += 1;
            }
            Debug.Log($"[{nameof(Part1)}] : {result}");
        }

        private static bool OneRangeIsFullyContainTheOther(string pair)
        {
            string[] elf = pair.Split(",");
            string[] e1 = elf[0].Split("-");
            (int start, int end) elf1 =  new(Convert.ToInt32(e1[0]), Convert.ToInt32(e1[1]));
            string[] e2 = elf[1].Split("-");
            (int start, int end) elf2 = new(Convert.ToInt32(e2[0]), Convert.ToInt32(e2[1]));

            return (elf1.start >= elf2.start && elf1.end <= elf2.end) ||
                   (elf2.start >= elf1.start && elf2.end <= elf1.end);
        }
        
        public static void Part2(TextAsset InputText)
        {
            string[] pairs = InputText.text.Split("\r\n");
            int result = 0;
            foreach (string pair in pairs)
            {
                if (OneRangeIsContainTheOther(pair))
                    result += 1;
            }
            Debug.Log($"[{nameof(Part2)}] : {result}");
        }
        
        private static bool OneRangeIsContainTheOther(string pair)
        {
            string[] elf = pair.Split(",");
            string[] e1 = elf[0].Split("-");
            (int start, int end) elf1 =  new(Convert.ToInt32(e1[0]), Convert.ToInt32(e1[1]));
            string[] e2 = elf[1].Split("-");
            (int start, int end) elf2 = new(Convert.ToInt32(e2[0]), Convert.ToInt32(e2[1]));

            return elf1.end >= elf2.start && elf1.start <= elf2.end;
        }
    }
}