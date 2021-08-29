using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipMovement : MonoBehaviour
{
    private BackgroundScroll bgs;

    private float m = 3.52f;

    void Start()
    {
        bgs = GameObject.Find("ArrangmentBackground").GetComponent<BackgroundScroll>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * bgs.Speed / 100 * m;
    }
}
