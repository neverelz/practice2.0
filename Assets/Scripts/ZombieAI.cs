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
    [SerializeField] private GameObject _soundTarget;
    [SerializeField] private float _targetFollowRange;
    [SerializeField] private float _stopTargetFollowingRange;
    [SerializeField] private EnemyAttack _enemyAttack;
    [SerializeField]  private AIDestinationSetter _aiDestinationSetter;
    [SerializeField] private float _microphoneDistance;
    public AudioSource source;
    
    public MicLoudnessDetection detector;

    public float threshold = 0.1f;

    public float loudnessSensibility = 100;
    private Player _player;
    private EnemyStates _currentState;
    private Vector3 _roamPosition;
    private MicLoudnessDetection _micLoudnessDetection;
    private Vector3 _soundPosition;

    void TryFindTarget()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) <= _targetFollowRange)
        {
            _currentState = EnemyStates.Following;
        }
    }

    void TryHearTarget()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        if (loudness < threshold) loudness = 0;
        if (loudness > _microphoneDistance)
        {
            _soundPosition = _player.transform.position;
            _soundTarget.transform.position = _soundPosition;

            _currentState = EnemyStates.MovingToSound;
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
                TryHearTarget();
                break;
            case EnemyStates.Following:
                _aiDestinationSetter.target = _player.transform;
                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) <
                    _enemyAttack.AttackRange)
                {
                    _enemyAttack.TryAttackPlayer();
                }
                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) >=
                    _targetFollowRange)
                {
                    _currentState = EnemyStates.Roaming;
                }
                break;
            case EnemyStates.MovingToSound:
                _aiDestinationSetter.target = _soundTarget.transform;
                
                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) < _targetFollowRange)
                {
                    _currentState = EnemyStates.Following;
                }

                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) < 1)
                {
                    _currentState = EnemyStates.Roaming;
                }

                break;
                
        }
    }

    public enum EnemyStates
    {
        Roaming,
        Following,
        MovingToSound
    }
}
