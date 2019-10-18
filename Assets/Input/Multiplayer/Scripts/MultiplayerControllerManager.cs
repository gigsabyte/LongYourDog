using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class MultiplayerControllerManager : MonoBehaviour
{
    void OnPlayerJoined(PlayerInput input) {
        var adapter = input.gameObject.GetComponent<PlayerControlsAdapter>();
        Assert.IsNotNull(adapter);
        var players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players) {
            var target = player.GetComponent<MultiplayerControllerTarget>();
            if (target != null && target.TryAssignPlayer(adapter, input)) {
                return;
            }
        }
        Debug.Log("Could not assign new controller input: not enough player targets");
    }
    void OnPlayerLeft(PlayerInput input) {
        var adapter = input.gameObject.GetComponent<PlayerControlsAdapter>();
        Assert.IsNotNull(adapter);
        if (adapter.target != null && adapter.target is MultiplayerControllerTarget) {
            var target = (MultiplayerControllerTarget)adapter.target;
            target.UnassignPlayer(adapter, input);
        }
    }
}
