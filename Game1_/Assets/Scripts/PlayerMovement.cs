
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/*references:
 https://learn.unity.com/course/2D-adventure-robot-repair/unit/game-environment-and-physics/tutorial/design-and-paint-your-game-tilemap?version=6.3
-for left and right movement

https://youtu.be/FO7auF7zXpU?si=7UI8rHodZFMC4DNJ
https://youtu.be/92DYkgBJBBo?si=OQK8xJwVJk-HmUNs
-for jump


*/
public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;

    public InputAction JumpAction;
    private float jumpForce = 3;
    private Rigidbody2D rb;

    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveAction.Enable();
        JumpAction.Enable();


    }

    // Update is called once per frame
    void Update()
    {
    

        Vector2 move = MoveAction.ReadValue<Vector2>();
        if (JumpAction.IsInProgress() && GetIsGrounded())
        {
            Jump();
        }
        Vector2 position_ = (Vector2)transform.position + move * 0.01f;
        transform.position = position_;
    }

    private bool GetIsGrounded(){
        return  Physics2D.Raycast(transform.position, Vector2.down, 1.5f, LayerMask.GetMask("Ground"));

    }

    



    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);

    }
}
