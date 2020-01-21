using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(0, 1, 0);
        transform.position = player.position + offset;
    }
}