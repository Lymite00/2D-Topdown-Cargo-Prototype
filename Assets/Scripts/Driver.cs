using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float steerspeed = 0.1f;
    [SerializeField] float movespeed = 0.05f;
    public BoxCollider2D car;
    public bool naber=true;
    void Start()
    {
        
        naber = true;

    }

   

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal")*steerspeed*Time.deltaTime;
        float steerStraight = Input.GetAxis("Vertical")*movespeed*Time.deltaTime;
        if (naber == true)
        {
            transform.Rotate(0,0,-steerAmount);
        }
        
        transform.Translate(0,movespeed*steerStraight,0);

        if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
        {
            naber = false;
            transform.Rotate(0,0,+steerAmount);
        }

        if (Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.DownArrow))
        {
            naber = true;
        }
        
        
        
        
    }

   
}
