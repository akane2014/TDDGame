using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
	public string mName;
	protected Text mText;
	protected int mLayer;

	protected List<string> mSubItems;
	protected List<MenuItem> mSubMenuItems;

	protected bool mSelected = false;
	public void SetSelected(bool selected)
	{
		if (mSelected != selected)
		{
			mSelected = selected;
			if (mSelected)
			{
				OnSelected();
			}
			else
			{
				OnUnselected();
			}
		}
	}
	public bool GetSelected()
	{
		return mSelected;
	}

	public delegate void MenuCallback();
	public MenuCallback mOnClickCallback;

	void Awake()
    {
		mSubMenuItems = new List<MenuItem>(); 
	}

	// Start is called before the first frame update
	void Start()
	{
		mOnClickCallback += OnClick;
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

	public void OnClicked()
	{
		if (mOnClickCallback != null)
		{
			mOnClickCallback();
		}
	}

	public void SetLayer(int layer)
	{
		mLayer = layer;
	}

	public void SetSubItems(List<string> items)
	{
		mSubItems = items;
	}

	public List<MenuItem> AddSubItems(List<string> items)
	{
		int item_idx = 0;
		foreach (string item in items)
		{
			MenuItem menu_item = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/UI/PrefabMenuItem")).GetComponent<MenuItem>();
			menu_item.SetLayer(mLayer + 1);
			menu_item.transform.SetParent(this.transform.parent, true);
			Vector3 menu_position = menu_item.GetComponent<RectTransform>().position;
			menu_position.x += item_idx * GameUI.MENU_GAP;
			menu_position.y += menu_item.mLayer * GameUI.MENU_GAP;
			menu_item.GetComponent<RectTransform>().position = menu_position;
			menu_item.SetName(item);
			mSubMenuItems.Add(menu_item);
			item_idx++;
		}
		return mSubMenuItems;
	}

	protected void OnClick()
	{
		if (mSelected)
		{
			SetSelected(false);
		}
		else
		{
			SetSelected(true);
		}
	}

	protected void OnSelected()
	{
		if (mSubItems != null && mSubItems.Count > 0 && mSubMenuItems.Count == 0)
		{
			AddSubItems(mSubItems);
		}
		else
		{
			Debug.Log(mName + " selected");
		}
	}

	protected void OnUnselected()
	{
		if (mSubItems != null && mSubMenuItems.Count > 0)
		{
			foreach (MenuItem item in mSubMenuItems)
			{
				GameObject.Destroy(item.gameObject);
			}
			mSubMenuItems.Clear();
		}
		else
		{
			Debug.Log(mName + " unselected");
		}
	}
}
