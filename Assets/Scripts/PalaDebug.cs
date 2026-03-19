using UnityEngine;

public class PalaDebug : MonoBehaviour
{
    [SerializeField] Transform controllerTransform;
    private Rigidbody rb;
    private Vector3 lastPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(controllerTransform.position);
        rb.MoveRotation(controllerTransform.rotation);
    }
}
