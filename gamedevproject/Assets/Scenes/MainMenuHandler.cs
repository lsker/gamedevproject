using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void PressPlay(){
        Debug.Log("pressed play!");
        SceneManager.LoadScene("TutorialScene");

    }

    public void PressQuit(){
        Debug.Log("QUIT!");
        Application.Quit(); //this does not work in the editor
    }
}
