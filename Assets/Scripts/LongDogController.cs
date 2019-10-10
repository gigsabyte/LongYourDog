using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

// Represents the entire dog.
// LongDogPlayerController represents a head / tail
public class LongDogController : MonoBehaviour {

    public LongDogPlayerController[] agents;
    public int numGamepads = 0;
    public float moveForce = 10.0f;
    private LocalMultiplayerGamepadMapper<LongDogPlayerController> controlMapper;

    public void Start() {
        var agents = GetComponentsInChildren<LongDogPlayerController>();
        if (agents.Length != 2) {
            Debug.LogError("expected exactly two controllable agents");
        }
        controlMapper = new LocalMultiplayerGamepadMapper<LongDogPlayerController>(agents);
    }

    public void Update() {
        // get current list of active gamepads
        var gamepads = Gamepad.all;
        
        // update our gamepad <-> game agent mappings
        // (ie. if a controller is detected or removed; try to handle this semi-intelligently)
        controlMapper.UpdateMappings(gamepads);
        
        // fire off gamepad input from every active gamepad to every mapped player agent
        // does so by calling methods defined on IPlayerAgent, which are implemented
        // by LongDogPlayerController.
        for (int i = 0; i < gamepads.Count; ++i) {
            var agent = controlMapper.GetAgentForGamepad(i);
            agent.Move(gamepads[i].leftStick.ReadValue(), moveForce);
        }
    }
    
    // Handles local coop gamepad remapping / hotswapping (hopefully, anyways...)
    private struct LocalMultiplayerGamepadMapper<T> {
        private Dictionary<int, GamepadMapping> mappedGamepadIds;
        private T[] agents;
        private int generation;
        private struct GamepadMapping {
            public int gamepadIndex;
            public int generation;
            public T agent;

            public GamepadMapping(int index, int gen, T agent) {
                this.gamepadIndex = index;
                this.generation = gen;
                this.agent = agent;
            }
        }
        public LocalMultiplayerGamepadMapper(T[] agents) {
            this.agents = agents;
            this.generation = 0;
            this.mappedGamepadIds = new Dictionary<int, GamepadMapping>();
        }
        public void UpdateMappings(ReadOnlyArray<Gamepad> gamepads) {
            
        }
        public T GetAgentForGamepad(int gamepad) {
            
        }

        public void UpdateAndDispatchAllGamepadActions() {
            var gamepads = Gamepad.all;
            UpdateMappings(gamepads);
            for (int i = 0; i < gamepads.Count; ++i) {
                GetAgentForGamepad(i).
            }
        }
    }
}
