using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _easyModeLabel;
    private bool _EasyFlag = false;
    public void changeToGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void switchMode(){
        if(_EasyFlag){
            _easyModeLabel.text = "More of an uwusome night";
            _EasyFlag = false;
        }else{
            _easyModeLabel.text = "Uuuh spooky";
            _EasyFlag = true;
        }
        
    }

    public void exitGame(){
        Application.Quit();
    }
}
