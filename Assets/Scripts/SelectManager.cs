using UnityEngine;

public class SelectManager : MonoBehaviour
{
    // 自コンポーネント取得
    private InputManager inputManager;

    // 他コンポーネント取得
    private Transition transition;
    private ColorData colorData;

    void Start()
    {
        inputManager = GetComponent<InputManager>();

        transition = GameObject.FindWithTag("Transition").GetComponent<Transition>();

        // 色データ取得
        colorData = new ColorData();
        colorData.Initialize();
    }

    void Update()
    {
        // 入力情報を最新に更新する
        inputManager.GetAllInput();

        // ステージセレクトに遷移する
        if (inputManager.IsTrgger(inputManager.jump) && !transition.GetIsTransitionNow())
        {
            transition.SetTransition("TitleScene");
        }
    }

    void LateUpdate()
    {
        inputManager.SetIsGetInput();
    }
}
