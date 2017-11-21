using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static bool MainToHSOn, HSToMainOn, MainToSettingsOn, SettingsToMainOn, MainToInstructionsOn, InstructionsToMainOn;
    public static float value = 50;
    public InputField input;
    public string s;
    private GameObject obj1;
    private GameObject obj2;
    private Slider slider;
    public void SliderChangeValue()
    {
        value = slider.GetComponent<Slider>().value / 100;//0->1.
    }
    public void NewGameBtn()
    {
        SceneManager.LoadScene(1);
    }
    public void InstructionsBtn()
    {
        MainToInstructionsOn = true;
    }
    public void SettingsBtn()
    {
        MainToSettingsOn = true;
    }
    //Settings' Buttons:
    
    public void GameSettingsSetMissilesKeyBtn()
    {
        s =  Input.inputString.ToUpper();
        obj2 = GameObject.FindGameObjectWithTag("MissilesBtnText");
        if (s == " ")
            obj2.GetComponent<Text>().text = "SPACE";
        else
            obj2.GetComponent<Text>().text = s;
    }
    
    /*
    public void SolvePressingEnterKey()
    {
        obj1 = GameObject.FindGameObjectWithTag("MissilesBtnText");
        if (Input.GetKey(KeyCode.KeypadEnter))
            obj1.GetComponent<Text>().text = "ENTER";
        else
        {
            if (Input.GetKey(KeyCode.Space))
                obj1.GetComponent<Text>().text = "SPACE";
            else
            {
                obj1.GetComponent<Text>().text=
            }
        }

    }
    */
    public void HighScoresBtn()
    {
        MainToHSOn = true;
    }
    public void ExitGameBtn()
    {
        Application.Quit();
    }
    public void HighScoresBackBtn()
    {
        HSToMainOn = true;
    }
    public void SettingsBackBtn()
    {
        SettingsToMainOn = true;
    }
    public void InstructionsBackBtn()
    {
        InstructionsToMainOn = true;
    }
}
