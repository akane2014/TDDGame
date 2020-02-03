using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	protected GameObject mCanvas;
	protected List<MenuItem> mMenuItems;
	static public float MENU_GAP = 88;

	private void Awake()
	{
		mCanvas = transform.Find("Canvas").gameObject;
		mMenuItems = new List<MenuItem>();
	}
	// Start is called before the first frame update
	void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public List<MenuItem> GetMenuItems()
	{
		List<MenuItem> items = new List<MenuItem>();
		for (int i = 0; i < mCanvas.transform.childCount; i++ )
		{
			MenuItem item = mCanvas.transform.GetChild(i).GetComponent<MenuItem>();
			if (item)
			{
				items.Add(item);
			}
		}
		return items;
	}

	public List<MenuItem> AddMenuItem(List<string> items, int layer)
	{
		int item_idx = 0;
		foreach(string item in items)
		{
			MenuItem menu_item = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/UI/PrefabMenuItem")).GetComponent<MenuItem>();
			menu_item.SetLayer(layer);
			menu_item.transform.SetParent( mCanvas.transform, true );
			Vector3 menu_position = menu_item.GetComponent<RectTransform>().position;
			menu_position.x += item_idx * GameUI.MENU_GAP;
			menu_item.GetComponent<RectTransform>().position = menu_position;
			menu_item.SetName(item);
			mMenuItems.Add(menu_item);
			item_idx++;
		}
		return mMenuItems;
	}
}
