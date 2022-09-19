using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public float speed, rotationSpeed, jumpPower, cd = 5.0f;
    public Rigidbody rb;
    bool isGrounded = true;
    public Animator animator;
    public Transform cam;
    public AudioClip deathSound;

    public static bool isGameOver = false;
    public bool audioPlayed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");


          transform.Translate(Vector3.forward * Time.deltaTime * speed * vertical);
          transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * horizontal * Mathf.Sign(vertical));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGrounded = false;
            animator.SetTrigger("jump");

        }

        if (Mathf.Abs(vertical) > 0 )
            animator.SetBool("run", true);
        else
            animator.SetBool("run", false);

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            isGameOver = true;
            animator.SetTrigger("death");
            if (!audioPlayed)
            {
                audioPlayed = true;
                SoundManager.instance.PlaySound(deathSound);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "portal")
            transform.position = new Vector3(65f, 4f, -15f);

        if (other.gameObject.tag == "portal2")
            transform.position = new Vector3(-50f, 4f, -15f);

    }

    private void Death()
    {
        while (!isGrounded)
        {
            cd -= Time.time;
            if (cd <= 0)
                isGameOver = true;
        }
    }


}
