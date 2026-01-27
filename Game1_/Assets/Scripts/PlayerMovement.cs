
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

/*references:
 https://learn.unity.com/course/2D-adventure-robot-repair/unit/game-environment-and-physics/tutorial/design-and-paint-your-game-tilemap?version=6.3
-for left and right movement

https://youtu.be/FO7auF7zXpU?si=7UI8rHodZFMC4DNJ
https://youtu.be/92DYkgBJBBo?si=OQK8xJwVJk-HmUNs
-for jump

https://learn.unity.com/course/roll-a-ball/tutorial/displaying-score-and-text?version=6.3
-for good and bad items, score

https://discussions.unity.com/t/how-to-freeze-and-unfreeze-my-game/311091
-pausing game
*/
public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;

    public InputAction JumpAction;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;
     public GameObject loseTextObject;
    private float jumpForce = 20;
    private Rigidbody2D rb;

    private int count;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveAction.Enable();
        JumpAction.Enable();
        count = 0;
        SetScoreText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 move = MoveAction.ReadValue<Vector2>();
        if (JumpAction.IsPressed() && GetIsGrounded())
        {
            Jump();
        }
        Vector2 position_ = (Vector2)transform.position + move * 0.2f;
        transform.position = position_;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("BadItem"))
        {
            other.gameObject.SetActive(false);
            loseTextObject.SetActive(true);
            Time.timeScale = 0;

        }
        else if (other.gameObject.CompareTag("GoodItem"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetScoreText();

        }
        

        
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + count.ToString();
        if (count >= 5)
        {
             winTextObject.SetActive(true);
        }
    }
    private bool GetIsGrounded(){
        return  Physics2D.Raycast(transform.position, Vector2.down, 0.6f, LayerMask.GetMask("Ground"));

    }

    



    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

    }
}
