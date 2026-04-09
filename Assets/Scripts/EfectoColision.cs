using UnityEngine;

public class EfectoColision : MonoBehaviour
{
    public GameObject particulasPrefab;
    public GameObject particulasPrefab2;

    private void OnCollisionEnter(Collision colision)
    {
        
        ContactPoint contacto = colision.contacts[0];
        Vector3 posicionImpacto = contacto.point;
        Quaternion rotacionImpacto = Quaternion.LookRotation(contacto.normal);

        if (colision.gameObject.CompareTag("Pala"))
        {
            if (particulasPrefab != null)
            {
                GameObject nuevasParticulas = Instantiate(particulasPrefab2, posicionImpacto, rotacionImpacto);
                Debug.Log("Particulas2");

                Destroy(nuevasParticulas, 2f);
            }

        }

            else if (particulasPrefab != null)
            {
                GameObject nuevasParticulas = Instantiate(particulasPrefab, posicionImpacto, rotacionImpacto);
                Debug.Log("Particulas");
           
                Destroy(nuevasParticulas, 2f);
            }
    }
}
