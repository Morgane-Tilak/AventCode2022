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
        
        throw new Exception("Wrong outcome");
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
        int s = MyChoiceScore(mine) + OutcomeScore(opponent, mine);
        return s;
    }

    private char ChangeMyChoice(char mine)
    {
        switch (mine)
        {
            case 'X':
                return 
        }
    }
    
}