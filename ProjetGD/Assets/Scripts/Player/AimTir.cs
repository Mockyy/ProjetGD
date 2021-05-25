using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTir : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject guide;
    private Rigidbody rbGuide;
    private float movement;
    private float angle = 0;

    private void OnEnable()
    {
        //Instantiation du prefab de cible
        guide = Instantiate(prefab, new Vector3(0, 0.2f, -5.5f), prefab.transform.rotation);
        guide.name = "Guide";
        rbGuide = guide.GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        Destroy(guide);
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        if (movement < 0)
        {
            angle++;
        }
        else if (movement > 0)
        {
            angle--;
        }

        angle = Mathf.Clamp(angle, -45, 45);

        guide.transform.eulerAngles = new Vector3(90, 0, angle);
    }
}
