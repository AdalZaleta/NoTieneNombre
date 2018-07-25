using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAAI
{
    public class Weapon_Main : MonoBehaviour
    {
        [Header("Varibles de todas las armas")]
        public Transform spawnPoint;
        public float AtackRate = 0.5f;
        internal float lastAtackTime;


        public virtual void OnShootDown()
        {

        }

        public virtual void OnThrowDown()
        {

        }

        public virtual void OnShoot()
        {

        }

        public virtual void OnShootUp()
        {

        }

        public virtual void Shoot()
        {
            if (Time.time > lastAtackTime + AtackRate)
            {
                ExecuteShoot();
            }
        }

        public virtual void Reload()
        {

        }

        public virtual void Sheathe()
        {

        }

        public virtual void UnSheathe()
        {

        }

        public virtual void ExecuteShoot()
        {
            lastAtackTime = Time.time;
        }
    }
}
