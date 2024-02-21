using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //declare variables
    public Vector2 direction = new Vector2(1, 0); //bullet direction is set to value of (1, 0),
    public float speed = 2; //bullet speed moving

    public Vector2 velocity; //current velocity of the bullet
    public bool isEnemy = false; //isEnemy property to check if bullet is a enemy or not

    // Start is called before the first frame update
    void Start()
    {
       Destroy(gameObject, 3);  //destroy bullet gameobject after 3 seconds
       DontDestroyOnLoad(gameObject); //prevent gameobject being destroyed after level
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;  //calculates the velocity of the bullet with speed and direction
    }

    
     private void FixedUpdate()
    {
        Vector2 pos = transform.position; //update bullet position

         //calculates the bullet new position with the current position, velocity
        // And the fixed time interval using the Time.fixedDeltaTime.
        pos += velocity * Time.fixedDeltaTime;
        transform.position = pos;
    }
}
