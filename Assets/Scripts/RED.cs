using UnityEngine;

public class RED : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float upForce = 50f;
    private bool isFalling= false;

    // Update is called once per frame
    void FixedUpdate ()
    {
        rb.AddForce(0,0,forwardForce*Time.deltaTime);

        if(Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rb.position.y<-1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }
    private void OnCollisionStay(Collision collision)
    {
        
            isFalling = false;
        
    }
}
