using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private InputProcessing _input;
    [SerializeField] private SearchEnemy _searcher;
    [SerializeField] private Health _player;

    private float _delayCoroutine = 1;
    private float _timePulling = 6;
    private float _spendTime = -1;
    private float _damage = 10;
    private float _heal = 5;
    private Coroutine _coroutine;

    private void Update() => ActivateAbility();

    private void ActivateAbility()
    {
        if (_input.CanUseAbility && _searcher.ClosestEnemy != null)
        {
            if (_spendTime == -1)
            {
                if (_coroutine != null)
                    StopCoroutine(_coroutine);

                _coroutine = StartCoroutine(StartPullingHealth());
            }
        }
    }

    private IEnumerator StartPullingHealth()
    {
        WaitForSeconds delay = new WaitForSeconds(_delayCoroutine);
        Health enemy = _searcher.ClosestEnemy;

        for (_spendTime = 0; _spendTime < _timePulling; _spendTime++)
        {
            if (enemy == null)
            {
                _spendTime = -1;
                yield break;
            }

            enemy.TakeDamage(_damage);
            _player.TakeHeal(_heal);

            yield return delay;
        }

        _spendTime = -1;
    }
}