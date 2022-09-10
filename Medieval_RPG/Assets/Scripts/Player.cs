using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private BoxCollider2D boxCollider; 
    private Vector3 moveDelta; 

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>(); 
    }

    // FixedUpdate follow the same frame as the physic 
    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal"); 
        float y = Input.GetAxisRaw("Vertical"); 
        // Reset moveDelta
        moveDelta = new Vector3(x, y, 0); 

        // Swap sprite direction when going right or left
        if (moveDelta.x > 0) {
            transform.localScale = Vector3.one; 
        }else if (moveDelta.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1); 
        }

        // Make the player move 
        transform.Translate(moveDelta * Time.deltaTime); 

    }
}
