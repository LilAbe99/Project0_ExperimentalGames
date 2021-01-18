using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLight : MonoBehaviour
{
    public GameObject CameraScriptObject;
    public GameObject Player;
    public int LightRestore;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("You gained 100 light!");
            CameraScriptObject.GetComponent<CameraTexV2>().LightAmount += LightRestore;
            CameraScriptObject.GetComponent<CameraTexV2>().UpdateLightAmount();
            Player.GetComponent<SpawnLights>().RefillLights();
        }
        Destroy(this.gameObject);
    }

}
