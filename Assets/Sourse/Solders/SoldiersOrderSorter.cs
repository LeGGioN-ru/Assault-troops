using System.Linq;
using UnityEngine;

public class SoldiersOrderSorter : MonoBehaviour
{
    private Solider[] _soldiers;
    private int sortingOrderIndex = 0;

    private void Update()
    {
        _soldiers = GetComponentsInChildren<Solider>();
        sortingOrderIndex = 0;

        var sortedSoldiers = _soldiers.OrderByDescending(s => s.transform.position.y);

        foreach (var soldiers in sortedSoldiers)
        {
            soldiers.GetComponent<SpriteRenderer>().sortingOrder = sortingOrderIndex;

            sortingOrderIndex++;
        }
    }
}