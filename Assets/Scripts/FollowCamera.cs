using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FollowCamera : MonoBehaviour {
    public Transform target;

    public float minFollowDist = 1.0f;
    public float maxFollowDist = 3.0f;
    public float followFactor = 0.1f;

    public float targetHeight = 4.0f;

    public float debugCurrentDist = 0f;

    public bool debugMovingAway = false;

    public bool debugMovingTowards = false;

    public Vector3 debugTargetPos = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        if (target) {
            transform.LookAt(target, Vector3.up);
            var offset = Vector3.up * targetHeight + target.rotation * Vector3.back * minFollowDist;
            var targetPos = target.position + offset;
            var dist = Vector3.Distance(transform.position, target.position);
            debugCurrentDist = dist;
            debugMovingAway = false;
            debugMovingTowards = false;
            debugTargetPos = targetPos;
            if (dist > maxFollowDist) {
                debugMovingTowards = true;
                // move towards target
                transform.position = Vector3.Lerp(transform.position, targetPos,
                    Mathf.Clamp(followFactor * Time.deltaTime, 0f, 1f));
            } else if (dist < minFollowDist) {
                debugMovingAway = true;
                // move away from target
                transform.position = Vector3.Lerp(transform.position,
                    transform.position + (targetPos - transform.position) * 2f,
                    Mathf.Clamp(followFactor * Time.deltaTime, 0f, 1f));
            }
        }
    }
}
