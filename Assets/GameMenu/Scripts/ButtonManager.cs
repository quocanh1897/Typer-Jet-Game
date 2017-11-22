using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static bool MainToHSOn, HSToMainOn, MainToSettingsOn, SettingsToMainOn, MainToInstructionsOn, InstructionsToMainOn;
    public static float value = 50;
    private Slider slider;
    public void SetVolume()
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
        string s =  Input.inputString.ToUpper();
        GameObject obj2 = GameObject.FindGameObjectWithTag("MissilesBtnText");
        if (s == " ")
            obj2.GetComponent<Text>().text = "SPACE";
        else
            obj2.GetComponent<Text>().text = s;
    }
    public void ChangeScreenSolution()
    {
        GameObject obj1 = GameObject.FindGameObjectWithTag("dropdown");
        int value = obj1.GetComponent<Dropdown>().value;
        int a = 1280, b = 720;
        bool fullScr = false;
        switch (value)
        {
            case 0:
                a = 1280;b = 720;break;
            case 1:
                a = 1280; b = 600; break;
            case 2:
                a = 800; b = 600; break;
            case 3:
                a = 640; b = 480; break;
            case 4:
                a = 640; b = 400; break;
            case 5:
                a = 512; b = 384; break;
            case 6:
                a = 400; b = 300; break;
            case 7:
                a = 320; b = 240; break;
            case 8:
                a = 320; b = 200; break;
            default:
                fullScr = true;break;
        }
        Screen.SetResolution(a, b, fullScr);
    }
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
