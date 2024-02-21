using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    Vector2 initialPosition;

    Gun[] guns; //An array of guns.

    float moveSpeed = 3; //player ship speed
    
    //player ship movement
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    bool speedUp;


    bool shoot; 

     private void Awake()
    {
        initialPosition = transform.position; //initializes the initialPosition
       
    }
    // Start is called before the first frame update
    void Start()
    {
       guns = transform.GetComponentsInChildren<Gun>(); //initializes the guns array
        foreach(Gun gun in guns)
        {
            gun.isActive = true; //set guns active
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ship movements based on key inputs
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        shoot = Input.GetKeyDown(KeyCode.X);

        //Check if player ship shooting
        if (shoot)
        {
            shoot = false;
            foreach(Gun gun in guns)
            {
          
                gun.Shoot(); //gun fires shots
            }
        }

    }

    private void FixedUpdate()
    {
        
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;

        //Moves the spaceship based on the boolean variables 
        if (speedUp)
        {
            moveAmount *= 3;
        }
        Vector2 move = Vector2.zero;


        if (moveUp)
        {
            move.y += moveAmount;
        }

        if (moveDown)
        {
            move.y -= moveAmount;
        }

        if (moveLeft)
        {
            move.x -= moveAmount;
        }

        if (moveRight)
        {
            move.x += moveAmount;
        }
        
        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
           if (moveMagnitude > moveAmount)
           {
             float ratio = moveAmount / moveMagnitude;
             move *= ratio;
           }

        pos += move;
      
        // limit the position on the x-axis
        if(pos.x <= 1.5f) // if the position is less than or equal to 1.5 units on the x-axis
        {
            pos.x = 1.5f; // set the x-position to 1.5 units
        }
        if(pos.x >= 16f) // if the position is greater than or equal to 16 units on the x-axis
        {
            pos.x = 16f; // set the x-position to 16 units
        }

        // limit the position on the y-axis
        if(pos.y <= 1) // if the position is less than or equal to 1 unit on the y-axis
        {
            pos.y = 1; // set the y-position to 1 unit
        }
        if(pos.y >= 9) // if the position is greater than or equal to 9 units on the y-axis
        {
            pos.y = 9; // set the y-position to 9 units
        }

        transform.position = pos;
    }
     
     void ResetShip()
    {
        //Resets the position of the spaceship to its initial position and resets the level.
        transform.position = initialPosition;
        Level.instance.ResetLevel();
    }

       //Checks if the spaceship collides with another object 
       private void OnTriggerEnter2D(Collider2D collision)
       {
        // checks if the object is an enemy bullet or destructible object
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (bullet.isEnemy)
            {
                ResetShip(); //call method
            }
        }
        
         Destructable destructable = collision.GetComponent<Destructable>();
        if (destructable != null)
        {
            ResetShip(); //call method
        }

     }
}
