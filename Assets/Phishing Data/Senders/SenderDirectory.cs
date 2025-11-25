using UnityEngine;

[CreateAssetMenu(fileName = "SenderDirectory", menuName = "Email Data/SenderDirectory")]
public class SenderDirectory : ScriptableObject
{
    [System.Serializable]
    public class Category
    {
        [HideInInspector]
        public string name;
        public SenderType type;
        public SenderData[] senders;
    }

    public Category[] categories;

    private void OnValidate()
    {
        foreach (var category in categories)
            category.name = category.type.ToString();
    }
}
