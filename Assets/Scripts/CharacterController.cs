﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Transform rayStart;
    public GameObject starParticleEffect;
    private Rigidbody rb;
    private bool walkingRight = true;
    private Animator anime;
    private GameManager gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if(!gameManager.gameStarted)
        {
            return;
        } else
        {
            anime.SetTrigger("gameStarted");
            rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.gameStarted)
        {
            SwitcWalkinghDirection();
        }
        if(transform.position.y < -10)
        {
            gameManager.EndGame();
        }

        RaycastHit hit;
        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            anime.SetTrigger("isFalling");
        } else
        {
            anime.SetTrigger("notFalling");
        }
    }

    private void SwitcWalkinghDirection()
    {
        walkingRight = !walkingRight;
        if (walkingRight)
            transform.rotation = Quaternion.Euler(0, 45, 0);
        else
            transform.rotation = Quaternion.Euler(0, -45, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Star")
        {
            gameManager.IncreaseScore();
            GameObject g = Instantiate(starParticleEffect, rayStart.transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
    }
}
