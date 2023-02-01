using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlQuest : MonoBehaviour
{
    [Serializable]
    public class Soal
    {
        [Serializable]
        public class ElementSoal
        {
            [TextArea]
            public string soal; //* soal
            public string[] jawabans; //* array untuk jawaban
            public int jawabanBenar; //* angka array dari jawabans yang merupakan jawaban benar
        }
        public ElementSoal elementSoal;
    }

    public List<Soal> soals;
}
