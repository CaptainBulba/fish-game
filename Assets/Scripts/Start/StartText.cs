using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartText : MonoBehaviour
{
    [TextArea]
    public string[] startText;

    private TextMeshProUGUI fishStartText;

    void Start()
    {
        fishStartText = gameObject.GetComponent<GameController>().fishStartText;
        int textNumber = Random.Range(0, startText.Length);
        fishStartText.text = startText[textNumber];
    }
}
