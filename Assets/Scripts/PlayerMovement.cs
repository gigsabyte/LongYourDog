using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerController {
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public float jumpSpeed = 10f;// m/s
    public float moveSpeed = 3.5f; // m/s
    public float turnSpeed = 180.0f; // degrees / sec

    // Update is called once per frame
    void Update() {
        transform.Translate(
            transform.rotation * (
                Vector3.forward * moveDir.y +
                Vector3.right * moveDir.x
            ) * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, turnDir.x * turnSpeed * Time.deltaTime);

    }

    private Vector2 moveDir = Vector2.zero;
    private Vector2 turnDir = Vector2.zero;
    private bool jumped = false;

    public void Jump() {
//        if (!jumped) {
            jumped = true;
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
//        }
    }
    
    public void UpdatePlayerMovement(Vector2 dir) {
        moveDir = dir;
    }
    public void UpdateCameraMovement(Vector2 dir) {
        turnDir = dir;
    }

    public void OnJumpButtonPressed() {
        Jump();
    }

    public void OnInteractButtonPressed() {
//        throw new System.NotImplementedException();
    }

    public void OnCancelButtonPressed() {
//        throw new System.NotImplementedException();
    }

    public void OnGrabButtonPressed() {
//        throw new System.NotImplementedException();
    }

    public void OnMenuButtonPressed() {
//        throw new System.NotImplementedException();
    }
}
