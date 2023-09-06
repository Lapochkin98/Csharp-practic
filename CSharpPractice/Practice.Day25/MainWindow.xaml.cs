using Microsoft.EntityFrameworkCore;
using Practice.Day25.Entities;
using Practice.Day25.Enums;
using Practice.Day25.Exports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Controls;
using OfficeOpenXml.Style;

namespace Practice.Day25;

public partial class MainWindow
{
    private AppDbContext DbContext { get; set; } = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    public void RefreshRentalItemList()
    {
        rentalItemList.ItemsSource = null;
        rentalItemList.ItemsSource = DbContext.Items.ToList();
    }

    public void RefreshClientsItemList()
    {
        clientList.ItemsSource = null!;
        clientList.ItemsSource = DbContext.Customers.ToList();
    }

    public void RefreshOrderItemList()
    {
        orderList.ItemsSource = null!;
        orderList.ItemsSource = DbContext.Orders.Include(o => o.Customer).ToList();
    }

    private void AddRentalItem_Click(object sender, RoutedEventArgs e)
    {
        var status = ItemStatus.Available;

        if (rentalItemStatus.Text == "Rented")
            status = ItemStatus.Rented;

        if (string.IsNullOrWhiteSpace(rentalItemStatus.Text))
            return;

        if (string.IsNullOrWhiteSpace(rentalItemName.Text))
            return;

        if (string.IsNullOrEmpty(rentalItemPrice.Text)) return;

        var item = new Item() { Name = rentalItemName.Text, Price = decimal.Parse(rentalItemPrice.Text), Status = ItemStatus.Rented };
        DbContext.Items.Add(item);
        DbContext.SaveChanges();
        RefreshRentalItemList();
    }

    private void DeleteRentalItem_Click(object sender, RoutedEventArgs e)
    {
        if (rentalItemList.SelectedItem == null)
            return;

        var selectedItem = rentalItemList.SelectedItem as Item;
        DbContext.Items.Remove(selectedItem!);
        DbContext.SaveChanges();
        RefreshRentalItemList();
    }

    private void EditRentalItem_Click(object sender, RoutedEventArgs e)
    {
        var selectedItem = rentalItemList.SelectedItem as Item;
        selectedItem.Name = rentalItemName.Text;
        selectedItem.Price = decimal.Parse(rentalItemPrice.Text);
        DbContext.SaveChanges();
        RefreshRentalItemList();
    }

    // Client Events
    private void AddClient_Click(object sender, RoutedEventArgs e)
    {
        var item = new Customer() { Name = clientName.Text, Phone = clientPhone.Text, PassportNumber = clientPassportNumber.Text };
        DbContext.Customers.Add(item);  
        DbContext.SaveChanges();
        RefreshClientsItemList();
    }

    private void DeleteClient_Click(object sender, RoutedEventArgs e)
    {
        if (clientList.SelectedItem == null)
            return;

        var selectedItem = clientList.SelectedItem as Customer;
        DbContext.Customers.Remove(selectedItem!);
        DbContext.SaveChanges();
        RefreshClientsItemList();
    }

    private void EditClient_Click(object sender, RoutedEventArgs e)
    {
        var selected = clientList.SelectedItem as Customer;
        selected.Name = clientName.Text;
        selected.PassportNumber = clientPassportNumber.Text;
        selected.Phone = clientPhone.Text;
        DbContext.SaveChanges();
        RefreshClientsItemList();
    }

    // Order Events
    private void AddOrder_Click(object sender, RoutedEventArgs e)
    {
        var item_id = orderItemId.Text;

        if (string.IsNullOrEmpty(item_id))
            return;

        var item = DbContext.Items.FirstOrDefault(i => i.Id == int.Parse(item_id));
        if (item == null) return;
        
        if (item.Status == ItemStatus.Rented)
        {
            MessageBox.Show("Данный товар уже арендован");
            return;
        }

        item.Status = ItemStatus.Rented;

        var date = orderRentalDate.SelectedDate!.Value;
        var order = new Order() { CustomerId = int.Parse(orderClientId.Text), ItemId = int.Parse(orderItemId.Text), 
            RentalDate = DateOnly.FromDateTime(date), RentalDuration = int.Parse(orderRentalDuration.Text), TotalCost = int.Parse(orderRentalDuration.Text) * item.Price };
        DbContext.Orders.Add(order);  
        DbContext.SaveChanges();
        RefreshRentalItemList();
        RefreshOrderItemList();
    }

    private void DeleteOrder_Click(object sender, RoutedEventArgs e)
    {
        if (orderList.SelectedItem == null)
            return;

        var selectedItem = orderList.SelectedItem as Order;
        var item = DbContext.Items.FirstOrDefault(i => i.Id == selectedItem!.ItemId);
        item!.Status = ItemStatus.Available;
        DbContext.Orders.Remove(selectedItem!);
        DbContext.SaveChanges();
        RefreshRentalItemList();
        RefreshOrderItemList();
    }

    private void EditOrder_Click(object sender, RoutedEventArgs e)
    {
        var selected = orderList.SelectedItem as Order;
        selected.RentalDate = DateOnly.FromDateTime(orderRentalDate.SelectedDate.Value);
        selected.RentalDuration = int.Parse(orderRentalDuration.Text);
        selected.TotalCost = decimal.Parse(orderTotalCost.Text);
        DbContext.SaveChanges();
        RefreshOrderItemList();

    }

