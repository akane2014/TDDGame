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
		return result;
	}
}
