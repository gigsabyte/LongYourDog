using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Gamepad.all.Count > 1) {
            movement = Gamepad.all[1].leftStick.ReadValue();
        }
        else {
            movement = Vector2.zero; 
        }
        transform.Translate(new Vector3(movement.x, 0, movement.y) * moveSpeed * Time.deltaTime);
    }

    public float moveSpeed = 1.0f;
    public Vector2 movement;
    
    
//    public void OnMove(InputAction.CallbackContext context) {
    
    public void OnMove(InputValue value) {
        movement = value.Get<Vector2>();
    }
}
