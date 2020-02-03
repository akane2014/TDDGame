using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

	public enum Mode
	{
		BUILDING,
		RUNNING
	};

	protected Spawner mSpawner;
	protected GameUI mGameUI;
	protected Mode mCurrentMode = Mode.RUNNING;

    // Start is called before the first frame update
    void Start()
    {
		mSpawner = GameObject.FindObjectOfType<Spawner>().GetComponent<Spawner>();
		GameObject man = mSpawner.Spawn("PrefabMan", 0, 0);
		Mover mover = man.GetComponent<Mover>();
		mover.SetSpeed(1);
		mover.MoveTo(2, 2);

		GameObject woman = mSpawner.Spawn("PrefabWoman", 0, 1);
		woman.GetComponent<Mover>().SetSpeed(1);
		woman.GetComponent<Mover>().MoveTo(2, 0);

		mGameUI = GameObject.FindObjectOfType<GameUI>().GetComponent<GameUI>();
		List<MenuItem> root_items = mGameUI.AddMenuItem(new List<string>() { "BUILD", "RECRUIT" }, 0);
		root_items[0].SetSubItems(new List<string>() { "DESK", "CHAIR" });
		root_items[1].SetSubItems(new List<string>() { "TEACHER", "CLEANER" });
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public static void Grid2Vec(int grid_x, int grid_y, ref float x, ref float y)
	{
		x = grid_x + 0.5f;
		y = grid_y + 0.5f;
	}
}
