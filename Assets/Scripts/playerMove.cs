using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    private CircleCollider2D coll;
    private Rigidbody2D rb;
    public float basesped;
    private float sped;

    void Start() {
        sped = basesped;
    }
    void Awake()
    {
        coll = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir;

        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift)) sped = basesped*0.5f;
        if (Input.GetKeyUp(KeyCode.LeftShift)) sped = basesped;

        rb.MovePosition(rb.position + dir * sped * Time.deltaTime);
    }
}
