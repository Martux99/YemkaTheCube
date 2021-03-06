﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemento : MonoBehaviour {
    public GameObject cube;
    public Transform player;
    public Vector3 hector;
    public Vector3 whereto;
    public Rigidbody rb;
    bool direccion2 = false;
    public bool grounded = false;
    public bool direccion = false;
    public bool notouch = true;
    public bool pelon = true;
    public int cuenta;
    public float sidewaysMov = 16f;
    public float TiempodeInversion;
    public float jumpForce;
    bool invertido = false;

    public float forwardForce = 2000f;
    public float maxForce = 1000f;
    private bool isFalling = false;



    private void Awake()
    {
        UnityEngine.Physics.gravity = new Vector3(0, -29.81f, 0);
    }
    void FixedUpdate()
    {
        if (transform.position.y < -3)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        if (rb.velocity.z < maxForce)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        cuenta = Input.touchCount;
        if (cuenta == 1)
        {
            notouch = false;
            Touch touch = (Input.GetTouch(0));
            if (Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10)).x < rb.transform.position.x)
            {
                direccion = false;
            }
            if (Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10)).x > rb.transform.position.x)
            {
                direccion = true;
            }
            
            ///Movimiento lateral
            ///2 if's
            if (direccion == false)
            {
                if (invertido == false)
                {
                    player.Translate(Vector3.left * Time.deltaTime * sidewaysMov);
                }
                if (invertido == true)
                {
                    player.Translate(Vector3.right * Time.deltaTime * sidewaysMov);
                }
            }
            else if (direccion == true)
            {
                if (invertido == false)
                {
                    player.Translate(Vector3.right * Time.deltaTime * sidewaysMov);
                }
                if (invertido == true)
                {
                    player.Translate(Vector3.left * Time.deltaTime * sidewaysMov);
                }
            }
        }
        if (cuenta > 1&& grounded == true)
        {
            rb.AddForce(Vector3.up * Time.deltaTime * jumpForce);
            grounded = false;
        }
        if (cuenta == 0 && grounded == false)
        {
            notouch = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Inversion")
        {
            invertido = true;
            StartCoroutine(TiempoInvertido());
        }
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    IEnumerator TiempoInvertido()
    {
        yield return (new WaitForSeconds(TiempodeInversion));
        invertido = false;
    }
}