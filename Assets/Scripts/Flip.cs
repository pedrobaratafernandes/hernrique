using UnityEngine;

public class Flip : MonoBehaviour
{
    private bool facingRight = false;

    public bool IsFacingRight => facingRight;

    public void FlipCharacter()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
