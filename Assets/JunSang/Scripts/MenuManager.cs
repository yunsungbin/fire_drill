using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _menuList; 
    [SerializeField] private Button[] _firstSelectButton; 
    [SerializeField] private int _Menuindex = 0; 
    [SerializeField] private int _Buttonindex = 0; 
    // Start is called before the first frame update

    void Awake(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Start()
    {
        SelectedMenu(_Menuindex, _Buttonindex);
    }

    public void SelectedMenu(int MenuIndex, int ButtonIndex){
        foreach(GameObject menu in _menuList){ 
            menu.SetActive(false);
        }
        _menuList[MenuIndex].SetActive(true); 
        _firstSelectButton[ButtonIndex].Select(); 
    }

    public void MenuButton(Button button){
        if(button.name == "Start_Button"){ 
            _Menuindex = 0;                       
            _Buttonindex = 0;
            StartCoroutine(WaitForSecond());  
        }
        else if(button.name == "OptionMenu_Button"){
            _Menuindex = 1;                      
            _Buttonindex = 3;
            StartCoroutine(WaitForSecond());
        }
        else if(button.name == "BackToMainMenu_Button"){
            _Menuindex = 0;                      
            _Buttonindex = 0;
            StartCoroutine(WaitForSecond());
        }
        else if(button.name == "ExitMenu_Button"){
            Debug.Log("게임 종료됨"); 
            Application.Quit();
        }
    }

    IEnumerator WaitForSecond(){              
        yield return new WaitForSeconds(.3f); 
        SelectedMenu(_Menuindex, _Buttonindex);         
    }


}
