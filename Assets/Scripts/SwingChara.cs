using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwingChara : MonoBehaviour
{
	public float speed = 2.5f;
	public float jumpSpeed = 3.5f;
	public float gravity = 8.0F;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    Rigidbody rb;
    Transform tf;
    private float speedVertical = 0.0f;
    private int count;
    private bool swinging = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        //rb.freezeRotation = true;
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
    	// moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (controller.isGrounded) {
             speedVertical = 0;
             if (Input.GetButtonDown ("Jump")) {
                 speedVertical = jumpSpeed;
             }
         }
        speedVertical -= gravity * Time.deltaTime;
        moveDirection.y = speedVertical;

        //movement
        if (!swinging)
            controller.Move(moveDirection * Time.deltaTime * speed);

        // if (Input.GetKey(KeyCode.W))
        //     rb.AddForce(new Vector3(5.0f,0.0f,0.0f));
        // if (Input.GetKey(KeyCode.A))
        //     rb.AddForce(new Vector3(0.0f,0.0f,5.0f));
        // if (Input.GetKey(KeyCode.S))
        //     rb.AddForce(new Vector3(-5.0f,0.0f,0.0f));
        // if (Input.GetKey(KeyCode.D))
        //     rb.AddForce(new Vector3(0.0f,0.0f,-5.0f));
        if (Input.GetKeyUp(KeyCode.Space))
        {
           if (GetComponent<HingeJoint>()!= null){
           		HingeJoint hjOut = GetComponent<HingeJoint>();
           		Destroy(hjOut);
           }
        }
    }
    void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.CompareTag ("Hook"))
        {
        	if (GetComponent<HingeJoint>()== null){
        		rb.isKinematic = false;
        		if(Input.GetKey(KeyCode.Space)){
	            	swinging = true;
	            	controller.enabled = false;
	            	HingeJoint hj = gameObject.AddComponent<HingeJoint>() as HingeJoint;
	            	hj.anchor = transform.InverseTransformPoint(other.gameObject.transform.position);
	            	hj.axis = (Vector3.forward);
	            	//rb.freezeRotation = false;
            	}
            }
        }
    }
    void OnCollisionEnter(Collision collision) 
    {
    	if (collision.gameObject.CompareTag("Ground"))
        {
        	swinging = false;
        	tf.rotation = Quaternion.Euler(new Vector3(0,0,0));
        	rb.isKinematic = true;
           	controller.enabled = true;
        }
    }
}
