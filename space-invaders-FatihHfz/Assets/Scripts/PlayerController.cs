using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10f;
    float minX = -8;
    float maxX = 8;
   
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftend = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightend = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        minX = leftend.x;
        maxX = rightend.x;
        
    }

    
    void Update()
    {
        border();
        ShipMovement();
    }

    public void ShipMovement()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
           //transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
           transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    public void border()
    {
        float newX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

    }

    
}
