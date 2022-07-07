using UnityEngine;
using UnityEngine.UI;

public class TalkWithCharacter : MonoBehaviour
{
    //�����
    //������ ��� ������ ���������
    private Text _txt;
    private int _curTextInt;
    //������ ��� ����� ���������
    private Text _nameCharacter;
    //��� ���������
    [SerializeField] private string _nameTxt;
    //����� ���������
    [SerializeField] private string[] _textToSay;
    //��� �������, ����� ������ �������������
    [SerializeField] private string _textIsOver;

    //UI
    //�����
    private GameObject _player;
    private PlayerInput _playerInput;
    private Animator _animator;
    [HideInInspector] public GameObject talkPanel;
    private GameObject playerPanel;
    [SerializeField] GameObject _canTalkImg;

    private void Awake()
    {
        _txt = GameObject.Find("TalkText").GetComponent<Text>();
        _nameCharacter = GameObject.Find("CharacterName").GetComponent<Text>();
        talkPanel = GameObject.Find("TalkPanel");
        playerPanel = GameObject.Find("PlayerPanel");
        _player = GameObject.FindGameObjectWithTag("mainPlayer");
        _playerInput = _player.GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        talkPanel.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("mainPlayer"))
            if (Input.GetKeyDown(KeyCode.E))
            {
                Talk();
            }
    }

    private void Talk()
    {
        if(_curTextInt == _textToSay.Length)
        {
            _txt.text = _textIsOver;
            _canTalkImg.SetActive(false);
        } 
        else
        {
            _txt.text = _textToSay[_curTextInt];
            _curTextInt++;
        }
        _nameCharacter.text = _nameTxt;
        playerPanel.SetActive(false);
        talkPanel.SetActive(true);
        _playerInput.enabled = false;
        _player.GetComponent<Animator>().SetBool("isTalking", true);
        _animator.SetTrigger("action");
    }
}
