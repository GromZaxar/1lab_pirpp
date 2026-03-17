using System;
using System.Windows.Forms;

namespace ReverseArrayApp
{
    public partial class Form1 : Form
    {
        private int[] originalArray = new int[5];
        private int[] reversedArray = new int[5];
        private TextBox[] textBoxes = new TextBox[5];
        private Button createButton;
        private Button reverseButton;
        private ListBox originalListBox;
        private ListBox reversedListBox;
        private Label originalLabel;
        private Label reversedLabel;

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            for (int i = 0; i < 5; i++)
            {
                Label label = new Label();
                label.Text = "Число " + (i + 1) + ":";
                label.Location = new System.Drawing.Point(20, 20 + i * 30);
                label.Size = new System.Drawing.Size(50, 20);

                textBoxes[i] = new TextBox();
                textBoxes[i].Location = new System.Drawing.Point(80, 20 + i * 30);
                textBoxes[i].Size = new System.Drawing.Size(100, 20);

                this.Controls.Add(label);
                this.Controls.Add(textBoxes[i]);
            }

            createButton = new Button();
            createButton.Text = "Создать массив";
            createButton.Location = new System.Drawing.Point(20, 180);
            createButton.Size = new System.Drawing.Size(120, 30);
            createButton.Click += CreateArray;

            reverseButton = new Button();
            reverseButton.Text = "Реверс";
            reverseButton.Location = new System.Drawing.Point(150, 180);
            reverseButton.Size = new System.Drawing.Size(100, 30);
            reverseButton.Click += ReverseArray;
            reverseButton.Enabled = false;

            originalLabel = new Label();
            originalLabel.Text = "Исходный массив:";
            originalLabel.Location = new System.Drawing.Point(20, 220);
            originalLabel.Size = new System.Drawing.Size(100, 20);

            originalListBox = new ListBox();
            originalListBox.Location = new System.Drawing.Point(20, 240);
            originalListBox.Size = new System.Drawing.Size(150, 80);

            reversedLabel = new Label();
            reversedLabel.Text = "Реверсивный массив:";
            reversedLabel.Location = new System.Drawing.Point(200, 220);
            reversedLabel.Size = new System.Drawing.Size(120, 20);

            reversedListBox = new ListBox();
            reversedListBox.Location = new System.Drawing.Point(200, 240);
            reversedListBox.Size = new System.Drawing.Size(150, 80);

            this.Controls.Add(createButton);
            this.Controls.Add(reverseButton);
            this.Controls.Add(originalLabel);
            this.Controls.Add(originalListBox);
            this.Controls.Add(reversedLabel);
            this.Controls.Add(reversedListBox);
        }

        private void CreateArray(object sender, EventArgs e)
        {
            bool validInput = true;

            for (int i = 0; i < 5; i++)
            {
                if (!int.TryParse(textBoxes[i].Text, out originalArray[i]))
                {
                    validInput = false;
                    break;
                }
            }

            if (validInput)
            {
                originalListBox.Items.Clear();
                for (int i = 0; i < 5; i++)
                {
                    originalListBox.Items.Add("[" + i + "] = " + originalArray[i]);
                }

                reverseButton.Enabled = true;
                reversedListBox.Items.Clear();
            }
            else
            {
                MessageBox.Show("Введите корректные числа");
            }
        }

        private void ReverseArray(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                reversedArray[i] = originalArray[4 - i];
            }

            reversedListBox.Items.Clear();
            for (int i = 0; i < 5; i++)
            {
                reversedListBox.Items.Add("[" + i + "] = " + reversedArray[i]);
            }
        }
    }
}