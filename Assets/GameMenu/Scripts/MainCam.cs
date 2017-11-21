using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCam : MonoBehaviour {
    // Use this for initialization
    Animator myAnim;
	void Start () {
        myAnim = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
        myAnim.SetBool("MainToHSOn", false);
        myAnim.SetBool("HSToMainOn", false);
        myAnim.SetBool("MainToSettingsOn", false);
        myAnim.SetBool("SettingsToMainOn", false);
        if (ButtonManager.MainToHSOn)
        {
            myAnim.SetBool("MainToHSOn", true);
            ButtonManager.MainToHSOn = false;
            return;
        }
        if (ButtonManager.HSToMainOn)
        {
            myAnim.SetBool("HSToMainOn", true);
            ButtonManager.HSToMainOn = false;
            return;
        }
        if (ButtonManager.MainToSettingsOn)
        {
            myAnim.SetBool("MainToSettingsOn", true);
            ButtonManager.MainToSettingsOn = false;
            return;
        }
        if (ButtonManager.SettingsToMainOn)
        {
            myAnim.SetBool("SettingsToMainOn", true);
            ButtonManager.SettingsToMainOn = false;
            return;
        }
    }
}
