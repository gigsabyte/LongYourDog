
using UnityEngine;

// Describes all input actions that eg. LongDogPlayerController can respond to
public interface IPlayerAgent {
    void Move(Vector2 direction, float moveForce);
}
