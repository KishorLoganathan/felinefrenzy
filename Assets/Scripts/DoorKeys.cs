using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySphere : MonoBehaviour
{
    public GameObject goldenDoor;  // This is a reference to the corresponding golden door

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) {

            Debug.Log("Player entered the key zone!");

            // Deactivate this key and its corresponding door
            gameObject.SetActive(false);  // This will disable the key itself (this object)
            goldenDoor.SetActive(false);  // This will disable the corresponding golden door
        }
    }
}
