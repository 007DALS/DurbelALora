using System.ComponentModel.DataAnnotations;

namespace DurbelALora.Utils
{
    public class MyDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d < DateTime.Now;
        }
    }
}
