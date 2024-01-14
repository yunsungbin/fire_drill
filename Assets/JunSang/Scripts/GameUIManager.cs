using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public bool gameUIOnoffFlag = false;
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Awake(){
        
    }
    void Start()
    {
        GameUIOnOff();
        TestGameManager.Instance.gameStation = TestGameManager.GANESTATION.PLAY;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            GameUIOnOff();
        }
    }

    void GameUIOnOff(){
        if(gameUIOnoffFlag == false && TestGameManager.Instance.gameStation == TestGameManager.GANESTATION.PLAY){
            gameUIOnoffFlag = true;
            TestGameManager.Instance.gameStation = TestGameManager.GANESTATION.STOP;
        }
        else if(gameUIOnoffFlag == true && TestGameManager.Instance.gameStation == TestGameManager.GANESTATION.STOP){
            gameUIOnoffFlag = false;
            TestGameManager.Instance.gameStation = TestGameManager.GANESTATION.PLAY;
        }
        pausePanel.SetActive(gameUIOnoffFlag);
    }
}
