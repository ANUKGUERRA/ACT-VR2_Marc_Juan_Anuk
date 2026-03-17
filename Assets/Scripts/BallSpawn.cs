using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] InputAction action;
    [SerializeField] GameObject ballPrefab;
    GameObject ball;

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

    private void OnTriggerPressed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Ball spawn");
        ball = Instantiate(ballPrefab, spawnPoint);
        ball.GetComponent<Rigidbody>().useGravity = false;
    }

    private void OnTriggerReleased(InputAction.CallbackContext ctx)
    {
        Debug.Log("Ball drop");
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball.transform.SetParent(null);
    }
}
