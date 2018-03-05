using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z-1);
    }
}
