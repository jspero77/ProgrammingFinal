using UnityEngine;
using System.Collections.Generic;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;

[CreateAssetMenu(fileName = "importer.asset", menuName = "Email Data/Importer")]

public class DataImporter : ScriptableObject
{
    public string excelPath = "Editor/Emaildata.xlsx";

    [ContextMenu("Import")]
    public void Import()
    {
        var excel = new ExcelImporter(excelPath);
        ImportSenders(excel);
        ImportMessages(excel);
    }

    void ImportSenders(ExcelImporter excel) {
        if (!excel.TryGetTable("Senders", out var senders)){
            Debug.LogError("Failed to find Senders table.");
            return;
        }

        var allSenders = DataHelper.GetAllAssetsOfType<SenderData>();

        for (int row = 1; row <= senders.RowCount; row++)
        {
            string name = senders.GetValue<string>(row, "Name");
            if (string.IsNullOrWhiteSpace(name)) continue;
            var asset = DataHelper.GetOrCreateAsset(name, allSenders, "Phishing Data/Senders");

            if (string.IsNullOrWhiteSpace(asset.displayName))
                asset.displayName = name;

            asset.emailAddress = senders.GetValue<string>(row, "Email");
            if (senders.TryGetEnum<SenderType>(row, "Type", out var type))
            {
                asset.type = type;
            }
        }

        Debug.Log($"Successfully imported {allSenders.Count} senders.");
    }

    void ImportMessages(ExcelImporter excel) {
        
        if (!excel.TryGetTable("Messages", out var table))
        {
            Debug.LogError("Failed to find Messages table.");
            return;
        }
    
        var messages = DataHelper.GetAllAssetsOfType<EmailData>();

        // Find first non-blank row.
        int startRow = GetNextNonBlankRow(0, table, "Message");

        while (startRow <= table.RowCount)
        {
            // Find where the next message starts.
            int next = GetNextNonBlankRow(startRow, table, "Message");
            ImportMessage(startRow, next, table, messages);
            startRow = next;
        }

        Debug.Log($"Successfully imported {messages.Count} messages.");
        foreach(var key in messages.Keys)
        {
            Debug.Log($"Message: '{key}'");
        }
    }


    void ImportMessage(int row, int next, ExcelImporter.Table table, Dictionary<string, EmailData> messages)
    {
        var name = table.GetValue<string>(row, "Message");

        var asset = DataHelper.GetOrCreateAsset(name, messages, "Phishing Data/Messages");

        if (table.TryGetEnum<SenderType>(row, "Sender", out var sender))
            asset.senderType = sender;

        if (table.TryGetEnum<PhishingType>(row, "Phishing Type", out var phish))
            asset.phishingType = phish;

        asset.subjects = GetAllVariants(row, next, table, "Subject");
        asset.greetings = GetAllVariants(row, next, table, "Greeting");
        asset.part1s = GetAllVariants(row, next, table, "Part 1");
    }

    /// <summary>
    /// Searches a table column from startRow to next and puts all non-empty strings into an array.
    /// </summary>
    string[] GetAllVariants(int startRow, int next, ExcelImporter.Table table, string column)
    {
        var entries = new List<string>();
        for (int row = startRow; row < next; row++)
        {
            var value = table.GetValue<string>(row, column);
            if (!string.IsNullOrWhiteSpace(value)) entries.Add(value);
        }    
        return entries.ToArray();
    }


    /// <summary>
    /// Finds the next non-blank row of a table after the one provided.
    /// </summary>
    /// <returns>Next non-blank row index, or table.RowCount+1 if no more non-blank rows found.</returns>
    int GetNextNonBlankRow(int start, ExcelImporter.Table table, string column) {
        int row = start + 1;
        while(row <= table.RowCount 
             && string.IsNullOrWhiteSpace(table.GetValue<string>(row, column)))
             row++;
        return row;            
    }

}
