using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    public partial class Form1 : Form
    {
        public CheckBox Done = new System.Windows.Forms.CheckBox();
        public Label MyTask = new System.Windows.Forms.Label();

        public TextBox Task = new System.Windows.Forms.TextBox();
        public DateTimePicker Date = new System.Windows.Forms.DateTimePicker();
        Dictionary<Label, Affair> tasks = new Dictionary<Label, Affair>();

        string my_task;

        int task_record = 0, task_done = 0;
        DateTime date_task;

        int place = 50;

        public Form _params = new Form();
        public Form1()
        {
            InitializeComponent();

            _params.ClientSize = new System.Drawing.Size(130, 150);
            _params.Location = new System.Drawing.Point(150, 150);

            Done.Location = new System.Drawing.Point(5, 5);
            Done.Name = "P";
            Done.Size = new System.Drawing.Size(118, 27);
            Done.TabIndex = 5;
            Done.Text = "";

            Task.Location = new System.Drawing.Point(5, 35);
            Task.Name = "P";
            Task.Size = new System.Drawing.Size(118, 27);
            Task.TabIndex = 5;
            Task.Text = "";

            Date.Location = new System.Drawing.Point(5, 55);
            Date.Name = "P";
            Date.Size = new System.Drawing.Size(118, 27);
            Date.TabIndex = 5;
            Date.Text = "";

            Done.CheckedChanged += new System.EventHandler(this.Checked);
            Task.TextChanged += new System.EventHandler(this.AddTask);
            MyTask.Click += new System.EventHandler(this.Copy);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Text = "";
            _params.Controls.Add(Task);
            _params.Controls.Add(Date);
            _params.ShowDialog(this);

            Affair t = new Affair();
            CreateTask(t);
        }

        public void CreateTask(Affair t)
        {
            t.task = my_task;
            t.done = false;
            t.date = date_task;
            t.IdInfo = new IdInfo(1);

            MyTask.Text = $"{t.task}  {t.date}";
            tasks.Add(MyTask, t);
            this.Controls.Add(MyTask);
            this.Controls.Add(Done);
            this.Controls.Add(Date);
            ChangeStatus();
        }

        private void Checked (object sender, EventArgs e)
        {
            if (Done.Checked)
            {
                task_done++;
            }
             
        }


        private void AddTask(object sender, EventArgs e)
        {
            my_task = Task.Text;
            task_record++;
        }

        private void Copy (object sender, EventArgs e)
        {
            Label cb = (sender as Label);
            Affair t_new = tasks[cb].DeepCopy();

            Task.Text = t_new.task;
            Date.Value = t_new.date;

            _params.Controls.Add(Task);
            _params.Controls.Add(Date);
            _params.ShowDialog(this);

            CreateTask(t_new);

        }

        public void ChangeStatus ()
        {
            label2.Text = $"{task_record} / {task_done}";
        }

    }
}
