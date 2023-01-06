using UnityEngine;

[RequireComponent(typeof(Solider))]
public class GrenadeThrowState : State
{
    [SerializeField] private GrenadeView _grenade;

    private bool _isPlayerTeam;

    private void Start()
    {
        _isPlayerTeam = GetComponent<Solider>().IsPlayerTeam;
    }

    private void OnEnable()
    {
        Instantiate(_grenade, transform).Grenade.Init(_isPlayerTeam);
    }
}
