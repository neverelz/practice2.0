using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] private float _minWalkableDistance;
    [SerializeField] private float _maxWalkableDistance;
    [SerializeField] private float _reachedPointDistance;
    [SerializeField] private GameObject _roamTarget;
    [SerializeField] private float _targetFollowRange;
    [SerializeField] private float _stopTargetFollowingRange;
    [SerializeField] private EnemyAttack _enemyAttack;
    [SerializeField]  private AIDestinationSetter _aiDestinationSetter;
    [SerializeField] private float _microphoneStrength;
    private Player _player;
    private EnemyStates _currentState;
    private Vector3 _roamPosition;
    private MicLoudnessDetection _micLoudnessDetection;

    void TryFindTarget()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) <= _targetFollowRange)
        {
            _currentState = EnemyStates.Following;
        }
    }

    Vector3 GenerateRoamPosition()
    {
        var roamPosition = gameObject.transform.position + GenerateRandomDirection() * GenerateRandomWalkableDistance();
        return roamPosition;
    }

    float GenerateRandomWalkableDistance()
    {
        var randomDistance = Random.Range(_minWalkableDistance, _maxWalkableDistance);
        return randomDistance;
    }

    Vector3 GenerateRandomDirection()
    {
        var newDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        return newDirection.normalized;
    }
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _currentState = EnemyStates.Roaming;
        _roamPosition = GenerateRoamPosition();
    }
    void Update()
    {
        switch (_currentState)
        {
            case EnemyStates.Roaming:
                _roamTarget.transform.position = _roamPosition;
                if (Vector3.Distance(gameObject.transform.position, _roamPosition) <= _reachedPointDistance)
                {
                    _roamPosition = GenerateRoamPosition();
                }

                _aiDestinationSetter.target = _roamTarget.transform;
                TryFindTarget();
                break;
            case EnemyStates.Following:
                _aiDestinationSetter.target = _player.transform;
                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) <
                    _enemyAttack.AttackRange)
                {
                    _enemyAttack.TryAttackPlayer();
                }
                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) >=
                    _stopTargetFollowingRange)
                {
                    _currentState = EnemyStates.Roaming;
                }

                break;
        }
    }

    public enum EnemyStates
    {
        Roaming,
        Following
    }
}
