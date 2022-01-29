using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour

{

    [SerializeField] GameObject lightSource;
    [SerializeField] private bool _isLightOn;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //print("Estas en la light");
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_isLightOn) switchLightOff();
                else switchLightOn();
            }
        }

    }

    public void switchLightOn()
    {
        lightSource.GetComponent<Light>().enabled = true;
        _isLightOn = true;
    }

    public void switchLightOff()
    {
        lightSource.GetComponent<Light>().enabled = false;
        _isLightOn = false;
    }
}