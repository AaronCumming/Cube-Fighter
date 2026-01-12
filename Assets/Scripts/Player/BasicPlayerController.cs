using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour
{
    /* 
    Create a variable called 'rb' that will represent the 
    rigid body of this object.
    */
    private Rigidbody rb;
    
    // Create a public variable for the cameraTarget object
    public GameObject cameraTarget;
    /* 
    You will need to set the cameraTarget object in Unity. 
    The direction this object is facing will be used to determine
    the direction of forces we will apply to our player.
    */
    public float movementIntensity;
    /* 
    Creates a public variable that will be used to set 
    the movement intensity (from within Unity)
    */
    public GameObject Projectile;
    public GameObject SpecialProjectile;
    /*
    Creates a variable for our Projectile.
    In this example this must be a prefab 
    with a rigid body component
    */

    private bool reload = false;
    public float reloadDuration = 0.1f;
    public float reloadDuration2 = 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        // make our rb variable equal the rigid body component
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Establish some directions 
        // based on the cameraTarget object's orientation 
        var ForwardDirection = cameraTarget.transform.forward;
        var RightDirection = cameraTarget.transform.right;

        if (Input.GetKey(KeyCode.R))
        {
        rb.linearVelocity = ForwardDirection * 0;
        }
        // Move Forwards
        if (Input.GetKey(KeyCode.W))
        {
            //rb.AddForce (ForwardDirection * movementIntensity);
            rb.linearVelocity = ForwardDirection * movementIntensity;
        }
        
        // Move Backwards
        if (Input.GetKey(KeyCode.S))
        {
            // Adding a negative to the direction reverses it
            //rb.AddForce (-ForwardDirection * movementIntensity);
            rb.linearVelocity = -ForwardDirection * movementIntensity;
            /* You may want to try using velocity rather than force.
            This allows for a more responsive control of the movement
            possibly better suited to first person controls, eg: */
            
        }
        // Move Rightwards (eg Strafe. *We are using A & D to swivel)
        if (Input.GetKey(KeyCode.E))
        {
           //rb.AddForce (RightDirection * movementIntensity);
           rb.linearVelocity = RightDirection * movementIntensity;
        }
        // Move Leftwards
        if (Input.GetKey(KeyCode.Q))
        {
           //rb.AddForce (-RightDirection * movementIntensity);
           rb.linearVelocity = -RightDirection * movementIntensity;
        }
        // shoot
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.M)) {
            if (reload) return;
            StartCoroutine(shootBasicProjectile());
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.K)) {
            if (reload) return;
            StartCoroutine(shootSpecialProjectile());
        }
        /*
        Calls a 'shootProjectile' function
        when the space key is pressed.
        */
    }

    private IEnumerator shootBasicProjectile()
    {
        reload = true;
        var ForwardDirection = cameraTarget.transform.forward;
        var RightDirection = cameraTarget.transform.right;
        var UpDirection = cameraTarget.transform.up;
        GameObject clone = Instantiate(Projectile, transform.position + 2 * ForwardDirection, transform.rotation);
        clone.GetComponent<Rigidbody>().AddForce(ForwardDirection * 10000);
        clone.GetComponent<Rigidbody>().AddForce(UpDirection * 200);
        clone.GetComponent<Rigidbody>().AddTorque(RightDirection * 200);
        Destroy(clone, 10.0f); // Destroy the clone after 5 seconds
        yield return new WaitForSeconds(reloadDuration);
        reload = false;
    }
    private IEnumerator shootSpecialProjectile()
    {
        reload = true;
        var ForwardDirection = cameraTarget.transform.forward;
        var RightDirection = cameraTarget.transform.right;
        var UpDirection = cameraTarget.transform.up;
        GameObject clone = Instantiate(SpecialProjectile, transform.position + 4 * ForwardDirection, transform.rotation);
        clone.GetComponent<Rigidbody>().AddForce(ForwardDirection * 4000);
        clone.GetComponent<Rigidbody>().AddForce(UpDirection * 200);
        clone.GetComponent<Rigidbody>().AddTorque(RightDirection * 200);
        clone.transform.Rotate(UpDirection, Space.World);
        Destroy(clone, 12.0f); // Destroy the clone after 5 seconds
        yield return new WaitForSeconds(reloadDuration2);
        reload = false;
    }    
}
