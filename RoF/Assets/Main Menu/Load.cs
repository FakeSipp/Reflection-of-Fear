using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public void OnLoad(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        
    } 
    public void QuitGame()
    {
        Application.Quit();
    }
}
