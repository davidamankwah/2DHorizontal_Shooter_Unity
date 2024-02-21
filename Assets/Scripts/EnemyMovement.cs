using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5; //speed of gameObject movements

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
     private void FixedUpdate()
     {
        Vector2 pos = transform.position; //gets the current position of the game object for Vector2 object called pos  

        //subtracts the moveSpeed and the Time.fixedDeltaTime from the x component of the pos vector. 
        // Time.fixedDeltaTime allow the game object moves at a consistent speed 
        pos.x -= moveSpeed * Time.fixedDeltaTime;

       
         //Sets the game object to the new pos vector.
        transform.position = pos;
     }
}
