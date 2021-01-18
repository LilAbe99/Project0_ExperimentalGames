using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnLights : MonoBehaviour
{
    public GameObject LineLight;
    public GameObject BigLight;
    public int BigLightNum = 3;
    public int LineLightNum = 5;

    public Text BigLightNumText;
    public Text LineLightNumText;

    private void Start()
    {
        UpdateText();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && BigLightNum > 0)
        {
            Debug.Log("Pressed primary button.");
            BigLightNum -= 1;
            UpdateText();
            Instantiate(BigLight, this.transform.position, Quaternion.identity);
        }

        if (Input.GetMouseButtonDown(0) && LineLightNum > 0)
        {
            Debug.Log("Pressed secondary button.");
            LineLightNum -= 1;
            UpdateText();
            Instantiate(LineLight, this.transform.position, this.transform.rotation);
        }

    }
    public void RefillLights()
    {
        BigLightNum = 3;
        LineLightNum = 5;
        UpdateText();
    }
    public void UpdateText()
    {
        BigLightNumText.text = BigLightNum.ToString();
        LineLightNumText.text = LineLightNum.ToString();
    }

}
