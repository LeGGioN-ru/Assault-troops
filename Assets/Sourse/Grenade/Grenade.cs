using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Grenade : MonoBehaviour
{
    [SerializeField] private float _blowUpDelay;
    [SerializeField] private Vector2 _sizeBlowUp;
    [SerializeField] private float _damage;

    private bool _isPlayerTeam;
    private Animator _animator;

    public void Init(bool isPlayerTeam)
    {
        _isPlayerTeam = isPlayerTeam;
        _animator = GetComponent<Animator>();

        if (_isPlayerTeam)
            _animator.Play(GrenadeAnimatorController.State.Fall);
        else
            _animator.Play(GrenadeAnimatorController.State.FallBack);
    }

    private void BlowUp()
    {
        StartCoroutine(BlowingUp());
    }

    private IEnumerator BlowingUp()
    {
        yield return new WaitForSeconds(_blowUpDelay);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, _sizeBlowUp, 0);

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out Solider solider))
            {
                if (solider.IsPlayerTeam != _isPlayerTeam)
                    solider.ApplyDamage(_damage);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(_sizeBlowUp.x, _sizeBlowUp.y));
    }
}
