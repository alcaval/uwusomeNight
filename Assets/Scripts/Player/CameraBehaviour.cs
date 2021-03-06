using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject _target = null;

    private RaycastHit[] hits = null;
    [SerializeField] private Transform originalPosition;


    private void Update()
    {

        if (hits != null)
        {
            foreach (RaycastHit hit in hits)
            {
                Renderer r = hit.collider.GetComponent<Renderer>();
                if (r)
                {
                    //r.enabled = true;
                    transform.position = originalPosition.position;
                }
            }
        }

        Debug.DrawRay(this.transform.position, (this._target.transform.position - this.transform.position), Color.magenta);

        hits = Physics.RaycastAll(this.transform.position, (this._target.transform.position - this.transform.position), Vector3.Distance(this.transform.position, this._target.transform.position));

        foreach (RaycastHit hit in hits)
        {
            Renderer r = hit.collider.GetComponent<Renderer>();
            if (r && r.gameObject.tag != "Player" && r.gameObject.tag != "Door")
            {
                //r.enabled = false;
                transform.position = transform.position + transform.forward * 1.2f;
            }
        }

    }
}

