using System;
using System.Windows.Forms;

namespace ShiftArrayApp
{
    public partial class Form1 : Form
    {
        private int[] originalArray = new int[5];
        private int[] shiftedArray = new int[5];
        private Button generateButton;
        private Button shiftButton;
        private ListBox originalListBox;
        private ListBox shiftedListBox;
        private Label originalLabel;
        private Label shiftedLabel;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            generateButton = new Button();
            generateButton.Text = "Сгенерировать массив";
            generateButton.Location = new System.Drawing.Point(20, 20);
            generateButton.Size = new System.Drawing.Size(130, 30);
            generateButton.Click += GenerateArray;

            shiftButton = new Button();
            shiftButton.Text = "Сдвинуть вправо";
            shiftButton.Location = new System.Drawing.Point(160, 20);
            shiftButton.Size = new System.Drawing.Size(120, 30);
            shiftButton.Click += ShiftRight;
            shiftButton.Enabled = false;

            originalLabel = new Label();
            originalLabel.Text = "Исходный массив:";
            originalLabel.Location = new System.Drawing.Point(20, 70);
            originalLabel.Size = new System.Drawing.Size(100, 20);

            originalListBox = new ListBox();
            originalListBox.Location = new System.Drawing.Point(20, 90);
            originalListBox.Size = new System.Drawing.Size(150, 100);

            shiftedLabel = new Label();
            shiftedLabel.Text = "Сдвинутый массив:";
            shiftedLabel.Location = new System.Drawing.Point(200, 70);
            shiftedLabel.Size = new System.Drawing.Size(120, 20);

            shiftedListBox = new ListBox();
            shiftedListBox.Location = new System.Drawing.Point(200, 90);
            shiftedListBox.Size = new System.Drawing.Size(150, 100);

            this.Controls.Add(generateButton);
            this.Controls.Add(shiftButton);
            this.Controls.Add(originalLabel);
            this.Controls.Add(originalListBox);
            this.Controls.Add(shiftedLabel);
            this.Controls.Add(shiftedListBox);
        }

        private void GenerateArray(object sender, EventArgs e)
        {
            originalListBox.Items.Clear();

            for (int i = 0; i < 5; i++)
            {
                originalArray[i] = random.Next(1, 101);
                originalListBox.Items.Add("[" + i + "] = " + originalArray[i]);
            }

            shiftButton.Enabled = true;
            shiftedListBox.Items.Clear();
        }

        private void ShiftRight(object sender, EventArgs e)
        {
            shiftedArray[0] = originalArray[4];

            for (int i = 1; i < 5; i++)
            {
                shiftedArray[i] = originalArray[i - 1];
            }

            shiftedListBox.Items.Clear();
            for (int i = 0; i < 5; i++)
            {
                shiftedListBox.Items.Add("[" + i + "] = " + shiftedArray[i]);
            }
        }
    }
}