using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    private static System.Random random = new System.Random();

    public static void Test() {
        Debug.Log("works");
    }

    public static int Next(int n) {
        return random.Next(n);
    }

    public static int[] GenerateSequence(int length) {
        int[] array = new int[length];
        for (int i = 0; i < length; i++) {
            bool flag = true;
            while (flag) {
                array[i] = random.Next(length);
                flag = false;
                for (int j = 0; j < i; j++) {
                    if (array[j] == array[i]) {
                        flag = true;
                        break;
                    }
                }
            }
        }
        return array;
    }
}
