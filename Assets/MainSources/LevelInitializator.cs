using System;
using UnityEngine;

public class LevelInitializator : MonoBehaviour
{
    [SerializeField] private EnemyContainer[] _enemyContainers;
    [SerializeField] private TrapContainer _trapContainer;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private PlayerUI _UIPrefab;
    [SerializeField] private LevelController _levelController;
    [SerializeField] private CameraController _camera;


    private Player _player;
    private PlayerUI _UI;

    private void Awake()
    {
        _levelController.Init();
        _UI = Instantiate(_UIPrefab);
        _UI.Initialize(_playerConfig);

        foreach (var container in _enemyContainers)
        {
            container.Initialize();
        }

        _trapContainer.Initialize();

        _player = Instantiate(_playerPrefab);
        _player.Init(_levelController.StartPosition, _playerConfig);

        ////TO DO
        //_player.Died += () => _levelController.ReturnToLastPoint(_player);
        

        _camera.SetTarget(_player.GetComponent<CameraTarget>());

    }

    private void Start()
    {
        _levelController.ReturnToLastPoint(_player);
    }

    public void OnLevelEnded()
    {
        foreach (var container in _enemyContainers)
        {
            container.Dispose();
        }
    }
}
