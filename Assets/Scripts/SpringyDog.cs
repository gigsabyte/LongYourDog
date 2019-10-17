using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringyDog : MonoBehaviour {
    public GameObject[]     heads;
    public GameObject segmentPrefab;
    public List<GameObject> segments;
    public int numSegments = 10;
    public float springForce = 100.0f;
    public float springDamp = 0.2f;

    private void addSpring(GameObject obj, Rigidbody target) {
        var sf = obj.AddComponent<SpringJoint>();
        sf.connectedBody = target;
        sf.spring = springForce;
        sf.damper = springDamp;
    }
    void Start() {
        // spawn body segements + add springs
        Rigidbody prev = heads[0].GetComponent<Rigidbody>();
        for (int i = 0; i < numSegments; ++i) {
            var t = (float)(i + 1) / (float) (numSegments + 1);
            var pos = Vector3.Slerp(heads[0].transform.position,
                heads[1].transform.position, t);
            var rot = Quaternion.Slerp(heads[0].transform.rotation,
                heads[1].transform.rotation, t);
            var obj = GameObject.Instantiate(segmentPrefab, pos, rot);
            var rigidbody = obj.AddComponent<Rigidbody>();
            rigidbody.freezeRotation = true;
            addSpring(obj, prev);
            prev = rigidbody;
            segments.Add(obj);
        }
        addSpring(heads[1], prev);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
