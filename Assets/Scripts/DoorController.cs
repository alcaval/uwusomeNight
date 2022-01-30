using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator _myDoor = null;
    [SerializeField] private bool _isFront;

    public bool isDoorClosed = true;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            print("Estas en la door");
        
            if (Input.GetKeyDown(KeyCode.E) && isDoorClosed)
            {
                if (_isFront) StartCoroutine(openDoorFront());
                else StartCoroutine(openDoorBack());
            }
        }    
    }

    public IEnumerator openDoorFront()
    {
        isDoorClosed = false;
        _myDoor.Play("DoorOpenFront", 0, 0.0f);
        print(_myDoor.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(_myDoor.GetCurrentAnimatorStateInfo(0).length + 0.5f);
        isDoorClosed = true;
    }

    public IEnumerator openDoorBack()
    {
        isDoorClosed = false;
        _myDoor.Play("DoorOpenBack", 0, 0.0f);
        print(_myDoor.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(_myDoor.GetCurrentAnimatorStateInfo(0).length + 0.5f);
        isDoorClosed = true;
    }

}
