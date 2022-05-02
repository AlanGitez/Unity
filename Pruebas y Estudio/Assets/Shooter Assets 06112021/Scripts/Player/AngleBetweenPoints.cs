using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleBetweenPoints : MonoBehaviour
{
    public static float AngleCalculate(Vector3 P1, Vector3 P2)
    {

        Vector3 vector = P1 - P2;
        vector.Normalize();

        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg - 90;

        return angle;
    }
}
