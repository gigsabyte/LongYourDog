using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;


// Represents a head (or tail?) of the dog
// All input is routed from LongDogController via the IPlayerAgent interface
public class LongDogPlayerController : MonoBehaviour, IPlayerController, IMultiplayerDevice {
    private Rigidbody rigidbody;
    private Renderer renderer;
    public bool hasPlayerAssigned = false;
    private static bool assignedP1 = false;
    private static bool assignedP2 = false;
    public int playerId = 0;
    private Vector2 moveDir = Vector2.zero;

    public void Start() {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
    }

    public void Update() {
        transform.Translate(new Vector3(moveDir.x, 0, moveDir.y) * Time.deltaTime * 10.0f);
    }
    public void UpdatePlayerMovement(Vector2 dir) {
        moveDir = dir;
    }
    public void OnJumpButtonPressed() {
        rigidbody.AddForce(Vector3.up * 80.0f,ForceMode.VelocityChange);
    }

    // Unused input callbacks
    public void UpdateCameraMovement(Vector2 dir) {}
    public void OnInteractButtonPressed() {}
    public void OnCancelButtonPressed() {}

    public void OnGrabButtonPressed() {}
    public void OnGrabButtonReleased() {}

    public void OnMenuButtonPressed() {
        throw new System.NotImplementedException();
    }

    public void OnControllerConnected(PlayerInput input) {
        if (playerId != 0) UnassignPlayer();
        TryAssignPlayer();
    }
    public void OnControllerDisconnected(PlayerInput input) {
        UnassignPlayer();
    }
    public bool TryAssignPlayer() {
        if (renderer == null)         renderer = GetComponent<Renderer>();

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
            moveDir = Vector2.zero;
            return true;
        }
        return false;
    }

    public void UnassignPlayer() {
        moveDir = Vector2.zero;
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
}