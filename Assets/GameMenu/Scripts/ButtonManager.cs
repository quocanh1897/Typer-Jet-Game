using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
public class ButtonManager : MonoBehaviour
{
    public static bool MainToHSOn, HSToMainOn, MainToSettingsOn, SettingsToMainOn, MainToInstructionsOn, InstructionsToMainOn;
    public static float GameVolume;
    public static KeyCode missilesKeyCode;
    private void Start()
    {
        GameVolume = 0.5f;
        missilesKeyCode = KeyCode.Space;
        GameObject obj1 = GameObject.FindGameObjectWithTag("ScreenSolution");
        GameObject obj2 = GameObject.FindGameObjectWithTag("DisplayQuality");
        Resolution s = Screen.currentResolution;
        int val = 0;
        if (Screen.fullScreen)
            val = 9;
        else
        {
            if (s.width == 1280)
            {
                if (s.height == 720)
                    val = 0;
                else
                    val = 1;
            }
            else
            {
                if (s.width == 800)
                    val = 2;
                else
                {
                    if (s.width == 640)
                    {
                        if (s.height == 480)
                            val = 3;
                        else
                            val = 4;
                    }
                    else
                    {
                        if (s.width == 512)
                            val = 5;
                        else
                        {
                            if (s.width == 400)
                                val = 6;
                            else
                            {
                                if (s.width == 320)
                                {
                                    if (s.height == 240)
                                        val = 7;
                                    else
                                        val = 8;
                                }
                            }
                        }
                    }
                }
            }
        }
        obj1.GetComponent<Dropdown>().value = val;
        obj2.GetComponent<Dropdown>().value = QualitySettings.GetQualityLevel();
    }
    public void ChangeVolume()
    {
        GameObject obj1 = GameObject.FindGameObjectWithTag("SfxVolume");
        GameObject obj2 = GameObject.FindGameObjectWithTag("MainMenuBackground");
        obj2.GetComponent<AudioSource>().volume = obj1.GetComponent<Slider>().value / 100;
        obj1 = GameObject.FindGameObjectWithTag("GameVolume");
        GameVolume = obj1.GetComponent<Slider>().value / 100;
    }
    public void NewGameBtn()
    {
        set_info_player("1",0,0,0);
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
        GameObject obj1 = GameObject.FindGameObjectWithTag("MissilesBtnText");
        if (Input.GetKey(KeyCode.Delete))
        {
            obj1.GetComponent<Text>().text = "DELETE/INSERT";
            missilesKeyCode = KeyCode.Delete;
            return;
        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            obj1.GetComponent<Text>().text = "-";
            missilesKeyCode = KeyCode.KeypadMinus;
            return;
        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            obj1.GetComponent<Text>().text = "BACKSPACE";
            missilesKeyCode = KeyCode.Backspace;
            return;
        }
        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKey((KeyCode)i + 256))
            {
                int num = '0' + i;
                obj1.GetComponent<Text>().text = "NUM-LK " + (char)num;
                missilesKeyCode = (KeyCode)i + 256;
                return;
            }
        }
        string s =  Input.inputString.ToUpper();
        if (s == " ")
        {
            obj1.GetComponent<Text>().text = "SPACE";
            missilesKeyCode = KeyCode.Space;
        }
        else
        {
            obj1.GetComponent<Text>().text = s;
            if (s[0] + 32 >= 97 && s[0] + 32 <= 122)
                missilesKeyCode = (KeyCode)(s[0] + 32);
            else
                missilesKeyCode = (KeyCode)(s[0]);
        }
    }
    public void ChangeScreenSolution()
    {
        GameObject obj1 = GameObject.FindGameObjectWithTag("ScreenSolution");
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
    public void ChangeDisplayQuality()
    {
        GameObject obj1 = GameObject.FindGameObjectWithTag("DisplayQuality");
        int value = obj1.GetComponent<Dropdown>().value;
        switch (value)
        {
            case 0:
                QualitySettings.SetQualityLevel(0); break;
            case 1:
                QualitySettings.SetQualityLevel(1); break;
            case 2:
                QualitySettings.SetQualityLevel(2); break;
            case 3:
                QualitySettings.SetQualityLevel(3); break;
            case 4:
                QualitySettings.SetQualityLevel(4); break;
            default:
                QualitySettings.SetQualityLevel(5); break;
        }
        value = QualitySettings.GetQualityLevel();
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
    public void set_info_player(string id,float point,float blood,float mana)
    {
	SqliteConnection sql_con = new SqliteConnection("Data Source="+Application.dataPath+"\\words.db;"+"Version=3;New=False;Compress=True");
        sql_con.Open();
        SqliteCommand sql_cmd = sql_con.CreateCommand();
	sql_cmd.CommandText = "UPDATE highscore SET Point='" +point+ "',HP='" +blood+ "',MP='" +mana+"' WHERE ID='1'";
        sql_cmd.ExecuteNonQuery();
        sql_con.Close();
    }
}
