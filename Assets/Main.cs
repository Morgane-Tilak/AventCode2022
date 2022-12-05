using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private TextAsset InputTextDay1;
    [SerializeField] private TextAsset InputTextDay2;

    void Start()
    {
        Day1_1();
        Day1_2();
        Day2_1();
        Day2_2();
    }

    private void Day1_1()
    {
        string[] elvesStrings = InputTextDay1.text.Split("\n\n");
        int max = elvesStrings.Select(s => s.Split("\n").Select(int.Parse).ToList().Sum()).Max();
        Debug.Log($"[{nameof(Day1_1)}] : {max}");
    }

    private void Day1_2()
    {
        string[] elvesStrings = InputTextDay1.text.Split("\n\n");
        int max3 = elvesStrings.Select(s => s.Split("\n").Select(int.Parse).ToList().Sum()).OrderByDescending(x => x)
            .Take(3).Sum();
        Debug.Log($"[{nameof(Day1_2)}] : {max3}");
    }

    private void Day2_1()
    {
        string[] rounds = InputTextDay2.text.Split("\r\n");
        int score = rounds.Sum(GetScoreRound);
        Debug.Log($"[{nameof(Day2_1)}] : {score}");
    }

    private int GetScoreRound(string round)
    {
        char opponent = round[0];
        char mine = round[2];
        int s = MyChoiceScore(mine) + OutcomeScore(opponent, mine);
        return s;
    }

    private int MyChoiceScore(char choice)
    {
        return choice switch
        {
            'X' => 1,
            'Y' => 2,
            'Z' => 3,
            _ => throw new Exception("Wrong argument")
        };
    }

    private int OutcomeScore(char opponent, char mine)
    {
        if (IsDraw(opponent, mine))
            return 3;
        if (Win(opponent, mine))
            return 6;
        return 0;
    }

    private bool IsDraw(char opponent, char mine)
    {
        return opponent == 'A' && mine == 'X' ||
               opponent == 'B' && mine == 'Y' ||
               opponent == 'C' && mine == 'Z';
    }

    private bool Win(char opponent, char mine)
    {
        return opponent == 'A' && mine == 'Y' ||
               opponent == 'B' && mine == 'Z' ||
               opponent == 'C' && mine == 'X';
    }
    
    
    private void Day2_2()
    {
        string[] rounds = InputTextDay2.text.Split("\r\n");
        int score = rounds.Sum(GetScoreRound2);
        Debug.Log($"[{nameof(Day2_2)}] : {score}");
    }
    
    private int GetScoreRound2(string round)
    {
        char opponent = round[0];
        
        char mine = round[2];
        (char m, int outcomeScore) choice = ChangeMyChoice(opponent, mine);
        int s = MyChoiceScore(choice.m) + choice.outcomeScore;
        return s;
    }

    private (char, int) ChangeMyChoice(char opponent, char mine)
    {
        return mine switch
        {
            'X' => (NeedLoose(opponent),0),
            'Y' => (NeedDraw(opponent), 3),
            'Z' => (NeedWin(opponent),6),
            _ => throw new Exception("Wrong argument")
        };
    }

    private char NeedDraw(char opponent)
    {
        return opponent switch
        {
            'A' => 'X',
            'B' => 'Y',
            'C' => 'Z',
            _ => throw new Exception("Wrong argument")
        };
    }
    private char NeedWin(char opponent)
    {
        return opponent switch
        {
            'A' => 'Y',
            'B' => 'Z',
            'C' => 'X',
            _ => throw new Exception("Wrong argument")
        };
    }
    private char NeedLoose(char opponent)
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