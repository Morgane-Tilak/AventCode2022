using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class Day6
    {
        public static void Part1(TextAsset inputText)
        {
            string s = inputText.text;
            int result = 0;
            for (int i = 4; i < s.Length; i++)
            {
                var temp = s.Substring(i-4, 4);
                if (temp.GroupBy(c => c).FirstOrDefault(g => g.Count() > 1) == null)
                {
                    result = i;
                    break;
                }
            }
            Debug.Log($"[{nameof(Part1)}] : {result}");
        }
        
        
        public static void Part2(TextAsset inputText)
        {
            string s = inputText.text;
            int result = 0;
            for (int i = 14; i < s.Length; i++)
            {
                var temp = s.Substring(i-14, 14);
                if (temp.GroupBy(c => c).FirstOrDefault(g => g.Count() > 1) == null)
                {
                    result = i;
                    break;
                }
            }
            Debug.Log($"[{nameof(Part2)}] : {result}");
        }
    }
}