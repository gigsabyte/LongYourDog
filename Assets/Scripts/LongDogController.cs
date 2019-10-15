using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        numGamepads = gamepads.Count;
        
        // update our gamepad <-> game agent mappings
        // (ie. if a controller is detected or removed; try to handle this semi-intelligently)
        controlMapper.UpdateMappings(gamepads);
        
        // fire off gamepad input from every active gamepad to every mapped player agent
        // does so by calling methods defined on IPlayerAgent, which are implemented
        // by LongDogPlayerController.
        for (var i = 0; i < gamepads.Count; ++i) {
            IPlayerAgent agent = controlMapper.GetAgentForGamepad(i);
            agent?.Move(gamepads[i].leftStick.ReadValue(), moveForce);
        }
    }
    
    // Handles local coop gamepad remapping / hotswapping (hopefully, anyways...)
    private struct LocalMultiplayerGamepadMapper<T> where T : IPlayerAgent {
        private AgentMapping[] agentMappings;
        private int generation;
        private struct AgentMapping {
            public T agent;
            public Gamepad gamepad;
            public int generation;
            public AgentMapping(T agent, Gamepad gamepad, int gen) {
                this.agent = agent;
                this.gamepad = gamepad;
                generation = gen;
            }
        }
        public LocalMultiplayerGamepadMapper(T[] agents) {
            agentMappings = new AgentMapping[agents.Length];
            for (int i = 0; i < agentMappings.Length; ++i) {
                agentMappings[i] = new AgentMapping(agents[i], null, 0);
            }
            this.generation = 0;
        }
        public void UpdateMappings(ReadOnlyArray<Gamepad> gamepads) {
            // add new gamepads (and fire detected event)
            generation += 1;

            // update generations of active gamepads + add new unmapped gamepads
            foreach (var gamepad in gamepads) {
                for (int i = agentMappings.Length; i-- > 0;) {
                    if (agentMappings[i].gamepad != null && agentMappings[i].gamepad.deviceId == gamepad.deviceId) {
                        agentMappings[i].generation = generation;
                        break;
                    }
                }
            }
            // remove old mappings
            for (int i = agentMappings.Length; i-- > 0;) {
                if (agentMappings[i].gamepad != null && agentMappings[i].generation != generation) {
                    agentMappings[i].agent.OnPlayerRemoved(agentMappings[i].gamepad);
                    agentMappings[i].gamepad = null;
                }
            }
            // add new mappings
            foreach (var gamepad in gamepads) {
                bool hasGamepad = false;
                foreach (var mapping in agentMappings) {
                    if (mapping.gamepad != null && mapping.gamepad.deviceId == gamepad.deviceId) {
                        hasGamepad = true;
                        break;
                    }
                }
                if (!hasGamepad) {
                    for (int i = 0; i < agentMappings.Length; ++i ) {
                        if (agentMappings[i].gamepad == null) {
                            agentMappings[i].gamepad = gamepad;
                            agentMappings[i].agent.OnPlayerAdded(agentMappings[i].gamepad);
                            break;
                        }
                    }
                }
            }
        }
        public T GetAgentForGamepad(int index) {
            return index >= 0 && index < agentMappings.Length ? agentMappings[index].agent : default(T);
        }
    }
}
