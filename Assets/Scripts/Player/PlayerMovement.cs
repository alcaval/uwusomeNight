using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 2.0f;
    [SerializeField] private Rigidbody _rb;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 5.0f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 2.0f;
        }

        Vector3 right = Quaternion.AngleAxis(90, Vector3.up) * transform.forward;

        _rb.MovePosition(_rb.transform.position + _rb.transform.forward * vertical * speed + right * horizontal * speed);

        Vector2 mousePos = Input.mousePosition;

        if (mousePos.x < Screen.width/6)
        {
            transform.Rotate(Vector3.up * -0.25f);
        }
        else if(mousePos.x >  5*Screen.width/6)
        {
            transform.Rotate(Vector3.up * 0.25f);
        }

    }
}
