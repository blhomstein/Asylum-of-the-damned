using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    //  move or run
    [SerializeField]private float speed = 2000f;
    [SerializeField] private float run = 3000f;
    // stamina for running
    private float staminaConsumptionRate = 0.1f;
    private float staminaRegenRate = 0.05f;
    private float maxStamina = 50f;
    private float stamina;
    private bool isRunning = false;


    private Rigidbody2D rb;
    private Vector2 moveDir;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stamina = maxStamina;
        
    }

    
    private void FixedUpdate()
    {
        if (Keyboard.current.leftShiftKey.isPressed && stamina > 0)
        {
            isRunning = true;
            stamina -= staminaConsumptionRate;
            
        }
        else {
            isRunning = false;
            stamina = Mathf.Clamp(stamina + staminaRegenRate, 0, maxStamina);
        }
        rb.AddForce(moveDir * (isRunning ? run : speed) * Time.fixedDeltaTime, ForceMode2D.Force);
    }
    private void Turning()
    {
        Quaternion newRotation = Quaternion.LookRotation(moveDir);
        rb.MoveRotation(newRotation);
    }
    void OnMove(InputValue value) {
        moveDir = value.Get<Vector2>();
    }
    
}
