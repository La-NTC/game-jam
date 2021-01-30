using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionesBasicasUnity : MonoBehaviour
{
    [SerializeField]
    private GameObject personaje;

    public float fuerza;

    private void Awake()
    {
        //referencias
    }

    void Start()
    {
//cuando inicia

    }

    void Update()
    {
       // calculos constantes

    }

    private void FixedUpdate()
    {
        //calculos constantes de fisica
    }

    private void OnCollisionEnter(Collision collision)
    {
        //colisiones sin traspasar
    }

    private void OnTriggerEnter(Collider other)
    {
        //colisiones q traspasan
    }


    public void Moverse()
    {
        //this.GetComponent<Rigidbody>().AddForce(Vector3.up * fuerza, ForceMode.Acceleration);

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+fuerza, this.transform.position.z);
    }

}
