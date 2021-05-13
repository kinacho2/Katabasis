using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputReader
{
    public class AirconsoleController : InputReaderKey
    {
        public AirconsoleController(string xAxis, string yAxis, KeyCode interact, KeyCode jump, KeyCode tool, KeyCode notify)
        {
            _interactKey = jump;
            _jumpKey = interact;
            _toolKey = jump;
            _notifyKey = notify;
            _xAxis = xAxis;
            _yAxis = yAxis;
        }
        private bool _OnInteract;
        private bool _Interacting;
        private bool _OffInteract;
        private bool _OnJump;
        private bool _Jumping;
        private bool _OffJump;
        private bool _OnTool;
        private bool _Tooling;
        private bool _OffTool;
        private bool _OnNotify;
        private bool _Notifing;
        private bool _OffNotify;

        public override bool OnInteract
        {
            get
            {
                if(_OnInteract)
                    _Interacting = true;
                bool toret = _OnInteract;
                _OnInteract = false;
                return toret;
            }
        }

        public override bool Interacting => _Interacting;

        public override bool OffInteract
        {
            get
            {
                bool toret = _OffInteract;
                _OffInteract = false;
                return toret;
            }
        }

        public override bool OnJump 
        {
            get
            {
                if (_OnJump)
                    _Jumping = true;
                bool toret = _OnJump;
                _OnJump = false;
                return toret;
            }
        }

        public override bool Jumping => _Jumping;

        public override bool OffJump
        { 
            get
            {
                bool toret = _OffJump;
                _OffJump = false;
                return toret;
            }
        }

        public override bool OnTool
        {
            get
            {
                if (_OnTool)
                    _Tooling = true;
                bool toret = _OnTool;
                _OnTool = false;
                return toret;
            }
        }

        public override bool Tooling => _Tooling;

        public override bool OffTool
        {
            get
            {
                bool toret = _OffTool;
                _OffTool = false;
                return toret;
            }
        }

        public override bool OnNotify
        {
            get
            {
                if (_OnNotify)
                    _Notifing = true;
                bool toret = _OnNotify;
                _OnNotify = false;
                return toret;
            }
        }

        public override bool Notifing => _Notifing;

        public override bool OffNotify
        {
            get
            {
                bool toret = _OffNotify;
                _OffNotify = false;
                return toret;
            }
        }

        public override void ButtonInput()
        {
            {
                if (Input.GetKeyDown(_jumpKey))
                {
                    _OnJump = true;
                    _Jumping = true;
                }
                if (Input.GetKeyUp(_jumpKey))
                {
                    _OffJump = true;
                    _Jumping = false;
                }
            }
            
            {
                if (Input.GetKeyDown(_interactKey))
                {
                    _OnInteract = true;
                    _OnTool = true;
                    _OffTool = false;
                    _OffInteract = false;
                }
                if (Input.GetKeyUp(_interactKey))
                {
                    _OnInteract = false;
                    _Interacting = false;
                    _OffInteract = true;
                    _OnTool = false;
                    _OffTool = true;
                    _Tooling = false;
                }
            }

            {
                if (Input.GetKeyDown(_notifyKey))
                {
                    _OnNotify = true;
                    _OffNotify = false;
                }
                if (Input.GetKeyUp(_notifyKey))
                {
                    _OnNotify = false;
                    _OffNotify = true;
                    _Notifing = false;
                }
            }

        }
        

    }
}