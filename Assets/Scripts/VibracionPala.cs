using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class VibracionPala : MonoBehaviour
{
    [Range(0, 1)] public float intensidad = 0.5f;
    public float duracion = 0.1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pelota"))
        {
            PalaTransformConstraint constraint = GetComponent<PalaTransformConstraint>();

            if (constraint != null && constraint.GetControllerTransform() != null)
            {
                constraint.GetControllerTransform().GetComponent<HapticImpulsePlayer>().SendHapticImpulse(intensidad, duracion);
            }

        }
    }
}


//Buscar ref a PalaTransformContraint sobre el collider
//Sacar ref de PalaTransformConstraint.controllerTransform.
//Sacar ref de XRBaseInteractor de PalaTransformConstraint.controllerTransform
//Llamar a SendHapticImpulse del HapticImpulsePlayer del XRBaseInteractor 