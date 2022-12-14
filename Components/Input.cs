

namespace TheRift.Components
{
    public enum KeyName
    {
        Left,
        Right,
        Up,
        Down,
        A,
        B,
        X,
        Y,
        L,
        R,
        Start,
        Select
    }

    public class Input : GameComponent
    {

        #region Props

        public KeyCodeList KeyCode;

        private int[] _keyStates;

        public int this[KeyName keyName] => _keyStates[(int)keyName];

        #endregion



        #region Constructor

        /// <summary>
        /// 输入检测组件
        /// </summary>
        /// <param name="keyCode">左右上下; ABXYLR; start, select</param>
        public Input(GameMain game, Keys[] keyCode) : base(game)
        {
            KeyCode = new(keyCode);
            _keyStates = new int[KeyCode.Length];
        }

        #endregion



        #region Methods

        public override void Update(GameTime gameTime)
        {
            KeyboardState key = Keyboard.GetState();

            for (int i = 0; i < _keyStates.Length; i++)
            {
                if (key.IsKeyDown(KeyCode[(KeyName)i]))
                {
                    if (_keyStates[i] < 0) _keyStates[i] = 0;

                    _keyStates[i] += 1;
                }
                else
                {
                    if (_keyStates[i] > 0) _keyStates[i] = 0;

                    _keyStates[i] -= 1;
                };
            };
        }

        /// <summary>
        /// 按键是否被按住
        /// </summary>
        public bool KeyDown(KeyName keyName) => this[keyName] > 0;

        /// <summary>
        /// 按键是否处于按下的一瞬间
        /// </summary>
        public bool KeyPress(KeyName keyName) => this[keyName] == 1;

        /// <summary>
        /// 按键是否没有被按下
        /// </summary>
        public bool KeyUp(KeyName keyName) => this[keyName] < 0;

        /// <summary>
        /// 按键是否处于松开的一瞬间
        /// </summary>
        public bool KeyRelease(KeyName keyName) => this[keyName] == -1;

        #endregion

    }

    public class KeyCodeList
    {
        private Keys[] _keyCodes;

        public Keys this[KeyName keyName] { get => _keyCodes[(int)keyName]; set => _keyCodes[(int)keyName] = value; }

        public int Length => _keyCodes.Length;

        public KeyCodeList(Keys[] keys) => _keyCodes = keys;
    }
}
