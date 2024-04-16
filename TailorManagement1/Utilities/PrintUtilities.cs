using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TailorManagementModels;

namespace TailorManagement1.Utilities
{
    public static class PrintUtilities
    {
        public static void PrintBill(Bill bill, Graphics graphics)
        {
            Font bodyFont = new Font("Arial", 14, FontStyle.Bold);
            Pen blackPen = new Pen(Color.Black);

            Font headerFont = new Font("Arial", 13, FontStyle.Regular);

            Brush redBrush = new SolidBrush(Color.Red);
            Brush blackBrush = new SolidBrush(Color.Black);

            Pen redPen = new Pen(Color.Red, 1);
            Pen darkPen = new Pen(Color.Black, 1);
            Pen lightPen = new Pen(Color.LightGray, 1);

            int sqaureWidth = 410;
            int sqaureHeight = 410;
            int margin = 10;
            int pageLeftPos = 10;
            int pageTopPos = 50;
            int textHeight = 25;
            int lineLeftPosStart = pageLeftPos + 100;
            int lineLeftPosEnd = pageLeftPos + 390;

            //=================Left Square Pant Section========================
            int topPos = pageTopPos;
            int leftPos = pageLeftPos;
            graphics.DrawRectangle(darkPen, leftPos, topPos, sqaureWidth, sqaureHeight);

            leftPos = leftPos + margin;
            topPos = topPos + margin;
            graphics.DrawString("Name:", headerFont, redBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Customer.Name, headerFont, blackBrush, new PointF(lineLeftPosStart, topPos));
            topPos = topPos + textHeight;
            graphics.DrawLine(redPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("Del. Date:", headerFont, redBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.DeliveryDate.ToString("dd/MM/yyyy"), headerFont, blackBrush, new PointF(lineLeftPosStart, topPos));
            topPos = topPos + textHeight;
            graphics.DrawLine(redPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("Pant:", headerFont, redBrush, new PointF(leftPos, topPos));
            graphics.DrawString("BillNo:", headerFont, redBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.BillNo.ToString(), headerFont, redBrush, new PointF(leftPos + 330, topPos));
            topPos = topPos + textHeight;
            graphics.DrawLine(redPen, leftPos + 320, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("Lambai", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Pant.Length1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Pant.Length2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Pant.Length3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Pant.Length4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Pant.Length5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("Kamar", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Pant.Kamar1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Pant.Kamar2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Pant.Kamar3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Pant.Kamar4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Pant.Kamar5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("seat", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Pant.Seat1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Pant.Seat2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Pant.Seat3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Pant.Seat4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Pant.Seat5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("jangh", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Pant.Jangh1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Pant.Jangh2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Pant.Jangh3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Pant.Jangh4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Pant.Jangh5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("gothan", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Pant.Gothan1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Pant.Gothan2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Pant.Gothan3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Pant.Gothan4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Pant.Gothan5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("jolo", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Pant.Jolo1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Pant.Jolo2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Pant.Jolo3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Pant.Jolo4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Pant.Jolo5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("moli", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Pant.Moli1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Pant.Moli2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Pant.Moli3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Pant.Moli4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Pant.Moli5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;

            topPos = topPos + margin;
            graphics.DrawString("Notes", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Pant.Notes, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);
            //==========================================================

            //=================Right Square Shirt Section========================
            leftPos = pageLeftPos + sqaureWidth + margin;
            topPos = pageTopPos;
            lineLeftPosStart = leftPos + 100;
            lineLeftPosEnd = leftPos + 390;

            graphics.DrawRectangle(darkPen, leftPos, topPos, sqaureWidth, sqaureHeight);

            leftPos = leftPos + margin;
            topPos = topPos + margin;
            graphics.DrawString("Name:", headerFont, redBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Customer.Name, headerFont, blackBrush, new PointF(lineLeftPosStart, topPos));
            topPos = topPos + textHeight;
            graphics.DrawLine(redPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("Del. Date:", headerFont, redBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.DeliveryDate.ToString("dd/MM/yyyy"), headerFont, blackBrush, new PointF(lineLeftPosStart, topPos));
            topPos = topPos + textHeight;
            graphics.DrawLine(redPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("Shirt:", headerFont, redBrush, new PointF(leftPos, topPos));
            graphics.DrawString("BillNo:", headerFont, redBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.BillNo.ToString(), headerFont, redBrush, new PointF(leftPos + 330, topPos));
            topPos = topPos + textHeight;
            graphics.DrawLine(redPen, leftPos + 320, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("Lambai", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Shirt.Length1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Shirt.Length2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Shirt.Length3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Shirt.Length4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Shirt.Length5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("Chati", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Shirt.Chati1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Shirt.Chati2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Shirt.Chati3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Shirt.Chati4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Shirt.Chati5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("Solder", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Shirt.Solder1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Shirt.Solder2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Shirt.Solder3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Shirt.Solder4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Shirt.Solder5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("Bye", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Shirt.Bye1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Shirt.Bye2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Shirt.Bye3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Shirt.Bye4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Shirt.Bye5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("Front", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Shirt.Front1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Shirt.Front2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Shirt.Front3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Shirt.Front4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Shirt.Front5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("Color", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Shirt.Kolor1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Shirt.Kolor2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Shirt.Kolor3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Shirt.Kolor4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Shirt.Kolor5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);

            topPos = topPos + margin;
            graphics.DrawString("Cuff", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Shirt.Cuff1, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString(bill.Shirt.Cuff2, headerFont, blackBrush, new PointF(leftPos + 150, topPos));
            graphics.DrawString(bill.Shirt.Cuff3, headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.Shirt.Cuff4, headerFont, blackBrush, new PointF(leftPos + 250, topPos));
            graphics.DrawString(bill.Shirt.Cuff5, headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            topPos = topPos + textHeight;

            topPos = topPos + margin;
            graphics.DrawString("Notes", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Shirt.Notes, headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            //graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);
            //================================================================================

            //========================Bill and Customer Section===============================

            topPos = pageTopPos + sqaureHeight + margin;
            leftPos = pageLeftPos;
            int imageWidth = 800 + 3 * margin;
            int imageHeight = 150;

            Image image = Image.FromFile(@"C:\Rakesh\RajMenswearLogo.png");
            graphics.DrawImage(image, new Rectangle(leftPos, topPos, imageWidth, imageHeight));

            topPos = topPos + imageHeight + margin;
            sqaureHeight = 280;
            sqaureWidth = sqaureWidth * 2 + margin;
            lineLeftPosStart = pageLeftPos + 100;
            lineLeftPosEnd = pageLeftPos + 390;

            graphics.DrawRectangle(darkPen, leftPos, topPos, sqaureWidth, sqaureHeight);

            leftPos = leftPos + margin;
            topPos = topPos + margin;
            sqaureWidth = 600;
            sqaureHeight = 80;
            graphics.DrawRectangle(darkPen, leftPos, topPos, sqaureWidth, sqaureHeight);

            leftPos = leftPos + sqaureWidth + margin;
            sqaureWidth = 200;
            graphics.DrawRectangle(darkPen, leftPos, topPos, sqaureWidth, sqaureHeight);

            leftPos = leftPos + margin;
            topPos = topPos + margin;
            graphics.DrawString("Bill No:", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.BillNo.ToString(), headerFont, redBrush, new PointF(leftPos + 70, topPos));

            leftPos = pageLeftPos + 2 * margin;
            graphics.DrawString("Name:", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Customer.Name, headerFont, blackBrush, new PointF(lineLeftPosStart, topPos));

            graphics.DrawString("Bok. Date:", headerFont, blackBrush, new PointF(leftPos + lineLeftPosEnd, topPos));
            graphics.DrawString(bill.BillDate.ToString("dd/MM/yyyy"), headerFont, blackBrush, new PointF(lineLeftPosStart + lineLeftPosEnd, topPos));

            topPos = topPos + textHeight;
            graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);
            graphics.DrawLine(blackPen, lineLeftPosStart + lineLeftPosEnd, topPos, lineLeftPosEnd + (lineLeftPosEnd / 2), topPos);

            topPos = topPos + margin;
            graphics.DrawString("Mobile:", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString(bill.Customer.Mobile, headerFont, blackBrush, new PointF(lineLeftPosStart, topPos));

            graphics.DrawString("Del. Date:", headerFont, blackBrush, new PointF(leftPos + lineLeftPosEnd, topPos));
            graphics.DrawString(bill.DeliveryDate.ToString("dd/MM/yyyy"), headerFont, blackBrush, new PointF(lineLeftPosStart + lineLeftPosEnd, topPos));
            topPos = topPos + textHeight;
            graphics.DrawLine(blackPen, lineLeftPosStart, topPos, lineLeftPosEnd, topPos);
            graphics.DrawLine(blackPen, lineLeftPosStart + lineLeftPosEnd, topPos, lineLeftPosEnd + (lineLeftPosEnd / 2), topPos);
            //================================================================================

            topPos = topPos + textHeight;
            leftPos = pageLeftPos + margin;
            sqaureHeight = 165;
            sqaureWidth = 800 + margin;
            graphics.DrawRectangle(darkPen, leftPos, topPos, sqaureWidth, sqaureHeight);

            leftPos = pageLeftPos + margin;
            topPos = topPos + margin;
            graphics.DrawString("Vigat", headerFont, blackBrush, new PointF(leftPos, topPos));
            graphics.DrawString("Qty", headerFont, blackBrush, new PointF(leftPos + 100, topPos));
            graphics.DrawString("Rate", headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString("Total", headerFont, blackBrush, new PointF(leftPos + 300, topPos));

            int decimalPlaces = 2;
            foreach (BillDetail billDetail in bill.BillDetails)
            {
                topPos = topPos + textHeight;
                //graphics.DrawLine(blackPen, leftPos, topPos, leftPos + 400, topPos);
                graphics.DrawString(billDetail.Product.Name, headerFont, blackBrush, new PointF(leftPos, topPos));
                graphics.DrawString(billDetail.Qty.ToString(), headerFont, blackBrush, new PointF(leftPos + 100, topPos));
                graphics.DrawString(billDetail.Price.ToString($"0.{new string('0', decimalPlaces)}"), headerFont, blackBrush, new PointF(leftPos + 200, topPos));
                decimal total = billDetail.Qty * billDetail.Price;
                graphics.DrawString(total.ToString($"0.{new string('0', decimalPlaces)}"), headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            }

            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, leftPos, topPos, leftPos + 400, topPos);
            graphics.DrawString("Total", headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.TotalAmount.ToString($"0.{new string('0', decimalPlaces)}"), headerFont, blackBrush, new PointF(leftPos + 300, topPos));
            
            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, leftPos, topPos, leftPos + 400, topPos);
            graphics.DrawString("Advance", headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.PaidAmount.ToString($"0.{new string('0', decimalPlaces)}"), headerFont, blackBrush, new PointF(leftPos + 300, topPos));

            topPos = topPos + textHeight;
            //graphics.DrawLine(blackPen, leftPos, topPos, leftPos + 400, topPos);
            graphics.DrawString("Due", headerFont, blackBrush, new PointF(leftPos + 200, topPos));
            graphics.DrawString(bill.DueAmount.ToString($"0.{new string('0', decimalPlaces)}"), headerFont, blackBrush, new PointF(leftPos + 300, topPos));

            topPos = topPos + textHeight + 2 * margin;
            leftPos = pageLeftPos;
            imageWidth = 800 + 3 * margin;
            imageHeight = 150;

            image = Image.FromFile(@"C:\Rakesh\RajMenswearFooter.png");
            graphics.DrawImage(image, new Rectangle(leftPos, topPos, imageWidth, imageHeight));

            //================================================================================
            darkPen.Dispose();
            lightPen.Dispose();
        }
    }
}
