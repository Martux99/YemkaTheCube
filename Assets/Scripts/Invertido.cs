using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invertido : MonoBehaviour {
    public GameObject esfera;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Destroy(esfera);
        }
    }
}
