using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBehaviour : MonoBehaviour
{
    private Camera _main;
    [SerializeField] private Light _torch;
    [SerializeField] private LightController _flickerController;
    [SerializeField] private float _battery = 100; 
    [SerializeField] private float _decrement = 0.5f;


    [SerializeField] private float _distance = 5.0f;

    

    private void Start() 
    {
        _main = Camera.main;
        _torch = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        * Cojo un punto a x distancia en la orientación del jugador
        * Creo un vector entre eso y la posición de la luz
        * Ese vector normalizado dicta la rotación de la luz
        */

        if(Input.GetKeyDown(KeyCode.F))
        {
            torchSwitch();
        }

        if(!_torch.enabled) return;
        
        Vector2 mousePos = Input.mousePosition;
        Ray ray = _main.ScreenPointToRay(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        Vector3 direction = ray.GetPoint(_distance);

        transform.LookAt(direction);
        
        decrementBattery();
    }

    private void decrementBattery()
    {
        _battery -= _decrement * Time.deltaTime;
        
        if(_battery <= 10f)
        {
            // Flicker
            _flickerController.startFlickering();
        }

        if(_battery <= 0)
        {
            _battery = 0;
            _torch.enabled = false;
            _flickerController.stopFlickering();
            
            // Tiene que recargarlo
            StartCoroutine(recargarLinterna());
        }
    }

    private void torchSwitch()
    {
        if(_battery <= 0) return;

        _torch.enabled = !_torch.enabled;
    }


    /*
    ! Importante meter input visual (Poner la tecla R asi pulsada rapido, y la bateria subiendo de alguna forma)
    */
    private IEnumerator recargarLinterna()
    {
        Debug.Log("Recarga la linterna");
        while(!Input.GetKeyDown(KeyCode.R)) // Primer input, todo el tiempo del mundo
        {
            yield return null;
        }

        yield return null;

        bool fallo = false; // fallo = tardar mucho en pulsar R
        float timeSinceLast = 0f; // Lo que tarda en pulsar R
        do
        {
            timeSinceLast = 0f;
            while(!Input.GetKeyDown(KeyCode.R) && !fallo) // Mientras tenga tiempo para pulsar R
            {
                timeSinceLast += Time.deltaTime;
                if(timeSinceLast > 1f)
                {
                    Debug.Log("Cagaste we");
                    fallo = true;
                }
                yield return null;
            }

            if(!fallo) // Si lo ha hecho bien, recarga un poco más la bateria
            {
                Debug.Log("ctm lo hiciste bien");
                _battery += 10f;
            }

            yield return null;

        }while(_battery < 100f && !fallo);

        if(!fallo) // Es decir, _battery >= 100
        {
            _battery = 100f;
        }

        torchSwitch();
    }
}
