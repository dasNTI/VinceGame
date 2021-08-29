using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Controls controls;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    private BackgroundScroll bgs;

    public float JumpForce;
    public float WalkSpeed;
    public bool WalkAvailable = true;
    public LayerMask lm;

    private void Awake()
    {
        controls = new Controls();

        controls.Player.Jump.performed += _ => Jump();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        bgs = GameObject.Find("ArrangmentBackground").GetComponent<BackgroundScroll>();
    }

    private void Update()
    {

        if (WalkAvailable) rb.velocity = new Vector2(controls.Player.SideDir.ReadValue<float>() * WalkSpeed, rb.velocity.y);
        if (TouchingGround() && controls.Player.SideDir.ReadValue<float>() == 0) transform.position += Vector3.left * bgs.Speed / 100 * 3.52f;

        if (controls.Player.SideDir.ReadValue<float>() != 0)
        {
            sr.flipX = controls.Player.SideDir.ReadValue<float>() < 0;
        }
    }

    private void Jump()
    {
        if (TouchingGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
    }

    private bool TouchingGround()
    {
        float length = 0.06f;
        float extrawidth = 1.0f;
        RaycastHit2D ray1 = Physics2D.Raycast(bc.bounds.center - new Vector3(-bc.bounds.extents.x * extrawidth, bc.bounds.extents.y, 0), Vector2.down, length, lm);
        RaycastHit2D ray2 = Physics2D.Raycast(bc.bounds.center - new Vector3(0, bc.bounds.extents.y, 0), Vector2.down, length, lm);
        RaycastHit2D ray3 = Physics2D.Raycast(bc.bounds.center - new Vector3(bc.bounds.extents.x * extrawidth, bc.bounds.extents.y, 0), Vector2.down, length, lm);

        return (ray1.collider != null || ray2.collider != null || ray3.collider != null);
    }
}
