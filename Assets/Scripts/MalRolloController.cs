using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalRolloController : MonoBehaviour
{
    [SerializeField] private List<LightController> _lights;
    // [SerializeField] private List<DoorController> _doors;
    [SerializeField] private List<Rigidbody> _objects;


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
            
            if(listaElegida == 1)
            {
                elementoElegido = Random.Range(0, _lights.Count);
                _lights[elementoElegido].startFlickering();
            }
            else if(listaElegida == 2)
            {
                elementoElegido = Random.Range(0, _lights.Count);
            }
            else
            {
                elementoElegido = Random.Range(0, _objects.Count);
            }

            tiempoEspera = Random.Range(0, _tiempoEsperaMax);
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}
