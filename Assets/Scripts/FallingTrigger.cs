using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour{
    [SerializeField] private Rigidbody player;
    [SerializeField] private Transform respawnPoint;

    private Rigidbody ball;
    private bool steppedon = false;

    // Start is called before the first frame update
    void Start(){
        ball = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            steppedon = true;
            ball.useGravity = true;
            ball.isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name == "Player") {
            StartCoroutine(Respawn());       
        }
    }

    IEnumerator Respawn() {
        Debug.Log("STOP!!");
        player.velocity = Vector3.zero;
        //player.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(1);
        player.transform.position = respawnPoint.transform.position;
        player.velocity = Vector3.zero;

    }
}
