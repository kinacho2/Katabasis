using UnityEngine;

namespace InputReader
{
	public interface IInputReader
	{
		Vector2 Stick { get; }
		
		bool OnInteract { get; }
		bool Interacting { get; }
        bool OffInteract { get; }

        bool OnJump { get; }
		bool Jumping { get; }
        bool OffJump { get; }

        bool OnTool { get; }
		bool Tooling { get; }
        bool OffTool { get; }

		bool OnNotify{ get; }
		bool Notifing{ get; }
		bool OffNotify{ get; }

		void ButtonInput();

	}
}
