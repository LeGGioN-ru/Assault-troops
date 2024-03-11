using UnityEngine;

public class NormalizedValueGetter : MonoBehaviour
{
    protected float GetNormilizedValue(float leftBorder, float rightBorder, float value)
    {
        float newValue = value - leftBorder;
        float distance = rightBorder - leftBorder;

        float normalizedValue = newValue / distance;

        return normalizedValue;
    }
}