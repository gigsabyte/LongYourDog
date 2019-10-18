using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IMultiplayerDevice {
    void OnControllerConnected(PlayerInput input);
    void OnControllerDisconnected(PlayerInput input);
}
