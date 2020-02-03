using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	protected Mover mMover;

	private void Awake()
	{
		mMover = GetComponent<Mover>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButton(0))
		{
			Vector3 mouse_pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			Vector3 world_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
			mMover.MoveToPosition(world_pos.x, world_pos.y);
		}
	}
}
