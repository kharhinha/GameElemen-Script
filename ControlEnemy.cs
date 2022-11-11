using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlEnemy : EnemyPoo
{
    //Para conocer la ubicacion del jugador
    [Header ("ControlEnemy")]
    private Vector3 seguimientoPlayer;

    private void Start()
    {
        animacion = GetComponent<Animator>();
    }

    void Update()
    {
        //Detecta si el jugador esta cerca del area de ataque, genera un circulo invisible estilo colaider
        puedeAtacar = Physics.CheckSphere(transform.position, radioAtaque, capaPlayer);

        /*Inicio ataque:
          el enemigo se mueve hacia la posición del player, con una velocidad determinada;
         */
        if (puedeAtacar)
        {
            /*Observa al player cuando ingresa al área de ataque, sigue su ubicacion en X,Z y 
            mantiene su pocion en el eje Y*/
            seguimientoPlayer = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(seguimientoPlayer);

            // se mueve hacia el player, (calcula la distancia entre ambos)
            transform.position = Vector3.MoveTowards(transform.position, seguimientoPlayer, speedMove * Time.deltaTime);

            controlAnimacion.AnimacionAtaque();
        }
        else
        {
            controlAnimacion.AnimacionIdle();
        }


    }

    public void ataca()
    {
        jugador.reciboDamage(nivelDeAtaque);
    }

    
}
