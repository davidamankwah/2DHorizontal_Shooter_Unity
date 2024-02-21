using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
   public void FinishGame()
    {
         SceneManager.LoadSceneAsync("ExitGame"); //load the ExitGame scene
    }
}
