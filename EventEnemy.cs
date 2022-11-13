using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEnemy : MonoBehaviour
{
    [SerializeField]
    private ControlEnemy enemy;
    
    //El enemigo ataca
    public void damage()
    {
        enemy.ataca();
    }

    public void hit(float danio)
    {
        enemy.recibeDamage(danio);
    }

    public void dead()
    {
        enemy.comprobarVida();
    }
   
}
