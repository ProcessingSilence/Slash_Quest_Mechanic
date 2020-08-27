using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Enemies simply move towards the player. Enemies have no attack function, do that yourself.
public class SimpleEnemy : MonoBehaviour
{
    public Transform target;

    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
