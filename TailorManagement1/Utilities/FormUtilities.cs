using NLog;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace TailorManagement1.Utilities
{
    public static class FormUtilities
    {
        private static readonly Logger logger = Utilities.LoggerUtilities.GetLogger();

        public static void FormKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Form form = sender as Form;                    
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (form.ActiveControl is CheckedListBox)
                    {
                        CheckedListBox activeControl = (CheckedListBox)form.ActiveControl;
                        SendKeys.Send(" ");

                        if (activeControl.SelectedIndex == activeControl.Items.Count - 1)
                        {
                            if (activeControl.GetItemChecked(activeControl.SelectedIndex))
                            {
                                SendKeys.Send(" ");
                                SendKeys.Send("{TAB}");
                            }
                        }
                        e.Handled = true;
                    }
                    else if (form.ActiveControl is TextBox || form.ActiveControl is RichTextBox
                        || form.ActiveControl is DateTimePicker || form.ActiveControl is MaskedTextBox)
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                else if (char.IsLower(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }
                
        public static void GetAllLabelsAndButtons(Control control)
        {
            foreach (Control subControl in control.Controls)
            {
                if (subControl is Label)
                {
                    Label lbl = (Label)subControl;
                    Console.WriteLine($"{lbl.Name.ToLower()}\t{lbl.Text}");
                }
                else if (subControl is Button)
                {
                    Button btn = (Button)subControl;
                    Console.WriteLine($"{btn.Name.ToLower()}\t{btn.Text}");
                }
                else if (subControl is Panel)
                {
                    GetAllLabelsAndButtons(subControl);
                }
            }
        }

        public static void NumericControlKeyPress(object sender, KeyPressEventArgs e, bool isWholeNumber= false)
        {
            try
            {
                TextBox textBox = (TextBox)sender;
                string value = textBox.Text;

                if (e.KeyChar == (char)Keys.Enter)
                    return;

                // Allow digits, backspace, delete, left arrow, and right arrow
                if (!(char.IsDigit(e.KeyChar) ||
                      e.KeyChar == '\b' ||  // Backspace
                      e.KeyChar == '\u007F' ||  // Delete
                      e.KeyChar == (char)Keys.Left ||  // Left arrow
                      e.KeyChar == (char)Keys.Right ||  // Right arrow
                      (!isWholeNumber && e.KeyChar == '.' && !value.Contains("."))))  // Decimal point (dot)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

        public static void NumericControlLeave(object sender, EventArgs e, bool isWholeNumber = false)
        {
            TextBox textBox = (TextBox)sender;
            try
            {
                string value = textBox.Text;
                if (isWholeNumber)
                {
                    textBox.Text = "0";
                }
                else
                {
                    textBox.Text = "0.00";
                }
                if (decimal.TryParse(value, out decimal numericValue))
                {
                    if (isWholeNumber)
                    {
                        textBox.Text = Convert.ToInt32(numericValue).ToString();
                    }
                    else
                    {
                        textBox.Text = numericValue.ToString("F2");
                    }
                }                
            }
            catch (Exception ex)
            {
                logger.Error($"{ex}");
            }
        }

    }
}
