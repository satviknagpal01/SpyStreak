using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class SoldierAI : MonoBehaviour
    {
        public string htiTag;
        public bool isLookingAtPlayer = false;
        public float speed;
        public GameObject theSoldier;
        public AudioSource GunFireAudio;
        public bool isFiring = false;
        public float fireRate =1;
        public int genHurt;
        public AudioSource[] hurtSound;
        public GameObject hurtFlash;
        public float range = 30;
        public Transform player;
        public NavMeshAgent agent;
        
        void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
            {
                htiTag = hit.transform.tag;
            }

            if (htiTag == "Player" && !isFiring)
            {
                StartCoroutine(EnemyFire());
            }
            else if (htiTag != "Player")
            {
                theSoldier.GetComponent<Animator>().Play("Idle");
                isLookingAtPlayer = false;
            }
        }

        IEnumerator EnemyFire()
        {
            isFiring = true;
            agent.SetDestination(player.position);
            theSoldier.GetComponent<Animator>().Play("Shoot",-1,0);
            theSoldier.GetComponent<Animator>().Play("Shoot");
            GunFireAudio.Play();
            isLookingAtPlayer = true;
            DisplayStuff.healthDisplayNumber -= 7;
            hurtFlash.SetActive(true);
            genHurt = Random.Range(0, 3);
            yield return new WaitForSeconds(0.2f);
            hurtSound[genHurt].Play();
            hurtFlash.SetActive(false);
            yield return new WaitForSeconds(fireRate);
            isFiring = false;
        }
    }
}
