using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght, starpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        starpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(starpos + distance, transform.position.y, transform.position.z);

        if (temp > starpos + lenght) 
            starpos += lenght;
        else if (temp < starpos - lenght) 
            starpos -= lenght;
    }
}
