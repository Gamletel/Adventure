using UnityEngine;
using UnityEngine.UI;

public class TalkPanelController : MonoBehaviour
{
    private bool _canSkip = false;
    private const float _timeToSkip = 3f;
    private float _curTime;
    [SerializeField] private Image _skipImg;
    private GameObject _player;
    private GameObject _playerPanel;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("mainPlayer");
        _playerPanel = GameObject.Find("PlayerPanel");
        _curTime = _timeToSkip;
    }

    private void FixedUpdate()
    {
        if(gameObject.activeSelf == true)
        {
            _curTime -= Time.deltaTime;
            _skipImg.fillAmount = _curTime / _timeToSkip;
        }
    }

    void Update()
    {
        if (_curTime <= 0)
            _canSkip = true;
        if (Input.GetKeyDown(KeyCode.E) && _canSkip)
        {
            ClosePanel();
        }

    }

    private void ClosePanel()
    {
        _playerPanel.SetActive(true);
        _player.GetComponent<PlayerInput>().enabled = true;
        _player.GetComponent<Animator>().SetBool("isTalking", false);
        _canSkip = false;
        _curTime = _timeToSkip;
        gameObject.SetActive(false);
    }
}
