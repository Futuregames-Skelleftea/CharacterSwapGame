using UnityEngine;
using UnityEngine.InputSystem;

public class DwarfCharacter : Character
{
    public float dwarfMoveSpeed = 3f;
    public float dwarfJumpForce = 12f;
    public float groundPoundForce = 15f;
    public float groundPoundDuration = 0.5f;
    private bool isGroundPounding = false;

    public override void Update()
    {
        base.Update();

        if (Keyboard.current.leftCtrlKey.wasPressedThisFrame)
        {
            ActivateGroundPound();
        }
        if (!isGroundPounding)
        {
            //float moveInput = moveRightAction.ReadValue<float>() - moveLeftAction.ReadValue<float>();
            rb.velocity = new Vector3(moveInput * dwarfMoveSpeed, rb.velocity.y, 0f);

            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0f, dwarfJumpForce, 0f), ForceMode.Impulse);
            }
        }
    }

    public void ActivateGroundPound()
    {
        if (!isGroundPounding)
        {
            isGroundPounding = true;
            rb.AddForce(new Vector3(0f, -groundPoundForce, 0f), ForceMode.Impulse);
            Invoke(nameof(DeactivateGroundPound), groundPoundDuration);
            Debug.Log("Dwarf character is ground pounding.");
        }
    }

    private void DeactivateGroundPound()
    {
        isGroundPounding = false;
        Debug.Log("Dwarf character is done ground pounding.");
    }

    public override void AbilityButton()
    {
        ActivateGroundPound();
        Debug.Log("Groundpound");
    }
}