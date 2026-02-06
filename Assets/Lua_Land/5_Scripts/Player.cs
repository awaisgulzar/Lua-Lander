using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidBody;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
     
    private void FixedUpdate()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard.upArrowKey.isPressed)
        {
            float moveSpeed = 650f;
            rigidBody.AddForce(transform.up * moveSpeed * Time.deltaTime);
        }
         
        if (keyboard.leftArrowKey.isPressed)
        {
            float turnSpeed = +100f;
            rigidBody.AddTorque(turnSpeed * Time.deltaTime);

        }
        if (keyboard.rightArrowKey.isPressed)
        {
            float turnSpeed = -100f;
            rigidBody.AddTorque( turnSpeed * Time.deltaTime);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        float softLandingMagnitude = 4f;

        if (collision2D.relativeVelocity.magnitude > softLandingMagnitude)
        {
            //Lander too hard
            Debug.Log("Landed too hard");
            return;
        }

        float dotVector = Vector2.Dot(Vector2.up , transform.up);
        float minDotVector = .90f;
        if (dotVector < minDotVector)
        {
            //Landed on a steep Angle!
            Debug.Log("Landed on a steep angle!");
            return;
        }
        Debug.Log(dotVector);
        Debug.Log("Successfully landed");
    }
}
