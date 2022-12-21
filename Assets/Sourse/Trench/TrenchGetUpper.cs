using UnityEngine;

public class TrenchGetUpper : MonoBehaviour
{
    [SerializeField] private Vector2 _distance;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), _distance, 0);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out Solider solider))
                {
                    if (solider.IsPlayerTeam == false)
                        return;

                    if (collider.TryGetComponent(out AttackState attackState) && solider.IsPlayerTeam)
                    {
                        if (attackState.enabled == false)
                            solider.GetUpTrech();
                    }
                    else
                    {
                        solider.GetUpTrech();
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Camera.main.ScreenToWorldPoint(Input.mousePosition), _distance);
    }
}
