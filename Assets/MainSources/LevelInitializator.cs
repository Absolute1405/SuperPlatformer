using UnityEngine;

public class LevelInitializator : MonoBehaviour
{
    [SerializeField] private EnemyContainer _enemyContainer;
    [SerializeField] private TrapContainer _trapContainer;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private InputController _input;
    [SerializeField] private PlayerConfig _playerConfig;

    private Player _player;

    private void Awake()
    {
        _enemyContainer.Initialize();
        _trapContainer.Initialize();

        _player = Instantiate(_playerPrefab);
        _player.Init(_startPoint.position, _playerConfig);
        _input.SetPlayer(_player);
    }
    private void Start()
    {
        _player.Restart();
    }
}
