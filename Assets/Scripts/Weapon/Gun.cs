using System.Collections;
using UnityEngine;

namespace Weapon
{
    public class Gun : MonoBehaviour
    {
        Transform cam;
        //
        //[Header("General")]
        //[SerializeField] private float range = 50f;
        //[SerializeField] private float damage = 10f;
        //[SerializeField] private float fireRate = 5f;
        //[SerializeField] private int maxAmmo;
        //[SerializeField] private float reloadTime;
        //[SerializeField] private float inaccuracyDistance;
        //[SerializeField] private float impactForce = 150f;
        //[SerializeField] private GameObject muzzleFlash;
        //[SerializeField] private GameObject impactEffect;
        //[SerializeField] private AudioSource gunFireFX;
        //public bool isFiring;
//
//
        //private WaitForSeconds reloadWait;
        //private int currentAmmo;
//
        //[Header("Rapid Fire")]
        //[SerializeField] private bool rapidFire = false;
        //private WaitForSeconds rapidFireWait;
//
        //[Header("Shotgun")]
        //[SerializeField] private bool shotgun = false;
        //[SerializeField] private int bulletsPerShot = 6;
//
        //[Header("HandGun")]
        //[SerializeField] private bool handgun = false;
        //
        void Awake()
        {
            cam = Camera.main.transform;
        //    rapidFireWait = new WaitForSeconds(1 / fireRate);
        //    currentAmmo = maxAmmo;
        //    reloadWait = new WaitForSeconds(reloadTime);
        }
//
        //private void Update()
        //{
        //    if (Input.GetButton("Fire1"))
        //    {
        //        Shoot();
        //    }
//
        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        StartCoroutine(RapidFire());
        //    }
        //}
//
        //public void Shoot()
        //{
        //    //Instantiate(shootEffect, muzzle, Quaternion.LookRotation(cam.forward));
        //    RaycastHit hit;
        //    if (shotgun)
        //    {
        //        for (int i = 0; i < bulletsPerShot; i++)
        //        {
        //            if (Physics.Raycast(cam.position, GetShootingDirection(), out hit, range))
        //            {
        //                //print(hit.collider.name);
        //                if (hit.rigidbody != null)
        //                {
        //                    hit.rigidbody.AddForce(-hit.normal * impactForce);
        //                }
        //                Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
        //                GameObject impact = Instantiate(impactEffect, hit.point, impactRotation);
        //                Destroy(impact,5);
        //            }
        //            currentAmmo--;
        //        }
        //    }
        //    if(handgun)
        //    {
        //        if (Physics.Raycast(cam.position, cam.forward, out hit, range))
        //        {
        //            //print(hit.collider.name);
        //            if (hit.rigidbody != null)
        //            {
        //                hit.rigidbody.AddForce(-hit.normal * impactForce);
        //            }
//
        //            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
        //            GameObject impact = Instantiate(impactEffect, hit.point, impactRotation);
        //            Destroy(impact, 5);
        //        }
        //    }
        //}
        //
        //public IEnumerator RapidFire()
        //{
        //    if (CanShoot())
        //    {
        //        Shoot();
        //        if (rapidFire)
        //        {
        //            while (CanShoot())
        //            {
        //                yield return rapidFireWait;
        //                Shoot();
        //            }
        //            StartCoroutine(Reload());
        //        }
        //    }
        //    else
        //    {
        //        StartCoroutine(Reload());
        //    }
        //}
//
        //IEnumerator Reload()
        //{
        //    if (currentAmmo == maxAmmo)
        //    {
        //        yield return null;
        //    }
        //    else
        //    {
        //        print("reloading...");
        //        yield return reloadWait;
        //        currentAmmo = maxAmmo;
        //        print("Finished Reloading ....");
        //    }
        //}
//
        //bool CanShoot()
        //{
        //    bool enoughAmmo = currentAmmo > 0;
        //    return enoughAmmo;
        //}
//
        //Vector3 GetShootingDirection()
        //{
        //    Vector3 targetPos = cam.position + cam.forward * range;
        //    targetPos = new Vector3(
        //        targetPos.x + Random.Range(-inaccuracyDistance, inaccuracyDistance),
        //        targetPos.y + Random.Range(-inaccuracyDistance, inaccuracyDistance),
        //        targetPos.z + Random.Range(-inaccuracyDistance, inaccuracyDistance)
        //    );
//
        //    Vector3 direction = targetPos - cam.position;
        //    return direction.normalized;
        //}
        
        public GameObject gun;
        public GameObject muzzleFlash;
        public AudioSource gunFire;
        public bool isFiring = false;
        public float shootWait = 0.25f;
        public AudioSource emptySound;
        public float targetDistance;
        public int damageAmount;
        
        void Update ()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (DisplayStuff.ammoDisplayNumber < 1)
                {
                    emptySound.Play();
                }
                else
                {
                    if (!isFiring)
                    { 
                        StartCoroutine(FiringHandgun());
                    }

                }
            }
        }

        IEnumerator FiringHandgun()
        {
            isFiring = true;
            Shoot();
            DisplayStuff.ammoDisplayNumber--;
            gun.GetComponent<Animator>().Play("Shoot");
            muzzleFlash.SetActive(true);
            gunFire.Play();
            yield return new WaitForSeconds(0.05f);
            muzzleFlash.SetActive(false);
            yield return new WaitForSeconds(shootWait);
            gun.GetComponent<Animator>().Play("New State");
            isFiring = false;
        }

        void Shoot()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                targetDistance = hit.distance;
                hit.transform.SendMessage("DamageEnemy",damageAmount,SendMessageOptions.DontRequireReceiver);
                Debug.Log(hit.collider.name);
                Debug.Log(hit.distance);
                //if (hit.rigidbody != null)
                //{
                //    hit.rigidbody.AddForce(-hit.normal * impactForce);
                //}
            }
        }
    }
}
