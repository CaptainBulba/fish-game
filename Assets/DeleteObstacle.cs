using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObstacle : MonoBehaviour
{
    public float DeleteAfter;

    public IEnumerator SelfDestruct(GameObject destroyObject)
    {
        yield return new WaitForSeconds(DeleteAfter);
        Destroy(destroyObject);
    }
}
