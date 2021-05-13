using UnityEngine;
using UnityEngine.Assertions;

namespace InputReader
{
    /// <summary>
    /// default = WASD - JKL
    /// </summary>
    internal class JoyInput : InputReaderKey
    {

        
        public JoyInput()
        {
            _interactKey = KeyCode.JoystickButton0;
            _jumpKey = KeyCode.JoystickButton1;
            _toolKey = KeyCode.JoystickButton2;
            _toolKey = KeyCode.JoystickButton3;
            _xAxis = "Joystick1Horizontal";
            _yAxis = "Joystick1Vertical";
        }
		
        public JoyInput(string xAxis, string yAxis, KeyCode interact, KeyCode jump, KeyCode tool, KeyCode notify)
        {
            _interactKey = interact;
            _jumpKey = jump;
            _toolKey = tool;
            _notifyKey = notify;
            _xAxis = xAxis;
            _yAxis = yAxis;
        }

        
    }
}