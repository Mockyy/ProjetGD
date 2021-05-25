using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPointe : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject GOarea;
    private GameObject target;
    private Rigidbody rbTarget;
    private Vector3 movement;

    [SerializeField] float xSensi = 5f;
    [SerializeField] float ySensi = 0.1f;
    [SerializeField] float xMaxSpeed = 5f;
    [SerializeField] float yMaxSpeed = 5f;

    private void OnEnable()
    {
        //Instantiation du prefab de cible
        target = Instantiate(prefab, new Vector3(0, 0.2f, 0), prefab.transform.rotation);
        target.name = "Target";
        rbTarget = target.GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        Destroy(target);
    }

    // Update is called once per frame
    void Update()
    {
        //On restreint la position de la cible à la zone de jeu
        Bounds playArea = GOarea.GetComponent<MeshCollider>().bounds;
        rbTarget.position = new Vector3(
            Mathf.Clamp(rbTarget.position.x, playArea.min.x, playArea.max.x), 0,
            Mathf.Clamp(rbTarget.position.z, playArea.min.z, playArea.max.z));

        //On limite la vitesse de la cible
        rbTarget.velocity = new Vector3(
            Mathf.Clamp(rbTarget.velocity.x, 0, xMaxSpeed),
            Mathf.Clamp(rbTarget.velocity.z, 0, yMaxSpeed));

        //Déplacement de la cible
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rbTarget.MovePosition(rbTarget.position + movement * xSensi);
    }
}