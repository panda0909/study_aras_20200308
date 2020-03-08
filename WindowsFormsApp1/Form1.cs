using Aras.IOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Innovator inn { set; get; }
        public string message { set; get; }

        public Form1()
        {
            InitializeComponent();
        }

       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                HttpServerConnection cnx = IomFactory.CreateHttpServerConnection(txtIP.Text,txtDB.Text,txtID.Text,txtPassword.Text);
                Item login_result = cnx.Login();
                if (!login_result.isError())
                {
                    inn = IomFactory.CreateInnovator(cnx);
                    txtAML.Text = "Login success";
                    return;
                }
                message = login_result.getErrorString();
                txtAML.Text = message;
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                txtAML.Text = message;
            }
        }

        private void btnLoadAML_Click(object sender, EventArgs e)
        {
            CAD cad = new CAD();
            cad.item_number = "P380000001";
            cad.name = "test";
            cad.native_file = @"C:\Users\TLTC\source\repos\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\程式練習.docx";

            Item itm = inn.newItem("CAD", "add");
            itm.setProperty("item_number", "P380000001");
            itm.setProperty("name", "test");
            itm.setFileProperty("native_file", @"C:\Users\TLTC\source\repos\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\程式練習.docx");
            itm = itm.apply();
        }
    }
}
