using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringyDog : MonoBehaviour {
    public GameObject[]     heads;
    public GameObject segmentPrefab;
    public List<GameObject> segments;
    public int numSegments = 10;
    void Start() {
        // spawn body segements
        Rigidbody prev = heads[0].GetComponent<Rigidbody>();
        for (int i = 0; i < numSegments; ++i) {
            var t = (float)(i + 1) / (float) (numSegments + 1);
            var pos = Vector3.Slerp(heads[0].transform.position,
                heads[1].transform.position, t);
            var rot = Quaternion.Slerp(heads[0].transform.rotation,
                heads[1].transform.rotation, t);
            var go = GameObject.Instantiate(segmentPrefab, pos, rot);
            var rigidbody = go.AddComponent<Rigidbody>();
            var sf = go.AddComponent<SpringJoint>();
            sf.connectedBody = prev;
            prev = rigidbody;
            segments.Add(go);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
