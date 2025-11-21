using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EmailCollection", menuName = "Email Data/EmailCollection")]
public class EmailCollection : ScriptableObject
{
    public EmailData[] emails;
    private EmailData[] _shuffled;
    private int _remaining;
    public EmailData GetRandom()
    {
        if (_shuffled == null || _shuffled.Length == 0)
        {
            _shuffled = (EmailData[])emails.Clone();
            _remaining = 0;
        }
        if (_remaining == 0)
        {

            _remaining = _shuffled.Length;
        }
        int chosenIndex = Random.Range(0, _remaining);
        _remaining--;
        var chosen = _shuffled[chosenIndex];
        _shuffled[chosenIndex] = _shuffled[_remaining];
        _shuffled[_remaining] = chosen;
        return chosen;
    }
    private void OnValidate()
    {
        _shuffled = null;
    }

}
