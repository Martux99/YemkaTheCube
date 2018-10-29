using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour {
    bool rotado=false;
    public Light luz;
    public Light luz2;
    // Use this for initialization
    private void Update()
    {
        
        if (rotado)
        FindObjectOfType<PlayerMovemento>().player.Rotate(Vector3.right * Time.deltaTime*120);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("gayUnity");
            StartCoroutine(TheRealChange()); 
        }
    }
    IEnumerator TheRealChange()
    {
        rotado = true;
        FindObjectOfType<PlayerMovemento>().forwardForce = -8000f;
        yield return (new WaitForSeconds(0.5f));
        UnityEngine.Physics.gravity = new Vector3(0, UnityEngine.Physics.gravity.y * -1, 0);
        FindObjectOfType<FollowPlayer>().offset= new Vector3(0,-1,5);
        StartCoroutine(TheRealChange2());
    }
    IEnumerator TheRealChange2()
    {
        luz.gameObject.SetActive(false);
        luz2.gameObject.SetActive(true);
        yield return (new WaitForSeconds(1));
        rotado = false;

        FindObjectOfType<PlayerMovement>().forwardForce = -9500f;
        FindObjectOfType<PlayerMovemento>().jumpForce = -50000f;
        FindObjectOfType<PlayerMovemento>().forwardForce = -2000f;

    }
}
