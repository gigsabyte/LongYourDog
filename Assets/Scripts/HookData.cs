using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookData : MonoBehaviour
{
	public float radius = 3.0f;
	public enum RotationAxis { X_axis, Z_axis };
	public RotationAxis rotationAxis = RotationAxis.X_axis;
	public Vector3 hookAxis;
    void Start()
    {
    	GetComponent<Transform>().localScale = new Vector3(radius,radius,radius);
        switch (rotationAxis)
        {
        	case RotationAxis.X_axis:
        		hookAxis = Vector3.right;
        		break;
        	case RotationAxis.Z_axis:
        		hookAxis = Vector3.forward;
        		break;
        }
    }
}
