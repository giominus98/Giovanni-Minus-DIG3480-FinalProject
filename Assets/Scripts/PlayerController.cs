﻿using UnityEngine;
using System.Collections;

[System.Serializable] //Makes new class visible in the inspector
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    //These 3 will appear as editable values in the inspector
    public float playerSpeed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public GameObject shot2;
    public Transform shotSpawn;
    public float fireRate;

    private Rigidbody rb;
    private float nextFire;
    private AudioSource audioSource; //Adds audio variable

    public bool canMove = true;

    public AudioClip secondWeapon;
    public bool secondWeaponGet = false; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); //Gets the audio thats in the game object component
    }

    public void GetSecondWeapon() //Fetches from Pickups and GameController scripts to see if player has power up
    {
        secondWeaponGet = true;
    }

    void Update()
    {
        if (canMove == true)
        {
            if (secondWeaponGet == false)
            {
                if (Input.GetButton("Fire1") && Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
                    audioSource.Play(); //Plays audio whenever shot
                }
            }

            if (secondWeaponGet == true)
            {
                audioSource.clip = secondWeapon;
                if (Input.GetButton("Fire1") && Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(shot2, shotSpawn.position, shotSpawn.rotation); // as GameObject;
                    audioSource.Play(); //Plays audio whenever shot
                }
            }
        }
    }

    void FixedUpdate()
    {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //Defines how fast you will go
            rb.velocity = movement * playerSpeed;
        

        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), //Sets the player boundary.
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt); 


    }
}
