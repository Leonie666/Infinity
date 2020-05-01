using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmovement : MonoBehaviour
{
	public PlayerMovement Player;
	public CameraController Camera;
	public float Speed;
	public bool IsActive;
	private bool cameraInPosition = false;
	private GameObject CamHolder;
	private Camera cam;

	public Rigidbody RB;



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
			RB.velocity = new Vector3(Input.GetAxis("Horizontal") * Speed, RB.velocity.y, Input.GetAxis("Vertical") * Speed);

			if (Input.GetKeyDown(KeyCode.Tab))
			{
				IsActive = false;
				Player.IsActive = true;
			}
		}
	}

	void SetCameraPosition()
	{
		Camera.SetPosition();
		cameraInPosition = true;
	}
}
