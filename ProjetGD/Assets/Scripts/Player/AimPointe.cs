using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPointe : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject target;
    private Vector2 movement;

    private void OnEnable()
    {
        target = Instantiate(prefab, Vector3.zero, prefab.transform.rotation);
    }

    private void OnDisable()
    {
        Destroy(target);
    }

    // Update is called once per frame
    void Update()
    {
        //movement = new Vector2(Input.GetAxis("Horinzontal"), Input.GetAxis("Vertical"));

        target.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0));
        //target.transform.position += new Vector3(Input.GetAxis("Horinzontal"), 0, Input.GetAxis("Vertical"));
    }
}
