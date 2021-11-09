using UnityEngine;

public class LevelInitializator : MonoBehaviour
{
    [SerializeField] private EnemyContainer _enemyContainer;
    [SerializeField] private TrapContainer _trapContainer;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private InputController _input;
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private PlayerUI _UIPrefab;

    private Player _player;
    private PlayerUI _UI;

    private void Awake()
    {
        _UI = Instantiate(_UIPrefab);
        _UI.Initialize(_playerConfig);
        
        _enemyContainer.Initialize();
        _trapContainer.Initialize();

        _player = Instantiate(_playerPrefab);
        _input.SpacePressed += _player.Jump;
        _input.HorizontalAxisChanged += _player.Move;
        _player.Init(_startPoint.position, _playerConfig);
        _player.HealthChanged += _UI.HealthBar.RefreshBar;
        _player.StaminaChanged += _UI.StaminaBar.RefreshBar;
        _player.SleepChanged += _UI.SleepBar.RefreshBar;

        
    }
    private void Start()
    {
        _player.Restart();
    }
}
