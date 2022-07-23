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
    private Vector2 inputDir;
    public float basesped;
    public float focusMultiplier = 0.15f;
    public ModifierList spedMods = new ModifierList();

    void Awake()
    {
        shooter = GetComponent<Shooter>();
        rb = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();
        bulletSpongeBox = transform.Find("PlayerBulletSponge").GetComponent<SpriteRenderer>();
    }

    void OnMove(InputValue movValue)
    {
        inputDir = movValue.Get<Vector2>();
    }

    // Update is called once every frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Z)) shooter.TryBoom();

        // inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if (Input.GetKeyDown(KeyCode.LeftShift)) StartFocusing();
        if (Input.GetKeyUp(KeyCode.LeftShift)) StopFocusing();
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
