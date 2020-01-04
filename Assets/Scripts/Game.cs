using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	protected Spawner mSpawner;

    // Start is called before the first frame update
    void Start()
    {
		mSpawner = GameObject.FindObjectOfType<Spawner>().GetComponent<Spawner>();
		mSpawner.Spawn("PrefabMan", 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
