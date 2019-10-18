using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpringyDog : MonoBehaviour {
    public GameObject[]     heads;
    public GameObject segmentPrefab;
    public List<GameObject> segments;
    public int numSegments = 10;
    public float springForce = 100.0f;
    public float springDamp = 0.2f;
    public bool spawnSprings = true;
    
    
    private void addSpring(GameObject obj, Rigidbody target) {
        var sf = obj.AddComponent<SpringJoint>();
        sf.connectedBody = target;
        sf.spring = springForce;
        sf.damper = springDamp;
//        sf.minDistance = 2.0f;
    }

    private void SpawnSprings() {
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
    void Start() {
        if (spawnSprings) SpawnSprings();
    }
    
    private int firstPlayerIndex = 0;
    public float playerMoveForce = 100.0f;
    public float playerMoveSpeed = 10.0f;

    void applyPlayerInputs() {
//        Debug.Log(""+Gamepad.all.Count+" gamepad(s) connected");
        
        applyPlayerInput(heads[firstPlayerIndex % heads.Length], 
            new Vector2(Keyboard.current.dKey.ReadValue() - Keyboard.current.aKey.ReadValue(),
                Keyboard.current.wKey.ReadValue() - Keyboard.current.sKey.ReadValue()));
        
        for (int i = 0; i < Gamepad.all.Count; ++i) {
            int j = (firstPlayerIndex + i) % heads.Length;
            applyPlayerInput(heads[j], Gamepad.all[i].leftStick.ReadValue());
        }
    }
    void applyPlayerInput(GameObject target, Vector2 input) {
        if (input.magnitude == 0) return;
        Debug.Log("updating " + target + " with input " + input);
        var r = target.GetComponent<Rigidbody>();
        var moveVector = new Vector3(input.x, 0.0f, input.y);
//        target.transform.Translate(moveVector * Time.deltaTime * playerMoveSpeed);
        r.AddRelativeForce(moveVector * playerMoveForce * Time.deltaTime,
            ForceMode.Acceleration
        );
    }
    // Update is called once per frame
    void Update()
    {
        applyPlayerInputs();   
    }
}
