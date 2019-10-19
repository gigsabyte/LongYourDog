using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawn_point;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnTriggerEnter(Collider other) {
        player.transform.position = respawn_point.transform.position;
    }
}
