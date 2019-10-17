using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour {
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

    public void OnDeviceLost() {
        Debug.Log("device lost!");
        DeactivateControls();
    }

    public void OnDeviceRegained() {
        Debug.Log("device regained!");
    }
}
