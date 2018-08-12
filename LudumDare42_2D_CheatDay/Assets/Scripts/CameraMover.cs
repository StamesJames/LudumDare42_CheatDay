using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    public GameObject player;
    private Vector3 cameraOffset;

	// Use this for initialization
	void Start () {
        cameraOffset = new Vector3(0,0,-10);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + cameraOffset;
	}
}
