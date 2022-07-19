using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 inputDir;

    //Publics
    public float basesped;
    public float focusMultiplier;
    public ModifierList spedMods;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spedMods = new ModifierList();
    }

    // Update is called once every frame
    void Update()
    {
        inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.LeftShift)) spedMods.SetMod(focusMultiplier, "FocusMod");
        if (Input.GetKeyUp(KeyCode.LeftShift)) spedMods.RemoveMod("FocusMod");
    }

    // FixedUpdate is called once every 0.02 seconds
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputDir * Time.deltaTime * (basesped * spedMods.Get()));
    }
}