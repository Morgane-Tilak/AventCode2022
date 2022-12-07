using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DefaultNamespace
{
    public static class Extensions
    {
        public static List<T> PopRange<T>(this Stack<T> stack, int amount)
        {
            var result = new List<T>(amount);
            while (amount-- > 0 && stack.Count > 0)
            {
                result.Add(stack.Pop());
            }
            return result;
        }
        
        public static void PushRange<T>(this Stack<T> stack, List<T> elements)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                stack.Push(elements[i]);
            }
        }
        
    }
    public class Day5
    {
        public static void Part1(TextAsset InputText)
        {
            List<string> inputs = InputText.text.Split("\r\n").ToList();
            int indexOfEmptyLine = inputs.IndexOf(String.Empty);
            
            List<Stack<char>> crates = CreateCrates(inputs, indexOfEmptyLine);
            List<List<int>> instructions = CreateInstructions(inputs, indexOfEmptyLine);
            foreach (List<int> instruction in instructions)
            {
                Stack<char> v = crates[instruction[1] - 1];
                List<char> charsToMove = v.PopRange(instruction[0]);
                crates[instruction[2]-1].PushRange(charsToMove);
            }
            
            string result = crates.Aggregate(String.Empty, (current, crate) => current + crate.Peek());
            Debug.Log($"[{nameof(Part1)}] : {result}");
        }

        private static List<Stack<char>> CreateCrates(List<string> inputs, int indexOfEmptyLine)
        {
            List<string> crates = inputs.Take(indexOfEmptyLine).ToList();
            crates.Reverse();
            List<Stack<char>> stacks = new List<Stack<char>>();

            int numberStacks = crates[0].Length / 4;
            foreach (string crate in crates)
            {
                int j = 0;
                for (int i = 1; i < crate.Length; i += 4)
                {
                    if (stacks.Count <= numberStacks)
                    {
                        Stack<char> stack = new Stack<char>();
                        if (crate[i] != (char)32)
                        {
                            stack.Push(crate[i]);
                        }
                        stacks.Add(stack);
                    }
                    else if (crate[i] != (char) 32)
                    {
                        stacks[j].Push(crate[i]);
                    }

                    j++;
                }
            }
            return stacks;
        }

        private static List<List<int>> CreateInstructions(List<string> inputs, int indexOfEmptyLine)
        {
            List<string> instructions = inputs.TakeLast(inputs.Count - indexOfEmptyLine -1).ToList();
            List<List<int>> result = new List<List<int>>();
            
            foreach (string instruction in instructions)
            {
                var r = instruction.Split(" ");
                result.Add(new List<int>(){Convert.ToInt32(r[1]), Convert.ToInt32(r[3]), Convert.ToInt32(r[5])});
            }
            return result;
        }
    }
}