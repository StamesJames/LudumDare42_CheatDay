using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomachMover : MonoBehaviour {

    #region public variables

    public Transform mainCamera;
    public PlayerController player;
    public Vector3 stomachMenuOffset;

    #endregion

    #region private variables


    #endregion


    private void Update()
    {
        if (player.stomachMenuActive)
        {
            transform.position = mainCamera.transform.position + stomachMenuOffset;
        }
        else
        {
            transform.position = mainCamera.transform.position + new Vector3(100, 100, 10);    
        }
    }


}
