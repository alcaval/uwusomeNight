using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 2.0f;

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

        transform.Translate(Vector3.forward * vertical * speed + Vector3.right * horizontal * speed);

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
