using System.Collections;
using UnityEngine;

namespace Door
{
    public class SecretDoorOpen : MonoBehaviour
    {
        [SerializeField] private AudioSource doorFX;

        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKey(KeyCode.F))
            {
                doorFX.Play();
                this.GetComponent<Animator>().Play("Door Open");
                this.GetComponent<CapsuleCollider>().enabled = false;
                FloorComplete.secretCount++;
            }
        }
    }
}
