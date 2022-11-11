using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
  Inteligencia artificial para seguimiento y ataque,
  el enemigo sigue al player hacia su ubicación, abarcando un área especifica, es
  establecida con NavMesh (navegación).
 */
public class EnemyIA : MonoBehaviour
{
    //Referencias  
    
    public GameObject player;
    [SerializeField]
    private PlayerController controlPlayer;

    [SerializeField]
    private NavMeshAgent IA;
    [SerializeField]
    private Animator animacion;

    //variables
    [SerializeField]
    private float speedMove=5.0f;
    private float nivelVida = 30.0f;
    private float nivelAtaque = 15.0f;

    
    void Start()
    {
        //velocidad a la que se mueve el enemigo
        IA.speed = speedMove;
        animacion = GetComponent<Animator>();
    }


    void Update()
    {
        /*marca la ubicacion del player:
         indicando hacia donde se mueve el jugador*/
        IA.SetDestination(player.transform.position);

        
    }


    public void atacar()
    {
        controlPlayer.reciboDamage(nivelAtaque);
    }
  
}

