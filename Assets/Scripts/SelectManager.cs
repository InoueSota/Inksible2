using UnityEngine;

public class SelectManager : MonoBehaviour
{
    // ���R���|�[�l���g�擾
    private InputManager inputManager;

    // ���R���|�[�l���g�擾
    private Transition transition;
    private ColorData colorData;

    void Start()
    {
        inputManager = GetComponent<InputManager>();

        transition = GameObject.FindWithTag("Transition").GetComponent<Transition>();

        // �F�f�[�^�擾
        colorData = new ColorData();
        colorData.Initialize();
    }

    void Update()
    {
        // ���͏����ŐV�ɍX�V����
        inputManager.GetAllInput();

        // �X�e�[�W�Z���N�g�ɑJ�ڂ���
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
