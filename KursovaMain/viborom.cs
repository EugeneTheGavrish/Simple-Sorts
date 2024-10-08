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
        public viborom()
        {
            InitializeComponent();
            label13.Visible = false;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.TransparencyKey = BackColor;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string masiv = textBox1.Text.ToString();
            int[] numbers = ConvertTextBoxToNumbersArray(masiv);
            int size = numbers.Length;
            if (numbers.Length == 0)
            {
                label4.Text = "Ввід має містити\nхоча б одне число";
                return;
            }
            string arrayElements = "";
            for (int i = 0; i < size; i++)
            {
                arrayElements += numbers[i].ToString();
                if (i < size - 1)
                {
                    arrayElements += ", ";
                }
            }

            // Виведення масиву чисел та його розміру на label4
            label4.Text = $"Масив: {arrayElements}\nРозмір: {size}";

            
            var (minElement, minIndex) = FindMinimum(numbers);
            // Виведення результату
            label7.Text = $"\nМінімальний елемент масиву: {minElement}";
            label9.Text = $"\nПерший елемент: {numbers[0]}    Мінімальний елемент: {minElement}";
            string arrayElements2 = "";
            if (minElement < numbers[0])
            {
                
                int bufer;
                bufer=numbers[0];
                numbers[minIndex]= bufer;
                numbers[0] = minElement ;
                 
                for (int i = 0; i < numbers.Length; i++)
                {
                    arrayElements2 += numbers[i].ToString();
                    arrayElements2 += ", ";
                }
                label10.Text = $"Перший елемент більше за мінімальний,\nміняємо їх місцями. Отримуємо масив: {arrayElements2}";
            }
            else
            {
                label10.Text = $"Перший елемент дорівнює мінімальному, \n залишаємо його на місці";

            }
            string sortedArray = SelectionSort(numbers);

            // Виведення масиву чисел label12
            label12.Text = sortedArray;
            

        }
        private (int min, int minIndex) FindMinimum(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("The array must not be null or empty.");
            }

            int min = numbers[0];
            int minIndex = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                    minIndex = i;
                }
            }

            return (min, minIndex);
        }

        private string SelectionSort(int[] array)
        {
            int n = array.Length;
            string result = "";

            for (int i = 0; i < n - 1; i++)
            {
                // Знаходження мінімального елемента в невідсортованій частині масиву
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Обмін мінімального елемента з першим елементом невідсортованої частини
                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;

                // Додавання інформації про індекси до результату
                
            }

            // Додавання відсортованого масиву до результату
            result += $"Відсортований масив: {string.Join(", ", array)}\nРозмір масиву: {n}";

            return result; // Повертаємо рядок замість нічого
        }

        static int[] ConvertTextBoxToNumbersArray(string text)
        {
            // Використання LINQ для розділення рядка і перетворення в масив чисел
            int[] numbers = text
                .Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries) // Розділення рядка за пробілами, комами, крапками з комою
                .Select(int.Parse) // Перетворення кожного елемента в число
                .ToArray(); // Перетворення результату в масив

            return numbers;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string masiv = textBox1.Text.ToString();
            int[] numbers = ConvertTextBoxToNumbersArray(masiv);
            int size = numbers.Length;
            string arrayElements = "";
            for (int i = 0; i < size; i++)
            {
                arrayElements += numbers[i].ToString();
                if (i < size - 1)
                {
                    arrayElements += ", ";
                }
            }

            // Виведення масиву чисел та його розміру на label4
            label4.Font = new Font("Arial", 8, FontStyle.Bold);

            label4.Text = $"Масив: {arrayElements}\nРозмір: {size}";
            if (numbers.Length == 0)
            {
                label4.Text = "Ввід має містити\nхоча б одне число";
                return;
            }
            string sortedArray = SelectionSort(numbers);
            label12.Text = sortedArray;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label13.Visible = true;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            label13.Visible = false;
        }
    }
}
