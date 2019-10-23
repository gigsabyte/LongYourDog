using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour{
    [SerializeField] private Rigidbody player;
    [SerializeField] private Transform respawnPoint;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") StartCoroutine(Respawn());
    }

    IEnumerator Respawn() {
        player.velocity = Vector3.zero;
        yield return new WaitForSeconds(1);
        player.transform.position = respawnPoint.transform.position;
    }
}

