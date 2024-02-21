using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{ 
    public Bullet bullet;
     Vector2 direction;

    [SerializeField] private bool autoShoot = false; //For the gun to shoot automatically.
    [SerializeField] private float shootIntervalSeconds = 0.5f; //Time interval between each shot.
    [SerializeField] private float shootDelaySeconds = 0.0f; //The delay before the gun starts shooting.
    float shootTimer = 0f;
    float delayTimer = 0f;

    public bool isActive = false; //check if the gun is active or not


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

     //when the gun is not active
      if (!isActive)
        {
          return;
        }

       //Set the direction variable to the normalized direction vector of the gun.
       direction = (transform.localRotation * Vector2.right).normalized; 

       //when aauto shoots
         if (autoShoot)
        {
            //checks if the delay timer is greater than or equal to the shoot delay seconds.
            if (delayTimer >= shootDelaySeconds)
            {
                //checks if the shoot timer is greater than or equal to the shoot interval.
                if (shootTimer >= shootIntervalSeconds)
                {

                    //Call the Shoot method and resets the shoot timer.
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime; //calculates by adding the shoot timer and Time.deltatime
                }
            }
            else
            {
                delayTimer += Time.deltaTime; //calculates by adding the delay timer and Time.deltatime
            }
        } 
    }

    //Function to instantiates a bullet object and sets its direction
    public void Shoot()
    {
        //Instantiates a bullet object at the position of the gun
        //Bullet object is created from the bullet prefab
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet goBullet = go.GetComponent<Bullet>();
        goBullet.direction = direction;
    }
}
