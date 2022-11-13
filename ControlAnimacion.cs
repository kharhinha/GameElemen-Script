using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimacion
{
    public Animator animacion;

    public ControlAnimacion(Animator animacion)
    {
        this.animacion = animacion;
    }

    public void AnimacionAtaque()
    {
        animacion.SetBool("atacar", true);
        animacion.SetBool("gritar", false);
    }

    public void AnimacionIdle()
    {
        animacion.SetBool("gritar", true);
        animacion.SetBool("atacar", false);
    }

    public void AnimacionDamage()
    {
        animacion.SetBool("damage", true);
        animacion.SetBool("atacar", false);
    }
    public void AnimacionDead()
    {
        animacion.SetBool("atacar", false);
        animacion.SetBool("gritar", false);
        animacion.SetBool("damage", false);
        animacion.SetBool("dead", true);
    }
}
