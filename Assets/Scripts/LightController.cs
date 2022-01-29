using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    [SerializeField] GameObject lightSource;
    [SerializeField] bool wantLightOn;
    [SerializeField] float lowerRange;
    [SerializeField] float upperRange;

    private float _tick;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Test to check the functionalities

        //if (Input.GetKey(KeyCode.K))
        //{
        //    switchLightOn();
        //}
        //if (Input.GetKey(KeyCode.L))
        //{
        //    switchLightOff();
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
           startFlickering();
        }
        if (Input.GetKey(KeyCode.M))
        {
           stopFlickering();
        }
    }

    public void switchLightOn()
    {
        lightSource.GetComponent<Light>().enabled = true;
    }

    public void switchLightOff()
    {
        lightSource.GetComponent<Light>().enabled = false;
    }

    public void startFlickering()
    {
        StartCoroutine(flicker());
    }

    public void stopFlickering()
    {
        StopAllCoroutines();
        if (wantLightOn) switchLightOn();
        else switchLightOff();
    }

    IEnumerator flicker()
    {
        _tick = Random.Range(lowerRange, upperRange);
        switchLightOn();
        //print("Se apaga");
        yield return new WaitForSeconds(_tick);
        switchLightOff();
        //print("Se enciende");
        yield return new WaitForSeconds(_tick);
        StartCoroutine(flicker());
    }
}
