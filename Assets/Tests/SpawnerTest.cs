using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SpawnerTest
    {
		GameObject spawner;

		[SetUp]
		public void Setup()
		{
			spawner = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/PrefabSpawner"));
		}

		[TearDown]
		public void Cleanup()
		{
			GameObject.Destroy(spawner);
		}

		// A Test behaves as an ordinary method
		[Test]
        public void SpawnerTestSimplePasses()
        {
			// Use the Assert class to test conditions
			spawner.GetComponent<Spawner>().Spawn("PrefabMan", 0, 0);
			Assert.AreEqual(1, GameObject.FindObjectsOfType<Mover>().Length);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SpawnerTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
