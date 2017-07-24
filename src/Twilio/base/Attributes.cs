using System;

namespace Twilio.Base
{
    /// <summary>
    /// Attribute to annotate beta products
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class BetaAttribute : System.Attribute
    {
       /// <summary>
       /// Attribute text
       /// </summary>
       public readonly string Text;

       public BetaAttribute()
       {
          this.Text = "This file contains beta products that are subject" +
                      " to change. Use them with caution.";
       }
    }

    /// <summary>
    /// Attribute to annotate preview products
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class PreviewAttribute : System.Attribute
    {
       /// <summary>
       /// Attribute text
       /// </summary>
       public readonly string Text;

       public PreviewAttribute()
       {
          this.Text = "This file contains preview products that are subject" +
                      " to change. Use them with caution.";
       }
    }
}
