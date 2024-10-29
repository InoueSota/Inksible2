using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    // ��{���
    private static Transition instance;

    // �J�ڐ�
    private string nextSceneName;

    // �t���O��
    private bool isTransition;
    private bool isTransitionNow;

    [Header("���I�u�W�F�N�g�擾")]
    [SerializeField] private Camera secondaryCamera;

    [Header("�㖋")]
    [SerializeField] private GameObject topObj;
    [SerializeField] private SpriteRenderer topSpriteRenderer;
    [SerializeField] private Vector3 topFirstPosition;
    [SerializeField] private Vector3 topSecondPosition;
    [SerializeField] private Ease topEase;

    [Header("����")]
    [SerializeField] private GameObject downObj;
    [SerializeField] private SpriteRenderer downSpriteRenderer;
    [SerializeField] private Vector3 downFirstPosition;
    [SerializeField] private Vector3 downSecondPosition;
    [SerializeField] private Ease downEase;

    [Header("������")]
    [SerializeField] private GameObject centerObj;
    [SerializeField] private Vector3 centerFirstScale;
    [SerializeField] private Vector3 centerSecondScale;
    [SerializeField] private Ease centerEase;

    [Header("�уe�L�X�g")]
    [SerializeField] private SpriteRenderer centerText;
    [SerializeField] private Color textFirstColor;
    [SerializeField] private Color textSecondColor;
    [SerializeField] private Ease textEase;

    [Header("�C�[�W���O")]
    [SerializeField] private float easeTime;

    void Awake()
    {
        // �V�[�����؂�ւ���Ă��I�u�W�F�N�g��ێ�����v���O����
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        isTransition = false;

        if (GameObject.FindWithTag("Transition"))
        {
            if (GameObject.FindWithTag("Transition") != gameObject)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnEnable()
    {
        // �V�[���ǂݍ���
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        // �V�[���ǂݍ���
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �V�[�������[�h���ꂽ��̓�����ĊJ
        if (isTransition)
        {
            DoTransition();
        }
    }

    void Update()
    {
        if (isTransition)
        {
            DoTransition();
        }
        if (Camera.main != null && Camera.main.GetUniversalAdditionalCameraData().cameraStack.Count == 0)
        {
            // �J�����ǉ�����
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(secondaryCamera);
        }
    }
    void DoTransition()
    {
        isTransitionNow = true;

        // �F�ς�
        topSpriteRenderer.color = GlobalVariables.color1;
        downSpriteRenderer.color = GlobalVariables.color2;

        centerText.DOColor(textFirstColor, easeTime).SetEase(textEase);
        centerObj.transform.DOScale(centerFirstScale, easeTime).SetEase(centerEase);
        downObj.transform.DOLocalMove(downFirstPosition, easeTime).SetEase(downEase);
        topObj.transform.DOLocalMove(topFirstPosition, easeTime).SetEase(topEase).OnComplete(() =>
        {
            // �����ŉ�ʐ؂�ւ�鏈��(��ʑJ�ڂŉ�ʂ������ĂȂ��ꏊ)
            SceneManager.LoadScene(nextSceneName);
            centerText.DOColor(textSecondColor, easeTime).SetEase(textEase);
            centerObj.transform.DOScale(centerSecondScale, easeTime).SetEase(centerEase);
            downObj.transform.DOLocalMove(downSecondPosition, easeTime).SetEase(downEase);
            topObj.transform.DOLocalMove(topSecondPosition, easeTime).SetEase(topEase).OnComplete(() =>
            {
                // ��ʑJ�ڂ�����
                isTransitionNow = false;
            });
        });

        isTransition = false;
    }

    // Setter
    public void SetTransition(string name)
    {
        isTransition = true;
        nextSceneName = name;
    }

    // Getter
    public bool GetIsTransitionNow()
    {
        return isTransitionNow;
    }
}
