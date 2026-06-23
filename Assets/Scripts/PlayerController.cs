using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float move;
    private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
        anim.SetFloat("Speed", Mathf.Abs(move));

        if (move > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
      

    }
}
