using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public  class EnemyPoo : MonoBehaviour
{
    [Header ("EnemyPoo")]
    [SerializeField] protected float nivelVida;
    [SerializeField] protected float nivelDeAtaque;
    [SerializeField] protected float speedMove;
    [SerializeField] protected float radioAtaque;
    [SerializeField] protected bool hit;
    [SerializeField] protected bool puedeAtacar;
    [SerializeField] protected GameObject player;
    [SerializeField] protected PlayerController jugador;

    //Referencias publicas
    public LayerMask capaPlayer;

    //Referencias privadas
    protected Animator animacion;
    private Rigidbody rigBody;
    protected ControlAnimacion controlAnimacion;

    private void Awake()
    {
        animacion = GetComponent<Animator>();
        rigBody = GetComponent<Rigidbody>();
        controlAnimacion = new ControlAnimacion(animacion);
        //Debug.Log("ver jugador; Awake Poo: " + jugador);
    }

    public float recibeDamage(float damage)
    {
        return nivelVida -= damage;
    }

    public void comprobarVida()
    {
        if (nivelVida <= 0)
        {
            Debug.Log("vida baja");
        }
    }
}
