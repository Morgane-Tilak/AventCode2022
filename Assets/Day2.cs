using System;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class Day2
    {
        public static void Part1(TextAsset InputTextDay2)
        {
            string[] rounds = InputTextDay2.text.Split("\r\n");
            int score = rounds.Sum(GetScoreRound);
            Debug.Log($"[{nameof(Part1)}] : {score}");
        }

        private static int GetScoreRound(string round)
        {
            char opponent = round[0];
            char mine = round[2];
            int s = MyChoiceScore(mine) + OutcomeScore(opponent, mine);
            return s;
        }

        private static int MyChoiceScore(char choice)
        {
            return choice switch
            {
                'X' => 1,
                'Y' => 2,
                'Z' => 3,
                _ => throw new Exception("Wrong argument")
            };
        }

        private static int OutcomeScore(char opponent, char mine)
        {
            if (IsDraw(opponent, mine))
                return 3;
            if (Win(opponent, mine))
                return 6;
            return 0;
        }

        private static bool IsDraw(char opponent, char mine)
        {
            return opponent == 'A' && mine == 'X' ||
                   opponent == 'B' && mine == 'Y' ||
                   opponent == 'C' && mine == 'Z';
        }

        private static bool Win(char opponent, char mine)
        {
            return opponent == 'A' && mine == 'Y' ||
                   opponent == 'B' && mine == 'Z' ||
                   opponent == 'C' && mine == 'X';
        }


        public static void Part2(TextAsset InputTextDay2)
        {
            string[] rounds = InputTextDay2.text.Split("\r\n");
            int score = rounds.Sum(GetScoreRound2);
            Debug.Log($"[{nameof(Part2)}] : {score}");
        }

        private static int GetScoreRound2(string round)
        {
            char opponent = round[0];

            char mine = round[2];
            (char m, int outcomeScore) choice = ChangeMyChoice(opponent, mine);
            int s = MyChoiceScore(choice.m) + choice.outcomeScore;
            return s;
        }

        private static (char, int) ChangeMyChoice(char opponent, char mine)
        {
            return mine switch
            {
                'X' => (NeedLoose(opponent), 0),
                'Y' => (NeedDraw(opponent), 3),
                'Z' => (NeedWin(opponent), 6),
                _ => throw new Exception("Wrong argument")
            };
        }

        private static char NeedDraw(char opponent)
        {
            return opponent switch
            {
                'A' => 'X',
                'B' => 'Y',
                'C' => 'Z',
                _ => throw new Exception("Wrong argument")
            };
        }

        private static char NeedWin(char opponent)
        {
            return opponent switch
            {
                'A' => 'Y',
                'B' => 'Z',
                'C' => 'X',
                _ => throw new Exception("Wrong argument")
            };
        }

        private static char NeedLoose(char opponent)
        {
            return opponent switch
            {
                'A' => 'Z',
                'B' => 'X',
                'C' => 'Y',
                _ => throw new Exception("Wrong argument")
            };
        }
    }
}