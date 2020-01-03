using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class FirstTestScript
    {
		GameObject goTest;

		[SetUp]
		public void Setup()
		{
			goTest = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/PrefabWorker"));
		}

		[TearDown]
		public void Cleanup()
		{
			GameObject.Destroy(goTest);
		}

		// A Test behaves as an ordinary method
		[Test]
        public void ICanInstantiatePrefabGameObjectInSimplePasses()
        {
			// Use the Assert class to test conditions
			Assert.IsTrue(goTest != null);
			Assert.IsTrue(goTest.GetComponent<Worker>() != null);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ICanInstantiatePrefabGameObjectInEnumeratorPasses()
        {
			// Use the Assert class to test conditions.
			// Use yield to skip a frame.
			Assert.IsTrue(goTest != null);
			Assert.IsTrue(goTest.GetComponent<Worker>() != null);
			yield return null;
        }

		[Test]
		public void ICanVerityTheStartStateInSimplePasses()
		{
			// Use the Assert class to test conditions
			Assert.IsTrue(goTest != null);
			Assert.IsTrue(goTest.GetComponent<Worker>() != null);
			Assert.AreEqual(0, goTest.GetComponent<Worker>().mCounter);
		}

		[UnityTest]
		public IEnumerator ICanVerityTheStartStateInEnumeratorPasses()
		{
			// Use the Assert class to test conditions.
			// Use yield to skip a frame.
			Assert.IsTrue(goTest != null);
			Assert.IsTrue(goTest.GetComponent<Worker>() != null);
			int counter_before = goTest.GetComponent<Worker>().mCounter;
			yield return null;
			Assert.AreEqual(counter_before + 1, goTest.GetComponent<Worker>().mCounter);
			yield return null;
		}
	}
}
