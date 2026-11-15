namespace MyWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Можу звертатися до змінних в середині класу
            string textPath = txtPath.Text; //Отримую значення з поля на формі
            //Перевіряю чи існує файл за даним шляхом
            if (File.Exists(textPath) == false)
            {
                MessageBox.Show("Файл за даним шляхом не існує!");
                return; //Виходжу із функції - метод
            }
            //Читаю вміст файлу, як текст
            string fileContent = File.ReadAllText(textPath);
            txtFileContent.Text = fileContent;

            //MessageBox.Show("Можна читати файл " + textPath);
        }
    }
}
