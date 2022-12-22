using UnityEngine;

public class CanNormilizeValue : MonoBehaviour
{
    protected float Normalize(float leftBorder, float rightBorder, float value)
    {
        float newValue = value - leftBorder;
        float distance = rightBorder - leftBorder;

        float normalizedValue = newValue / distance;

        return normalizedValue;
    }
}