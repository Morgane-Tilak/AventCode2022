using DefaultNamespace;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private TextAsset InputTextDay1;
    [SerializeField] private TextAsset InputTextDay2;
    [SerializeField] private TextAsset InputTextDay3;
    [SerializeField] private TextAsset InputTextDay4;
    [SerializeField] private TextAsset InputTextDay5;
    [SerializeField] private TextAsset InputTextDay6;
    [SerializeField] private TextAsset InputTextDay8;

    void Start()
    {
        // Day1.Part1(InputTextDay1);
        // Day1.Part2(InputTextDay1);
        // Day2.Part1(InputTextDay2);
        // Day2.Part2(InputTextDay2);
        // Day3.Part1(InputTextDay3);
        // Day3.Part2(InputTextDay3);
        // Day4.Part1(InputTextDay4);
        // Day4.Part2(InputTextDay4);
        // Day5.Part1(InputTextDay5);
        // Day5.Part2(InputTextDay5);
        // Day6.Part1(InputTextDay6);
        // Day6.Part2(InputTextDay6);
        //Day8.Part1(InputTextDay8);
        Day8.Part2(InputTextDay8);
    }
}