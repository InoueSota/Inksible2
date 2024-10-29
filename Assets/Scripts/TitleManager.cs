using UnityEditor.SceneManagement;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // ���R���|�[�l���g�擾
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
        // ���͏����ŐV�ɍX�V����
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
