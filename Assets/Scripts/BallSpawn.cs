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

    private Vector3 lastPosition;
    private Vector3 velocity;

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

            // calcular velocidad manual
            velocity = (controllerTransform.position - lastPosition) / Time.deltaTime;
            lastPosition = controllerTransform.position;
        }
    }

    private void OnTriggerPressed(InputAction.CallbackContext ctx)
    {
        ballInHand = true;
        ball = Instantiate(ballPrefab);
        rb = ball.GetComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = true;

        lastPosition = controllerTransform.position;
    }

    private void OnTriggerReleased(InputAction.CallbackContext ctx)
    {
        ballInHand = false;

        rb.isKinematic = false;
        rb.useGravity = true;

        rb.linearVelocity = velocity;
    }
}
