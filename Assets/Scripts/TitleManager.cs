using UnityEditor.SceneManagement;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // 自コンポーネント取得
    private InputManager inputManager;

    private enum State
    {
        BEFORE,
        AFTER
    }
    private State state = State.BEFORE;

    [Header("UI")]
    [SerializeField] private GameObject pushAObj;
    [SerializeField] private GameObject playObj;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        // 入力情報を最新に更新する
        inputManager.GetAllInput();

        switch (state)
        {
            case State.BEFORE:

                if (inputManager.IsTrgger(inputManager.jump))
                {
                    ToAfter();
                    state = State.AFTER;
                }

                break;
            case State.AFTER:

                if (inputManager.IsTrgger(inputManager.cancel))
                {
                    ToBefore();
                    state = State.BEFORE;
                }

                break;
        }
    }
    void ToAfter()
    {
        // False
        pushAObj.SetActive(false);

        // True
        playObj.SetActive(true);
    }
    void ToBefore()
    {
        // False
        playObj.SetActive(false);

        // True
        pushAObj.SetActive(true);
    }

    void LateUpdate()
    {
        inputManager.SetIsGetInput();
    }
}
