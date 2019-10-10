using UnityEngine;


// Represents a head (or tail?) of the dog
// All input is routed from LongDogController via the IPlayerAgent interface
public class LongDogPlayerController : MonoBehaviour, IPlayerAgent {
    private Rigidbody rigidbody;
        
    public void Start() {
        rigidbody = GetComponent<Rigidbody>();
        if (!rigidbody) {
            Debug.LogError("Missing rigidbody component!");
        }
    }    
    public void Move(Vector2 movement, float moveForce) {
        rigidbody.AddForce(new Vector3(movement.x, 0, movement.y) * Time.deltaTime * moveForce,
            ForceMode.Acceleration);
    }
}