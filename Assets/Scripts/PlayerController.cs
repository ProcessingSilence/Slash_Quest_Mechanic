using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player, swordRotPoint, swordObj;

    // Player movement speed.
    public float moveSpeed;

    // Sword rotation speed.
    public float rotateSpeed;

    public Rigidbody2D playerRB;
    
    private Vector3 rotation;

    void Start()
    {
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = player.transform.position;
        swordRotPoint.transform.position = playerPos;
        
        // A + D are pressed: move based on rotation.
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            rotation = swordRotPoint.transform.rotation * Vector3.up;
            Debug.Log(rotation);
            playerRB.velocity = rotation * moveSpeed * Time.deltaTime;
        }
        else
        {
            playerRB.velocity = new Vector2(0,0);
        }
        // A pressed: clockwise sword rotation.
        
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("D");
            swordRotPoint.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        // D pressed: counterclockwise sword movement.
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("A");
            swordRotPoint.transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
        }               
    }
}
