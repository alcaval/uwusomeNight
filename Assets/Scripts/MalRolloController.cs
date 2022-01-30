using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalRolloController : MonoBehaviour
{
    [SerializeField] private List<LightController> _lights;
    [SerializeField] private List<DoorController> _doors;
    [SerializeField] private List<ObjectController> _objects;


    [SerializeField] private float _tiempoEsperaMax;

    /*
    Cada x (aleatorio) segundos, cogemos un tipo de objeto aleatorio (lights, doors, objects)
    y de cada lista "activamos" un objeto aleatorio
    */


    // Start is called before the first frame update
    private void OnEnable() 
    {
        StartCoroutine(rutinaMalRollo());
    }

    private void OnDisable() 
    {
        StopAllCoroutines();
    }

    private IEnumerator rutinaMalRollo()
    {
        int listaElegida, elementoElegido;
        float tiempoEspera;
        while(true)
        {
            listaElegida = Random.Range(0, 3);
            listaElegida = 2;
            
            if(listaElegida == 0)
            {
                if(_lights.Count > 0)
                {
                    elementoElegido = Random.Range(0, _lights.Count);
                    StartCoroutine(malRolloLightController(_lights[elementoElegido]));
                }
                
            }
            else if(listaElegida == 1)
            {
                if(_doors.Count > 0)
                {
                    elementoElegido = Random.Range(0, _doors.Count);
                    malRolloDoorController(_doors[elementoElegido]);
                }
            }
            else
            {
                if(_objects.Count > 0)
                {
                    elementoElegido = Random.Range(0, _objects.Count);
                    malRolloObjectController(_objects[elementoElegido]);
                }
            }

            tiempoEspera = Random.Range(0, _tiempoEsperaMax);
            yield return new WaitForSeconds(tiempoEspera);
        }
    }

    private IEnumerator malRolloLightController(LightController light)
    {
        Debug.Log("Asustate RAPIDO");
        light.startFlickering();
        yield return new WaitForSeconds(5f);
        light.stopFlickering();
    }

    private void malRolloDoorController(DoorController door)
    {
        StartCoroutine(door.openDoorFront());
    }

    private void malRolloObjectController(ObjectController obj)
    {
        obj.makeFall();
    }
}
