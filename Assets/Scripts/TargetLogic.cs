using System;
using UnityEngine;

public class TargetLogic : MonoBehaviour
{
    public static event Action OnTargetHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere(Clone)")
        {
            Debug.Log("targetHit");

            OnTargetHit?.Invoke();

            SpawnDiana();
        }
    }

    public void SpawnDiana()
    {
        transform.localPosition =
            new Vector3(
                UnityEngine.Random.Range(TargetBounds.Instance.min.x, TargetBounds.Instance.max.x),
                UnityEngine.Random.Range(TargetBounds.Instance.min.y, TargetBounds.Instance.max.y),
                UnityEngine.Random.Range(TargetBounds.Instance.min.z, TargetBounds.Instance.max.z));
    }
}