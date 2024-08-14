using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI Elements")]
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _plinkButton;
    [SerializeField] private Button _plinkBoostButton;
    [SerializeField] private TextMeshProUGUI _currentScoreText, _scoredScoreText;
    [SerializeField] private TMP_FontAsset _greenFont, _redFont;
    [SerializeField] private GameObject _winMenu;

    [Header("Game Elements")]
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _boostBall;
    [SerializeField] private Transform _portal;
    [SerializeField] private Transform _dotsParent;
    [SerializeField] private int[] _levels;
    [SerializeField]
    private GameObject[] _dotsPrefab;
    private GameObject _currentDot;

    [Header("Game Settings")]
    [SerializeField] private float _timeBetweenPlinks = 0.5f;
    private const float _DELTAX = 0.6f;

    private float _currentScore = 0;

    private bool _startCountTime = false;
    private bool StartCountTime
    {
        get { return _startCountTime; }
        set
        {
            _startCountTime = value;
            _plinkButton.interactable = !_startCountTime;
            _plinkBoostButton.interactable = !_startCountTime;
        }
    }

    private float _timer = 0f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        _slider.maxValue = _levels[LevelData.GetCurrentLevel()];
        int currentLevel = LevelData.GetCurrentLevel();
        if (currentLevel < _dotsPrefab.Length)
        {
            _currentDot = _dotsPrefab[currentLevel];
            Instantiate(_currentDot, _dotsParent.position, Quaternion.identity);
        }
        
    }

    private void Update()
    {
        if (StartCountTime)
        {
            if (_timer < _timeBetweenPlinks)
                _timer += Time.deltaTime;
            else
            {
                StartCountTime = false;
                _timer = 0;
            }
        }
    }

    [OPS.Obfuscator.Attribute.DoNotRename]
    public void PlinkButton()
    {
        Vector3 spawnPosition = _portal.position + new Vector3(Random.Range(-_DELTAX, _DELTAX), 0f, 0f);
        Instantiate(_ball, spawnPosition, Quaternion.identity);

        StartCountTime = true;
    }
    
    public void PlinkBoostButton()
    {
        if (ValueManager.GetValueCount() > 1)
        {
            ValueManager.ChangeValueCount(-2);
            Vector3 spawnPosition = _portal.position + new Vector3(Random.Range(-_DELTAX, _DELTAX), 0f, 0f);
            Instantiate(_boostBall, spawnPosition, Quaternion.identity);

            StartCountTime = true;
        }
        else if (ValueManager.GetValueCount() == 0)
        {
            
        }

    }

    public void AddScore(float amount)
    {
        if ((_currentScore + amount) < 0)
        {
            _currentScore = 0;
        }
        else
        {
            _currentScore += Mathf.Round(amount);

            if (_currentScore >= _levels[LevelData.GetCurrentLevel()])
                _winMenu.SetActive(true);
        }

        UpdateUI(amount);
    }

    private void UpdateUI(float amount)
    {
        _currentScoreText.text = _currentScore.ToString();

        _scoredScoreText.font = Mathf.Sign(amount) < 0 ? _redFont : _greenFont;
        _scoredScoreText.text = Mathf.Sign(amount) < 0 ? Mathf.Round(amount).ToString() : "+" + " " + Mathf.Round(amount).ToString();

        _slider.value = _currentScore;
    }
}