
using UnityEngine;
using UnityEngine.InputSystem;

// Describes all input actions that eg. LongDogPlayerController can respond to
public interface IPlayerAgent {
    void Move(Vector2 direction, float moveForce);
    void OnPlayerAdded(Gamepad gamepad);
    void OnPlayerRemoved(Gamepad gamepad);
}
