using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static Laba2_4_Kiprin_Kravsov.MainWindow;

namespace Laba2_4_Kiprin_Kravsov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        protected void Signal([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private Pacient pacients = new();
        public List<Pacient> testPacients = new List<Pacient>();

        private PacientOtchet pacientOtchets = new();
        public List<PacientOtchet> testpacientOtchets = new List<PacientOtchet>();

        public string TestTest = "";
        public MainWindow()
        {
            TestOtchetForm();
            TestPacient();
            InitializeComponent();
            DataContext = this;
        }

        public class Pacient()
        {
            public string NumberPacient { get; set; }
            public string SurnamePacient { get; set; }
            public string NamePacient { get; set; }
            public string PatronymicPacient { get; set; }
            public string DateBithday { get; set; }
            public string MCNumber { get; set; }
            public string MCRegister { get; set; }
            public string Telephone { get; set; }
            public string Maile { get; set; }
            public string Adress { get; set; }
            public int Otchet_ID { get; set; }
        }

        public class PacientOtchet()
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string NameVrach { get; set; }
            public string CabNum { get; set; }
            public string Procedur { get; set; }
            public string ResultProcedur { get; set; }

        }

        public void TestPacient()
        {
            Pacient testAddPacient = new Pacient();

            testAddPacient.NumberPacient = "1";
            testAddPacient.SurnamePacient = "TestSP1";
            testAddPacient.NamePacient = "TestNP1";
            testAddPacient.PatronymicPacient = "TestPP1";
            testAddPacient.DateBithday = "01.01.1111";
            testAddPacient.MCNumber = "1";
            testAddPacient.MCRegister = "testRegisterMC1";
            testAddPacient.Telephone = "+11111111111";
            testAddPacient.Maile = "test1@ru.ru";
            testAddPacient.Adress = "test 1, d1";
            testAddPacient.Otchet_ID = 1;

            testPacients.Add(testAddPacient);

            Pacient testAddPacient2 = new Pacient();

            testAddPacient2.NumberPacient = "2";
            testAddPacient2.SurnamePacient = "TestSP2";
            testAddPacient2.NamePacient = "TestNP2";
            testAddPacient2.PatronymicPacient = "TestPP2";
            testAddPacient2.DateBithday = "01.01.1111";
            testAddPacient2.MCNumber = "2";
            testAddPacient2.MCRegister = "testRegisterMC2";
            testAddPacient2.Telephone = "+22222222222";
            testAddPacient2.Maile = "test2@ru.ru";
            testAddPacient2.Adress = "test 2, d2";
            testAddPacient2.Otchet_ID = 2;

            testPacients.Add(testAddPacient2);

            Pacient testAddPacient3 = new Pacient();

            testAddPacient3.NumberPacient = "3";
            testAddPacient3.SurnamePacient = "TestSP3";
            testAddPacient3.NamePacient = "TestNP3";
            testAddPacient3.PatronymicPacient = "TestPP3";
            testAddPacient3.DateBithday = "01.01.1111";
            testAddPacient3.MCNumber = "3";
            testAddPacient3.MCRegister = "testRegisterMC3";
            testAddPacient3.Telephone = "+33333333333";
            testAddPacient3.Maile = "test3@ru.ru";
            testAddPacient3.Adress = "test 3, d3";
            testAddPacient3.Otchet_ID = 3;

            testPacients.Add(testAddPacient3);

            Pacients = new ObservableCollection<Pacient>(testPacients);
        }

        public void TestOtchetForm()
        {
            PacientOtchet pacientOtchet = new PacientOtchet();

            pacientOtchet.Id = 1;
            pacientOtchet.Date = DateTime.Now;
            pacientOtchet.NameVrach = "Test Vrach 1";
            pacientOtchet.CabNum = "1";
            pacientOtchet.Procedur = "TestProcedur1";
            pacientOtchet.ResultProcedur = "Horosho";

            testpacientOtchets.Add(pacientOtchet);

            PacientOtchet pacientOtchet2 = new PacientOtchet();

            pacientOtchet2.Id = 2;
            pacientOtchet2.Date = DateTime.Now;
            pacientOtchet2.NameVrach = "Test Vrach 2";
            pacientOtchet2.CabNum = "2";
            pacientOtchet2.Procedur = "TestProcedur2";
            pacientOtchet2.ResultProcedur = "Horosho";

            testpacientOtchets.Add(pacientOtchet2);

            PacientOtchet pacientOtchet3 = new PacientOtchet();

            pacientOtchet3.Id = 3;
            pacientOtchet3.Date = DateTime.Now;
            pacientOtchet3.NameVrach = "Test Vrach 3";
            pacientOtchet3.CabNum = "3";
            pacientOtchet3.Procedur = "TestProcedur3";
            pacientOtchet3.ResultProcedur = "Ploho";

            testpacientOtchets.Add(pacientOtchet3);

            PacientOtchets = new ObservableCollection<PacientOtchet>(testpacientOtchets);
        }
        public Pacient SelectedTestPacient
        {
            get => pacients;
            set
            {
                pacients = value;
                Signal();
            }
        }

        public MainWindow(ObservableCollection<Pacient>? pacients)
        {
            Pacients = pacients;
        }
        public ObservableCollection<Pacient> Pacients { get; set; }

        public PacientOtchet SelectedTestOthcet
        {
            get => pacientOtchets;
            set
            {
                pacientOtchets = value;
                Signal();
            }
        }

        public MainWindow(ObservableCollection<PacientOtchet>? pacientOtchets)
        {
            PacientOtchets = pacientOtchets;
        }
        public ObservableCollection<PacientOtchet> PacientOtchets { get; set; }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListView listView && listView.SelectedItem is Pacient selectedPacient)
            {
                // Заполняем TextBox значениями из выбранного объекта
                SurnameX.Text = selectedPacient.SurnamePacient;
                NameX.Text = selectedPacient.NamePacient;
                PatronymicX.Text = selectedPacient.PatronymicPacient;
                DateBithdayX.Text = selectedPacient.DateBithday;
                MCNumperX.Text = selectedPacient.MCNumber;
                MCRegisterX.Text = selectedPacient.MCRegister;
                TelephoneX.Text = selectedPacient.Telephone;
                MaileX.Text = selectedPacient.Maile;
                AdressX.Text = selectedPacient.Adress;
                TestTest = selectedPacient.NumberPacient;
            }
        }

        private void ClearInfoPacient_Click(object sender, RoutedEventArgs e)
        {
            SurnameX.Text = "";
            NameX.Text = "";
            PatronymicX.Text = "";
            DateBithdayX.Text = "";
            MCNumperX.Text = "";
            MCRegisterX.Text = "";
            TelephoneX.Text = "";
            MaileX.Text = "";
            AdressX.Text = "";
            TestTest = "";
        }
        private void UpdatePacient_Click(object sender, RoutedEventArgs e)
        {
            if (TestTest == "")
            {
                MessageBox.Show("Идиот? Ты не выбрал поциента.");
            }
            else
            {
                for (int i = 0; i < testPacients.Count; i++)
                {
                    if (TestTest == testPacients[i].NumberPacient)
                    {
                        testPacients[i].SurnamePacient = SurnameX.Text;
                        testPacients[i].NamePacient = NameX.Text;
                        testPacients[i].PatronymicPacient = PatronymicX.Text;
                        testPacients[i].MCNumber = MCNumperX.Text;
                        testPacients[i].MCRegister = MCRegisterX.Text;
                        testPacients[i].Telephone = TelephoneX.Text;
                        testPacients[i].Maile = MaileX.Text;
                        testPacients[i].Adress = AdressX.Text;
                        Signal();
                        DataContext = this;
                        return;
                    }
                }
                MessageBox.Show("Куку? Ты в кого решил эти данные сохранить?");
            }
        }

        private void AddPacient_Click(object sender, RoutedEventArgs e)
        {
            AddPacientWindow addPacientWindow = new AddPacientWindow();
            addPacientWindow.ShowDialog();
        }

        private void MCFull_Ckick(object sender, RoutedEventArgs e)
        {
            MCFullInformationWindow MCFullInformationWindow = new MCFullInformationWindow();
            MCFullInformationWindow.ShowDialog();
        }

        private void SearcPacient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Поиск доступен только в \n SUPER PRO MASTER подписке! \n ВСЕГО ЗА 999999999$ В ДЕНЬ!");
        }

        private void ListView2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListView listView && listView.SelectedItem is Pacient selectedPacient)
            {
                FIOX.Content = selectedPacient.SurnamePacient + " " + selectedPacient.NamePacient + " " + selectedPacient.PatronymicPacient;
            }
        }

        private void CreatPDF_Click(object sender, RoutedEventArgs e)
        {
            if (PacientOtchets == null || !PacientOtchets.Any())
            {
                MessageBox.Show("Нет данных для экспорта!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string filePath = "PacientOtchet.pdf";

            try
            {
                // Создаём документ
                Document document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Добавляем заголовок
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Отчёт по пациентам", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20
                };
                document.Add(title);

                // Создаём таблицу (5 колонок, т.к. Id не нужен)
                PdfPTable table = new PdfPTable(5)
                {
                    WidthPercentage = 100
                };

                // Настройка ширины колонок (по пропорциям)
                float[] columnWidths = { 15f, 25f, 15f, 25f, 30f };
                table.SetWidths(columnWidths);

                // Заголовки столбцов
                Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                table.AddCell(new PdfPCell(new Phrase("Дата посещения", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Врач", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Кабинет", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Процедура", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                table.AddCell(new PdfPCell(new Phrase("Результат", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                // Заполняем таблицу данными
                Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                foreach (var item in PacientOtchets)
                {
                    table.AddCell(new PdfPCell(new Phrase(item.Date.ToString("dd.MM.yyyy"), cellFont)));
                    table.AddCell(new PdfPCell(new Phrase(item.NameVrach, cellFont)));
                    table.AddCell(new PdfPCell(new Phrase(item.CabNum, cellFont)));
                    table.AddCell(new PdfPCell(new Phrase(item.Procedur, cellFont)));
                    table.AddCell(new PdfPCell(new Phrase(item.ResultProcedur, cellFont)));
                }

                // Добавляем таблицу в документ
                document.Add(table);
                document.Close();

                MessageBox.Show($"Отчёт успешно создан: {filePath}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании PDF: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}