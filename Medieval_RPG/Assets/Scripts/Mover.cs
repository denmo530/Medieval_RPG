using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected RaycastHit2D hit;
    public float ySpeed = 0.75f;
    public float xSpeed = 1.0f;
    private Vector3 originalSize;
    //[SerializeField] private AudioSource walkingSoundEffect;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        originalSize = transform.localScale;
        boxCollider = GetComponent<BoxCollider2D>();
        //animator = GetComponent<Animator>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {

        // Reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        // Swap sprite direction when going right or left
        if (moveDelta.x > 0)
        {
            transform.localScale = originalSize;
            //walkingSoundEffect.Play();
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(originalSize.x * -1, originalSize.y, originalSize.z);
            //walkingSoundEffect.Play();
        }

        // Add push vector, if there is one
        moveDelta += pushDirection;

        // Reduce pushforce every frame, based of recovery speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);



        //make sure we can move in this direction, by casting a box there first, if the box returns null we are free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        //make sure we can move in this direction, by casting a box there first, if the box returns null we are free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);

        }
        // Make the player move 
        //transform.Translate(moveDelta * Time.deltaTime);
        //print(hit.collider);

    }
}
