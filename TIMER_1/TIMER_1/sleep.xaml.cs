using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace TIMER_1
{
    /// <summary>
    /// Логика взаимодействия для sleep.xaml
    /// </summary>
    public partial class sleep : Window
    {
        DateTime completion_2;
        public sleep()
        {
            InitializeComponent();
        }

        struct timing
        {
            public double h;
            public double m;
            public double s;
        };

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timing time;
            if (hours.Text.Length == 0 || minutes.Text.Length == 0 || seconds.Text.Length == 0)
            {
                MessageBox.Show("Каждое поле обязательно для заполнения!");
                sleep str4 = new sleep();
                str4.Show();
                Close();
                goto start;
            }
            string checking = Convert.ToString(hours.Text);
            for (int i = 0; i < checking.Length; i++)
            {
                if (checking[i] < 48 || checking[i] > 57)
                {
                    MessageBox.Show("Введены символы! Попробуйте ещё раз!");
                    sleep str4 = new sleep();
                    str4.Show();
                    Close();
                    goto start;
                }
            }
            time.h = Convert.ToDouble(checking);
            string checking2 = Convert.ToString(minutes.Text);
            for (int i = 0; i < checking2.Length; i++)
            {
                if (checking2[i] < 48 || checking2[i] > 57)
                {
                    MessageBox.Show("Введены символы! Попробуйте ещё раз!");
                    sleep str4 = new sleep();
                    str4.Show();
                    Close();
                    goto start;
                }
            }
            time.m = Convert.ToDouble(checking2);
            string checking3 = Convert.ToString(seconds.Text);
            for (int i = 0; i < checking3.Length; i++)
            {
                if (checking3[i] < 48 || checking3[i] > 57)
                {
                    MessageBox.Show("Введены символы! Попробуйте ещё раз!");
                    sleep str4 = new sleep();
                    str4.Show();
                    Close();
                    goto start;
                }
            }
            time.s = Convert.ToDouble(checking3);
            if (time.h > 24)
            {
                MessageBox.Show("Максимальное значение в часах 24! Попробуйте ещё раз!");
                sleep str4 = new sleep();
                str4.Show();
                Close();
                goto start;
            }
            if (time.m > 60)
            {
                MessageBox.Show("Максимальное значение в минутах 60! Попробуйте ещё раз!");
                sleep str4 = new sleep();
                str4.Show();
                Close();
                goto start;
            }
            if (time.s > 60)
            {
                MessageBox.Show("Максимальное значение в секундах 60! Попробуйте ещё раз!");
                sleep str4 = new sleep();
                str4.Show();
                Close();
                goto start;
            }
            if (time.h * 60 * 60 + time.m * 60 + time.s > 86400)
            {
                MessageBox.Show("Максимальное время, которое Вы можете суммарно установить не должно превышать 24 часа! Попробуйте ещё раз!");
                sleep str4 = new sleep();
                str4.Show();
                Close();
                goto start;
            }
            completion_2 = DateTime.Now.AddHours(time.h).AddMinutes(time.m).AddSeconds(time.s);
            label_sleep.Visibility = Visibility;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        start:
            ;
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (DateTime.Now < completion_2)
            {
                TimeSpan time = completion_2 - DateTime.Now;
                label_sleep.Content = "До включения режима сна осталось " + time.Hours + " часа " + time.Minutes + " минут " + time.Seconds + " секунд!";
                label_sleep.Visibility = Visibility.Visible;
            }
            else
            {
                System.Diagnostics.Process.Start("rundll32.exe", "powrprof.dll, SetSuspendState sleep");
                Close();
            }
        }
    }
}
