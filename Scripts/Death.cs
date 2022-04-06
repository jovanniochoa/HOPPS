using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject player;
    public Transform destination;
    void Update()
    {
        {
            if (player.transform.position.y < -5)
            {
                this.player.transform.position = new Vector3(-3, 1, 0);
            }
        }
    }
}