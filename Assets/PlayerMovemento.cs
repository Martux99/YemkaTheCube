using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemento : MonoBehaviour {
    public GameObject cube;
    public Transform player;
    public Vector3 hector;
    public Vector3 whereto;
    bool direccion2 = false;
    public bool grounded = false;
    public bool direccion = false;
    public bool notouch = true;
    public bool pelon = true;
    public int cuenta;

    void FixedUpdate()
    {
        //Vector3 cannon = new Vector3(0, player.position.y+3.7f, -10);
        cuenta = Input.touchCount;
        if (cuenta > 0)
        {
            Touch touch = (Input.GetTouch(0));
            if (Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10)).x < 0)
            {
                direccion = false;
            }
            if (Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10)).x > 0)
            {
                direccion = true;
            }
            if (pelon == true)
            {
                hector = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10));
                pelon = false;
            }
            whereto = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10));
            if (whereto.x > hector.x + 1)
            {
                whereto = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10));
                direccion = true;
                pelon = true;
            }
            if (whereto.x < hector.x - 1)
            {
                whereto = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                direccion = false;
                pelon = true;
            }
            notouch = false;
            if (direccion == false)
            {
                if (direccion2 == true)
                {
                    cube.transform.localScale = new Vector3(-cube.transform.localScale.x, cube.transform.localScale.y, cube.transform.localScale.z);
                }
                direccion2 = direccion;
                player.Translate(Vector3.left * Time.deltaTime * 16f);
            }
            else if (direccion == true)
            {
                if (direccion2 == false)
                {
                    cube.transform.localScale = new Vector3(-cube.transform.localScale.x, cube.transform.localScale.y, cube.transform.localScale.z);
                }
                direccion2 = direccion;
                player.Translate(Vector3.right * Time.deltaTime * 16f);
            }
        }
        if (cuenta == 0 && grounded == false)
        {
            notouch = true;
        }
    }    
}