using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEnemy : MonoBehaviour
{
    //private EnemyIA enemy;
    [SerializeField]
    private EnemigosController enemigo;
    
    //El enemigo ataca
    public void damage()
    {
        enemigo.ataque();
    }

    public void hit(float danio)
    {
        enemigo.recibeDamage(danio);
    }

    public void dead()
    {
        enemigo.comprobarVida();
    }
   
}
