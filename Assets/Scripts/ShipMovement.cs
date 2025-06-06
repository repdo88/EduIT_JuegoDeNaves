using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    [SerializeField] private float speed = 20f; // Velocidad de movimiento de la nave
    private Vector3 move; // Vector de movimiento

    // Variables para limitar movimiento
    private float limIzquierda;
    private float limDerecha;
    private float limAdelante;
    private float limAtras;
    private float anchoPlano;
    private float largoPlano;
    public Transform plano; // Referencia al plano donde se mueve

    // Start is called before the first frame update
    void Start()
    {
        Renderer planoRenderer = plano.GetComponent<Renderer>();
        float anchoPlano = planoRenderer.bounds.size.x; // Ancho del plano
        float largoPlano = planoRenderer.bounds.size.z; // Largo del plano

        Renderer autoRenderer = GetComponent<Renderer>();
        float largoNave = autoRenderer.bounds.size.z / 2f; // Largo del auto (la mitad para centrarlo)
        float anchoNave = autoRenderer.bounds.size.x / 2f; // Ancho del auto (la mitad para centrarlo)

        float centroX = plano.position.x; // Centro del plano en X
        float centroZ = plano.position.z; // Centro del plano en Z

        limIzquierda = centroX - (anchoPlano / 2f) + anchoNave; // Límite izquierdo
        limDerecha = centroX + (anchoPlano / 2f) - anchoNave; // Límite derecho
        limAdelante = centroZ + (largoPlano / 2f) - largoNave; // Límite adelante
        limAtras = centroZ - (largoPlano / 2f) + largoNave; // Límite atrás
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }





    private void Movimiento()
    {
        move = new Vector3(0, 0, 0); // Resetear el vector de movimiento cada frame
        if (Input.GetAxis("Horizontal") == -1f)
        {
            move.x -= 1; // Mover a la izquierda
        }
        else if (Input.GetAxis("Horizontal") == 1f)
        {
            move.x += 1; // Mover a la derecha
        }
        if (Input.GetAxis("Vertical") == -1f)
        {
            move.z -= 1; // Mover atras
        }
        else if (Input.GetAxis("Vertical") == 1f)
        {
            move.z += 1; // Mover adelante
        }

        transform.Translate(move.normalized * speed * Time.deltaTime); // Cambiar posición

        // Limitar movimiento dentro del plano
        Vector3 pos = transform.position; // Obtener la posición actual del auto
        pos.x = Mathf.Clamp(pos.x, limIzquierda, limDerecha); // Limitar movimiento en X
        pos.z = Mathf.Clamp(pos.z, limAtras, limAdelante); // Limitar movimiento en Z
        transform.position = pos; // Aplicar la posición limitada
    }
}
