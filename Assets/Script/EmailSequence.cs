using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;

[CreateAssetMenu(fileName = "EmailSequence", menuName = "Email Data/EmailSequence")]
public class EmailSequence : ScriptableObject
{
    [System.Serializable]
    public class Pull {
        public EmailCollection collection;
        public int count;

    }
    [System.Serializable]
    public class Block
    {
        public List<Pull> pulls;
        public bool shuffle;

    }

    public List<Block> blocks;

    public void GetSequence(List<EmailData> list)
    {
        list.Clear();
        foreach (var block in blocks)
        {
            int startIndex = list.Count;
            foreach (var pull in block.pulls)
            {
                for (int i = 0; i < pull.count; i++)
                {
                    list.Add(pull.collection.GetRandom());

                }

            }
            if (block.shuffle)
            {
                for (int i = list.Count - 1; i > startIndex; i--)
                {
                    int swapIndex = Random.Range(startIndex, i + 1);
                    var swap = list[swapIndex];
                    list[swapIndex] = list[i];
                    list[i] = swap;
                }
            }
        }
        
    }

}
