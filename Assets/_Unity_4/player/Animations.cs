using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAAI
{
    public class Animations : MonoBehaviour
    {
        public Animator Controller;

        void Awake()
        {
            Manager_Static.animacionesPersonajes = this;
        }

        public void setVelocitys(float _x, float _z)
        {
            Controller.SetFloat("VelocityX", _x);
            Controller.SetFloat("VelocityZ", _z);
        }

        public void takeDamage()
        {
            Controller.SetTrigger("TakeDamage");
        }

        public void setDead(bool _isDead)
        {
            Controller.SetBool("IsDead", _isDead);
        }

        public void setDamage()
        {
            Controller.SetTrigger("Atack");
        }
    }
}
