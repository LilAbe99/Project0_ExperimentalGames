using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class YouWin : MonoBehaviour
{
    public GameObject YouWinText;
    void OnTriggerEnter(Collider collider)
    {
        YouWinText.SetActive(true);
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
        GameObject.Find("PlayerLightSpawner").gameObject.SetActive(false);
    }
}
