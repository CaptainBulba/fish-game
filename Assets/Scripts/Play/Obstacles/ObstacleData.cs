using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleData : MonoBehaviour
{
    public float minimumCord;
    public float maximumCord;

    [TextArea]
    public string[] facts;

    public float GetMinimumCord()
    {
        return minimumCord;
    }

    public float GetMaximumCord()
    {
        return maximumCord;
    }

    public string GetRandomFact()
    {
        int textNumber = Random.Range(0, facts.Length);
        return facts[textNumber];
    }
}
