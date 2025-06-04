using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursovaMain
{
    public partial class viborom : Form
    {
        private int[] numbers = new int[8];
        private Label[] labels;

        public viborom()
        {
            InitializeComponent();
            label13.Visible = false;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.TransparencyKey = BackColor;
            labels = new Label[] { label5, label6, label7, label8, label9, label10, label11, label12 };
        }

        private void UpdateLabels()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                labels[i].Text = numbers[i].ToString();
                labels[i].BackColor = Color.LightGray;
            }
        }

        private bool TryParseInput(out int[] arr)
        {
            arr = null;
            var input = textBox1.Text
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (input.Length != 8)
                return false;

            int[] temp = new int[8];
            for (int i = 0; i < 8; i++)
            {
                if (!int.TryParse(input[i], out temp[i]))
                    return false;
            }
            arr = temp;
            return true;
        }

        private async void buttonSort_Click(object sender, EventArgs e)
        {
            if (!TryParseInput(out numbers))
            {
                MessageBox.Show("Введіть рівно 8 цілих чисел, розділених пробілом або комою.");
                return;
            }
            UpdateLabels();
            await SelectionSortVisualized();
        }

        private async Task SelectionSortVisualized()
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int minIdx = i;
                labels[i].BackColor = Color.Yellow;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    labels[j].BackColor = Color.Orange;
                    await Task.Delay(400);

                    if (numbers[j] < numbers[minIdx])
                    {
                        if (minIdx != i)
                            labels[minIdx].BackColor = Color.LightGray;
                        minIdx = j;
                        labels[minIdx].BackColor = Color.Red;
                    }
                    else
                    {
                        labels[j].BackColor = Color.LightGray;
                    }
                }

                if (minIdx != i)
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[minIdx];
                    numbers[minIdx] = temp;

                    labels[i].Text = numbers[i].ToString();
                    labels[minIdx].Text = numbers[minIdx].ToString();
                }

                labels[i].BackColor = Color.Green;
                if (minIdx != i)
                    labels[minIdx].BackColor = Color.LightGray;
            }
            labels[numbers.Length - 1].BackColor = Color.Green;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label13.Visible = true;
            label13.Location = new Point(37, 93);
            label13.BringToFront();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            label13.Visible = false;
        }

    }
}
