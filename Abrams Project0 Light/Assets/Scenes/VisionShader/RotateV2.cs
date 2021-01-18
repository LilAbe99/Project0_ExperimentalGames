using UnityEngine;
using System.Collections;

public class RotateV2 : MonoBehaviour
{
	public float TurnSpeed;
	void Update()
	{
		transform.Rotate(0, Time.deltaTime * TurnSpeed, 0);
	}
}