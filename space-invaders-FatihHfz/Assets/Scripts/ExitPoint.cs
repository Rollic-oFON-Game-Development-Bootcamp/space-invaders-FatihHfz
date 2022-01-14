using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    public GameObject enemyprefab;
    void Start()
    {
        foreach(Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyprefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
