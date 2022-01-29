using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] ParticleSystem particleGenerator;
    [SerializeField] float particleDuration;
    private bool _itemObtained = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //print("Estas en el object");
            if (Input.GetKeyDown(KeyCode.E) && !_itemObtained)
            {
                StartCoroutine(getObject());
            }
        }

    }

    IEnumerator getObject()
    {
        item.GetComponent<MeshRenderer>().enabled = false;
        item.GetComponent<BoxCollider>().enabled = false;
        particleGenerator.Play();
        _itemObtained = true;
        yield return new WaitForSeconds(particleDuration);
        particleGenerator.Stop();
    }

}
