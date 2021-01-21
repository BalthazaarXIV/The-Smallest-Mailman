using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DialogueManager : MonoBehaviour
    {
        public TMP_Text nameText;
        public TMP_Text dialogueText;
        private Queue<string> _sentences;

        private void Start()
        {
            _sentences = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            nameText.text = dialogue.name;
            
            _sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                _sentences.Enqueue(sentence);
            }
        }

        public void DisplayNextSentence()
        {
            if (_sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = _sentences.Dequeue();
            dialogueText.text = sentence;
        }
        void EndDialogue()
        {
            Debug.Log("End Of Conversation");
        }
    }
}
