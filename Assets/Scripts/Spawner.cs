using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public GameObject Spawn(string prefab_name, int x, int y)
	{
		GameObject result = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/" + prefab_name));
		float f_x = 0;
		float f_y = 0;
		Game.Grid2Vec(x, y, ref f_x, ref f_y);
		result.transform.position = new Vector3(f_x, f_y, 0);
		return result;
	}
}
