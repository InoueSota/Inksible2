using UnityEngine;

public class InputManager : MonoBehaviour
{
    // 基本クラス
    public class InputPattern
    {
        public float input = 0f;
        public float preInput = 0f;

        private bool isGetInput = false;

        public void GetInput(string _inputName)
        {
            if (!isGetInput)
            {
                preInput = input;
                input = Input.GetAxisRaw(_inputName);

                isGetInput = true;
            }
        }
        public void SetIsGetInput(bool _isGetInput)
        {
            isGetInput = _isGetInput;
        }
    }

    // 入力の種類
    public InputPattern horizontal;
    public InputPattern vertical;
    public InputPattern change;
    public InputPattern cancel;
    public InputPattern reset;
    public InputPattern right;
    public InputPattern left;
    public InputPattern menu;
    public InputPattern jump;

    void Start()
    {
        horizontal = new InputPattern();
        vertical = new InputPattern();
        change = new InputPattern();
        cancel = new InputPattern();
        reset = new InputPattern();
        right = new InputPattern();
        left = new InputPattern();
        menu = new InputPattern();
        jump = new InputPattern();
    }

    public void SetIsGetInput()
    {
        horizontal.SetIsGetInput(false);
        vertical.SetIsGetInput(false);
        change.SetIsGetInput(false);
        cancel.SetIsGetInput(false);
        reset.SetIsGetInput(false);
        right.SetIsGetInput(false);
        left.SetIsGetInput(false);
        menu.SetIsGetInput(false);
        jump.SetIsGetInput(false);
    }

    public void GetAllInput()
    {
        horizontal.GetInput("Horizontal");
        vertical.GetInput("Vertical");
        change.GetInput("Change");
        cancel.GetInput("Cancel");
        reset.GetInput("Reset");
        right.GetInput("Right");
        left.GetInput("Left");
        menu.GetInput("Menu");
        jump.GetInput("Jump");
    }

    public bool IsTrgger(InputPattern _inputPattern)
    {
        if (_inputPattern.input != 0f && _inputPattern.preInput == 0f)
        {
            return true;
        }
        return false;
    }

    public bool IsPush(InputPattern _inputPattern)
    {
        if (_inputPattern.input != 0f && _inputPattern.preInput != 0f)
        {
            return true;
        }
        return false;
    }

    public bool IsRelease(InputPattern _inputPattern)
    {
        if (_inputPattern.input == 0f && _inputPattern.preInput != 0f)
        {
            return true;
        }
        return false;
    }

    public float ReturnInputValue(InputPattern _inputPattern)
    {
        return _inputPattern.input;
    }
}
