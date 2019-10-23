using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour{
    public GameObject text;
    // Start is called before the first frame update
    void Start(){
        text.SetActive(false); 
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            text.SetActive(true);
            StartCoroutine("Wait_for_sec");
        }
    }

    IEnumerator Wait_for_sec() {
        yield return new WaitForSeconds(28);
        Destroy(text);
    }
}
