using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float move;
    private Animator anim;

    //tes Interact
    public Camera cam;
    public TextScript textScript;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>().x;
    }

    public void OnTap(InputAction.CallbackContext ctx)
    {
        if(ctx.started)
        {
            Vector2 screenPos = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector2 worldPos = cam.ScreenToWorldPoint(screenPos);
            Collider2D[] hits = Physics2D.OverlapPointAll(worldPos);

            if (textScript.isTalking)
            {
                textScript.TextAdvance();
                return;
            }

            foreach (Collider2D hit in hits)
            {
                NPCDialogues npc = hit.GetComponent<NPCDialogues>();

                if (npc != null)
                {
                    npc.StartDialogue();
                    break;
                }
            }
        }
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
