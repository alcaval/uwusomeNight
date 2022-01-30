using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private Rigidbody _rb;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime;

        // if(!Physics.Linecast(transform.position + transform.forward * -1.2f, transform.position + transform.forward * 1.2f)){
        //     transform.Translate(Vector3.forward * vertical * speed + Vector3.right * horizontal * speed);
        // }
        Vector3 right = Quaternion.AngleAxis(90, Vector3.up) * transform.forward;

        _rb.MovePosition(_rb.transform.position + _rb.transform.forward * vertical * speed + right * horizontal * speed);

        Vector2 mousePos = Input.mousePosition;

        if (mousePos.x < Screen.width/6)
        {
            transform.Rotate(Vector3.up * -0.5f);
        }
        else if(mousePos.x >  5*Screen.width/6)
        {
            transform.Rotate(Vector3.up * 0.5f);
        }

    }
}
