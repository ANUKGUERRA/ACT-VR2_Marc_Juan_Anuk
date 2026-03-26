using UnityEngine;

public class EfectoColision : MonoBehaviour
{
    public GameObject particulasPrefab; 

    private void OnCollisionEnter(Collision colision)
    {
        
        ContactPoint contacto = colision.contacts[0];
        Vector3 posicionImpacto = contacto.point;
        Quaternion rotacionImpacto = Quaternion.LookRotation(contacto.normal);

        
        if (particulasPrefab != null)
        {
            GameObject nuevasParticulas = Instantiate(particulasPrefab, posicionImpacto, rotacionImpacto);
            Debug.Log("Particulas");
           
            Destroy(nuevasParticulas, 2f);
        }
    }
}
