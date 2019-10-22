using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerControllerAdapter : MonoBehaviour {
    public PlayerControlsAdapter adapter;

    public void Start() {
        adapter = GetComponent<PlayerControlsAdapter>();
        if (adapter == null) {
            adapter = gameObject.AddComponent<PlayerControlsAdapter>();
        }
        adapter.target = GetComponent<IPlayerController>();
    }
}
