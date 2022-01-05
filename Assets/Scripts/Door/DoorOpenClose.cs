using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Door
{
    public class DoorOpenClose : MonoBehaviour
    {
        [SerializeField] private AudioSource doorFX;
        public bool needsKey;
        public GameObject pickUpDisplay;

        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (needsKey && DisplayStuff.hasKey)
                {
                    doorFX.Play();
                    this.GetComponent<Animator>().Play("DoorOpen");
                    this.GetComponent<CapsuleCollider>().enabled = false;
                    DisplayStuff.hasKey = false;
                }
                else if (!needsKey)
                {
                    doorFX.Play();
                    this.GetComponent<Animator>().Play("DoorOpen");
                    this.GetComponent<CapsuleCollider>().enabled = false;
                    StartCoroutine(CloseDoor());
                }
                else
                {
                    pickUpDisplay.SetActive(false);
                    pickUpDisplay.GetComponent<Text>().text = "Needs Key";
                    pickUpDisplay.SetActive(true);
                }
            }
        }
        private IEnumerator CloseDoor()
        {
            yield return new WaitForSeconds(5);
            doorFX.Play();
            this.GetComponent<Animator>().Play("DoorClose");
            yield return new WaitForSeconds(0.1f);
            this.GetComponent<CapsuleCollider>().enabled = true;
        }
    }
}
