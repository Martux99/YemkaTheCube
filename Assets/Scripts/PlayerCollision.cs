﻿using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovemento movement;
	
	// Update is called once per frame
	void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.tag=="Obstacle")
        {
            
            movement.enabled=false;
            FindObjectOfType<GameManager>().EndGame();

        }
    }
		
	}

