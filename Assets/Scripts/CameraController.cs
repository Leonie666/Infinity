using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject Player;

	private Vector2 lookVelocity;
	private Vector2 currentLookPos;
	private float mouseSensitivity = 0.5f;

	private GameObject CamHolder;

	[SerializeField] private float smoothing;

	
	void Start()
    {
		LockCursor();
		transform.Rotate(0, 0, 0);
		CamHolder = GameObject.Find("CamHolder");
	}

    
    void Update()
    {
		camRotation();
	}
	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}


	private void camRotation()
	{
		Vector2 input = new Vector2(Input.GetAxis("Mouse X") * mouseSensitivity, Input.GetAxis("Mouse Y") * mouseSensitivity);

		lookVelocity.x = Mathf.Lerp(lookVelocity.x, input.x, 1f ); //input.x, 1f / smoothing)
		lookVelocity.y = Mathf.Lerp(lookVelocity.y, input.y, 1f ); //input.y, 1f / smoothing)

		currentLookPos += lookVelocity;

		transform.localRotation = Quaternion.AngleAxis(-currentLookPos.y, Vector3.right);
		Player.transform.localRotation = Quaternion.AngleAxis(-currentLookPos.x, -Player.transform.up);
	}

	public void SetPosition()
	{
		transform.parent = CamHolder.transform;
		transform.position = CamHolder.transform.position;
		transform.rotation = CamHolder.transform.rotation;
	}
}
