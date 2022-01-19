using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public void playGame(){
        SceneManager.LoadScene("MainScene");
    }
    public void backToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
