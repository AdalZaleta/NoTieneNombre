using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAAI
{
    public class BossBehaviour : MonoBehaviour
    {

        public float speed;
        public float atkDistance;
        GameObject player;
        Rigidbody rig;
        bool foundPlayer = false;
        bool canStep = true;
        bool attacking = false;
        int HP = 100;

        private void OnTriggerEnter(Collider _col)
        {
            if (_col.gameObject.CompareTag("Player") && !foundPlayer)
            {
                foundPlayer = true;
                Manager_Static.uiManager.BossFound();
                player = _col.gameObject;
            }
        }

        // TEMPORARY TESTING
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                ReceiveDamage();
            }
        }

        public void ReceiveDamage()
        {
            HP -= 25;
            Manager_Static.uiManager.UpdateBossHP(HP);
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }

        // Use this for initialization
        void Start()
        {
            rig = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (foundPlayer)
            {
                Vector3 playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                transform.LookAt(playerPos);
            }
            if (foundPlayer)
            {
                float gap = Vector3.Distance(transform.position, player.transform.position);
                if (gap <= atkDistance)
                {
                    Attack();
                }
                else if (gap > atkDistance)
                {
                    Move(1, 0);
                }

                if (canStep)
                {
                    int randSide = (int)Random.Range(0, 10);
                    Debug.Log("Step: " + randSide);
                    if (randSide == 5)
                    {
                        Debug.Log("Entered SideStep");
                        StartCoroutine(SideStep(5, 1));
                    }
                    else if (randSide == 10)
                    {
                        Debug.Log("Entered SideStep");
                        StartCoroutine(SideStep(5, -1));
                    }
                    else if (randSide == 8)
                    {
                        Debug.Log("Entered BackStep");
                        StartCoroutine(BackStep(3, -1));
                    }
                }
            }
        }

        public void Attack()
        {
            if (!attacking)
                StartCoroutine(AttackCD());
        }

        void Move(int zDir, int xDir)
        {
            Debug.Log("Moving Z: " + zDir + ", X: " + xDir);
            Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
            transform.Translate(Vector3.forward * zDir * speed * Time.deltaTime, Space.Self);
            transform.Translate(Vector3.right * xDir * speed * Time.deltaTime, Space.Self);
        }

        IEnumerator AttackCD()
        {
            attacking = true;
            yield return new WaitForSeconds(1.2f);
            attacking = false;
        }

        IEnumerator BackStep(float time, int dir)
        {
            if (time > 0)
            {
                Debug.Log("BackStep " + time);
                canStep = false;
                Move(dir, 0);
                yield return new WaitForSeconds(0.1f);
                time -= 0.1f;
                BackStep(time, dir);
            }
            else
            {
                Debug.Log("Ended BackStep");
                canStep = true;
            }
        }

        IEnumerator SideStep(float time, int dir)
        {
            if (time > 0)
            {
                Debug.Log("SideStep " + time);
                canStep = false;
                Move(0, dir);
                yield return new WaitForSeconds(0.1f);
                time -= 0.1f;
                SideStep(time, dir);
            }
            else
            {
                Debug.Log("Ended SideStep");
                canStep = true;
            }
        }
    }
}