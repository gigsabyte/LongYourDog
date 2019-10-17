using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;


// Represents a head (or tail?) of the dog
// All input is routed from LongDogController via the IPlayerAgent interface
public class LongDogPlayerController : MonoBehaviour, IPlayerAgent {
    private Rigidbody rigidbody;
    private Renderer renderer;
    public bool hasPlayerAssigned = false;
    private static bool assignedP1 = false;
    private static bool assignedP2 = false;
    public int playerId = 0;

    public void Start() {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
    }
    
    public void Move(Vector2 movement, float moveForce) {
        transform.Translate(new Vector3(movement.x, 0, movement.y) * Time.deltaTime * 10.0f);
//        rigidbody.AddForce(new Vector3(movement.x, 0, movement.y) * Time.deltaTime * moveForce,
//            ForceMode.Acceleration);
    }

    public bool TryAssignPlayer() {
        if (!hasPlayerAssigned) {
            hasPlayerAssigned = true;
            if (!assignedP1) {
                assignedP1 = true;
                playerId = 1;
                renderer.material.color = Color.red;
            } else if (!assignedP2) {
                assignedP2 = true;
                playerId = 2;
                renderer.material.color = Color.blue;
            }
            else {
                renderer.material.color = Color.magenta;
            }
            Debug.Log("assigned player "+playerId+"!");
            return true;
        }
        return false;
    }

    public void UnassignPlayer() {
        hasPlayerAssigned = false;
        if (playerId == 1) {
            assignedP1 = false; 
        } else if (playerId == 2) {
            assignedP2 = false;
        }
        Debug.Log("unassigned player "+playerId+"!");
        playerId = 0;
        renderer.material.color = Color.white;
    }
    public void OnPlayerAdded(Gamepad gamepad) {
    }

    public void OnPlayerRemoved(Gamepad gamepad) {
    }
}