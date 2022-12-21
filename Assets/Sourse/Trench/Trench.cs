using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Trench : MonoBehaviour
{
    [SerializeField] private float _percentMiss;

    private List<Solider> _solidersIn = new List<Solider>();

    public float PercentMiss => _percentMiss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Solider solider = collision.GetComponent<Solider>();

        if (solider == null)
            return;

        bool isTrenchFreeOrBusy = _solidersIn.Count == 0 || _solidersIn.All(soliderTeam => soliderTeam.IsPlayerTeam == solider.IsPlayerTeam);

        if (isTrenchFreeOrBusy == false)
            return;

        solider.SitTrench(_percentMiss);
        _solidersIn.Add(solider);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Solider solider))
            if (_solidersIn.Contains(solider))
                _solidersIn.Remove(solider);
    }
}