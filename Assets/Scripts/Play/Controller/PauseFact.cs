using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseFact : MonoBehaviour
{
    [TextArea]
    public string[] facts;

    public string pauseFactText()
    {
        int textNumber = Random.Range(0, facts.Length);
        return facts[textNumber];
    }
}
