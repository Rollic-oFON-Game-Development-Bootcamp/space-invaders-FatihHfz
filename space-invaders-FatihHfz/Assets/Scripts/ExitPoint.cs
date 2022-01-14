using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    public GameObject enemyprefab;
    public float width;
    public float height;
    private bool moveright = true;
    private float speed = 5f;
    private float xmax;
    private float xmin;
    void Start()
    { 
        //obje ile kameranın z sinin arasındaki fark
        float betweenobjectandcamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftendcamera = Camera.main.ViewportToWorldPoint(new Vector3(0,0,betweenobjectandcamera));
        Vector3 rightendcamera = Camera.main.ViewportToWorldPoint(new Vector3(1,0,betweenobjectandcamera));
        xmax = rightendcamera.x;
        xmin = leftendcamera.x;

        foreach(Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyprefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
        
    }

    public void OnDrawGizmos() 
    {
        Gizmos.DrawWireCube(transform.position,new Vector3(width,height));    
    }
    void Update()
    {
        if(moveright)
        {
           // transform.position += new Vector3(speed * Time.deltaTime, 0);
           transform.position += speed * Vector3.right * Time.deltaTime;
        }
        else
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
        
        float rightorder = transform.position.x + width/2;
        float leftorder = transform.position.x - width/2;
        
        if(rightorder > xmax || leftorder < xmin)
        {
            moveright = !moveright;
        }
    }
}
