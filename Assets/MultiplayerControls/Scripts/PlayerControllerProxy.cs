using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Spawned on a prefab (PlayerInputController) when a gamepad / input device is connected (and player presses a button)
// Responsible for routing input to a 'pawn', ie. an actual player character, which has a LongDogPlayerController
// attached, and handles connecting / disconnecting to that pawn via TryAssignPlayer() and UnassignPlayer().
//
public class PlayerControllerProxy : MonoBehaviour {
    private bool wasActive = false;
    public LongDogPlayerController pawn = null;
    public void ActivateControls() {
        wasActive = true;
        if (pawn == null) {
            var objects = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject obj in objects) {
                var controller = obj.GetComponent<LongDogPlayerController>();
                if (controller != null && controller.TryAssignPlayer()) {
                    Debug.Log("Assigned player!");
                    pawn = controller;
                    return;
                }
            }
            Debug.Log("cound not find player to assign!");
        }
    }
    public void DeactivateControls() {
        Debug.Log("deactiviating player controls!!!");
        wasActive = false;
        if (pawn != null) {
            pawn.UnassignPlayer();
            pawn = null;
        }
    }
    public void OnMove(InputValue value) {
        if (!wasActive) {
            ActivateControls();
        }

        if (pawn != null) {
            var input = value.Get<Vector2>();
            pawn.Move(input, 100.0f);
        }

//        Debug.Log("got movement!"+value+": "+input);
//        transform.Translate(
//            new Vector3(
//                input.x, 0.0f, input.y
//        ) * Time.deltaTime * 2.0f);
    }

    public void OnJump(InputValue value) {
        if (!wasActive) {
            ActivateControls();
        }
        if (pawn != null) {
            pawn.Jump();
        }
    }
    
    public void OnDeviceLost() {
        Debug.Log("device lost!");
        DeactivateControls();
    }

    public void OnDeviceRegained() {
        Debug.Log("device regained!");
    }
}
