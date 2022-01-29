using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllusionController : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target != null)
            transform.rotation = target.rotation;
    }
}
