using System;
using System.IO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using DogBoarding.Models;
using DogBoarding.Infrastructure;

namespace DogBoarding.Services
{
    class InvoicePdfService
    {
        public void CreatePdf(Invoice invoice)
        {
            string filePath = Path.Combine(
                AppPaths.InvoicesDirectory,
                $"{invoice.InvoiceNumber}.pdf"
            );

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(40);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Content()
                        .Column(column =>
                        {
                            column.Spacing(15);

                            BuildHeader(column, invoice);
                            BuildCustomerSection(column, invoice);
                            BuildServiceSection(column, invoice);
                            BuildTotalSection(column, invoice);
                            BuildFooter(column);
                        });
                });
            })
            .GeneratePdf(filePath);
        }

        #region ENTERPRISE NAME 

        //Adapt  Enterprise Name in Header-Method if needed

        #endregion


            #region Methods 

                    private void BuildHeader(ColumnDescriptor column, Invoice invoice)
                    {
                        column.Item().Text("ABC Dog Boarding")
                            .FontSize(20)
                            .Bold();

                        column.Item().Text("Invoice")
                            .FontSize(16)
                            .Bold();

                        column.Item().Text($"Invoice Number: {invoice.InvoiceNumber}");
                        column.Item().Text($"Invoice Date: {invoice.InvoiceDate:dd.MM.yyyy}");
                    }

                    private void BuildCustomerSection(ColumnDescriptor column, Invoice invoice)
                    {
                        column.Item().LineHorizontal(1);

                        column.Item().Text("Customer:")
                            .Bold();

                        column.Item().Text(invoice.Booking.Dog.OwnerName);
                        column.Item().Text(
                            $"Dog: {invoice.Booking.Dog.DogName} ({invoice.Booking.Dog.DogWeight} lbs)"
                        );
                    }

                    private void BuildServiceSection(ColumnDescriptor column, Invoice invoice)
                    {
                        column.Item().LineHorizontal(1);

                        column.Item().Text("Service Period:")
                            .Bold();

                        column.Item().Text($"From: {invoice.Booking.StartDate:dd.MM.yyyy}");
                        column.Item().Text($"To: {invoice.Booking.EndDate:dd.MM.yyyy}");
                        column.Item().Text($"Days: {invoice.Booking.DaysBooked}");
                    }

                    private void BuildTotalSection(ColumnDescriptor column, Invoice invoice)
                    {
                        column.Item().LineHorizontal(1);

                        column.Item()
                            .Row(row =>
                            {
                                row.RelativeItem().Text("Net Amount:")
                                    .Bold();

                                row.ConstantItem(120)
                                    .AlignRight()
                                    .Text($"{invoice.Amount:F2} €")
                                    .Bold();
                            });

                        column.Item().Text($"Invoice Status: {invoice.Status}");
                    }

                    private void BuildFooter(ColumnDescriptor column)
                    {
                        column.Item().LineHorizontal(1);
                        column.Item().Text("Thank you for your trust!");
                    }

            #endregion
    }
}








            

        
