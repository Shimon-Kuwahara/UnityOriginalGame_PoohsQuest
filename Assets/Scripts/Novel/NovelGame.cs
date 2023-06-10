using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NovelGame
{
    public class NovelGame : MonoBehaviour
    {
        public static NovelGame Instance { get; private set; }

        public UserScriptManager userScriptManager;
        public MainTextController mainTextController;

        // ユーザスクリプトの、今の行の数値。クリック（タップ）のたびに1ずつ増える。
        [System.NonSerialized] public int lineNumber;

        void Awake()
        {
            // これで、別のクラスからGameManagerの変数などを使えるようになる。
            Instance = this;

            lineNumber = 0;
        }
    }
}