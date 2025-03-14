using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Counter _scoreCounter;
    [SerializeField] private Counter _levelCounter;
    [SerializeField] private SpawnersCommander _spawners;
    [SerializeField] private int _scoreLevelMultiplier = 100;
    [SerializeField] private Window2Buttons _windowStart;
    [SerializeField] private Window1Button _windowOptions;
    [SerializeField] private Window2Buttons _windowGameOver;
    [SerializeField] private Window _windowPause;
    [SerializeField] private WindowAdvertisement _windowAdvertisement;
    [SerializeField] private Toggle _masterVolumeMuteTogle;

    private bool _isBossMode = false;
    private bool _isSomeWindowOpened = true;
    private bool _masterVolumeMuteTogleState = false;

    private void Awake()
    {
        Stop();
    }

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
        _spawners.ObjectKilled += _scoreCounter.Add;
        _scoreCounter.Changed += CalcLevel;
        _levelCounter.Changed += ChangeLevel;
        _userInput.PauseButtonPressed += OnPauseButtonClick;
        _windowStart.Button1Clicked += OnStartButtonClick;
        _windowStart.Button2Clicked += OnOptionsButtonClick;
        _windowOptions.Button1Clicked += OnOptionsOkButtonClick;
        _windowGameOver.Button1Clicked += OnRestartButtonClick;
        _windowGameOver.Button2Clicked += OnAdvertisementButtonClick;
        _windowAdvertisement.AdvertisementFinished += OnAdvertisementFinish;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
        _spawners.ObjectKilled -= _scoreCounter.Add;
        _scoreCounter.Changed -= CalcLevel;
        _levelCounter.Changed -= ChangeLevel;
        _userInput.PauseButtonPressed -= OnPauseButtonClick;
        _windowStart.Button1Clicked -= OnStartButtonClick;
        _windowStart.Button2Clicked -= OnOptionsButtonClick;
        _windowOptions.Button1Clicked -= OnOptionsOkButtonClick;
        _windowGameOver.Button1Clicked -= OnRestartButtonClick;
        _windowGameOver.Button2Clicked -= OnAdvertisementButtonClick;
        _windowAdvertisement.AdvertisementFinished -= OnAdvertisementFinish;
    }

    private void RestartProgress()
    {
        _levelCounter.Reset();
        _scoreCounter.Reset();
    }

    private void ResetCharacters()
    {
        _player.Reset();
        _spawners.Reset();
    }

    private void CalcLevel()
    {
        if(_levelCounter.Value * _scoreLevelMultiplier <= _scoreCounter.Value)
        {
            _levelCounter.Add();
        }
    }

    private void ChangeLevel()
    {
        _spawners.SetLevel(_levelCounter.Value);
    }

    private void OnPauseButtonClick()
    {
        if(_isBossMode)
        {
            _isBossMode = false;
            _windowPause.Hide();
            _masterVolumeMuteTogle.isOn = _masterVolumeMuteTogleState;

            if (_isSomeWindowOpened == false)
            {
                _windowStart.Show();
                _isSomeWindowOpened = true;
            }
        }
        else
        {
            _isBossMode = true;
            _windowPause.Show();
            Stop();
            _masterVolumeMuteTogleState = _masterVolumeMuteTogle.isOn;
            _masterVolumeMuteTogle.isOn = false;
        }
    }

    private void OnStartButtonClick()
    {
        _windowStart.Hide();
        _isSomeWindowOpened = false;
        Run();
    }

    private void OnOptionsButtonClick()
    {
        _windowStart.Hide();
        _windowOptions.Show();
    }

    private void OnOptionsOkButtonClick()
    {
        _windowStart.Show();
        _windowOptions.Hide();
    }

    private void OnGameOver()
    {
        Stop();
        _windowGameOver.Show();
        _isSomeWindowOpened = true;
    }

    private void OnRestartButtonClick()
    {
        _windowGameOver.Hide();
        _windowStart.Show();
        ResetCharacters();
        RestartProgress();
    }

    private void OnAdvertisementButtonClick()
    {
        _windowGameOver.Hide();
        _windowAdvertisement.Show();
        _windowAdvertisement.Play();
    }

    private void OnAdvertisementFinish()
    {
        ResetCharacters();
        _windowAdvertisement.Hide();
        _windowStart.Show();
    }

    private void Run()
    {
        Time.timeScale = 1;
    }

    private void Stop()
    {
        Time.timeScale = 0;
    }
}
