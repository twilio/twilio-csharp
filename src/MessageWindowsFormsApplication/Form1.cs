using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Twilio;

namespace MessageWindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account   
            string AccountSid = "AC5ef8732a3c49700934481addd5ce1659";  
            string AuthToken = "{{ auth_token }}";   
            var twilio = new TwilioRestClient(AccountSid, AuthToken);        
            var message = twilio.SendMessage("+14158141829", "+15558675309", "Jenny please?! I love you <3", new string[] {"http://www.example.com/hearts.png"});
            
            try
            {
                MessageBox.Show(message.Sid);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {


            // Find your Account Sid and Auth Token at twilio.com/user/account
            string AccountSid = "AC5ef8732a3c49700934481addd5ce1659";
            string AuthToken = "{{ auth_token }}";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            int maxsize=10;
            try
            {
                 twilio.CreateQueue("newqueue", null);
            }
            catch (ArgumentException ex) 
            {
                MessageBox.Show(ex.Message);
                return;
            
            }

            //MessageBox.Show(queue.Sid.ToString());
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string AccountSid = "AC32a3c49700934481addd5ce1659f04d2";
            string AuthToken = "{{ auth_token }}";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var accounts = twilio.ListSubAccounts("MySubaccount",AccountStatus.Active);
            foreach (var account in accounts.Accounts)
            {
                Console.WriteLine(account.Status);
            }

        }
    }
}
