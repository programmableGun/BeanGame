using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class maxDistanceHandler : MonoBehaviour
{
    Stack<float> stack = new Stack<float>();
    public Text maxDistanceUI; 

    // add a function to add something to this stack
    public void addMaxDistance(float maxDistance) {
        stack.Push(maxDistance);
        updateMaxDistanceText();
    }
    // make a function to convert stack to a unity text object and make it show only the recent 5 runs
    public void updateMaxDistanceText() {
        maxDistanceUI.text = "Recent Distances Recorded:";
        int counter = 0;
        foreach (float value in stack)
        {
            counter++;
            if (counter == 5) {
                break;
            }
            maxDistanceUI.text += "\n" + value;
        }
    }

}
