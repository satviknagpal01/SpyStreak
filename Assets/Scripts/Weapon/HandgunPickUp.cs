using UnityEngine;
using UnityEngine.UI;

namespace Weapon
{
    public class HandgunPickUp : MonoBehaviour
    {
        public GameObject pickUpDisplay;

        [SerializeField] private GameObject showGun;
        [SerializeField] private GameObject realGun;
        [SerializeField] private AudioSource gunPickUpFX;
        public GameObject gunImage;

        private void OnTriggerEnter(Collider other)
        {
            showGun.SetActive(false);
            this.GetComponent<BoxCollider>().enabled = false;
            gunPickUpFX.Play();
            realGun.SetActive(true);
            pickUpDisplay.SetActive(false);
            pickUpDisplay.GetComponent<Text>().text = "Gun picked up"; 
            pickUpDisplay.SetActive(true);
            gunImage.SetActive(true);
        }
    }
}
