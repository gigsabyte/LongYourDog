using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerControllerTarget : MonoBehaviour {
    public IPlayerController target;
    public PlayerControlsAdapter controller;
    public bool TryAssignPlayer(PlayerControlsAdapter adapter, PlayerInput playerInput) {
        var target = GetComponent<IPlayerController>();
        if (target == null || adapter.target != null) return false;
        adapter.target = target;
        controller = adapter;
        if (target is IMultiplayerDevice) {
            ((IMultiplayerDevice)target).OnControllerConnected(playerInput);
        }
        return true;
    }
    public void UnassignPlayer(PlayerControlsAdapter adapter, PlayerInput playerInput) {
        if (controller != null) {
            controller.target = null;
        }

        if (target != null) {
            if (target is IMultiplayerDevice) {
                ((IMultiplayerDevice)target).OnControllerDisconnected(playerInput);
            }
            target = null;
        }
    }
}
