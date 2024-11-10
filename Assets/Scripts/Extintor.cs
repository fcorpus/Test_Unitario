using UnityEngine;

public class Extintor : MonoBehaviour
{
    public float intensidad = 10f;
    public float range = 10f;

    public Camera fpCam;
    public ParticleSystem espuma;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Usar();
        }
    }

    void Usar()
    {
        espuma.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpCam.transform.position, fpCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Fuego fire = hit.transform.GetComponent<Fuego>();

            if(fire != null)
            {
                fire.Apagar(intensidad);
            }
        }
    }
}
