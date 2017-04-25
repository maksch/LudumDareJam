﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour {
    float currentXAxisMove = 0;
    float currentYAxisMove = 0;
    float currentZAxisMove = 0;
    float currentZAxisRotate = 0;

    float nextXAxisMove = 0;
    float nextYAxisMove = 0;
    float nextZAxisMove = 0;
    float nextZAxisRotate = 0;

    float speedLimiter = 0.1f;
    float currentSpeed = 0;
    float nextSpeed = 0.1f;
    bool goingUp = true;
    bool startCurrentNewDirection = true;
    bool startNextNewDirection;
    Vector3 pointSelected;
    float magnifier = 0.06f;

    public bool allowMovement = true;

    Animator animator;

    Rigidbody rb;

    int myId;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myId = GetInstanceID();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (allowMovement && (!TeamCounter.isGameOver && !ShrineHandler.gameWon))
        {
            if (startCurrentNewDirection)
            {
                currentXAxisMove = Random.Range(-1f, 1f);
                currentYAxisMove = Random.Range(-1f, 1f);
                currentZAxisMove = Random.Range(-1f, 1f);
                currentZAxisRotate = Random.Range(-1f, 1f);
                startCurrentNewDirection = false;
            }
            if (startNextNewDirection)
            {

                nextXAxisMove = Random.Range(-1f, 1f);
                nextYAxisMove = Random.Range(-1f, 1f);
                nextZAxisMove = Random.Range(-1f, 1f);
                nextZAxisRotate = Random.Range(-1f, 1f);
                startNextNewDirection = false;
            }
            if (goingUp)
            {
                nextSpeed -= 0.001f;
                currentSpeed += 0.001f;
                if (currentSpeed >= speedLimiter)
                {
                    nextSpeed = 0;
                    goingUp = false;
                    startNextNewDirection = true;
                }
            }
            else
            {
                currentSpeed -= 0.001f;
                nextSpeed += 0.001f;
                if (currentSpeed <= 0)
                {
                    currentSpeed = 0;
                    goingUp = true;
                    startCurrentNewDirection = true;
                }
            }
            currentXAxisMove = Random.Range(currentXAxisMove - currentSpeed , currentXAxisMove + currentSpeed);
            currentYAxisMove = Random.Range(currentYAxisMove - currentSpeed , currentYAxisMove + currentSpeed);
            currentZAxisRotate = Random.Range(currentZAxisRotate - currentSpeed , currentZAxisRotate + currentSpeed);
            if (nextXAxisMove != 0 || nextYAxisMove != 0)
            {
                nextXAxisMove = Random.Range(nextXAxisMove - nextSpeed, nextXAxisMove + nextSpeed);
                nextYAxisMove = Random.Range(nextYAxisMove - nextSpeed, nextYAxisMove + nextSpeed);
                nextZAxisRotate = Random.Range(nextZAxisRotate - nextSpeed, nextZAxisRotate + nextSpeed);
            }
            if(((currentXAxisMove * (currentSpeed / (speedLimiter + currentSpeed)) + nextXAxisMove *
                                 (nextSpeed / (speedLimiter + nextSpeed)))) * magnifier < 0)
            {
                transform.localScale = new Vector3(-4, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(4, transform.localScale.y, transform.localScale.z);
            }
            animator.speed = Mathf.Abs(((currentXAxisMove * (currentSpeed / (speedLimiter + currentSpeed)) + nextXAxisMove *
                                 (nextSpeed / (speedLimiter + nextSpeed)))) * magnifier * 100);

            transform.Translate(((currentXAxisMove * (currentSpeed / (speedLimiter + currentSpeed)) + nextXAxisMove *
                                 (nextSpeed / (speedLimiter + nextSpeed)))) * magnifier,
                                 (currentYAxisMove * (currentSpeed / (speedLimiter + currentSpeed)) + nextXAxisMove *
                                 (nextSpeed / (speedLimiter + nextSpeed))) * magnifier, 0);
           // transform.Rotate(0, 0, (currentZAxisRotate * (currentSpeed / (speedLimiter + currentSpeed)) + nextZAxisRotate *
             //                    (nextSpeed / (speedLimiter + nextSpeed))));
        }
        else
        {
            startCurrentNewDirection = true;
            startNextNewDirection = false;
            currentSpeed = 0;
            nextSpeed = speedLimiter;
            nextXAxisMove = 0;
            nextYAxisMove = 0;
            nextZAxisMove = 0;
            nextZAxisRotate = 0;

            animator.speed = 0;
        }
        if (TeamCounter.isGameOver  || ShrineHandler.gameWon)
        {
          
            currentXAxisMove = 0;
            currentYAxisMove = 0;
            currentZAxisMove = 0;
            currentZAxisRotate = 0;

            nextXAxisMove = 0;
            nextYAxisMove = 0;
            nextZAxisMove = 0;
            nextZAxisRotate = 0;
            animator.speed = 0;
        }

        rb.velocity = new Vector3(0, 0, 0);
    }
}
