using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TaskScript : MonoBehaviour
{
    public void Task_1()
    {
        int sum = 0;
        int a = 7;
        int b = 21;

        for (int i = a; i <= b; i++)
        {

            if (i%2 != 0)
            {
                continue;
            }

            sum += i;
        }

        Debug.Log($"Сумма четных чисел в деапозоне от {a} до {b} = {sum}");
    }

    public void Task_2()
    {
        int[] array = new int[10] { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };

        int sum = 0;

        foreach (int i in array)
        {
            if (i % 2 != 0)
            {
                continue;
            }

            sum += i;
        }

        Debug.Log($"Сумма четных чисел в массиве = {sum}");
    }

    public void Task_3()
    {
        int[] array = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };

        int n = 34;

        var result = FirstOccurrence(array, n);

        OutputLogTask_3(n, result);

        array = new int[] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };

        n = 55;

        result = FirstOccurrence(array, n);

        OutputLogTask_3(n, result);
    }

    private int FirstOccurrence(int[] array, int value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return i;
            }
        }

        return -1;
    }

    private void OutputLogTask_3(int n, int result)
    {
        Debug.Log($" В первом массиве число {n} {(result < 0 ? "не найдено, результат " : "найдено, под индексом ")} {result}");
    }

    public void Task_4()
    {
        int[] originalArray = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        OutputLogArray(originalArray, "Исходный массив");

        int[] sortedArray = SortArray((int[])originalArray.Clone());
        OutputLogArray(sortedArray, "Отсортированый программой массив");

        int[] expectedArray = { 10, 13, 15, 22, 26, 34, 34, 68, 71, 81 };
        OutputLogArray(expectedArray, "Отсортированый правильно массив");

        Debug.Log(sortedArray.SequenceEqual(expectedArray) ? "Результат верный" : "Результат не верный");
    }

    private void OutputLogArray(int[] arr, string name)
    {
        Debug.Log($" {name} {string.Join(",",arr)} ");
    }

    private int[] SortArray(int[] arr)
    {
        for (int i = 0; i < arr.Length-1; i++)
        {
            int min = arr[i];
            int indMin = i;

            for (int j = i+1; j < arr.Length; j++)
            {
                if (arr[j] < min)
                {
                    min = arr[j];
                    indMin = j;
                }
            }

            if (indMin != i)
            {
                arr[indMin] = arr[i];
                arr[i] = min;
            }
        }

        return arr;
    }
}
