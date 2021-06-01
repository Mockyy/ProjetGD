using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AimTir : MonoBehaviour
{
    public static event Action IncreaseDecrease;

    [SerializeField] private GameObject prefab;
    private GameObject guide;
    private Rigidbody rbGuide;
    private Material guideShader;
    private float movement;
    private float angle = 0;

    [SerializeField] private float power = 0;
    //public bool filling = true;

    private void OnEnable()
    {
        //Instantiation du prefab de cible
        guide = Instantiate(prefab, new Vector3(0, 0.2f, -5.5f), prefab.transform.rotation);
        guide.name = "Guide";
        rbGuide = guide.GetComponent<Rigidbody>();
        guideShader = guide.GetComponent<Renderer>().material;
        Debug.Log(guideShader.name);
    }

    private void OnDisable()
    {
        Destroy(guide);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        power = Mathf.PingPong(Time.time, 3);
        guideShader.SetFloat("Vector1_88db8ece61324dcbb29a5c6f73fc2e1b", power);
    }

    private void Move()
    {
        movement = Input.GetAxisRaw("Horizontal");

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

    ///Mathf.PingPong() en moins bien
    //IEnumerator Power()
    //{
    //    while (true)
    //    {
    //        if (filling)
    //        {
    //            while (power < 3)
    //            {
    //                power += 0.1f;
    //                yield return new WaitForSeconds(0.1f);
    //            }

    //            filling = false;
    //        }
    //        else
    //        {
    //            while (power > 0)
    //            {
    //                power -= 0.1f;
    //                yield return new WaitForSeconds(0.1f);
    //            }

    //            filling = true;
    //        }
    //    }
    //}
}
