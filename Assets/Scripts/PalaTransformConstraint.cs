using UnityEngine;

public class PalaTransformConstraint : MonoBehaviour
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

    public Transform GetControllerTransform()
    {
        return controllerTransform;
    }

}
