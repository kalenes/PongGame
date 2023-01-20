using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isPlayer1;
    public float moveSpeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
           rb.velocity= Vector2.up * Input.GetAxisRaw("Vertical") * moveSpeed;
        }
        else
        {
            rb.velocity= Vector2.up * Input.GetAxisRaw("Vertical2") * moveSpeed;
        }
    }
}
