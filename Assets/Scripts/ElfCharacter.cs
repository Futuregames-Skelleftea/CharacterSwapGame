using UnityEngine;
using UnityEngine.InputSystem;

public class ElfCharacter : Character
{
    public float elfMoveSpeed = 8f;
    public float elfJumpForce = 5f;
    public float stealthDuration = 2f;
    private bool isStealthMode = false;

    public override void Update()
    {
        base.Update();

        if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
        {
            ActivateStealth();
        }
        if (!isStealthMode)
        {
            //float moveInput = moveRightAction.ReadValue<float>() - moveLeftAction.ReadValue<float>();
            rb.velocity = new Vector3(moveInput * elfMoveSpeed, rb.velocity.y, 0f);

            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0f, elfJumpForce, 0f), ForceMode.Impulse);
            }
        }
    }

    public void ActivateStealth()
    {
        if (!isStealthMode)
        {
            isStealthMode = true;
            GetComponent<MeshRenderer>().enabled = false;
            Invoke(nameof(DeactivateStealth), stealthDuration);
            Debug.Log("Elf character is in stealth mode.");
        }
    }

    private void DeactivateStealth()
    {
        isStealthMode = false;
        GetComponent<MeshRenderer>().enabled = true;
        Debug.Log("Elf character is out of stealth mode.");
    }

    public override void AbilityButton()
    {
        ActivateStealth();
    }
}


