using UnityEngine;

public class RaycastTargetActivator : MonoBehaviour
{
    [SerializeField] private RaycastTarget _raycastTarget;

    private void OnEnable()
    {
        _raycastTarget.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _raycastTarget.gameObject.SetActive(false);
    }
}