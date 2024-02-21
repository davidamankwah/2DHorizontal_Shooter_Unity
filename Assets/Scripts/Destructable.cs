using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] private GameObject explosion; //for explosion animation 
    bool canBeDestroyed = false; //check if the game object is in range of the player's gun
    [SerializeField] private int scoreValue = 100; //decide the number of points the player earns when the game object is destroyed.

    // Start is called before the first frame update
    void Start()
    {
      Level.instance.AddDestructable(); //keeps track of the number of destructible objects
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the game object moved a certain point
         if(transform.position.x < -2)
        {
            Level.instance.RemoveDestructable();
            Destroy(gameObject); //removes gameobjects
        }

        //checks if the game object moved a certain point 
        //and the gameobject is in range of player's gun
         if (transform.position.x < 17.0f && !canBeDestroyed)
        {
            canBeDestroyed = true; //player can destroy
             Gun[] guns = transform.GetComponentsInChildren<Gun>();
            
            foreach (Gun gun in guns)
            {
                gun.isActive = true;
            }
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //if gameobject can't be destroyed. return
        if (!canBeDestroyed)
        {
            return;
        }

        Bullet bullet = collision.GetComponent<Bullet>();

        //when the gameobject is within player's gun and collides with bullet
        if (bullet != null)
        {
            if (!bullet.isEnemy) 
            {
                Level.instance.AddScore(scoreValue); //adds points to the player's score

                // destroys the game object and create explosion
                DestroyDestructable(); 
                Destroy(bullet.gameObject);
            }
        }
     }

    void DestroyDestructable()
    {   
        //create an explosion animation
        Instantiate(explosion, transform.position, Quaternion.identity); 

        Level.instance.RemoveDestructable(); //remove the game object from the Level class
        Destroy(gameObject); //destroy the game object.
    }

}