using UnityEngine;

public class movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingpower = 16f;
    private bool isfacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundlayer;

   

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("horizontal");
        if(Input.GetButtonDown("Jump") && IsGrounded())
            {
            rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
            }
        if(Input.GetButtonUp("Jump") && rb.velocity.y >0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed,rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position,0.2f,groundlayer);
    }
    private void flip()
    {
        if(isfacingRight && horizontal < 0f || isfacingRight && horizontal > 0f)
        {
            isfacingRight = !isfacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
