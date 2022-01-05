using UnityEngine;
using UnityEngine.UI;

namespace Weapon
{
    public class AmmoPickUp : MonoBehaviour
    {
        public GameObject pickUpDisplay;
        [SerializeField] private AudioSource ammoPickUpFX;

        private void OnTriggerStay(Collider other)
        {
            this.gameObject.SetActive(false);
            ammoPickUpFX.Play();
            DisplayStuff.ammoDisplayNumber += 10;
            pickUpDisplay.SetActive(false);
            pickUpDisplay.GetComponent<Text>().text = "Ammo picked up";
            pickUpDisplay.SetActive(true);
        }
    }
}
