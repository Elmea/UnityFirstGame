using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Animator))]
public class MoveAnim : MonoBehaviour
{
    Animator controller;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<Animator>();
    }

    public void animRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            controller.SetFloat("Speed", 10f);
        }

        if (context.canceled)
            controller.SetFloat("Speed", 0f);
    }

    public void animLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            controller.SetFloat("Speed", 10f);
        }

        if (context.canceled)
            controller.SetFloat("Speed", 0f);
    }

    public void animJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            controller.SetBool("Jump", true);
            timer = 0.5f;
        }
        
        if (context.canceled)
        {
            controller.SetBool("Jump", false);
        }
    }

    public void animGodMode(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            controller.SetBool("GMode", true);
            timer = 3f;
        }
    }

    private void Update()
    {
        if (controller.GetBool("Jump"))
        {
            timer -= Time.deltaTime;
            if (timer < 0)
                controller.SetBool("Jump", false);
        }

        if (controller.GetBool("GMode"))
        {
            timer -= Time.deltaTime;
            if (timer < 0)
                controller.SetBool("GMode", false);
        }

        if (PlayerInfo.reachEnd)
        {
            controller.SetBool("Win", true);
        }
    }
}
