using UnityEngine;
using UnityEngine.InputSystem;
public class HumanCharacter : Character
{
    public float humanMoveSpeed = 6f;
    public float humanJumpForce = 8f;
    public float dashSpeed = 50f;
    public float dashDuration = 0.5f;
    private bool isDashing = false;

    public override void Update()
    {
        base.Update();

        if (Keyboard.current.leftAltKey.wasPressedThisFrame)
        {
            ActivateDash();
        }
        if (!isDashing)
        {
            //float moveInput = moveRightAction.ReadValue<float>() - moveLeftAction.ReadValue<float>();
            rb.velocity = new Vector3(moveInput * humanMoveSpeed, rb.velocity.y, 0f);

            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0f, humanJumpForce, 0f), ForceMode.Impulse);
            }
        }
    }

    public void ActivateDash()
    {
        if (!isDashing)
        {
            isDashing = true;
            float dashDirection = Mathf.Sign(Input.GetAxis("Horizontal"));
            rb.velocity = new Vector3(dashDirection * dashSpeed, rb.velocity.y, 0f);
            Invoke(nameof(DeactivateDash), dashDuration);
            Debug.Log("Human character is dashing.");
        }
    }
    private void DeactivateDash()
    {
        isDashing = false;
        Debug.Log("Human character is done dashing.");
    }

    public override void AbilityButton()
    {
        ActivateDash();
    }
}


