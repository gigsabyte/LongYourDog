using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{

    void OnMove(InputValue value) {
        Debug.Log("got movement!"+value+": "+value.Get<Vector2>());
        var input = value.Get<Vector2>();
        transform.Translate(new Vector3(
            input.x, 0.0f, input.y
           ) * Time.deltaTime * 2.0f);
    }

    void OnDeviceLost() {
        Debug.Log("device lost!");
    }

    void OnDeviceRegained() {
        Debug.Log("device regained!");
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
