using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Calculator : MonoBehaviour
{
    public InputField FirstNum;
    public InputField SecondNum;
    public InputField AnswerNum;

    public void Addition()
    {
        AnswerNum.text = (double.Parse(FirstNum.text,CultureInfo.InvariantCulture.NumberFormat) + double.Parse(SecondNum.text, CultureInfo.InvariantCulture.NumberFormat)).ToString();
    }

    public void Subtraction()
    {
        AnswerNum.text = (double.Parse(FirstNum.text, CultureInfo.InvariantCulture.NumberFormat) - double.Parse(SecondNum.text, CultureInfo.InvariantCulture.NumberFormat)).ToString();
    }

    public void Multiplication()
    {
        AnswerNum.text = (double.Parse(FirstNum.text, CultureInfo.InvariantCulture.NumberFormat) * double.Parse(SecondNum.text, CultureInfo.InvariantCulture.NumberFormat)).ToString();
    }

    public void Division()
    {
        if (double.Parse(SecondNum.text, CultureInfo.InvariantCulture.NumberFormat) == 0) AnswerNum.text = "/ на 0";
        else AnswerNum.text = (double.Parse(FirstNum.text, CultureInfo.InvariantCulture.NumberFormat) / double.Parse(SecondNum.text, CultureInfo.InvariantCulture.NumberFormat)).ToString();
    }
}
