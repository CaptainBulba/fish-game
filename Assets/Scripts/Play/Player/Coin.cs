using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        gameObject.transform.parent.transform.parent.GetComponent<Score>().AddScore();
        Destroy(gameObject);
    }
}
