using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public Transform background;
    public Transform playerTank;
    // Update is called once per frame
    void Update()
    {
        background.position = new Vector3(playerTank.position.x, playerTank.position.y, playerTank.position.z);

    }
}
