using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public NPCmovement NPC; 
	public CameraController Camera;
	public float Speed;
	public Rigidbody RB;
	public bool IsActive = true;

	private bool cameraInPosition = false;
	private GameObject CamHolder;
	private bool isSneaky = false;
	



    void Start()
    {
		RB = GetComponent<Rigidbody>();
		CamHolder = GameObject.Find("CamHolder");
	}


    void Update()
    {
		//if (IsActive && !cameraInPosition)
		//{
		//	SetCameraPosition();
		//}

		if (IsActive)
		{
			if (Input.GetKeyDown(KeyCode.LeftControl))
			{
				if (isSneaky)
				{
					isSneaky = false;
					Speed = 10;
				}

				else
				{
					isSneaky = true;
					Speed = 4.5f;
				}
			}

			RB.velocity = new Vector3(Input.GetAxis("Horizontal") * Speed, RB.velocity.y, Input.GetAxis("Vertical") * Speed);

			if (Input.GetKeyDown(KeyCode.Tab))
			{
				NPC.IsActive = true;
				IsActive = false;
			
			}
		}
	}

	void SetCameraPosition()
	{
		Camera.SetPosition();
		cameraInPosition = true;
	}
}
