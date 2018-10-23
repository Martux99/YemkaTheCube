using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce = 200f;
    public float maxForce = 100f;
    public float minForce = -100f;
    int cuenta;
    bool notouch;
    public bool direccion = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.position.z < 0)
        {
            transform.position = new Vector3(-4.51f, 1, 0);
        }
        cuenta = Input.touchCount;
        if (cuenta == 1)
        {
            notouch = false;
            Touch touch = (Input.GetTouch(0));
            if (Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, -1.73f)).x < 0)
            {
                direccion = false;
            }
            if (Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, -1.73f)).x > 0)
            {
                direccion = true;
            }
            if (direccion == false)
            {
                if (rb.velocity.z < maxForce)
                    rb.AddForce(0, 0, forwardForce * Time.deltaTime);
            }
            else if (direccion == true)
            {
                if (rb.velocity.z > minForce && transform.position.z > 0)
                {
                    rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
                }
                else if (transform.position.z < 0)
                {
                    transform.position = new Vector3(-4.51f, 1, 0);
                }
            }
        }
        }
}
