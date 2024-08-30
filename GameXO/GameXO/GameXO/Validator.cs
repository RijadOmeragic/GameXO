using System.Windows.Forms;

namespace GameXO
{
    public class Validator
    {
        public static bool ValidateControl(Control control, ErrorProvider err, string message)   
        {
            bool valid = true;
            if (control is TextBox && string.IsNullOrWhiteSpace(control.Text))
                valid = false;
         

            if (valid == false)
            {
                err.SetError(control, message);
                return false;
            }
            err.Clear();
            return true;
        }
    }
}
