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
        public Form1()
        {
            InitializeComponent();
        }
        DataTable toDoList = new DataTable();
        bool isEditing = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            toDoList.Columns.Add("Title");
            toDoList.Columns.Add("Description");

            toDoListView.DataSource = toDoList;
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = "";
            descTextBox.Text = "";
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            isEditing = true;

            titleTextBox.Text = toDoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            descTextBox.Text = toDoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                toDoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            } catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if(isEditing)
            {
                toDoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"] = titleTextBox.Text;
                toDoList.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = descTextBox.Text;
            } else
            {
                toDoList.Rows.Add(titleTextBox.Text, descTextBox.Text);
            }

            titleTextBox.Text = "";
            descTextBox.Text = "";
            isEditing = false;
        }
    }
}
