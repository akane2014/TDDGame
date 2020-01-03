using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
	public int mCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
		mCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
		mCounter += 1;
	}
}
