using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangementCameraMovement : MonoBehaviour
{
    public GameObject follow;
    public float max;
    public float min;
    public float Speed = 150;

    // Update is called once per frame
    void Update()
    {
        //float xdif = follow.transform.position.x - transform.position.x;
        //float ydif = Mathf.Clamp(follow.transform.position.y, min, max) - transform.position.y;

        Vector3 

        transform.position = Vector3.Lerp(
            transform.position,
            follow.transform.position,
            1 / 7f
        );

    }
}
