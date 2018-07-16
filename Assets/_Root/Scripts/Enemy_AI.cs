using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TAAI
{
    public class Enemy_AI : MonoBehaviour
    {
        public GameObject player;
        Vector3 OG_pos;
        NavMeshAgent agent;
        bool canFollow;

        private void OnTriggerStay(Collider _col)
        {
            if (_col.gameObject.CompareTag("player"))
            {
                if (canFollow)
                {
                    agent.destination = _col.transform.position;
                }  
            }
        }

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            if (Vector3.Distance(transform.position, OG_pos) >= 20.0f)
            {
                agent.destination = OG_pos;
            }
        }

        IEnumerator FollowCD(float cd_time)
        {
            canFollow = false;
            yield return new WaitForSeconds(cd_time);
            canFollow = true;
        }
    }
}