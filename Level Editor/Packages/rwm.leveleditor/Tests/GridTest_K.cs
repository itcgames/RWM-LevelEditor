using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class GridTest_K : MonoBehaviour
{
    GridLayout_K tile;
    Vector3 mousePos;
    Camera mainCamera;

    private void Start()
    {
        tile = new GridLayout_K(10, 8, 10.0f, new Vector3(-50, -40));
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            tile.SetValue(mousePos, 1);
        }

        if (Input.GetMouseButtonDown(1))
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            tile.SetValue(mousePos, 0);
        }

        if (Input.GetMouseButtonDown(2))
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(tile.GetValue(mousePos));
        }
    }
}

namespace Tests
{
    public class GridLayoutTest
    {
        GridLayout_K grid;

        [SetUp]
        public void Setup()
        {
            grid = new GridLayout_K(10, 8, 10.0f, new Vector3(-50, -40));
        }

        [UnityTest]
        public IEnumerator getValueTest()
        {
            int inputX = 5;
            int inputY = 5;
            int expected = 0;

            int output = grid.GetValue(inputX, inputY); // Testing

            yield return new WaitForSeconds(0.1f);

            Assert.AreEqual(expected, output);
        }

        [UnityTest]
        public IEnumerator setValueTest()
        {
            int inputX = 5;
            int inputY = 5;
            int value = 25;
            int expected = 25;

            grid.SetValue(inputX, inputY, value); // Testing

            int output = grid.GetValue(inputX, inputY);

            yield return new WaitForSeconds(0.1f);

            Assert.AreEqual(expected, output);
        }

        [UnityTest]
        public IEnumerator getValueTest2()
        {
            Vector3 mousePos = new Vector3(-5, 5, 0);
            int expected = 0;

            int output = grid.GetValue(mousePos); // Testing

            yield return new WaitForSeconds(0.1f);

            Assert.AreEqual(expected, output);

            yield return new WaitForSeconds(0.1f);

            Assert.AreEqual(expected, output);
        }

        [UnityTest]
        public IEnumerator setValueTest2()
        {
            Vector3 mousePos = new Vector3(-5, 5, 0);
            int value = 25;
            int expected = 25;

            grid.SetValue(mousePos, value); // Testing

            int output = grid.GetValue(mousePos);

            yield return new WaitForSeconds(0.1f);

            Assert.AreEqual(output, expected);
        }

        [TearDown]
        public void Teardown()
        {
            
        }
    }
}