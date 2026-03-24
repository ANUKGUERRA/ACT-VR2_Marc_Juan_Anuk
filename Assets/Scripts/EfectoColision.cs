using UnityEngine;

public class EfectoColision : MonoBehaviour
{
    public GameObject particulasPrefab; // Arrastra aquí tu Prefab de partículas

    private void OnCollisionEnter(Collision colision)
    {
        // 1. Obtenemos el punto exacto donde la pelota tocó el objeto
        ContactPoint contacto = colision.contacts[0];
        Vector3 posicionImpacto = contacto.point;
        Quaternion rotacionImpacto = Quaternion.LookRotation(contacto.normal);

        // 2. Creamos las partículas en ese sitio
        if (particulasPrefab != null)
        {
            GameObject nuevasParticulas = Instantiate(particulasPrefab, posicionImpacto, rotacionImpacto);

            // 3. Opcional: Destruir el objeto de partículas tras 2 segundos para no llenar la memoria
            Destroy(nuevasParticulas, 2f);
        }
    }
}
