using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsciencePointer : MonoBehaviour {

    public Transform pointerPosition;

    private GameObject player;

    private GameObject Conscience;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Conscience != null)
        {
            transform.rotation = Quaternion.Euler(0, 0, - Vector2.SignedAngle(Conscience.transform.position - player.transform.position  , Vector2.right ));
        }
        else
        {

            Conscience = GameObject.FindGameObjectWithTag("Conscience");
        }

        transform.position = pointerPosition.position;
    }



}
