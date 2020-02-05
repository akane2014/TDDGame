using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	public float mSpeed = 1;

	protected float mSpeedFactor = 1;
	protected const float SPEED_FACTOR_ONCOLLISION = 0.5f;
	protected float mTargetX = 0;
	protected float mTargetY = 0;

    // Start is called before the first frame update
    void Start()
    {
		RefreshDepth();
	}

	void RefreshDepth()
	{
		Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.y);
		this.transform.position = pos;
	}

    // Update is called once per frame
    void Update()
    {
		if (this.transform.position.x != mTargetX || this.transform.position.y != mTargetY)
		{
			Vector3 target = new Vector3(mTargetX, mTargetY, 0);
			Vector3 delta = target - this.transform.position;
			delta.z = 0;
			float dist = delta.magnitude;
			if (dist < mSpeed * Time.deltaTime)
			{
				this.transform.position = target;
			}
			else
			{
				delta.Normalize();
				this.transform.Translate(delta * mSpeed * mSpeedFactor * Time.deltaTime);
			}

			RefreshDepth();
		}
	}

	public void SetSpeed(float speed)
	{
		mSpeed = speed;
	}

	public void MoveToGrid(int x, int y)
	{
		Game.Grid2Vec(x, y, ref mTargetX, ref mTargetY);
	}

	public void MoveToPosition(float x, float y)
	{
		mTargetX = x;
		mTargetY = y;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		mSpeedFactor = SPEED_FACTOR_ONCOLLISION;
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		mSpeedFactor = 1;
	}
}
