using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class Day8
    {
        public static void Part1(TextAsset inputText)
        {
            string[] rows = inputText.text.Split("\n");
            int[][] tempsMatrix = rows.Select(s => s.ToCharArray().Select(ch => ch - '0').ToArray()).ToArray();
            int[][] matrix = tempsMatrix.Select(row => row.Where(i => i >= 0).ToArray()).ToArray();

            int numberOfRows = matrix.Length;
            int numberOfColumns = matrix[0].Length;

            int numberOfVisibleTrees = numberOfRows * 2 + numberOfColumns * 2 - 4;

            for (int i = 1; i < numberOfRows - 1; i++)
            {
                for (int j = 1; j < numberOfColumns - 1; j++)
                {
                    if (IsVisibleFromLeft(matrix, i, j) || IsVisibleFromRight(matrix, i, j) ||
                        IsVisibleFromTop(matrix, i, j) || IsVisibleFromBottom(matrix, i, j))
                    {
                        numberOfVisibleTrees++;
                    }

                }
            }

            Debug.Log($"[{nameof(Part1)}] : {numberOfVisibleTrees}");
        }

        private static bool IsVisibleFromLeft(int[][] matrix, int i, int j)
        {
            int maxInLeftRow = matrix[i].ToList().GetRange(0, j).Max();
            return matrix[i][j] > maxInLeftRow;
        }

        private static bool IsVisibleFromRight(int[][] matrix, int i, int j)
        {
            int maxInRightRow = matrix[i].ToList().GetRange(j + 1, matrix[0].Length - j - 1).Max();
            return matrix[i][j] > maxInRightRow;
        }

        private static bool IsVisibleFromTop(int[][] matrix, int i, int j)
        {
            int max = 0;
            for (int k = 0; k < i; k++)
            {
                max = Mathf.Max(matrix[k][j], max);
            }

            return matrix[i][j] > max;
        }

        private static bool IsVisibleFromBottom(int[][] matrix, int i, int j)
        {
            int max = 0;
            for (int k = i+1; k < matrix.Length; k++)
            {
                max = Mathf.Max(matrix[k][j], max);
            }

            return matrix[i][j] > max;
        }
        
        // ----------------------------------------------------------------
        public static void Part2(TextAsset inputText)
        {
            string[] rows = inputText.text.Split("\n");
            int[][] tempsMatrix = rows.Select(s => s.ToCharArray().Select(ch => ch - '0').ToArray()).ToArray();
            int[][] matrix = tempsMatrix.Select(row => row.Where(i => i >= 0).ToArray()).ToArray();

            int numberOfRows = matrix.Length;
            int numberOfColumns = matrix[0].Length;

            int scenicScoreMax = 0;
            for (int i = 1; i < numberOfRows -1; i++)
            {
                for (int j = 1; j < numberOfColumns-1; j++)
                {
                    int scenicScore = NumberTreeVisibleLeft(matrix, i, j) * NumberTreeVisibleRight(matrix, i, j) * NumberTreeVisibleTop(matrix, i, j) * NumberTreeVisibleBottom(matrix, i, j);
                    if (scenicScore > scenicScoreMax)
                        scenicScoreMax = scenicScore;
                }
            }

            Debug.Log($"[{nameof(Part2)}] : {scenicScoreMax}");
        }
        
        private static int NumberTreeVisibleLeft(int[][] matrix, int i, int j)
        {
            List<int> inLeftRow = matrix[i].ToList().GetRange(0, j);
            inLeftRow.Reverse();
            int number = 0;
            foreach (int tree in inLeftRow)
            {
                if (tree < matrix[i][j])
                    number++;
                else
                    return ++number;
            }
            return number;
        }
        
        private static int NumberTreeVisibleRight(int[][] matrix, int i, int j)
        {
            List<int> inRightRow = matrix[i].ToList().GetRange(j + 1, matrix[0].Length - j - 1);
            int number = 0;
            foreach (int tree in inRightRow)
            {
                if (tree < matrix[i][j])
                    number++;
                else
                    return ++number;
            }
            return number;
        }
        private static int NumberTreeVisibleTop(int[][] matrix, int i, int j)
        {
            int number = 0;
            for (int k = i-1; k >= 0; k--)
            {
                if (matrix[k][j] < matrix[i][j])
                    number++;
                else
                    return ++number;
            }

            return number;
        }

        private static int NumberTreeVisibleBottom(int[][] matrix, int i, int j)
        {
            int number = 0;
            for (int k = i+1; k < matrix.Length; k++)
            {
                if (matrix[k][j] < matrix[i][j])
                    number++;
                else
                    return ++number;
            }
            return number;
        }
    }
}