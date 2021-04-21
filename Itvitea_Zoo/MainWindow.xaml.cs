using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Itvitea_Zoo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Zoo.ZooManager manager = new Zoo.ZooManager();
        private PersonNameGenerator nameGenerator = new PersonNameGenerator();
        private System.Timers.Timer timer = new System.Timers.Timer();

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 500);
            dispatcherTimer.Start();

            UpdateSlowASSLOadingLabelUIContent();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            manager.UseEnergy();
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            AnimalListBox.Items.Clear();
            foreach (Zoo.Animal animal in manager.Animals)
            {
                AnimalListBox.Items.Add(new ListBoxItem { Content = $"{animal.Name} | {animal.GetType().ToString()}"});
            }
        }

        private void FeedMonkeybtn_Click(object sender, RoutedEventArgs e)
        {
            manager.FeedingTime("Monkey");
        }

        private void FeedLionbtn_Click(object sender, RoutedEventArgs e)
        {
            manager.FeedingTime("Lion");
        }

        private void FeedElephantbtn_Click(object sender, RoutedEventArgs e)
        {
            manager.FeedingTime("Elephant");
        }

        private void FeedAllbtn_Click(object sender, RoutedEventArgs e)
        {
            manager.FeedingTime();
        }

        private void AddMonkeybtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            manager.AddAnimal(new Zoo.Monkey(nameGenerator.GenerateRandomFirstName()));
            UpdateListBox();
        }

        private void AddLionbtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            manager.AddAnimal(new Zoo.Lion(nameGenerator.GenerateRandomFirstName()));
            UpdateListBox();
        }

        private void AddElephantbtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            manager.AddAnimal(new Zoo.Elephant(nameGenerator.GenerateRandomFirstName()));
            UpdateListBox();
        }

        private void TimerSpeedSlicer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            dispatcherTimer.Interval = new TimeSpan(0, 0, (int)TimerSpeedSlicer.Value);
            UpdateSlowASSLOadingLabelUIContent();
        }

        private void UpdateSlowASSLOadingLabelUIContent()
        {
            if (timerSpeedLabel != null)
                timerSpeedLabel.Content = $"{dispatcherTimer.Interval.TotalSeconds} speed units";
        }
    }
}
