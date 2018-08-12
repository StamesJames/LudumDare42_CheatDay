using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomachManager : MonoBehaviour {

    #region public variables

    public float maxTime;
    public Vector2 detectionSize;
    public LayerMask whatIsFood;

    #endregion

    #region private variables

    private float currentTimer;
    private bool somethingInPipe;

    #endregion


    private void Update()
    {
        if (Physics2D.OverlapBox(transform.position, detectionSize, 0, whatIsFood) != null)
        {
            somethingInPipe = true;
        }
        else
        {
            somethingInPipe = false;
        }

        if (somethingInPipe)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer > maxTime)
            {
                GameManager.Instance.DieBecauseOfStomach();
            }
        }
        else
        {
            currentTimer = 0f;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(detectionSize.x, detectionSize.y, 1f));
    }

    private void LateUpdate()
    {
        somethingInPipe = false;
        
    }

}
