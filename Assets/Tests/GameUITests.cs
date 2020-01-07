using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GameUITests
    {
		GameUI gameUI;

		[SetUp]
		public void Setup()
		{
			gameUI = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/UI/PrefabGameUI")).GetComponent<GameUI>();
		}

		[TearDown]
		public void Cleanup()
		{
			GameObject.Destroy(gameUI.gameObject);
		}

		// A Test behaves as an ordinary method
		[Test]
        public void ICanAddMenuItemsSimplePasses()
        {
			// Use the Assert class to test conditions
			gameUI.AddMenuItem(new List<string>( ){ "BUILD", "RECRUIT" }, 0 );
			Assert.AreEqual(2, GameObject.FindObjectsOfType<MenuItem>().Length);

			MenuItem[] items = gameUI.GetMenuItems();
			float x0 = items[0].GetComponent<RectTransform>().position.x;
			float y0 = items[0].GetComponent<RectTransform>().position.y;
			float x1 = items[1].GetComponent<RectTransform>().position.x;
			float y1 = items[1].GetComponent<RectTransform>().position.y;
			Assert.AreEqual(0, x0);
			Assert.AreEqual(GameUI.MENU_GAP, x1 - x0);
			Assert.AreEqual(0, y0);
			Assert.AreEqual(0, y1);

			Assert.AreEqual("BUILD", items[0].mName);
			Assert.AreEqual("RECRUIT", items[1].mName);
		}

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator GameUITestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
