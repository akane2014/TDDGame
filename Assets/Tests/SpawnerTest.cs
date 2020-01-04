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
			GameObject man = GameObject.FindObjectOfType<Mover>().gameObject;
			Assert.AreEqual(1, GameObject.FindObjectsOfType<Mover>().Length);
			Assert.AreEqual(0.5f, man.transform.position.x);
			Assert.AreEqual(0.5f, man.transform.position.y);
			GameObject.Destroy(man);
			spawner.GetComponent<Spawner>().Spawn("PrefabMan", 1, 1);
			man = GameObject.FindObjectOfType<Mover>().gameObject;
			Assert.AreEqual(1.5f, man.transform.position.x);
			Assert.AreEqual(1.5f, man.transform.position.y);
		}

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SpawnerTestWithEnumeratorPasses([Values("PrefabMan", "PrefabWoman")] string prefab)
        {
			spawner.GetComponent<Spawner>().Spawn(prefab, 0, 0);
			Mover mover = GameObject.FindObjectOfType<Mover>();
			Assert.AreEqual(0.5f, mover.transform.position.x);
			Assert.AreEqual(0.5f, mover.transform.position.y);

			mover.SetSpeed(5);
			mover.MoveTo(1, 0);
			yield return null;

			Assert.AreNotEqual(0.5f, mover.transform.position.x);
			Assert.AreEqual(0.5f, mover.transform.position.y);

			yield return new WaitForSeconds(0.2f);

			Assert.AreEqual(1.5f, mover.transform.position.x);
			Assert.AreEqual(0.5f, mover.transform.position.y);
		}
    }
}
