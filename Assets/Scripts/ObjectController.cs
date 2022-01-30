using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Vector3 _fallForce;

    public void makeFall()
    {
        Debug.Log(" * c cae * ");
        _rb.AddForce(_fallForce);
    }
}
