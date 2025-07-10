using System.Collections;
using UnityEngine;

public class PlayerParrot : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float acceleration = 0.2f;
    public float maxSpeed = 10f;
    private float currentSpeed;
    public float JumpForce;
    private Rigidbody2D rig;
    private Animator anim;

    private bool canFly = false;
    private float originalGravityScale;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentSpeed = baseSpeed;

        originalGravityScale = rig.gravityScale;
        rig.gravityScale = 0f;

        // Ativa a animação de cutscene
        anim.SetBool("cutscene", true);

        StartCoroutine(CutsceneBeforeFlying(3f));
    }

    void Update()
    {
        if (!PlayerStatus.playerDestroyed)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

            move();

            if (canFly)
                fly();
        }
    }

    void move()
    {
        Vector3 movement = new Vector3(1f, 0f, 0f);
        transform.position += movement * Time.deltaTime * currentSpeed;
    }

    void fly()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            anim.SetBool("jumpAve", true);
        }
        if (rig.velocity.y <= 0)
        {
            anim.SetBool("jumpAve", false);
        }
    }

    IEnumerator CutsceneBeforeFlying(float delay)
    {
        yield return new WaitForSeconds(delay);

        rig.gravityScale = originalGravityScale;
        canFly = true;

        // Desativa a cutscene e volta pra idle
        anim.SetBool("cutscene", false);
    }
}
