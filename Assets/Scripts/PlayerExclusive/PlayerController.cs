using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // SKY: Instead of just an interface, we'll put anything that ONLY the player would need in here, including but not limited to controls.

    // Privates
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private SpriteRenderer bulletSpongeBox;
        // Shooting
    private Shooter shooter;
        // Movement
    [Space]
    [Header("Movement")]
    private Houtou controls;
    private Vector2 inputDir;
    public float basesped;
    public float focusMultiplier = 0.15f;
    public ModifierList spedMods = new ModifierList();

    void Awake()
    {
        shooter = GetComponent<Shooter>();
        rb = GetComponent<Rigidbody2D>();
        controls = new Houtou();

        sprite = GetComponent<SpriteRenderer>();
        bulletSpongeBox = transform.Find("PlayerBulletSponge").GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {    
        controls.Player.Disable();
    }

    // void OnMove(InputValue movValue)
    // {
    //     inputDir = movValue.Get<Vector2>();
    // }

    // void OnFocus() {
    //     StartFocusing();
    // }

    // Update is called once every frame
    void Update()
    {
        controls.Player.Move.performed += ctx => inputDir = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => inputDir = Vector2.zero;

        controls.Player.Fire.performed += ctx => shooter.StartBooming();
        controls.Player.Fire.canceled += ctx => shooter.StopBooming();

        controls.Player.Focus.performed += ctx => StartFocusing();
        controls.Player.Focus.canceled += ctx => StopFocusing();
    }

    // FixedUpdate is called once every 0.02 seconds
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputDir * Time.deltaTime * (basesped * spedMods.Get()));
    }

    void StartFocusing()
    {
        sprite.color = new Color32(255, 177, 245, 127);
        bulletSpongeBox.color = new Color32(255, 255, 255, 255);
        spedMods.SetMod(focusMultiplier, "FocusMod");
    }

    void StopFocusing()
    {
        sprite.color = new Color32(255, 177, 245, 255);
        bulletSpongeBox.color = new Color32(255, 255, 255, 0);
        spedMods.RemoveMod("FocusMod");
    }
}
