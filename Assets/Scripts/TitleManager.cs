using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    // 自コンポーネント取得
    private InputManager inputManager;

    // 他コンポーネント取得
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

        // 色データ取得
        colorData = new ColorData();
        colorData.Initialize();
        ColorInitialize(true);
    }

    void Update()
    {
        // 入力情報を最新に更新する
        inputManager.GetAllInput();

        // 色変え
        ChangeColor();
        // 色徐々変え
        ColorStalker();

        // ステージセレクトに遷移する
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
        // 色代入
        GlobalVariables.color1 = colorData.GetMainColor(GlobalVariables.colorNum);
        GlobalVariables.color2 = colorData.GetSubColor(GlobalVariables.colorNum);

        // Startメソッドのみ
        if (_isStart)
        {
            inkImage.color = GlobalVariables.color1;
            inkTargetColor = GlobalVariables.color1;
            titleImage.color = GlobalVariables.color1;
            titleTargetColor = GlobalVariables.color1;
            titleBackImage.color = GlobalVariables.color2;
            titleBackTargetColor = GlobalVariables.color2;
        }
        // それ以外
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
