﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlue : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            player.increaseScore(5);
        }
    }
}
