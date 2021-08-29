using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float Speed;

    private float dir;
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.sharedMaterial.SetTextureOffset("_MainTex", sr.sharedMaterial.GetTextureOffset("_MainTex") + Vector2.right * Speed / 100f);
    }

}
