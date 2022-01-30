using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestUpdating : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private List<string> _quests; 
    public int _currentQuest = 0;

    void Start() {
        GameObject.FindWithTag("firstDoor").GetComponentInChildren<DoorController>().isDoorClosed = false;
    }

    void Update()
    {
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

    public void accessNextQuest()
    {
        if(_currentQuest == 2)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<TorchBehaviour>().TorchObtained();
        }

        _currentQuest++;
        if(_currentQuest == 4){
            GameObject.FindWithTag("firstDoor").GetComponentInChildren<DoorController>().isDoorClosed = true;
        }
        if(_currentQuest <= _quests.Count - 1){
            _label.text = (string) _quests[_currentQuest];
        }
    }

    private void lastQuest(){
        SceneManager.LoadScene(0); //Load startmenu
    }
}
