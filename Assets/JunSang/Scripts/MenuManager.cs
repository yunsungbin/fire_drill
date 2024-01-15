using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Jobs;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _menuList; 
    [SerializeField] private Button[] _firstSelectButton;
    [SerializeField] private Slider[] _firstSelectSlider;
    [SerializeField] private int _Menuindex = 0; 
    [SerializeField] private int _Buttonindex = 0; 
    [SerializeField] private int _Sliderindex = -1;
    // Start is called before the first frame update

    void Awake(){
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }
    void Start()
    {
        TestGameManager.Instance.gameStation = TestGameManager.GAMESTATION.READY;
        SelectedMenu(_Menuindex, _Buttonindex, _Sliderindex);
    }

    public void SelectedMenu(int MenuIndex, int ButtonIndex, int SliderIndex){
        foreach(GameObject menu in _menuList){ 
            menu.SetActive(false);
        }
        _menuList[MenuIndex].SetActive(true); 
        if(_Buttonindex >= 0)
            _firstSelectButton[ButtonIndex].Select(); 
        if(_Sliderindex >= 0){
            _firstSelectSlider[SliderIndex].Select();
        }
    }

    public void MenuButton(Button button){
        if(button.name == "Start_Button"){ 
            AudioManager.Instance.PlaySFX("ButtonClick");
            StartCoroutine(WaitForSecond());
            SceneManager.LoadScene("Test"); 
        }
        else if(button.name == "OptionMenu_Button"){
            _Menuindex = 1;                      
            _Buttonindex = -1;
            _Sliderindex = 0;
            AudioManager.Instance.PlaySFX("ButtonClick");
            StartCoroutine(WaitForSecond());
        }
        else if(button.name == "BackToMainMenu_Button"){
            _Menuindex = 0;                      
            _Buttonindex = 0;
            _Sliderindex = -1;
            AudioManager.Instance.PlaySFX("ButtonClick");
            StartCoroutine(WaitForSecond());
        }
        else if(button.name == "ExitMenu_Button"){
            AudioManager.Instance.PlaySFX("ButtonClick");
            Debug.Log("게임 종료됨"); 
            Application.Quit();
        }
    }

    IEnumerator WaitForSecond(){              
        yield return new WaitForSeconds(.3f); 
        SelectedMenu(_Menuindex, _Buttonindex, _Sliderindex);         
    }

}
