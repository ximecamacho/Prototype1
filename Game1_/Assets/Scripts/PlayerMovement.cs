using UnityEngine;
using UnityEngine.InputSystem;

/*referenced https://learn.unity.com/course/2D-adventure-robot-repair/unit/game-environment-and-physics/tutorial/design-and-paint-your-game-tilemap?version=6.3
for left and right movement

*/
public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
    
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector2 move = MoveAction.ReadValue<Vector2>();
      
      
       Debug.Log(move);
      
       Vector2 position = (Vector2)transform.position + move  * 0.01f;

       
       transform.position = position; 
        
    }
}