    private void orderList_Initialized(object sender, System.EventArgs e)
    {        
        orderList.ItemsSource = DbContext.Orders.ToList();
    }

    private void clientList_Initialized(object sender, System.EventArgs e)
    {
        
        clientList.ItemsSource = DbContext.Customers.ToList();
    }

    private void rentalList_Initialized(object sender, System.EventArgs e)
    {
        rentalItemList.ItemsSource = DbContext.Items.ToList();
    }

    //Selection Changed
    private void RentalItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = rentalItemList.SelectedItem as Item;
        if (selectedItem != null)
        {
            rentalItemId.Text = selectedItem.Id.ToString();
            rentalItemName.Text = selectedItem.Name;
            rentalItemPrice.Text = selectedItem.Price.ToString();
            rentalItemStatus.Text = selectedItem.Status.ToString();
        }
    }

    private void clientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = clientList.SelectedItem as Customer;
        if (selectedItem != null)
        {   
            clientId.Text = selectedItem.Id.ToString();
            clientName.Text = selectedItem.Name;
            clientPhone.Text = selectedItem.Phone;
            clientPassportNumber.Text = selectedItem.PassportNumber;
        }
    }

    private void orderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = orderList.SelectedItem as Order;
        if (selectedItem != null)
        {
            orderId.Text = selectedItem.Id.ToString();
            orderClientId.Text = selectedItem.CustomerId.ToString();
            orderItemId.Text = selectedItem.ItemId.ToString();
            orderRentalDate.Text = selectedItem.RentalDate.ToString();
            orderRentalDuration.Text = selectedItem.RentalDuration.ToString();
            orderTotalCost.Text = selectedItem.TotalCost.ToString();
        }

        wordExport.IsEnabled = true;
        excelExport.IsEnabled = true;
    }

    private void orderListSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        
    }

    private void rentalItemSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        var box = sender as TextBox;

        if (string.IsNullOrWhiteSpace(box!.Text))
            RefreshRentalItemList();

        rentalItemList.ItemsSource = null;
        rentalItemList.ItemsSource = DbContext.Items.Where(i => i.Name.ToLower().Contains(box!.Text.ToLower())).ToList();
    }

    private void clientListSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        var box = sender as TextBox;

        if (string.IsNullOrWhiteSpace(box!.Text))
            RefreshClientsItemList();

        clientList.ItemsSource = null;
        clientList.ItemsSource = DbContext.Customers.Where(i => i.Name.ToLower().Contains(box!.Text.ToLower())).ToList();
    }

    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void wordExportButton_Click(object sender, RoutedEventArgs e)
    {
        var order = DbContext.Orders.Include(o => o.Customer).Include(o => o.Item)
            .FirstOrDefault(o => o.Id == int.Parse(orderId.Text));

        var export = new WordExport(order!);

        export.GenerateContract("Templates/template.docx", $"{order!.Id} - {DateTime.Now.ToShortTimeString().Replace(":", ".")}.docx");
    }
    
    private void excelExportButton_Click(object sender, RoutedEventArgs e)
    {
        var orders = DbContext.Orders.ToList();
        ExportToExcel(orders, $"{DateTime.Now.ToString().Replace(":", ".")}.xlsx");
        MessageBox.Show("Успешно");
    }
    
    public void ExportToExcel(List<Order> orders, string filePath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage())
        {

            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Orders");
            worksheet.Cells[1, 1].Value = "Id";
            worksheet.Cells[1, 2].Value = "ItemName";
            worksheet.Cells[1, 3].Value = "ItemId";
            worksheet.Cells[1, 4].Value = "CustomerId";
            worksheet.Cells[1, 5].Value = "CustomerName";
            worksheet.Cells[1, 6].Value = "RentalDate";
            worksheet.Cells[1, 7].Value = "RentalDuration";
            worksheet.Cells[1, 8].Value = "TotalCost";


            using (var range = worksheet.Cells[1, 1, 1, 6])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
            }

            for (int i = 0; i < orders.Count; i++)
            {
                Order order = orders[i];
                worksheet.Cells[i + 2, 1].Value = order.Id;
                worksheet.Cells[i + 2, 2].Value = order.Item.Name;
                worksheet.Cells[i + 2, 3].Value = order.ItemId;
                worksheet.Cells[i + 2, 4].Value = order.CustomerId;
                worksheet.Cells[i + 2, 5].Value = order.Customer.Name;
                worksheet.Cells[i + 2, 6].Value = order.RentalDate.ToString("yyyy-MM-dd");
                worksheet.Cells[i + 2, 7].Value = order.RentalDuration;
                worksheet.Cells[i + 2, 8].Value = order.TotalCost;
            }

            worksheet.Cells.AutoFitColumns(0);

            package.SaveAs(new FileInfo(filePath));
        }
    }

    private void orderRentalDuration_TextChanged(object sender, TextChangedEventArgs e)
    {
        var item_id = orderItemId.Text;

        if (string.IsNullOrEmpty(item_id))
            return;

        var item = DbContext.Items.FirstOrDefault(i => i.Id == int.Parse(item_id));
        if (item == null) return;

        if (string.IsNullOrEmpty(orderRentalDuration.Text))
            return;
        orderTotalCost.Text = (item.Price * int.Parse(orderRentalDuration.Text)).ToString();
    }
    
}