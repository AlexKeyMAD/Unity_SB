using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoNumbersComparer : MonoBehaviour
{
    public InputField FirstNum;
    public InputField SecondNum;
    public InputField Answer;

    public void Comparer()
    {
        int a = int.Parse(FirstNum.text);
        int b = int.Parse(SecondNum.text);

        if (a == b) Answer.text = "�����";
        else if (a > b) Answer.text = $"{a.ToString()} ������ {b.ToString()}";
        else Answer.text = $"{a.ToString()} ������ {b.ToString()}";
    }
}
