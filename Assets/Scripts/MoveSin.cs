using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    float sinCenterY; //store the initial y-position of the GameObject.
    [SerializeField] private float amplitude = 2;
    [SerializeField] private float frequency = 0.5f;

    [SerializeField] private bool inverted = false; //check if wave direction is inverted.

    // Start is called before the first frame update
    void Start()
    {
        sinCenterY = transform.position.y; //sets the variable to the y-position of the GameObject.
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        Vector2 pos = transform.position; // stores current position of the GameObject to pos variable

        // calculates sine of the gameobject x-position. 
        //multiplied by the frequency variable and multiplied by the amplitude variable.
        float sin = Mathf.Sin(pos.x * frequency) * amplitude;  

        //if inverted variable is true.
        if (inverted)
        {
            sin *= -1; //multiplies the sine value by -1.
        }

        pos.y = sinCenterY + sin; // sets pos y-position to the sinCenterY variable plus the sine value.

        transform.position = pos; //sets gameObject position to the pos variable.
    }
}
