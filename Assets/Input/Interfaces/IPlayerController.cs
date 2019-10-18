using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// interface that player controllers should implement to handle player input using the new input system
public interface IPlayerController {
    // called when player movement input changes
    // (gamepad: mapped to left stick)
    // (keyboard: WASD / arrow keys)
    void UpdatePlayerMovement(Vector2 dir);
    
    // called when camera movement input changes
    // (gamepad: mapped to right stick)
    // (keyboard: mapped to mouse delta?)
    void UpdateCameraMovement(Vector2 dir);
    
    // called when player jump button is pressed
    // (gamepad: A key)
    // (keyboard: space key)
    void OnJumpButtonPressed();

    // called when interaction button (eg. start dialog?) pressed
    // (gamepad: X or Y key?)
    // (keyboard: tab key?)
    void OnInteractButtonPressed();

    // called when cancel button (to exit dialog / menus?) pressed
    // (gamepad: B key)
    // (keyboard: esc key)
    void OnCancelButtonPressed();

    // called when grab button pressed
    // (gamepad: right trigger?)
    // (keyboard: right mouse button?)
    void OnGrabButtonPressed();

    // called when menu button pressed (not necessary, but added in case we want to add this)
    // (gamepad: start (or select?) button)
    // (keyboard: esc key)
    void OnMenuButtonPressed();
}
