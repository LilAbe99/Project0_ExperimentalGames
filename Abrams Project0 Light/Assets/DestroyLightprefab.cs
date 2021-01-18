using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLightprefab : MonoBehaviour
{
    public float TimeToLive = 5f;
    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
}
