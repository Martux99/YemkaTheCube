using UnityEngine;

public class RED2: MonoBehaviour {

    public RED movement;
	
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

