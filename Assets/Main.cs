using DefaultNamespace;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private TextAsset InputTextDay1;
    [SerializeField] private TextAsset InputTextDay2;

    void Start()
    {
        Day1.Part1(InputTextDay1);
        Day1.Part2(InputTextDay1);
        Day2.Part1(InputTextDay2);
        Day2.Part2(InputTextDay2);
    }
}