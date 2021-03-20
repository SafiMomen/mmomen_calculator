using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using TMPro;

public class MainCalculator : MonoBehaviour
{
    public GameObject DisplayObject;
    public TextMeshPro text;

    public string TextCalc;
    public string currentOperation = string.Empty;
    float[] operation = new float[2];
    string[] SimpleArthematics = new string[] {"/", "*", "+", "-"};
    public void Solve() {
        if (currentOperation != string.Empty) {
            if (operation[1] != 0f)
            {
                if (currentOperation == "/")
                    operation[0] = operation[0] / operation[1];
                
                else if (currentOperation == "*")
                    operation[0] = operation[0] * operation[1];

                else if (currentOperation == "-")
                    operation[0] = operation[0] - operation[1];

                else if (currentOperation == "+")
                    operation[0] = operation[0] + operation[1];


                operation[1] = 0f;
            }
        }
    }
    public new void SendMessage(string name) {
        if (name == "C")
        {
            TextCalc = string.Empty;
            currentOperation = string.Empty;

            operation = new float[2];
        } 
        else if (SimpleArthematics.Contains(name))
        {
            Solve();
            currentOperation = name;
            TextCalc = string.Empty;
        }
        else if (name == "=")
        {
            Solve();
            currentOperation = string.Empty;
            TextCalc = operation[0].ToString();
        }
        else {
            TextCalc +=  name;
        }

        text.text = TextCalc;
        if (TextCalc != string.Empty) {
            if (currentOperation == string.Empty)
            {
                float value = float.Parse(TextCalc);
                operation[0] = value;
            }
            else
            {
                float value = float.Parse(TextCalc);
                operation[1] = value;
            }
        }
    }
    public void Start()
    {
        text = DisplayObject.GetComponent<TextMeshPro>();
    }
}
