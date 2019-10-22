using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

// Sends unity input system events to an IPlayerController instance (if it is set).
// Building block for MultiplayerControllerProxy; can also be used directly.
// Methods get called via eg. SendMessages from a PlayerInput script.
public class PlayerControlsAdapter : MonoBehaviour {
    [SerializeField]
    public IPlayerController target = null;
    public enum MouseButton {
        Left,
        Right,
        None
    };
    public MouseButton cameraMovementMouseButton;
    
    public void OnPlayerMovement(InputValue value) {
        target?.UpdatePlayerMovement(value.Get<Vector2>());
    }
    public void OnCameraMovement(InputValue value) {
        target?.UpdateCameraMovement(value.Get<Vector2>());
    }
    public void OnCameraMovementMouse(InputValue value) {
        var pressed =
            cameraMovementMouseButton == MouseButton.Left ? Mouse.current.leftButton.isPressed :
            cameraMovementMouseButton != MouseButton.Right || Mouse.current.rightButton.isPressed;
        
        // send camera motion updates only when a mouse button (if one is required) is pressed.
        // if it is not, send Vector2.zero so we won't fail to send some updates, specifically
        // when this stops changing and 0, 0 should be sent
        target?.UpdateCameraMovement(pressed ? value.Get<Vector2>() : Vector2.zero);
    }
    public void OnJump(InputValue value) {
        if (value.isPressed)
            target?.OnJumpButtonPressed();
    }
    public void OnInteract(InputValue value) {
        if (value.isPressed)
            target?.OnInteractButtonPressed();
    }
    public void OnCancel(InputValue value) {
        if (value.isPressed)
            target?.OnCancelButtonPressed();
    }
    public void OnGrab(InputValue value) {
        if (value.isPressed) {
            target?.OnGrabButtonPressed();
        } else {
            target?.OnGrabButtonReleased();
        }
    }
    public void OnMenuOpened(InputValue value) {
        if (value.isPressed)
            target?.OnMenuButtonPressed();
    }
}
