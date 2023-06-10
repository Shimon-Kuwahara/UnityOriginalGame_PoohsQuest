using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace NovelGame
{
    public class MainTextController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _mainTextObject;
        int _displayedSentenceLength;
        int _sentenceLength;
        float _time;
        float _feedTime;
        public AudioClip bgm;
        public AudioClip sound1;
        AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            Invoke("Bgm", 0.8f);
            _time = 0f;
            _feedTime = 0.05f;

            // 最初の行のテキストを表示、または命令を実行
            string statement = NovelGame.Instance.userScriptManager.GetCurrentSentence();
            if (NovelGame.Instance.userScriptManager.IsStatement(statement))
            {
                NovelGame.Instance.userScriptManager.ExecuteStatement(statement);
                GoToTheNextLine();
            }
            DisplayText();
        }

        private void Bgm()
        {
            audioSource.PlayOneShot(bgm);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("Stage1");
            }

            if(Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("GamePerfect");
            }

            // 文章を１文字ずつ表示する
            _time += Time.deltaTime;
            if (_time >= _feedTime)
            {
                _time -= _feedTime;
                if (!CanGoToTheNextLine())
                {
                    _displayedSentenceLength++;
                    _mainTextObject.maxVisibleCharacters = _displayedSentenceLength;
                }
            }

            // クリックされたとき、次の行へ移動
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if(NovelGame.Instance.lineNumber < 14)
                {
                    if (CanGoToTheNextLine())
                    {
                        audioSource.PlayOneShot(sound1);
                        GoToTheNextLine();
                        DisplayText();
                    }
                    else
                    {
                        _displayedSentenceLength = _sentenceLength;
                    }
                }
            }
        }

        // その行の、すべての文字が表示されていなければ、まだ次の行へ進むことはできない
        public bool CanGoToTheNextLine()
        {
            string sentence = NovelGame.Instance.userScriptManager.GetCurrentSentence();
            _sentenceLength = sentence.Length;
            return (_displayedSentenceLength > sentence.Length);
        }

        // 次の行へ移動
        public void GoToTheNextLine()
        {
            _displayedSentenceLength = 0;
            _time = 0f;
            _mainTextObject.maxVisibleCharacters = 0;
            NovelGame.Instance.lineNumber++;
            string sentence = NovelGame.Instance.userScriptManager.GetCurrentSentence();
            if (NovelGame.Instance.userScriptManager.IsStatement(sentence))
            {
                NovelGame.Instance.userScriptManager.ExecuteStatement(sentence);
                GoToTheNextLine();
            }
        }

        // テキストを表示
        public void DisplayText()
        {
            string sentence = NovelGame.Instance.userScriptManager.GetCurrentSentence();
            _mainTextObject.text = sentence;
        }
    }
}