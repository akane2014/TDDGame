using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private static readonly float PanSpeed = 10f;
	private static readonly float ZoomSpeedMouse = 1.5f;

	private static readonly float[] BoundsX = new float[] { -10f, 10f };
	private static readonly float[] BoundsY = new float[] { -18f, 18f };
	private static readonly float[] ZoomBounds = new float[] { 2f, 10f };

	private Camera cam;
	private Vector3 lastPanPosition;

	void Awake()
	{
		cam = GetComponent<Camera>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		HandleMouse();
	}

	void HandleMouse()
	{
		// On mouse down, capture it's position.
		// Otherwise, if the mouse is still down, pan the camera.
		if (Input.GetMouseButtonDown(0))
		{
			lastPanPosition = Input.mousePosition;
		}
		else if (Input.GetMouseButton(0))
		{
			PanCamera(Input.mousePosition);
		}

		// Check for scrolling to zoom the camera
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		ZoomCamera(scroll, ZoomSpeedMouse);
	}

	void PanCamera(Vector3 newPanPosition)
	{
		// Determine how much to move the camera
		Vector3 offset = cam.ScreenToViewportPoint(lastPanPosition - newPanPosition);
		Vector3 move = new Vector3(offset.x * PanSpeed, offset.y * PanSpeed, 0 );

		// Perform the movement
		transform.Translate(move, Space.World);

		// Ensure the camera remains within bounds.
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp(transform.position.x, BoundsX[0], BoundsX[1]);
		pos.y = Mathf.Clamp(transform.position.y, BoundsY[0], BoundsY[1]);
		transform.position = pos;

		// Cache the position
		lastPanPosition = newPanPosition;
	}

	void ZoomCamera(float offset, float speed)
	{
		if (offset == 0)
		{
			return;
		}

		cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - (offset * speed), ZoomBounds[0], ZoomBounds[1]);
	}
}
