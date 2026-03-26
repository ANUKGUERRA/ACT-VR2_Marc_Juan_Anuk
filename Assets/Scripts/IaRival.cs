using UnityEngine;

public class IaRival : MonoBehaviour
{
    [SerializeField] GameObject manoRival;
    public void iaDeflect(Vector3 ballPosition, Vector3 ballDirection, Rigidbody rb)
    {
        Vector3 intersectionPoint;
        //intersectionPoint = Vector3.Dot(ballPosition, rb.angularVelocity);
    }
}
