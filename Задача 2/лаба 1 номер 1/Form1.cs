using System;
using System.Windows.Forms;

namespace MinMaxApp
{
    public partial class Form1 : Form
    {
        private TextBox sizeTextBox;
        private Button createButton;
        private Button findButton;
        private ListBox arrayListBox;
        private Label resultLabel;
        private int[] array;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            Label sizeLabel = new Label();
            sizeLabel.Text = "Введите размер массива N:";
            sizeLabel.Location = new System.Drawing.Point(20, 20);
            sizeLabel.Size = new System.Drawing.Size(150, 20);

            sizeTextBox = new TextBox();
            sizeTextBox.Location = new System.Drawing.Point(180, 20);
            sizeTextBox.Size = new System.Drawing.Size(50, 20);

            createButton = new Button();
            createButton.Text = "Создать массив";
            createButton.Location = new System.Drawing.Point(250, 20);
            createButton.Size = new System.Drawing.Size(100, 25);
            createButton.Click += CreateArray;

            arrayListBox = new ListBox();
            arrayListBox.Location = new System.Drawing.Point(20, 60);
            arrayListBox.Size = new System.Drawing.Size(150, 150);

            findButton = new Button();
            findButton.Text = "Найти макс и мин";
            findButton.Location = new System.Drawing.Point(20, 220);
            findButton.Size = new System.Drawing.Size(120, 30);
            findButton.Click += FindMinMax;
            findButton.Enabled = false;

            resultLabel = new Label();
            resultLabel.Text = "";
            resultLabel.Location = new System.Drawing.Point(20, 260);
            resultLabel.Size = new System.Drawing.Size(350, 40);

            this.Controls.Add(sizeLabel);
            this.Controls.Add(sizeTextBox);
            this.Controls.Add(createButton);
            this.Controls.Add(arrayListBox);
            this.Controls.Add(findButton);
            this.Controls.Add(resultLabel);
        }

        private void CreateArray(object sender, EventArgs e)
        {
            if (int.TryParse(sizeTextBox.Text, out int n) && n > 0)
            {
                array = new int[n];
                arrayListBox.Items.Clear();

                for (int i = 0; i < n; i++)
                {
                    array[i] = random.Next(1, 101);
                    arrayListBox.Items.Add("[" + i + "] = " + array[i]);
                }

                findButton.Enabled = true;
                resultLabel.Text = "";
            }
            else
            {
                MessageBox.Show("Введите корректное положительное число");
            }
        }

        private void FindMinMax(object sender, EventArgs e)
        {
            int min = array[0];
            int max = array[0];
            int minIndex = 0;
            int maxIndex = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    minIndex = i;
                }

                if (array[i] > max)
                {
                    max = array[i];
                    maxIndex = i;
                }
            }

            resultLabel.Text = "Минимальный элемент: [" + minIndex + "] = " + min + "\n" +
                              "Максимальный элемент: [" + maxIndex + "] = " + max;
        }
    }
}