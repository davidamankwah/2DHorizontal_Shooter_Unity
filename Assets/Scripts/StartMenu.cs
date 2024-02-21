using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
   public void StartGame()
    {
         SceneManager.LoadSceneAsync("Level1"); //Load level 1 scene
    }
}
