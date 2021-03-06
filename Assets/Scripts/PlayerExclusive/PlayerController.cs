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
    private ShootersController shootersController;
        // Movement
    [Space]
    [Header("Movement")]
    private Houtou controls; // i have been controlled by an alien
    private Vector2 inputDir;
    public float basesped;
    public float focusMultiplier = 0.15f;
    public ModifierList spedMods = new ModifierList();

    void Awake()
    {
        // Component references
        shootersController = GetComponent<ShootersController>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        controls = new Houtou();

        // TODO Find a better way to do this 
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

    // Control functions, these are called only upon input state changes, NOT continuously!
    public void OnMove(InputAction.CallbackContext ctx)
    {
        inputDir = ctx.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValueAsButton()) shootersController.StartBoomingAll();
        else shootersController.StopBoomingAll();
    }

    public void OnFocus(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValueAsButton()) StartFocusing();
        else StopFocusing();
    }

    public void OnBomb(InputAction.CallbackContext ctx)
    {
        Debug.LogWarning("Bombs not implemented.");
    }

    // Update is called once every frame
    void Update()
    {

    }

    // FixedUpdate is called with physics updates every 0.02 seconds
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputDir * Time.deltaTime * (basesped * spedMods.Get()));
    }

    // Focus functions
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
