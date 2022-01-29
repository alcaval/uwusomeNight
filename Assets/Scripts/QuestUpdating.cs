using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestUpdating : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private List<string> _quests; 
    private int _currentQuest = 0;

    void Update()
    {
        print(_currentQuest);
        if(_currentQuest == 0 & Input.GetKeyDown(KeyCode.W)){
            accessNextQuest();
        }
        if(_currentQuest == 1 & (Input.GetAxis("Mouse X") != 0 | Input.GetAxis("Mouse Y") != 0)){
            accessNextQuest();
        }
        
        if(_currentQuest >= _quests.Count){
            lastQuest();
        }
    }

    public void accessNextQuest(){
        _currentQuest++;
        if(_currentQuest <= _quests.Count - 1){
            _label.text = (string) _quests[_currentQuest];
        }
    }

    private void lastQuest(){
        SceneManager.LoadScene(0); //Load startmenu
    }
}
