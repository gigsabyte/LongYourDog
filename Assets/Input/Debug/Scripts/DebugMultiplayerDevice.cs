using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugMultiplayerDevice : MonoBehaviour, IMultiplayerDevice {
    public void OnControllerConnected(PlayerInput input) {
        Debug.Log("Player input: controller connected! "+input);
    }
    public void OnControllerDisconnected(PlayerInput input) {
        Debug.Log("Player input: controller disconnected! "+input);
    }
}
