using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
	public string mName;
	protected Text mText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SetName(string name)
	{
		mName = name;
		if (!mText)
		{
			mText = this.transform.GetComponentInChildren<Text>();
		}
		mText.text = mName;
	}
}
