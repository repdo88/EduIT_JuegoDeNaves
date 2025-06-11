using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    [SerializeField] private float speed = 20f; // Velocidad de movimiento de la nave
    private Vector3 move; // Vector de movimiento
    [SerializeField] private float velocidadRotacion = 10f; // Velocidad de rotaci�n de la nave
    private float way; // Variable para controlar la rotaci�n de la nave
    private float wayx; // Variable para controlar la rotaci�n en el eje X

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

        limIzquierda = centroX - (anchoPlano / 2f) + anchoNave; // L�mite izquierdo
        limDerecha = centroX + (anchoPlano / 2f) - anchoNave; // L�mite derecho
        limAdelante = centroZ + (largoPlano / 2f) - largoNave; // L�mite adelante
        limAtras = centroZ - (largoPlano / 2f) + largoNave; // L�mite atr�s
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Rotacion();

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

        transform.Translate(move.normalized * speed * Time.deltaTime, Space.World); // Cambiar posici�n

        // Limitar movimiento dentro del plano
        Vector3 pos = transform.position; // Obtener la posici�n actual del auto
        pos.x = Mathf.Clamp(pos.x, limIzquierda, limDerecha); // Limitar movimiento en X
        pos.z = Mathf.Clamp(pos.z, limAtras, limAdelante); // Limitar movimiento en Z
        transform.position = pos; // Aplicar la posici�n limitada
    }


    private void Rotacion()
    {
        way = 0f; // Resetear la variable de rotaci�n cada frame
        //Rotaci�n en z
        if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow))) // Rotar a la izquierda
        {
            way += 1;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) // Dejar de rotar a la izquierda
        {
            way -= 1;
        }
        if ((Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow))) // Rotar a la derecha
        {
            way -= 1;
        }
        if ((Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.RightArrow))) // Dejar de rotas
        {
            way += 1;
        }
        // Rotaci�n en x
        wayx = 0f; // Resetear la variable de rotaci�n en x cada frame
        if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.UpArrow))) // Rotar a la izquierda
        {
            wayx += 1;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) // Dejar de rotar a la izquierda
        {
            wayx -= 1;
        }
        if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.DownArrow))) // Rotar a la derecha
        {
            wayx -= 1;
        }
        if ((Input.GetKeyUp(KeyCode.S)) || (Input.GetKeyUp(KeyCode.DownArrow))) // Dejar de rotas
        {
            wayx += 1;
        }

        transform.Rotate(new Vector3(wayx * velocidadRotacion, 0, way * velocidadRotacion)); // Cambiar rotaci�n
    }
}
