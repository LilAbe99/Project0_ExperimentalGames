using UnityEngine;
using System.Collections;

public class ReplaceTexV2 : MonoBehaviour
{

    public Shader dif;
    public Camera VisionCamera;

    void OnEnable()
    {
        VisionCamera.SetReplacementShader(dif, "RenderType");
    }

    void OnDisable()
    {
        VisionCamera.ResetReplacementShader();
    }
}