using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;
using Microsoft.Win32;
using System.Drawing;
using System.Windows.Documents;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace KhTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Data data;
        private BroadcastWindow broadcast;
        public int collected;
        private int total = 55;

        //dumb stuff to help figure out what to do about custom images
        public static bool CustomNumbersFound = false;
        public static bool CustomBlueNumbersFound = false;
        public static bool CustomSwordFound = false;
        public static bool CustomStaffFound = false;
        public static bool CustomShieldFound = false;
        public static bool CustomLevelFound = false;
        public static bool CustomStrengthFound = false;
        public static bool CustomMagicFound = false;
        public static bool CustomDefenseFound = false;


        public MainWindow()
        {
            InitializeComponent();

            InitData();

            InitOptions();

            collectedChecks = new List<ImportantCheck>();
            newChecks = new List<ImportantCheck>();
            previousChecks = new List<ImportantCheck>();
        }

        private void InitData()
        {
            data = new Data();

            data.Reports.Add(Report1);
            data.Reports.Add(Report2);
            data.Reports.Add(Report3);
            data.Reports.Add(Report4);
            data.Reports.Add(Report5);
            data.Reports.Add(Report6);
            data.Reports.Add(Report7);
            data.Reports.Add(Report8);
            data.Reports.Add(Report9);
            data.Reports.Add(Report10);
            data.Reports.Add(Report11);
            data.Reports.Add(Report12);
            data.Reports.Add(Report13);

            data.ReportAttemptVisual.Add(Attempts1);
            data.ReportAttemptVisual.Add(Attempts2);
            data.ReportAttemptVisual.Add(Attempts3);
            data.ReportAttemptVisual.Add(Attempts4);
            data.ReportAttemptVisual.Add(Attempts5);
            data.ReportAttemptVisual.Add(Attempts6);
            data.ReportAttemptVisual.Add(Attempts7);
            data.ReportAttemptVisual.Add(Attempts8);
            data.ReportAttemptVisual.Add(Attempts9);
            data.ReportAttemptVisual.Add(Attempts10);
            data.ReportAttemptVisual.Add(Attempts11);
            data.ReportAttemptVisual.Add(Attempts12);
            data.ReportAttemptVisual.Add(Attempts13);

            data.TornPages.Add(TornPage1);
            data.TornPages.Add(TornPage2);
            data.TornPages.Add(TornPage3);
            data.TornPages.Add(TornPage4);
            data.TornPages.Add(TornPage5);

            #region Numbers

            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/_QuestionMark.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/_0.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/_1.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/_2.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/_3.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/_4.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/_5.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/_6.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/_7.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/_8.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/_9.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/10.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/11.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/12.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/13.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/14.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/15.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/16.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/17.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/18.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/19.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/20.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/21.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/22.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/23.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/24.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/25.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/26.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/27.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/28.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/29.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/30.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/31.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/32.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/33.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/34.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/35.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/36.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/37.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/38.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/39.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/40.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/41.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/42.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/43.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/44.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/45.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/46.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/47.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/48.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/49.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/50.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/51.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/52.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/53.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/54.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/55.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/56.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/57.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/58.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/59.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/60.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/61.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/62.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/63.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/64.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/65.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/66.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/67.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/68.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/69.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/70.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/71.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/72.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/73.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/74.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/75.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/76.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/77.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/78.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/79.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/80.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/81.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/82.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/83.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/84.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/85.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/86.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/87.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/88.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/89.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/90.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/91.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/92.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/93.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/94.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/95.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/96.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/97.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/98.png", UriKind.Relative)));
            data.Numbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/99.png", UriKind.Relative)));

            data.SingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/QuestionMark.png", UriKind.Relative)));
            data.SingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/0.png", UriKind.Relative)));
            data.SingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/1.png", UriKind.Relative)));
            data.SingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/2.png", UriKind.Relative)));
            data.SingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/3.png", UriKind.Relative)));
            data.SingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/4.png", UriKind.Relative)));
            data.SingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/5.png", UriKind.Relative)));
            data.SingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/6.png", UriKind.Relative)));
            data.SingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/7.png", UriKind.Relative)));
            data.SingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/8.png", UriKind.Relative)));
            data.SingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbers/9.png", UriKind.Relative)));

            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/_QuestionMark.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/_0.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/_1.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/_2.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/_3.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/_4.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/_5.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/_6.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/_7.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/_8.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/_9.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/10.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/11.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/12.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/13.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/14.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/15.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/16.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/17.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/18.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/19.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/20.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/21.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/22.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/23.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/24.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/25.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/26.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/27.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/28.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/29.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/30.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/31.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/32.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/33.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/34.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/35.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/36.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/37.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/38.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/39.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/40.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/41.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/42.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/43.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/44.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/45.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/46.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/47.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/48.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/49.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/50.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/51.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/52.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/53.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/54.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/55.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/56.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/57.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/58.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/59.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/60.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/61.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/62.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/63.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/64.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/65.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/66.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/67.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/68.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/69.png", UriKind.Relative)));
            data.BlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/70.png", UriKind.Relative)));

            data.BlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/QuestionMark.png", UriKind.Relative)));
            data.BlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/0.png", UriKind.Relative)));
            data.BlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/1.png", UriKind.Relative)));
            data.BlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/2.png", UriKind.Relative)));
            data.BlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/3.png", UriKind.Relative)));
            data.BlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/4.png", UriKind.Relative)));
            data.BlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/5.png", UriKind.Relative)));
            data.BlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/6.png", UriKind.Relative)));
            data.BlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/7.png", UriKind.Relative)));
            data.BlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/8.png", UriKind.Relative)));
            data.BlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Kh2/numbersblue/9.png", UriKind.Relative)));

            //BW numbers Test
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/_QuestionMark.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/_0.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/_1.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/_2.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/_3.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/_4.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/_5.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/_6.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/_7.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/_8.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/_9.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/10.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/11.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/12.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/13.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/14.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/15.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/16.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/17.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/18.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/19.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/20.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/21.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/22.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/23.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/24.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/25.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/26.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/27.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/28.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/29.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/30.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/31.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/32.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/33.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/34.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/35.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/36.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/37.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/38.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/39.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/40.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/41.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/42.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/43.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/44.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/45.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/46.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/47.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/48.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/49.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/50.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/51.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/52.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/53.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/54.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/55.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/56.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/57.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/58.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/59.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/60.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/61.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/62.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/63.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/64.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/65.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/66.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/67.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/68.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/69.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/70.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/71.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/72.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/73.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/74.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/75.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/76.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/77.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/78.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/79.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/80.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/81.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/82.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/83.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/84.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/85.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/86.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/87.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/88.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/89.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/90.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/91.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/92.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/93.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/94.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/95.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/96.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/97.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/98.png", UriKind.Relative)));
            data.RaisinNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/99.png", UriKind.Relative)));

            data.RaisinSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/QuestionMark.png", UriKind.Relative)));
            data.RaisinSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/0.png", UriKind.Relative)));
            data.RaisinSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/1.png", UriKind.Relative)));
            data.RaisinSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/2.png", UriKind.Relative)));
            data.RaisinSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/3.png", UriKind.Relative)));
            data.RaisinSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/4.png", UriKind.Relative)));
            data.RaisinSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/5.png", UriKind.Relative)));
            data.RaisinSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/6.png", UriKind.Relative)));
            data.RaisinSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/7.png", UriKind.Relative)));
            data.RaisinSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/8.png", UriKind.Relative)));
            data.RaisinSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbers/9.png", UriKind.Relative)));

            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/_QuestionMark.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/_0.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/_1.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/_2.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/_3.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/_4.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/_5.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/_6.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/_7.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/_8.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/_9.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/10.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/11.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/12.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/13.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/14.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/15.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/16.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/17.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/18.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/19.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/20.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/21.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/22.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/23.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/24.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/25.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/26.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/27.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/28.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/29.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/30.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/31.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/32.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/33.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/34.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/35.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/36.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/37.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/38.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/39.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/40.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/41.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/42.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/43.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/44.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/45.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/46.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/47.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/48.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/49.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/50.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/51.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/52.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/53.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/54.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/55.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/56.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/57.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/58.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/59.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/60.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/61.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/62.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/63.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/64.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/65.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/66.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/67.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/68.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/69.png", UriKind.Relative)));
            data.RaisinBlueNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/70.png", UriKind.Relative)));

            data.RaisinBlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/QuestionMark.png", UriKind.Relative)));
            data.RaisinBlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/0.png", UriKind.Relative)));
            data.RaisinBlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/1.png", UriKind.Relative)));
            data.RaisinBlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/2.png", UriKind.Relative)));
            data.RaisinBlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/3.png", UriKind.Relative)));
            data.RaisinBlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/4.png", UriKind.Relative)));
            data.RaisinBlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/5.png", UriKind.Relative)));
            data.RaisinBlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/6.png", UriKind.Relative)));
            data.RaisinBlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/7.png", UriKind.Relative)));
            data.RaisinBlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/8.png", UriKind.Relative)));
            data.RaisinBlueSingleNumbers.Add(new BitmapImage(new Uri("Images/Numbers/Raisin/numbersblue/9.png", UriKind.Relative)));


            //Custom numbers
            string GoodPath = "Images/Numbers/Kh2/";
            string GoodPathBlue = "Images/Numbers/Kh2/";
            var urikindvar = UriKind.Relative;
            var urikindvarblue = UriKind.Relative;

            //very lazy method here. i don't feel like setting it up to check if each and every number image exists cause there are literally over 200
            //so i just check 4 images in each folder to decide if custom numbers should be used.
            //either the user has every number image in the folders or they can't load custom numbers
            //(or they get errors if they somehow happen to have the exact 4 i check for and are missing others)
            if (File.Exists("CustomImages/numbers/_5.png") && File.Exists("CustomImages/numbers/48.png") && File.Exists("CustomImages/numbers/_QuestionMark.png") && File.Exists("CustomImages/numbers/QuestionMark.png"))
            {
                GoodPath = "pack://application:,,,/CustomImages/";
                urikindvar = UriKind.Absolute;
                CustomNumbersFound = true;
            }
            if (File.Exists("CustomImages/numbersblue/_5.png") && File.Exists("CustomImages/numbersblue/48.png") && File.Exists("CustomImages/numbersblue/_QuestionMark.png") && File.Exists("CustomImages/numbersblue/QuestionMark.png"))
            {
                GoodPathBlue = "pack://application:,,,/CustomImages/";
                urikindvarblue = UriKind.Absolute;
                CustomBlueNumbersFound = true;
            }

            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/_QuestionMark.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/_0.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/_1.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/_2.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/_3.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/_4.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/_5.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/_6.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/_7.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/_8.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/_9.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/10.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/11.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/12.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/13.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/14.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/15.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/16.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/17.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/18.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/19.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/20.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/21.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/22.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/23.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/24.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/25.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/26.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/27.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/28.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/29.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/30.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/31.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/32.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/33.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/34.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/35.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/36.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/37.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/38.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/39.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/40.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/41.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/42.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/43.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/44.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/45.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/46.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/47.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/48.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/49.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/50.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/51.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/52.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/53.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/54.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/55.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/56.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/57.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/58.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/59.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/60.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/61.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/62.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/63.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/64.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/65.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/66.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/67.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/68.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/69.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/70.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/71.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/72.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/73.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/74.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/75.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/76.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/77.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/78.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/79.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/80.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/81.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/82.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/83.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/84.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/85.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/86.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/87.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/88.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/89.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/90.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/91.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/92.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/93.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/94.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/95.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/96.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/97.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/98.png", urikindvar)));
            data.CustomNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/99.png", urikindvar)));
            data.CustomSingleNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/QuestionMark.png", urikindvar)));
            data.CustomSingleNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/0.png", urikindvar)));
            data.CustomSingleNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/1.png", urikindvar)));
            data.CustomSingleNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/2.png", urikindvar)));
            data.CustomSingleNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/3.png", urikindvar)));
            data.CustomSingleNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/4.png", urikindvar)));
            data.CustomSingleNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/5.png", urikindvar)));
            data.CustomSingleNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/6.png", urikindvar)));
            data.CustomSingleNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/7.png", urikindvar)));
            data.CustomSingleNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/8.png", urikindvar)));
            data.CustomSingleNumbers.Add(new BitmapImage(new Uri(GoodPath + "numbers/9.png", urikindvar)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/_QuestionMark.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/_0.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/_1.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/_2.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/_3.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/_4.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/_5.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/_6.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/_7.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/_8.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/_9.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/10.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/11.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/12.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/13.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/14.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/15.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/16.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/17.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/18.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/19.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/20.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/21.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/22.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/23.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/24.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/25.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/26.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/27.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/28.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/29.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/30.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/31.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/32.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/33.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/34.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/35.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/36.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/37.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/38.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/39.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/40.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/41.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/42.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/43.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/44.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/45.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/46.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/47.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/48.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/49.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/50.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/51.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/52.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/53.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/54.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/55.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/56.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/57.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/58.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/59.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/60.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/61.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/62.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/63.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/64.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/65.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/66.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/67.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/68.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/69.png", urikindvarblue)));
            data.CustomBlueNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/70.png", urikindvarblue)));
            data.CustomBlueSingleNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/QuestionMark.png", urikindvarblue)));
            data.CustomBlueSingleNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/0.png", urikindvarblue)));
            data.CustomBlueSingleNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/1.png", urikindvarblue)));
            data.CustomBlueSingleNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/2.png", urikindvarblue)));
            data.CustomBlueSingleNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/3.png", urikindvarblue)));
            data.CustomBlueSingleNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/4.png", urikindvarblue)));
            data.CustomBlueSingleNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/5.png", urikindvarblue)));
            data.CustomBlueSingleNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/6.png", urikindvarblue)));
            data.CustomBlueSingleNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/7.png", urikindvarblue)));
            data.CustomBlueSingleNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/8.png", urikindvarblue)));
            data.CustomBlueSingleNumbers.Add(new BitmapImage(new Uri(GoodPathBlue + "numbersblue/9.png", urikindvarblue)));
            #endregion

            data.WorldsData.Add("SorasHeart", new WorldData(SorasHeartTop, SorasHeart, null, SorasHeartHint, SorasHeartGrid, SorasHeartBar, false));
            data.WorldsData.Add("DriveForms", new WorldData(DriveFormsTop, DriveForms, null, DriveFormsHint, DriveFormsGrid, DriveFormsBar, false));
            data.WorldsData.Add("SimulatedTwilightTown", new WorldData(SimulatedTwilightTownTop, SimulatedTwilightTown, SimulatedTwilightTownProgression, SimulatedTwilightTownHint, SimulatedTwilightTownGrid, SimulatedTwilightTownBar, false));
            data.WorldsData.Add("TwilightTown", new WorldData(TwilightTownTop, TwilightTown, TwilightTownProgression, TwilightTownHint, TwilightTownGrid, TwilightTownBar, false));
            data.WorldsData.Add("HollowBastion", new WorldData(HollowBastionTop, HollowBastion, HollowBastionProgression, HollowBastionHint, HollowBastionGrid, HollowBastionBar, false));
            data.WorldsData.Add("BeastsCastle", new WorldData(BeastsCastleTop, BeastsCastle, BeastsCastleProgression, BeastsCastleHint, BeastsCastleGrid, BeastsCastleBar, false));
            data.WorldsData.Add("OlympusColiseum", new WorldData(OlympusColiseumTop, OlympusColiseum, OlympusColiseumProgression, OlympusColiseumHint, OlympusColiseumGrid, OlympusBar, false));
            data.WorldsData.Add("Agrabah", new WorldData(AgrabahTop, Agrabah, AgrabahProgression, AgrabahHint, AgrabahGrid, AgrabahBar, false));
            data.WorldsData.Add("LandofDragons", new WorldData(LandofDragonsTop, LandofDragons, LandofDragonsProgression, LandofDragonsHint, LandofDragonsGrid, LandofDragonsBar, false));
            data.WorldsData.Add("HundredAcreWood", new WorldData(HundredAcreWoodTop, HundredAcreWood, HundredAcreWoodProgression, HundredAcreWoodHint, HundredAcreWoodGrid, HundredAcreWoodBar, false));
            data.WorldsData.Add("PrideLands", new WorldData(PrideLandsTop, PrideLands, PrideLandsProgression, PrideLandsHint, PrideLandsGrid, PrideLandsBar, false));
            data.WorldsData.Add("DisneyCastle", new WorldData(DisneyCastleTop, DisneyCastle, DisneyCastleProgression, DisneyCastleHint, DisneyCastleGrid, DisneyCastleBar, false));
            data.WorldsData.Add("HalloweenTown", new WorldData(HalloweenTownTop, HalloweenTown, HalloweenTownProgression, HalloweenTownHint, HalloweenTownGrid, HalloweenTownBar, false));
            data.WorldsData.Add("PortRoyal", new WorldData(PortRoyalTop, PortRoyal, PortRoyalProgression, PortRoyalHint, PortRoyalGrid, PortRoyalBar, false));
            data.WorldsData.Add("SpaceParanoids", new WorldData(SpaceParanoidsTop, SpaceParanoids, SpaceParanoidsProgression, SpaceParanoidsHint, SpaceParanoidsGrid, SpaceParanoidsBar, false));
            data.WorldsData.Add("TWTNW", new WorldData(TWTNWTop, TWTNW, TWTNWProgression, TWTNWHint, TWTNWGrid, TWTNWBar, false));
            data.WorldsData.Add("GoA", new WorldData(GoATop, GoA, null, null, GoAGrid, GoABar, true));
            data.WorldsData.Add("Atlantica", new WorldData(AtlanticaTop, Atlantica, AtlanticaProgression, AtlanticaHint, AtlanticaGrid, AtlanticaBar, false));

            data.ProgressKeys.Add("SimulatedTwilightTown", new List<string>() { "", "ComputerRoom", "Axel", "DataRoxas" });
            data.ProgressKeys.Add("TwilightTown", new List<string>() { "", "MysteriousTower", "Sandlot", "Mansion", "BetwixtAndBetween", "DataAxel" });
            data.ProgressKeys.Add("HollowBastion", new List<string>() { "", "HBChests", "Bailey", "AnsemStudy", "Corridor", "Dancers", "HBDemyx", "FinalFantasy", "1000Heartless", "Sephiroth", "DataDemyx" });
            data.ProgressKeys.Add("BeastsCastle", new List<string>() { "", "BCChests", "Thresholder", "Beast", "DarkThorn", "Dragoons", "Xaldin", "DataXaldin" });
            data.ProgressKeys.Add("OlympusColiseum", new List<string>() { "", "OCChests", "Cerberus", "OCDemyx", "OCPete", "Hydra", "AuronStatue", "Hades", "Zexion" });
            data.ProgressKeys.Add("Agrabah", new List<string>() { "", "AGChests", "Abu", "Chasm", "TreasureRoom", "Lords", "Carpet", "GenieJafar", "Lexaeus" });
            data.ProgressKeys.Add("LandofDragons", new List<string>() { "", "LoDChests", "Cave", "Summmit", "ShanYu", "ThroneRoom", "StormRider", "DataXigbar" });
            data.ProgressKeys.Add("HundredAcreWood", new List<string>() { "", "Pooh", "Piglet", "Rabbit", "Kanga", "SpookyCave", "StarryHill" });
            data.ProgressKeys.Add("PrideLands", new List<string>() { "", "PLChests", "Simba", "Scar", "GroundShaker", "DataSaix" });
            data.ProgressKeys.Add("DisneyCastle", new List<string>() { "", "DCChests", "Minnie", "OldPete", "Windows", "BoatPete", "DCPete", "Marluxia", "LingeringWill" });
            data.ProgressKeys.Add("HalloweenTown", new List<string>() { "", "HTChests", "CandyCaneLane", "PrisonKeeper", "OogieBoogie", "Presents", "Experiment", "Vexen" });
            data.ProgressKeys.Add("PortRoyal", new List<string>() { "", "PRChests", "Town", "Barbossa", "Gambler", "GrimReaper", "DataLuxord" });
            data.ProgressKeys.Add("SpaceParanoids", new List<string>() { "", "SPChests", "Screens", "HostileProgram", "SolarSailer", "MCP", "Larxene" });
            data.ProgressKeys.Add("TWTNW", new List<string>() { "", "TWTNWChests", "Roxas", "Xigbar", "Luxord", "Saix", "Xemnas1", "DataXemnas" });
            data.ProgressKeys.Add("Atlantica", new List<string>() { "" });

            foreach (ContentControl item in ItemPool.Children)
            {
                if (item is Item)
                {
                    data.Items.Add(item as Item);
                }
            }

            broadcast = new BroadcastWindow(data);

            //i really hate how i did some of this

            //check for custom stat and weapon icons
            {
                if (File.Exists("CustomImages/Other/sword.png"))
                    CustomSwordFound = true;
                if (File.Exists("CustomImages/Other/staff.png"))
                    CustomStaffFound = true;
                if (File.Exists("CustomImages/Other/shield.png"))
                    CustomShieldFound = true;

                if (File.Exists("CustomImages/Other/level.png"))
                    CustomLevelFound = true;
                if (File.Exists("CustomImages/Other/strength.png"))
                    CustomStrengthFound = true;
                if (File.Exists("CustomImages/Other/magic.png"))
                    CustomMagicFound = true;
                if (File.Exists("CustomImages/Other/defence.png"))
                    CustomDefenseFound = true;
            }

            //set stuff for the vertical images
            {
                data.VerticalBarW = new BitmapImage(new Uri("Images/VerticalBarWhite.png", UriKind.Relative));
                data.VerticalBarY = new BitmapImage(new Uri("Images/VerticalBar.png", UriKind.Relative));

                data.RaisinVerticalBarW = new BitmapImage(new Uri("Images/VerticalBarWhite.png", UriKind.Relative));
                data.RaisinVerticalBarY = new BitmapImage(new Uri("Images/VerticalBarBlack.png", UriKind.Relative));

                {
                    if (File.Exists("CustomImages/VerticalBarWhite.png"))
                        data.CustomnVerticalBarW = new BitmapImage(new Uri("pack://application:,,,/CustomImages/VerticalBarWhite.png", UriKind.Absolute));
                    else
                        data.CustomnVerticalBarW = data.VerticalBarW;
                }

                {
                    if (File.Exists("CustomImages/VerticalBar.png"))
                        data.CustomnVerticalBarY = new BitmapImage(new Uri("pack://application:,,,/CustomImages/VerticalBar.png", UriKind.Absolute));
                    else
                        data.CustomnVerticalBarY = data.VerticalBarY;
                }
            }

            //check basic quesstion mark image
            {
                data.Question = new BitmapImage(new Uri("Images/question.png", UriKind.Relative));
                data.RaisinQuestion = new BitmapImage(new Uri("Images/question.png", UriKind.Relative));

                if (File.Exists("CustomImages/question.png"))
                {
                    data.CustomQuestion = new BitmapImage(new Uri("pack://application:,,,/CustomImages/question.png", UriKind.Absolute));
                }

                else
                    data.CustomQuestion = data.Question;
            }

            //set stuff for the slash bar images
            {
                data.SlashBarB = new BitmapImage(new Uri("Images/Numbers/Kh2/BarBlue.png", UriKind.Relative));
                data.SlashBarY = new BitmapImage(new Uri("Images/Numbers/Kh2/Bar.png", UriKind.Relative));

                data.RaisinSlashBarB = new BitmapImage(new Uri("Images/Numbers/Raisin/BarBlue.png", UriKind.Relative));
                data.RaisinSlashBarY = new BitmapImage(new Uri("Images/Numbers/Raisin/Bar.png", UriKind.Relative));

                {
                    if (File.Exists("CustomImages/BarBlue.png"))
                        data.CustomnSlashBarB = new BitmapImage(new Uri("pack://application:,,,/CustomImages/BarBlue.png", UriKind.Absolute));
                    else
                        data.CustomnSlashBarB = data.SlashBarB;
                }

                {
                    if (File.Exists("CustomImages/Bar.png"))
                        data.CustomnSlashBarY = new BitmapImage(new Uri("pack://application:,,,/CustomImages/Bar.png", UriKind.Absolute));
                    else
                        data.CustomnSlashBarY = data.SlashBarY;
                }
            }
        }

        private void InitOptions()
        {
            PromiseCharmOption.IsChecked = Properties.Settings.Default.PromiseCharm;
            HandleItemToggle(PromiseCharmOption.IsChecked, PromiseCharm, true);

            ReportsOption.IsChecked = Properties.Settings.Default.AnsemReports;
            for (int i = 0; i < data.Reports.Count; ++i)
            {
                HandleItemToggle(ReportsOption.IsChecked, data.Reports[i], true);
            }

            AbilitiesOption.IsChecked = Properties.Settings.Default.Abilities;
            HandleItemToggle(AbilitiesOption.IsChecked, OnceMore, true);
            HandleItemToggle(AbilitiesOption.IsChecked, SecondChance, true);

            TornPagesOption.IsChecked = Properties.Settings.Default.TornPages;
            for (int i = 0; i < data.TornPages.Count; ++i)
            {
                HandleItemToggle(TornPagesOption.IsChecked, data.TornPages[i], true);
            }

            CureOption.IsChecked = Properties.Settings.Default.Cure;
            HandleItemToggle(CureOption.IsChecked, Cure1, true);
            HandleItemToggle(CureOption.IsChecked, Cure2, true);
            HandleItemToggle(CureOption.IsChecked, Cure3, true);

            FinalFormOption.IsChecked = Properties.Settings.Default.FinalForm;
            HandleItemToggle(FinalFormOption.IsChecked, Final, true);

            //check icon change
            SimpleOption.IsChecked = Properties.Settings.Default.Simple;
            if (SimpleOption.IsChecked)
                SimpleToggle(null, null);

            OrbOption.IsChecked = Properties.Settings.Default.Orb;
            if (OrbOption.IsChecked)
                OrbToggle(null, null);

            AltOption.IsChecked = Properties.Settings.Default.Alt;
            if (AltOption.IsChecked)
                AltToggle(null, null);

            //world icon change
            DefWorldOption.IsChecked = Properties.Settings.Default.DefWorld;
            if (DefWorldOption.IsChecked)
                DefWorldToggle(null, null);

            OutWorldOption.IsChecked = Properties.Settings.Default.OutWorld;
            if (OutWorldOption.IsChecked)
                OutWorldToggle(null, null);

            GamWorldOption.IsChecked = Properties.Settings.Default.GamWorld;
            if (GamWorldOption.IsChecked)
                GamWorldToggle(null, null);

            BawWorldOption.IsChecked = Properties.Settings.Default.BawWorld;
            if (BawWorldOption.IsChecked)
                BawWorldToggle(null, null);

            //progression icon change
            DefProgOption.IsChecked = Properties.Settings.Default.DefProg;
            if (DefProgOption.IsChecked)
                DefProgToggle(null, null);

            OldProgOption.IsChecked = Properties.Settings.Default.OldProg;
            if (OldProgOption.IsChecked)
                OldProgToggle(null, null);

            BaWProgOption.IsChecked = Properties.Settings.Default.BaWProg;
            if (BaWProgOption.IsChecked)
                BaWProgToggle(null, null);

            //CustomFolder change
            CustomFolderOption.IsChecked = Properties.Settings.Default.CustomFolder;
            if (CustomFolderOption.IsChecked)
                CustomImageToggle(null, null);


            //new ICs
            HadesTrophyOption.IsChecked = Properties.Settings.Default.CupTrophy;
            HandleItemToggle(HadesTrophyOption.IsChecked, HadesCup, true);

            HBCardOption.IsChecked = Properties.Settings.Default.MemberCard;
            HandleItemToggle(HBCardOption.IsChecked, MembershipCard, true);

            OStoneOption.IsChecked = Properties.Settings.Default.Stone;
            HandleItemToggle(OStoneOption.IsChecked, OlympusStone, true);

            ComboMasterOption.IsChecked = Properties.Settings.Default.ComboMaster;
            HandleItemToggle(ComboMasterOption.IsChecked, ComboMaster, true);

            WorldProgressOption.IsChecked = Properties.Settings.Default.WorldProgress;
            WorldProgressToggle(null, null);

            SoraHeartOption.IsChecked = Properties.Settings.Default.SoraHeart;
            SoraHeartToggle(SoraHeartOption.IsChecked);
            SimulatedOption.IsChecked = Properties.Settings.Default.Simulated;
            SimulatedToggle(SimulatedOption.IsChecked);
            HundredAcreWoodOption.IsChecked = Properties.Settings.Default.HundredAcre;
            HundredAcreWoodToggle(HundredAcreWoodOption.IsChecked);
            AtlanticaOption.IsChecked = Properties.Settings.Default.Atlantica;
            AtlanticaToggle(AtlanticaOption.IsChecked);

            DragAndDropOption.IsChecked = Properties.Settings.Default.DragDrop;
            DragDropToggle(null, null);

            TopMostOption.IsChecked = Properties.Settings.Default.TopMost;
            TopMostToggle(null, null);

            BroadcastStartupOption.IsChecked = Properties.Settings.Default.BroadcastStartup;
            BroadcastStartupToggle(null, null);

            FormsGrowthOption.IsChecked = Properties.Settings.Default.FormsGrowth;
            FormsGrowthToggle(null, null);

            Top = Properties.Settings.Default.WindowY;
            Left = Properties.Settings.Default.WindowX;

            Width = Properties.Settings.Default.Width;
            Height = Properties.Settings.Default.Height;

            //testing background settings stuff ( thought this would be simplier than the above methods)
            //maybe i was wrong.
            {
                int MainBG = Properties.Settings.Default.MainbBgColor;
                if (MainBG == 0)
                {
                    ColorDefOption.IsChecked = true;
                    ColorRedOption.IsChecked = false;
                    ColorGrnOption.IsChecked = false;
                    ColorBluOption.IsChecked = false;
                    ColorImg1Option.IsChecked = false;
                    ColorImg2Option.IsChecked = false;
                    ColorImg3Option.IsChecked = false;
                    ColorChangeTestDef(null, null);
                }
                else if (MainBG == 1)
                {
                    ColorDefOption.IsChecked = false;
                    ColorRedOption.IsChecked = true;
                    ColorGrnOption.IsChecked = false;
                    ColorBluOption.IsChecked = false;
                    ColorImg1Option.IsChecked = false;
                    ColorImg2Option.IsChecked = false;
                    ColorImg3Option.IsChecked = false;
                    ColorChangeTestRed(null, null);
                }
                else if (MainBG == 2)
                {
                    ColorDefOption.IsChecked = false;
                    ColorRedOption.IsChecked = false;
                    ColorGrnOption.IsChecked = true;
                    ColorBluOption.IsChecked = false;
                    ColorImg1Option.IsChecked = false;
                    ColorImg2Option.IsChecked = false;
                    ColorImg3Option.IsChecked = false;
                    ColorChangeTestGrn(null, null);

                }
                else if (MainBG == 3)
                {

                    ColorDefOption.IsChecked = false;
                    ColorRedOption.IsChecked = false;
                    ColorGrnOption.IsChecked = false;
                    ColorBluOption.IsChecked = true;
                    ColorImg1Option.IsChecked = false;
                    ColorImg2Option.IsChecked = false;
                    ColorImg3Option.IsChecked = false;
                    ColorChangeTestBlu(null, null);
                }
                else if (MainBG == 4)
                {
                    ColorDefOption.IsChecked = false;
                    ColorRedOption.IsChecked = false;
                    ColorGrnOption.IsChecked = false;
                    ColorBluOption.IsChecked = false;
                    ColorImg1Option.IsChecked = true;
                    ColorImg2Option.IsChecked = false;
                    ColorImg3Option.IsChecked = false;
                    ColorChangeTestImg1(null, null);
                }
                else if (MainBG == 5)
                {
                    ColorDefOption.IsChecked = false;
                    ColorRedOption.IsChecked = false;
                    ColorGrnOption.IsChecked = false;
                    ColorBluOption.IsChecked = false;
                    ColorImg1Option.IsChecked = false;
                    ColorImg2Option.IsChecked = true;
                    ColorImg3Option.IsChecked = false;
                    ColorChangeTestImg2(null, null);
                }
                else if (MainBG == 6)
                {
                    ColorDefOption.IsChecked = false;
                    ColorRedOption.IsChecked = false;
                    ColorGrnOption.IsChecked = false;
                    ColorBluOption.IsChecked = false;
                    ColorImg1Option.IsChecked = false;
                    ColorImg2Option.IsChecked = false;
                    ColorImg3Option.IsChecked = true;
                    ColorChangeTestImg3(null, null);
                }                 
                else
                {
                    ColorDefOption.IsChecked = true;
                    ColorRedOption.IsChecked = false;
                    ColorGrnOption.IsChecked = false;
                    ColorBluOption.IsChecked = false;
                    ColorImg1Option.IsChecked = false;
                    ColorImg2Option.IsChecked = false;
                    ColorImg3Option.IsChecked = false;
                    ColorChangeTestDef(null, null);
                }
            }
            {
                int BroadcastBG = Properties.Settings.Default.BroadcastBgColor;
                if (BroadcastBG == 0)
                {
                    BroadcastColorDefOption.IsChecked = true;
                    BroadcastColorRedOption.IsChecked = false;
                    BroadcastColorGrnOption.IsChecked = false;
                    BroadcastColorBluOption.IsChecked = false;
                    BroadcastColorImg1Option.IsChecked = false;
                    BroadcastColorImg2Option.IsChecked = false;
                    BroadcastColorImg3Option.IsChecked = false;
                    ColorChangeBroadcastDef(null, null);
                }
                else if (BroadcastBG == 1)
                {
                    BroadcastColorDefOption.IsChecked = false;
                    BroadcastColorRedOption.IsChecked = true;
                    BroadcastColorGrnOption.IsChecked = false;
                    BroadcastColorBluOption.IsChecked = false;
                    BroadcastColorImg1Option.IsChecked = false;
                    BroadcastColorImg2Option.IsChecked = false;
                    BroadcastColorImg3Option.IsChecked = false;
                    ColorChangeBroadcastRed(null, null);
                }
                else if (BroadcastBG == 2)
                {
                    BroadcastColorDefOption.IsChecked = false;
                    BroadcastColorRedOption.IsChecked = false;
                    BroadcastColorGrnOption.IsChecked = true;
                    BroadcastColorBluOption.IsChecked = false;
                    BroadcastColorImg1Option.IsChecked = false;
                    BroadcastColorImg2Option.IsChecked = false;
                    BroadcastColorImg3Option.IsChecked = false;
                    ColorChangeBroadcastGrn(null, null);

                }
                else if (BroadcastBG == 3)
                {

                    BroadcastColorDefOption.IsChecked = false;
                    BroadcastColorRedOption.IsChecked = false;
                    BroadcastColorGrnOption.IsChecked = false;
                    BroadcastColorBluOption.IsChecked = true;
                    BroadcastColorImg1Option.IsChecked = false;
                    BroadcastColorImg2Option.IsChecked = false;
                    BroadcastColorImg3Option.IsChecked = false;
                    ColorChangeBroadcastBlu(null, null);
                }
                else if (BroadcastBG == 4)
                {
                    BroadcastColorDefOption.IsChecked = false;
                    BroadcastColorRedOption.IsChecked = false;
                    BroadcastColorGrnOption.IsChecked = false;
                    BroadcastColorBluOption.IsChecked = false;
                    BroadcastColorImg1Option.IsChecked = true;
                    BroadcastColorImg2Option.IsChecked = false;
                    BroadcastColorImg3Option.IsChecked = false;
                    ColorChangeBroadcastImg1(null, null);
                }
                else if (BroadcastBG == 5)
                {
                    BroadcastColorDefOption.IsChecked = false;
                    BroadcastColorRedOption.IsChecked = false;
                    BroadcastColorGrnOption.IsChecked = false;
                    BroadcastColorBluOption.IsChecked = false;
                    BroadcastColorImg1Option.IsChecked = false;
                    BroadcastColorImg2Option.IsChecked = true;
                    BroadcastColorImg3Option.IsChecked = false;
                    ColorChangeBroadcastImg2(null, null);
                }
                else if (BroadcastBG == 6)
                {
                    BroadcastColorDefOption.IsChecked = false;
                    BroadcastColorRedOption.IsChecked = false;
                    BroadcastColorGrnOption.IsChecked = false;
                    BroadcastColorBluOption.IsChecked = false;
                    BroadcastColorImg1Option.IsChecked = false;
                    BroadcastColorImg2Option.IsChecked = false;
                    BroadcastColorImg3Option.IsChecked = true;
                    ColorChangeBroadcastImg3(null, null);
                }
                else
                {
                    BroadcastColorDefOption.IsChecked = true;
                    BroadcastColorRedOption.IsChecked = false;
                    BroadcastColorGrnOption.IsChecked = false;
                    BroadcastColorBluOption.IsChecked = false;
                    BroadcastColorImg1Option.IsChecked = false;
                    BroadcastColorImg2Option.IsChecked = false;
                    BroadcastColorImg3Option.IsChecked = false;
                    ColorChangeBroadcastDef(null, null);
                }

            }
        }

        /// 
        /// Input Handling
        /// 
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            //this chunk of garbage for using the correct vertical images
            bool RaisinMode = Properties.Settings.Default.Alt;
            bool CustomMode = Properties.Settings.Default.CustomFolder;
            var NormalNum = data.Numbers;
            BitmapImage BarW = data.VerticalBarW;
            BitmapImage BarY = data.VerticalBarY;
            {
                if (CustomMode)
                {
                    NormalNum = data.CustomNumbers;

                    if (File.Exists("CustomImages/VerticalBarWhite.png"))
                        BarW = data.CustomnVerticalBarW;
                    if (File.Exists("CustomImages/VerticalBar.png"))
                        BarY = data.CustomnVerticalBarY;
                }
                else if (RaisinMode)
                {
                    NormalNum = data.RaisinNumbers;
                    BarW = data.RaisinVerticalBarW;
                    BarY = data.RaisinVerticalBarY;
                }
            }

            Button button = sender as Button;
            if (e.ChangedButton == MouseButton.Left)
            {
                if (data.selected != null)
                {
                    data.WorldsData[data.selected.Name].selectedBar.Source = BarW;
                }
                data.selected = button;
                data.WorldsData[button.Name].selectedBar.Source = BarY;
            }
            //changed this. it was pointing to the wrong image before and was trigering when hints were loaded when it wasn't supposed to.
            else if (e.ChangedButton == MouseButton.Middle && data.mode == Mode.None)
            {
                if (data.WorldsData.ContainsKey(button.Name) && data.WorldsData[button.Name].hint != null)
                {
                    data.WorldsData[button.Name].hint.Source = NormalNum[0];
                }
            }
        }

        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            Button button = sender as Button;

            if (data.WorldsData.ContainsKey(button.Name) && data.WorldsData[button.Name].hint != null)
            {
                HandleReportValue(data.WorldsData[button.Name].hint, e.Delta);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.PageDown && data.selected != null)
            {
                if (data.WorldsData.ContainsKey(data.selected.Name) && data.WorldsData[data.selected.Name].hint != null)
                {
                    HandleReportValue(data.WorldsData[data.selected.Name].hint, -1);
                }
            }
            if (e.Key == Key.PageUp && data.selected != null)
            {
                if (data.WorldsData.ContainsKey(data.selected.Name) && data.WorldsData[data.selected.Name].hint != null)
                {
                    HandleReportValue(data.WorldsData[data.selected.Name].hint, 1);
                }
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Save("kh2fm-tracker-autosave.txt");
            Properties.Settings.Default.Save();
            broadcast.canClose = true;
            broadcast.Close();
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.WindowY = RestoreBounds.Top;
            Properties.Settings.Default.WindowX = RestoreBounds.Left;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Properties.Settings.Default.Width = RestoreBounds.Width;
            Properties.Settings.Default.Height = RestoreBounds.Height;
        }

        /// 
        /// Handle UI Changes
        /// 
        private void HandleReportValue(Image Hint, int delta)
        {
            if (data.mode != Mode.None)
                return;

            //all this garbage to get the correct number images
            bool RaisinMode = Properties.Settings.Default.Alt;
            bool CustomMode = Properties.Settings.Default.CustomFolder;
            var NormalNum = data.Numbers;
            {
                if (CustomMode)
                {
                    NormalNum = data.CustomNumbers;
                }
                else if (RaisinMode)
                {
                    NormalNum = data.RaisinNumbers;
                }
            }

            int num = 0;

            for (int i = 0; i < NormalNum.Count; ++i)
            {
                if (Hint.Source == NormalNum[i])
                {
                    num = i;
                }
            }

            if (delta > 0)
                ++num;
            else
                --num;

            // cap hint value to 51
            if (num > 56)
                num = 56;

            if (num < 0)
                Hint.Source = NormalNum[0];
            else
                Hint.Source = NormalNum[num];

            broadcast.UpdateTotal(Hint.Name.Remove(Hint.Name.Length - 4, 4), num - 1);
        }

        public void SetReportValue(Image Hint, int value)
        {
            //all this garbage to get the correct number images
            bool RaisinMode = Properties.Settings.Default.Alt;
            bool CustomMode = Properties.Settings.Default.CustomFolder;
            var numList = data.Numbers;
            var numListB = data.BlueNumbers;
            {
                if (CustomMode)
                {
                    numList = data.CustomNumbers;
                    numListB = data.CustomBlueNumbers;
                }
                else if (RaisinMode)
                {
                    numList = data.RaisinNumbers;
                    numListB = data.RaisinBlueNumbers;
                }
            }


            string location = Hint.Name.Substring(0, Hint.Name.Length - 4);
            if (data.WorldsData[location].hintedHint || data.WorldsData[location].complete)
                numList = numListB;

            if (value > 56)
                value = 56;

            if (value < 1 && (data.mode == Mode.AltHints || data.mode == Mode.OpenKHAltHints))
                Hint.Source = numList[1];
            else if (value < 0)
                Hint.Source = numList[0];
            else
                Hint.Source = numList[value];

            broadcast.UpdateTotal(Hint.Name.Remove(Hint.Name.Length - 4, 4), value - 1);
        }

        public void IncrementCollected()
        {
            //all this garbage to get the correct number images
            bool RaisinMode = Properties.Settings.Default.Alt;
            bool CustomMode = Properties.Settings.Default.CustomFolder;
            var NormalNum = data.Numbers;
            {
                if (CustomMode)
                {
                    NormalNum = data.CustomNumbers;
                }
                else if (RaisinMode)
                {
                    NormalNum = data.RaisinNumbers;
                }
            }

            ++collected;
            if (collected > 55)
                collected = 55;

            Collected.Source = NormalNum[collected + 1];
            broadcast.Collected.Source = NormalNum[collected + 1];
        }

        public void DecrementCollected()
        {
            //all this garbage to get the correct number images
            bool RaisinMode = Properties.Settings.Default.Alt;
            bool CustomMode = Properties.Settings.Default.CustomFolder;
            var NormalNum = data.Numbers;
            {
                if (CustomMode)
                {
                    NormalNum = data.CustomNumbers;
                }
                else if (RaisinMode)
                {
                    NormalNum = data.RaisinNumbers;
                }
            }

            --collected;
            if (collected < 0)
                collected = 0;

            Collected.Source = NormalNum[collected + 1];
            broadcast.Collected.Source = NormalNum[collected + 1];
        }

        public void IncrementTotal()
        {
            //all this garbage to get the correct number images
            bool RaisinMode = Properties.Settings.Default.Alt;
            bool CustomMode = Properties.Settings.Default.CustomFolder;
            var NormalNum = data.Numbers;
            {
                if (CustomMode)
                {
                    NormalNum = data.CustomNumbers;
                }
                else if (RaisinMode)
                {
                    NormalNum = data.RaisinNumbers;
                }
            }

            ++total;
            if (total > 55)
                total = 55;

            CheckTotal.Source = NormalNum[total + 1];
            broadcast.CheckTotal.Source = NormalNum[total + 1];
        }

        public void DecrementTotal()
        {
            //all this garbage to get the correct number images
            bool RaisinMode = Properties.Settings.Default.Alt;
            bool CustomMode = Properties.Settings.Default.CustomFolder;
            var NormalNum = data.Numbers;
            {
                if (CustomMode)
                {
                    NormalNum = data.CustomNumbers;
                }
                else if (RaisinMode)
                {
                    NormalNum = data.RaisinNumbers;
                }
            }

            --total;
            if (total < 0)
                total = 0;

            CheckTotal.Source = NormalNum[total + 1];
            broadcast.CheckTotal.Source = NormalNum[total + 1];

        }

        public void SetHintText(string text)
        {
            HintText.Content = text;
        }

        private void ResetSize(object sender, RoutedEventArgs e)
        {
            Width = 570;
            Height = 880;

            broadcast.Width = 500;
            broadcast.Height = 680;
        }

        //dumb window backgound stuff
        private void ColorChangeTestDef(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (ColorDefOption.IsChecked == false)
            {
                ColorDefOption.IsChecked = true;
                return;
            }

            ColorRedOption.IsChecked = false;
            ColorGrnOption.IsChecked = false;
            ColorBluOption.IsChecked = false;
            ColorImg1Option.IsChecked = false;
            ColorImg2Option.IsChecked = false;
            ColorImg3Option.IsChecked = false;

            Properties.Settings.Default.MainbBgColor = 0;

            if (ColorDefOption.IsChecked)
            {
                Background = Application.Current.Resources["BG-Default"] as SolidColorBrush;
            }
        }

        private void ColorChangeTestRed(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (ColorRedOption.IsChecked == false)
            {
                ColorRedOption.IsChecked = true;
                return;
            }

            ColorDefOption.IsChecked = false;
            ColorGrnOption.IsChecked = false;
            ColorBluOption.IsChecked = false;
            ColorImg1Option.IsChecked = false;
            ColorImg2Option.IsChecked = false;
            ColorImg3Option.IsChecked = false;

            Properties.Settings.Default.MainbBgColor = 1;

            if (ColorRedOption.IsChecked)
            {
                Background = Application.Current.Resources["BG-Red"] as SolidColorBrush;
            }
        }

        private void ColorChangeTestGrn(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (ColorGrnOption.IsChecked == false)
            {
                ColorGrnOption.IsChecked = true;
                return;
            }

            ColorRedOption.IsChecked = false;
            ColorDefOption.IsChecked = false;
            ColorBluOption.IsChecked = false;
            ColorImg1Option.IsChecked = false;
            ColorImg2Option.IsChecked = false;
            ColorImg3Option.IsChecked = false;

            Properties.Settings.Default.MainbBgColor = 2;

            if (ColorGrnOption.IsChecked)
            {
                Background = Application.Current.Resources["BG-Green"] as SolidColorBrush;
            }
        }

        private void ColorChangeTestBlu(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (ColorBluOption.IsChecked == false)
            {
                ColorBluOption.IsChecked = true;
                return;
            }

            ColorRedOption.IsChecked = false;
            ColorGrnOption.IsChecked = false;
            ColorDefOption.IsChecked = false;
            ColorImg1Option.IsChecked = false;
            ColorImg2Option.IsChecked = false;
            ColorImg3Option.IsChecked = false;

            Properties.Settings.Default.MainbBgColor = 3;

            if (ColorBluOption.IsChecked)
            {
                Background = Application.Current.Resources["BG-Blue"] as SolidColorBrush;
            }
        }

        private void ColorChangeTestImg1(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (ColorImg1Option.IsChecked == false)
            {
                ColorImg1Option.IsChecked = true;
                return;
            }

            ColorRedOption.IsChecked = false;
            ColorGrnOption.IsChecked = false;
            ColorDefOption.IsChecked = false;
            ColorBluOption.IsChecked = false;
            ColorImg2Option.IsChecked = false;
            ColorImg3Option.IsChecked = false;

            Properties.Settings.Default.MainbBgColor = 4;

            if (ColorImg1Option.IsChecked)
            {
                if (File.Exists("CustomImages/BG.png"))
                    Background = Application.Current.Resources["BG-ImageTest"] as ImageBrush;
                else
                    Background = Application.Current.Resources["BG-ImageDef"] as ImageBrush;
            }
        }

        private void ColorChangeTestImg2(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (ColorImg2Option.IsChecked == false)
            {
                ColorImg2Option.IsChecked = true;
                return;
            }

            ColorRedOption.IsChecked = false;
            ColorGrnOption.IsChecked = false;
            ColorDefOption.IsChecked = false;
            ColorBluOption.IsChecked = false;
            ColorImg1Option.IsChecked = false;
            ColorImg3Option.IsChecked = false;

            Properties.Settings.Default.MainbBgColor = 5;

            if (ColorImg2Option.IsChecked)
            {
                if (File.Exists("CustomImages/BG.png"))
                    Background = Application.Current.Resources["BG-ImageTestUni"] as ImageBrush;
                else
                    Background = Application.Current.Resources["BG-ImageDefUni"] as ImageBrush;
            }
        }

        private void ColorChangeTestImg3(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (ColorImg3Option.IsChecked == false)
            {
                ColorImg3Option.IsChecked = true;
                return;
            }

            ColorRedOption.IsChecked = false;
            ColorGrnOption.IsChecked = false;
            ColorDefOption.IsChecked = false;
            ColorBluOption.IsChecked = false;
            ColorImg1Option.IsChecked = false;
            ColorImg2Option.IsChecked = false;

            Properties.Settings.Default.MainbBgColor = 6;

            if (ColorImg3Option.IsChecked)
            {
                if (File.Exists("CustomImages/BG.png"))
                    Background = Application.Current.Resources["BG-ImageTestNon"] as ImageBrush;
                else
                    Background = Application.Current.Resources["BG-ImageDefNon"] as ImageBrush;
            }
        }

        private void ColorChangeBroadcastDef(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (BroadcastColorDefOption.IsChecked == false)
            {
                BroadcastColorDefOption.IsChecked = true;
                return;
            }

            BroadcastColorRedOption.IsChecked = false;
            BroadcastColorGrnOption.IsChecked = false;
            BroadcastColorBluOption.IsChecked = false;
            BroadcastColorImg1Option.IsChecked = false;
            BroadcastColorImg2Option.IsChecked = false;
            BroadcastColorImg3Option.IsChecked = false;

            Properties.Settings.Default.BroadcastBgColor = 0;

            if (BroadcastColorDefOption.IsChecked)
            {
                broadcast.Background = Application.Current.Resources["BG-Default"] as SolidColorBrush;
            }
        }

        private void ColorChangeBroadcastRed(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (BroadcastColorRedOption.IsChecked == false)
            {
                BroadcastColorRedOption.IsChecked = true;
                return;
            }

            BroadcastColorDefOption.IsChecked = false;
            BroadcastColorGrnOption.IsChecked = false;
            BroadcastColorBluOption.IsChecked = false;
            BroadcastColorImg1Option.IsChecked = false;
            BroadcastColorImg2Option.IsChecked = false;
            BroadcastColorImg3Option.IsChecked = false;

            Properties.Settings.Default.BroadcastBgColor = 1;

            if (BroadcastColorRedOption.IsChecked)
            {
                broadcast.Background = Application.Current.Resources["BG-Red"] as SolidColorBrush;
            }
        }

        private void ColorChangeBroadcastGrn(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (BroadcastColorGrnOption.IsChecked == false)
            {
                BroadcastColorGrnOption.IsChecked = true;
                return;
            }

            BroadcastColorRedOption.IsChecked = false;
            BroadcastColorDefOption.IsChecked = false;
            BroadcastColorBluOption.IsChecked = false;
            BroadcastColorImg1Option.IsChecked = false;
            BroadcastColorImg2Option.IsChecked = false;
            BroadcastColorImg3Option.IsChecked = false;

            Properties.Settings.Default.BroadcastBgColor = 2;

            if (BroadcastColorGrnOption.IsChecked)
            {
                broadcast.Background = Application.Current.Resources["BG-Green"] as SolidColorBrush;
            }
        }

        private void ColorChangeBroadcastBlu(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (BroadcastColorBluOption.IsChecked == false)
            {
                BroadcastColorBluOption.IsChecked = true;
                return;
            }

            BroadcastColorRedOption.IsChecked = false;
            BroadcastColorGrnOption.IsChecked = false;
            BroadcastColorDefOption.IsChecked = false;
            BroadcastColorImg1Option.IsChecked = false;
            BroadcastColorImg2Option.IsChecked = false;
            BroadcastColorImg3Option.IsChecked = false;

            Properties.Settings.Default.BroadcastBgColor = 3;

            if (BroadcastColorBluOption.IsChecked)
            {
                broadcast.Background = Application.Current.Resources["BG-Blue"] as SolidColorBrush;
            }
        }

        private void ColorChangeBroadcastImg1(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (BroadcastColorImg1Option.IsChecked == false)
            {
                BroadcastColorImg1Option.IsChecked = true;
                return;
            }

            BroadcastColorRedOption.IsChecked = false;
            BroadcastColorGrnOption.IsChecked = false;
            BroadcastColorDefOption.IsChecked = false;
            BroadcastColorBluOption.IsChecked = false;
            BroadcastColorImg2Option.IsChecked = false;
            BroadcastColorImg3Option.IsChecked = false;

            Properties.Settings.Default.BroadcastBgColor = 4;

            if (BroadcastColorImg1Option.IsChecked)
            {
                if (File.Exists("CustomImages/BG.png"))
                    broadcast.Background = Application.Current.Resources["BG-BImageTest"] as ImageBrush;
                else
                    broadcast.Background = Application.Current.Resources["BG-BImageDef"] as ImageBrush;
            }
        }

        private void ColorChangeBroadcastImg2(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (BroadcastColorImg2Option.IsChecked == false)
            {
                BroadcastColorImg2Option.IsChecked = true;
                return;
            }

            BroadcastColorRedOption.IsChecked = false;
            BroadcastColorGrnOption.IsChecked = false;
            BroadcastColorDefOption.IsChecked = false;
            BroadcastColorBluOption.IsChecked = false;
            BroadcastColorImg1Option.IsChecked = false;
            BroadcastColorImg3Option.IsChecked = false;

            Properties.Settings.Default.BroadcastBgColor = 5;

            if (BroadcastColorImg2Option.IsChecked)
            {
                if (File.Exists("CustomImages/BG.png"))
                    broadcast.Background = Application.Current.Resources["BG-BImageTestUni"] as ImageBrush;
                else
                    broadcast.Background = Application.Current.Resources["BG-BImageDefUni"] as ImageBrush;
            }
        }

        private void ColorChangeBroadcastImg3(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (BroadcastColorImg3Option.IsChecked == false)
            {
                BroadcastColorImg3Option.IsChecked = true;
                return;
            }

            BroadcastColorRedOption.IsChecked = false;
            BroadcastColorGrnOption.IsChecked = false;
            BroadcastColorDefOption.IsChecked = false;
            BroadcastColorBluOption.IsChecked = false;
            BroadcastColorImg1Option.IsChecked = false;
            BroadcastColorImg2Option.IsChecked = false;

            Properties.Settings.Default.BroadcastBgColor = 6;

            if (BroadcastColorImg3Option.IsChecked)
            {
                if (File.Exists("CustomImages/BG.png"))
                    broadcast.Background = Application.Current.Resources["BG-BImageTestNon"] as ImageBrush;
                else
                    broadcast.Background = Application.Current.Resources["BG-BImageDefNon"] as ImageBrush;
            }
        }

    }
}