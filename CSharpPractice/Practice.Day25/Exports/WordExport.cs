using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

using Practice.Day25.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;

namespace Practice.Day25.Exports;

public class WordExport
{
    private Order Order { get; set; }

    public WordExport(Order order) => Order = order;

    public void GenerateContract(string templatePath, string outputFilePath)
    {
        File.Copy(templatePath, outputFilePath, true);

        using WordprocessingDocument doc = WordprocessingDocument.Open(outputFilePath, true);
        MainDocumentPart mainPart = doc.MainDocumentPart!;

        IEnumerable<Text> texts = mainPart.Document.Body!.Descendants<Text>();

        foreach (Text text in texts)
        {
            if (text.Text.Contains("user"))
            {
                text.Text = text.Text.Replace("user", Order.Customer.Name);
            }
            if (text.Text.Contains("item"))
            {
                text.Text = text.Text.Replace("item", Order.Item.Name);
            }
            if (text.Text.Contains("start"))
            {
                text.Text = text.Text.Replace("start", Order.RentalDate.ToShortDateString());
            }
            if (text.Text.Contains("end"))
            {
                text.Text = text.Text.Replace("end", Order.RentalDate.AddDays(Order.RentalDuration).ToString());
            }
            if (text.Text.Contains("count"))
            {
                // Вычисление количества дней между датами
                var start = Order.RentalDate.ToDateTime(new TimeOnly(0));
                var end = Order.RentalDate.AddDays(Order.RentalDuration).ToDateTime(new TimeOnly(0));
                int days = (end - start).Days;

                text.Text = text.Text.Replace("count", days.ToString());
            }
            if (text.Text.Contains("price"))
            {
                text.Text = text.Text.Replace("price", Order.TotalCost.ToString(CultureInfo.InvariantCulture));
            }
            if (text.Text.Contains("shtraf"))
            {
                // Вычисление штрафа за каждый день просрочки
                decimal penaltyAmount = Order.TotalCost * 0.5m;
                text.Text = text.Text.Replace("shtraf", penaltyAmount.ToString(CultureInfo.InvariantCulture));
            }
            
            if (text.Text.Contains("now"))
            {
                text.Text = text.Text.Replace("now", DateTime.Now.ToString());
            }
        }

        MessageBox.Show("Файл успешно сохранён");
    }
}
