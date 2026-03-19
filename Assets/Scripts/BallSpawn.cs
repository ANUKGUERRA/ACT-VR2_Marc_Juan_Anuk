using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] InputAction action;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform controllerTransform;

    GameObject ball;
    Rigidbody rb;

    private bool ballInHand = false;

    private void OnEnable()
    {
        action.Enable();

        action.started += OnTriggerPressed;
        action.canceled += OnTriggerReleased;   
    }

    private void OnDisable()
    {
        action.performed -= OnTriggerPressed;
        action.canceled -= OnTriggerReleased;

        action.Disable();
    }

    private void Update()
    {
        if (ballInHand)
        {
            rb.MovePosition(controllerTransform.position);
            rb.MoveRotation(controllerTransform.rotation);
            Debug.Log(rb.linearVelocity);
        }
    }

    private void OnTriggerPressed(InputAction.CallbackContext ctx)
    {
        ballInHand = true;
        ball = Instantiate(ballPrefab);
        rb = ball.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    private void OnTriggerReleased(InputAction.CallbackContext ctx)
    {
        ballInHand = false;
        rb.useGravity = true;
        rb.isKinematic = false;
    }
}
