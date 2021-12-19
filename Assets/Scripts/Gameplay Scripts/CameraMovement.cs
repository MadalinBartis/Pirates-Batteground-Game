using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private Transform playerTarget;

    [SerializeField]
    private float smoothSpeed = 2f;

    [SerializeField]
    private float playerBoundMin_Y = -1f, playerBoundMin_X = -65f, playerBoundMax_X = 65f;

    [SerializeField]
    private float Y_Gap = 2f;

    private Vector3 tempPos;

    void Start()
    {
        playerTarget = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    void Update()
    {
        if (!playerTarget)
            return;
        tempPos = transform.position;

        if(playerTarget.position.y <= playerBoundMin_Y)
        {
            tempPos = Vector3.Lerp(transform.position, new Vector3(playerTarget.position.x, playerTarget.position.y, -10f), Time.deltaTime * smoothSpeed);
        }
        else
        {
            tempPos = Vector3.Lerp(transform.position, new Vector3(playerTarget.position.x, playerTarget.position.y + Y_Gap, -10f), Time.deltaTime * smoothSpeed);
        }

        if (tempPos.x > playerBoundMax_X)
            tempPos.x = playerBoundMax_X;

        if (tempPos.x < playerBoundMin_X)
            tempPos.x = playerBoundMin_X;

        transform.position = tempPos;
    }
}
