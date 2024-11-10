using UnityEngine;
using TMPro;

public class Fuego : MonoBehaviour
{
    public float calor = 50f;
    public float scaleDecrement = 0.1f;
    public TMP_Text mesajeUI;

    public void Apagar(float cantidad)
    {
        calor -= cantidad;
        Vector3 newScale = transform.localScale - new Vector3(scaleDecrement, scaleDecrement, scaleDecrement);
        transform.localScale = newScale;
        if (calor <= 0 )
        {
            Apagado();
        }
    }

    void Apagado()
    {
        mesajeUI.color = Color.green;
        mesajeUI.text = "El fuego ha sido apagado";
        Destroy(gameObject);
    }
}
