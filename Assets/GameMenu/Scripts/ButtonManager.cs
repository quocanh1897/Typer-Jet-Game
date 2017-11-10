using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static bool MainToHSOn, HSToMainOn, MainToSettingsOn, SettingsToMainOn;
    public InputField input;
    GameObject obj;
    public void NewGameBtn()
    {
        SceneManager.LoadScene(1);
    }
    public void SettingsBtn()
    {
        MainToSettingsOn = true;
    }
    //Settings' Buttons:
    public void GameSettingsSetMissilesKeyBtn()
    {
        obj = GameObject.FindGameObjectWithTag("MissilesBtnText");
        obj.GetComponent<Text>().text = input.text.ToUpper();
        if (obj.GetComponent<Text>().text == " ")
            obj.GetComponent<Text>().text = "SPACE";
    }
    public void SolvePressingEnterKey()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
            obj.GetComponent<Text>().text = "ENTER";
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
}
