using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : MonoBehaviour {
    float zetaentrecomillas=0;
    Rigidbody rbd;
    bool movPermitted=true;
	void Start ()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (movPermitted)
        {
        zetaentrecomillas += (1 * Time.deltaTime)*2;
        rbd.transform.position = new Vector3 (Mathf.Cos(zetaentrecomillas)*5.5f, rbd.transform.position.y, rbd.transform.position.z);

        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            movPermitted = false;
            UnityEngine.Physics.gravity = new Vector3(0, 29.81f, 0);
        }
    }
}
