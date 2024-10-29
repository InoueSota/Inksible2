using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    // ���R���|�[�l���g�擾
    private InputManager inputManager;

    // ���R���|�[�l���g�擾
    private Transition transition;
    private ColorData colorData;

    [Header("UI")]
    [SerializeField] private float stalkerPower;
    [SerializeField] private Image inkImage;
    private Color inkTargetColor;
    [SerializeField] private Image titleImage;
    private Color titleTargetColor;
    [SerializeField] private Image titleBackImage;
    private Color titleBackTargetColor;

    void Start()
    {
        inputManager = GetComponent<InputManager>();

        transition = GameObject.FindWithTag("Transition").GetComponent<Transition>();

        // �F�f�[�^�擾
        colorData = new ColorData();
        colorData.Initialize();
        ColorInitialize(true);
    }

    void Update()
    {
        // ���͏����ŐV�ɍX�V����
        inputManager.GetAllInput();

        // �F�ς�
        ChangeColor();
        // �F���X�ς�
        ColorStalker();

        // �X�e�[�W�Z���N�g�ɑJ�ڂ���
        if (inputManager.IsTrgger(inputManager.jump) && !transition.GetIsTransitionNow())
        {
            transition.SetTransition("SelectScene");
        }
    }
    void ChangeColor()
    {
        if (inputManager.IsTrgger(inputManager.left))
        {
            if (GlobalVariables.colorNum > 0)
            {
                GlobalVariables.colorNum--;
            }
            else
            {
                GlobalVariables.colorNum = colorData.maxColorNum - 1;
            }
            ColorInitialize(false);
        }
        else if (inputManager.IsTrgger(inputManager.right))
        {
            if (GlobalVariables.colorNum < colorData.maxColorNum - 1)
            {
                GlobalVariables.colorNum++;
            }
            else
            {
                GlobalVariables.colorNum = 0;
            }
            ColorInitialize(false);
        }
    }
    void ColorInitialize(bool _isStart)
    {
        // �F���
        GlobalVariables.color1 = colorData.GetMainColor(GlobalVariables.colorNum);
        GlobalVariables.color2 = colorData.GetSubColor(GlobalVariables.colorNum);

        // Start���\�b�h�̂�
        if (_isStart)
        {
            inkImage.color = GlobalVariables.color1;
            inkTargetColor = GlobalVariables.color1;
            titleImage.color = GlobalVariables.color1;
            titleTargetColor = GlobalVariables.color1;
            titleBackImage.color = GlobalVariables.color2;
            titleBackTargetColor = GlobalVariables.color2;
        }
        // ����ȊO
        else
        {
            inkTargetColor = GlobalVariables.color1;
            titleTargetColor = GlobalVariables.color1;
            titleBackTargetColor = GlobalVariables.color2;
        }
    }
    void ColorStalker()
    {
        float deltaStalkerPower = stalkerPower * Time.deltaTime;

        inkImage.color += (inkTargetColor - inkImage.color) * deltaStalkerPower;
        titleImage.color += (titleTargetColor - titleImage.color) * deltaStalkerPower;
        titleBackImage.color += (titleBackTargetColor - titleBackImage.color) * deltaStalkerPower;
    }

    void LateUpdate()
    {
        inputManager.SetIsGetInput();
    }
}
