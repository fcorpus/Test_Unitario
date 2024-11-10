using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickExtintor : MonoBehaviour
{
    public Transform equipPosition;
    public float distance = 10f;
    GameObject current;
    GameObject wp;
    public Extintor extintor;
    public TMP_Text mesajeUI;

    bool canGrab;
    // Start is called before the first frame update
    void Start()
    {
        extintor.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckExtintor();

        if(canGrab)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }

        if(current != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                Drop();
        }
    }

    private void CheckExtintor()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit,distance))
        {
            if (hit.transform.tag == "CanGrab")
            {
                Debug.Log("puedo agarrarlo");
                canGrab = true;
                wp = hit.transform.gameObject;
            }
        }
        else
            canGrab = false;
    }

    private void PickUp()
    {
        current = wp;
        current.transform.position = equipPosition.position;
        current.transform.parent = equipPosition;
        current.transform.localEulerAngles = new Vector3(86.911f, -7.151f, 348.11f);
        current.GetComponent<Rigidbody>().isKinematic = true;
        current.GetComponent<BoxCollider>().enabled = false;
        extintor.enabled = true;
        mesajeUI.color = Color.green;
        mesajeUI.text = "Extintor tomado :]";
    }

    private void Drop()
    {
        current.transform.parent = null;
        current.GetComponent<Rigidbody>().isKinematic = false;
        current.GetComponent<BoxCollider>().enabled = true;
        current = null;
        extintor.enabled = false;
    }
}
