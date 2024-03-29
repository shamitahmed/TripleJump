﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType
{
    rocket,
    ufo,
    meteor
}
public class Obstacle : MonoBehaviour
{
    public ObstacleType ot;
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.levelNumber < 2)
        {
            speed = 3f;
        }
        else if (GameManager.instance.levelNumber < 5)
        {
            speed = 3.5f;
        }
        else
        {
            speed = 4f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.startGame)
        {
            transform.position -= Vector3.forward * speed * Time.deltaTime;
           
        }
        if (ot == ObstacleType.ufo)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        if (ot == ObstacleType.meteor)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

    }
    private void OnCollisionEnter(Collision other)
    {

    }
}
