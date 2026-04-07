using FMODUnity;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MagnusEffect : MonoBehaviour
{
    public float radius = 0.5f;
    public float airDensity = 0.1f;

    private Rigidbody rb;
    [SerializeField] StudioEventEmitter boardEmitter;
    [SerializeField] StudioEventEmitter PalaEmitter;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var direction = Vector3.Cross(rb.angularVelocity, rb.linearVelocity);
        var magnitude = 4 / 3f * Mathf.PI * airDensity * Mathf.Pow(radius, 3);
        rb.AddForce(magnitude * direction);
        if (rb.IsSleeping()) Debug.Log("Sleeping");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Board")
        {
            boardEmitter.Play();
        }

        if (collision.gameObject.tag == "Pala")
        {
            PalaEmitter.Play();
        }
        
    }

}