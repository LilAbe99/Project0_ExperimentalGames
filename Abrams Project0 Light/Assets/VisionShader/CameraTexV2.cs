using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.Rendering.HighDefinition;
using UnityStandardAssets.Characters.FirstPerson;

public class CameraTexV2 : MonoBehaviour
{

    private void Start()
    {
        RenderPipelineManager.endFrameRendering += OnEndFrameRendering;
    }

    // Grab the camera's view when this variable is true.
    public bool grab;

    // The "display" is the object whose texture will be set
    // to the captured image.
    public Renderer display;
	public GameObject DarknessText;
	public int LightAmount = 1000;
	public Slider LightSlider;
	public GameObject Vignette;
	private Vignette _vignette;

    private int TargetHit = 0;
    public int TargetThresh = 5;

    private void Update()
    {
		//Debug.Log("Frame");
	}
    void OnEndFrameRendering(ScriptableRenderContext context, Camera[] cameras)
	{
		foreach (Camera camera in cameras)
		{
			if (camera.transform.name == "VisionTextureCamera")
			{
				if (grab)
				{
					var tsize = 128;  //needs to match up with size of RenderTexture or camera window
					var tex = new Texture2D(tsize, tsize, TextureFormat.ARGB32, false);
					tex.ReadPixels(new Rect(0, 0, tsize, tsize), 0, 0);
					tex.Apply();
					if (true)
					{
						int xx = 0;
						int zz = 0;
						for (xx = 0; xx < tsize; xx++)
						{
							for (zz = 0; zz < tsize; zz++)
							{
								Color pixcol = tex.GetPixel(xx, zz);
								if (!pixcol.Equals(Color.black))
								{
									TargetHit++;
									Debug.Log("Seen");
								}
							}
						}
					}
					if (TargetHit > TargetThresh)
					{
						Debug.Log("========Found TARGET!!");
						Vignette.SetActive(false);
					}
					else
					{
						LightAmount -= 1;
						Vignette.SetActive(true);
						UpdateLightAmount();
					}
					if (LightAmount <= 0)
                    {
						DarknessText.SetActive(true);
						GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
						GameObject.Find("PlayerLightSpawner").gameObject.SetActive(false);
					}
					TargetHit = 0;

					// Set the display texture to the newly captured image.
					display.material.mainTexture = tex;

					// Reset the grab variable to avoid making multiple
					// captures.
					//grab = false;
				}
			}
		}
	}

	public void UpdateLightAmount()
    {
		LightSlider.value = LightAmount;
	}
	void OnDestroy()
	{
		RenderPipelineManager.endFrameRendering -= OnEndFrameRendering;
	}
}