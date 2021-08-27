using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    [CreateAssetMenu(menuName = "Game/Dialogue Element")]
    public class DialogueElement : ScriptableObject
    {
        public string nameOfNextDialogue;
        [TextArea(4, 16)]
        public string text;
    }
}