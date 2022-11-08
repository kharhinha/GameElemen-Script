using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  Para enemigos que solo atacan al jugador cuando este ingresa en su rango de ataque.
 */
public class EnemigosController : MonoBehaviour
{
    //State
    private float fuerzaDeAtaque= 10.0f;
    private float nivelVida = 20.0f;
    private float speedMove = 5.0f;
    private bool hit;

    //Verifican cuando puede atacar
    public float radioAtaque = 5.0f;
    private bool puedeAtacar;
    private Vector3 seguimientoPlayer;

    //Referencias privadas

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private PlayerController jugador;
    [SerializeField]
    private Animator animacion;

    private Rigidbody riBody;

    //Referencias publicas
    public LayerMask capaPlayer;

    void Start()
    {
        riBody = GetComponent<Rigidbody>();
        animacion = GetComponent<Animator>();
  
    }

    void Update()
    {
        //Detecta si el jugador esta cerca del area de ataque, genera un circulo invisible estilo colaider
        puedeAtacar= Physics.CheckSphere(transform.position,radioAtaque,capaPlayer);

        /*Inicio ataque:
          el enemigo se mueve hacia la posición del player, con una velocidad determinada;
         */
        if (puedeAtacar)
        {
            /*Observa al player cuando ingresa al área de ataque, sigue su ubicacion en X,Z y 
            mantiene su pocion en el eje Y*/
            seguimientoPlayer = new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z);
            transform.LookAt(seguimientoPlayer);

            // se mueve hacia el player, (calcula la distancia entre ambos)
            transform.position = Vector3.MoveTowards(transform.position,seguimientoPlayer,speedMove * Time.deltaTime);

            animacionAtaque();
        }
        else
        {
            animacionIdle();
            
        }

        //Hasta este punto funciona junto con las lineas 85-101 y la funcion ataque()

        //-------CODIGO de Prueba
        hit = false;
        //es atacado por el player?
        if (hit)
        {
            animacionDamage();
            recibeDamage(10);
            comprobarVida();
            animacionAtaque();
            Debug.Log("pierde hp"+ nivelVida);
        }

    }


    void animacionAtaque()
    {
        animacion.SetBool("atacar", true);
        animacion.SetBool("gritar", false);
    }

    void animacionIdle()
    {
        animacion.SetBool("gritar", true);
        animacion.SetBool("atacar", false);
    }

    void animacionDamage()
    {
        animacion.SetBool("damage",true);
        animacion.SetBool("atacar",false);
    }

    void animacionDead()
    {
        animacion.SetBool("dead",true);
        animacion.SetBool("atacar",false);
        animacion.SetBool("gritar",false);
        animacion.SetBool("damage",false);
    }

    //ataca al player
    public void ataque()
    {
        if (jugador.vida > 0)
        {
            jugador.recibiDamage(fuerzaDeAtaque);
            Debug.Log(jugador.vida);
        }
    }

    /*Comprueba si los puntos de vida llegan al minimo,
     para iniciar la animacion de agonizing.
     */
    public void comprobarVida()
    {
        if (nivelVida <= 0)
        {
            animacionDead();
            hit = false;
        }
    }

    

    public void recibeDamage(float damage)
    {
        nivelVida -= damage;
    }
}
