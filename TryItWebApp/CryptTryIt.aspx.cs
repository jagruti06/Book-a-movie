using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PasswordCrypt;

namespace TryItWebApp
{
    public partial class CryptTryIt : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Encrypt_Handler(object sender, EventArgs e)
        {
            string text = CryptLibrary.Encrypt(password_text.Text);
            encrypt_ans.Text = text;
        }

        protected void Decrypt_Handler(object sender, EventArgs e)
        {
            string text = CryptLibrary.Decrypt(decrypt_text.Text);
            decrypt_ans.Text = text;
        }
    }
}