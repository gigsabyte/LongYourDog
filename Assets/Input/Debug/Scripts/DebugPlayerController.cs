using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayerController : MonoBehaviour, IPlayerController {
    public void UpdatePlayerMovement(Vector2 dir) {
        Debug.Log("Player movement at "+Time.time+": "+dir);
    }
    public void UpdateCameraMovement(Vector2 dir) {
        Debug.Log("Camera movement at "+Time.time+": "+dir);
    }
    public void OnJumpButtonPressed() {
        Debug.Log("Player jump at "+Time.time);
    }
    public void OnInteractButtonPressed() {
        Debug.Log("Player interact at "+Time.time);
    }
    public void OnCancelButtonPressed() {
        Debug.Log("Player cancel at "+Time.time);
    }
    public void OnGrabButtonPressed() {
        Debug.Log("Player grab at "+Time.time);
    }
    public void OnMenuButtonPressed() {
        Debug.Log("Player open menu at "+Time.time);
    }
}
