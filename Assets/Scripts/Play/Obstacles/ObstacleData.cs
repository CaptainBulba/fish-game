using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleData : MonoBehaviour
{
    public float minimumCord;
    public float maximumCord; 

    public float GetMinimumCord()
    {
        return minimumCord;
    }

    public float GetMaximumCord()
    {
        return maximumCord;
    }

    void Start()
    {
        
    }
}
