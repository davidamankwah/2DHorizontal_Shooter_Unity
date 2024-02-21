using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static Level instance; // Ensure that one instance of the class exists in the game.


    uint numDestructables = 0; //Keep track of the number of destructible objects
    bool startNextLevel = false; //Determine whether the next level should be started.
    float nextLevelTimer = 3; //Keeps track of the time until the next level starts

    string[] levels = {"Level1", "Level2", "Level3"}; //store the names of the levels
    int currentLevel = 1; //keep track of the current level. 

    int score = 0; // keep track of the player's score. 
    Text scoreText; //stores a reference to the Text component that displays the score on the screen.

    private void Awake()
    {
        
         if (instance == null)
        {
            instance = this; //The instance is set to this. 
            DontDestroyOnLoad(gameObject);
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        }
        else
        {
            
            Destroy(gameObject);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks if startNextLevel is true 
        if (startNextLevel)
        {
            // check if nextLevelTimer is less than or equal to 0. 
            if (nextLevelTimer <= 0)
            {
                currentLevel++; //increment currentlevel
                if (currentLevel <= levels.Length)
                {
                    //next level is loaded
                    string sceneName = levels[currentLevel - 1];
                    SceneManager.LoadSceneAsync(sceneName);
                }
                else
                {
                    // the game is over.
                    Debug.Log("GAME OVER!!!");
                }
                nextLevelTimer = 3;
                startNextLevel = false;
            }
            else
            {
                nextLevelTimer -= Time.deltaTime;
            }
        }
    }

    //Reset the level when the player dies
    public void ResetLevel()
    {
        foreach(Bullet b in GameObject.FindObjectsOfType<Bullet>())
        {
            Destroy(b.gameObject);
        }
        numDestructables = 0;
        score = 0;
        AddScore(score); //Add points to the player's score
        string sceneName = levels[currentLevel - 1];
        SceneManager.LoadScene(sceneName);
    }

     public void AddScore(int amountToAdd)
    {
        score += amountToAdd;
        scoreText.text = score.ToString();
    }

    //Adds a destructible object to the level.
    public void AddDestructable()
    {
        numDestructables++;
    }

    //Remove a destructible object from the level.
    public void RemoveDestructable()
    {
        numDestructables--;

        if (numDestructables == 0)
        {
            startNextLevel = true;
        }

    }

}
