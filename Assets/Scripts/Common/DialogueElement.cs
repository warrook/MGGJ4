using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    [CreateAssetMenu(menuName = "Game/Dialogue Element")]
    public class DialogueElement : ScriptableObject
    {
        public string dialogueKey;
        public string text;
        public string keyForNextDialogue;
    }
}