using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivarSalto : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("gayUnity");
            FindObjectOfType<PlayerMovemento>().jumpForce = 0f;
        }
    }
}
