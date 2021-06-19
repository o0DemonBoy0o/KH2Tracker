using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media.Imaging;

namespace KhTracker
{
    public class HideZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 0)
            {
                return " ";
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == " ")
            {
                return 0;
            }
            else
            {
                return value;
            }
        }
    }

    public class ObtainedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return 1;
            }
            else
            {
                return 0.85;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class ObtainedConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == false)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class ObtainedConverterOrig : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return 1;
            }
            else
            {
                return 0.25;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class LevelConverter : IValueConverter
    {
        string NormalPath = "Images/Numbers/Kh2";
        string RaisinPath = "Images/Numbers/Raisin";
        string CustomPath = "pack://application:,,,/CustomImages";
        string EnabledPath;
        string BluePath;
        bool Raisinmode = Properties.Settings.Default.Alt;
        bool CustomMode = Properties.Settings.Default.CustomFolder;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            {
                if (MainWindow.CustomNumbersFound && CustomMode)
                {
                    EnabledPath = CustomPath;

                    if (MainWindow.CustomBlueNumbersFound)
                    {
                        BluePath = CustomPath;
                    }
                    else if (MainWindow.CustomBlueNumbersFound == false)
                    {
                        if (Raisinmode)
                            BluePath = RaisinPath;
                        else
                            BluePath = NormalPath;
                    }
                }
                else if (Raisinmode)
                {
                    EnabledPath = RaisinPath;
                    BluePath = RaisinPath;
                }
                else
                {
                    EnabledPath = NormalPath;
                    BluePath = NormalPath;
                }
            }

            if ((int)value == 1)
            {
                return (EnabledPath + "/numbers/1.png");
            }
            else if ((int)value == 2)
            {
                return (EnabledPath + "/numbers/2.png");
            }
            else if ((int)value == 3)
            {
                return (EnabledPath + "/numbers/3.png");
            }
            else if ((int)value == 4)
            {
                return (EnabledPath + "/numbers/4.png");
            }
            else if ((int)value == 5)
            {
                return (EnabledPath + "/numbers/5.png");
            }
            else if ((int)value == 6)
            {
                return (EnabledPath + "/numbers/6.png");
            }
            else if ((int)value == 7)
            {
                return (BluePath + "/numbers/7.png");
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == (EnabledPath + "/numbers/2.png"))
            {
                return 2;
            }
            else if ((string)value == (EnabledPath + "/numbers/3.png"))
            {
                return 3;
            }
            else if ((string)value == (EnabledPath + "/numbers/4.png"))
            {
                return 4;
            }
            else if ((string)value == (EnabledPath + "/numbers/5.png"))
            {
                return 5;
            }
            else if ((string)value == (EnabledPath + "/numbers/6.png"))
            {
                return 6;
            }
            else if ((string)value == (BluePath + "/numbers/7.png"))
            {
                return 7;
            }
            else
            {
                return 1;
            }
        }
    }

    public class WeaponConverter : IValueConverter
    {
        private string RaisinPath = "Images/Other/Raisin";
        private string CustomPath = "pack://application:,,,/CustomImages/Other";
        private string EnabledPath1 = "Images/Other/Simple";
        private string EnabledPath2 = "Images/Other/Simple";
        private string EnabledPath3 = "Images/Other/Simple";
        private bool Raisinmode = Properties.Settings.Default.Alt;
        private bool CustomMode = Properties.Settings.Default.CustomFolder;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //there is probably a better way to do this
            {
                if (CustomMode)
                {
                    //sword
                    {
                        if (MainWindow.CustomSwordFound)
                            EnabledPath1 = CustomPath;
                        else if (Raisinmode)
                            EnabledPath1 = RaisinPath;
                    }
                    //staff
                    {
                        if (MainWindow.CustomStaffFound)
                            EnabledPath2 = CustomPath;
                        else if (Raisinmode)
                            EnabledPath2 = RaisinPath;
                    }
                    //shield
                    {
                        if (MainWindow.CustomShieldFound)
                            EnabledPath3 = CustomPath;
                        else if (Raisinmode)
                            EnabledPath3 = RaisinPath;
                    }
                }
                else if (Raisinmode)
                {
                    EnabledPath1 = RaisinPath;
                    EnabledPath2 = RaisinPath;
                    EnabledPath3 = RaisinPath;
                }
            }

            if ((string)value == "Sword")
            {
                return (EnabledPath1 + "/sword.png");
            }
            else if ((string)value == "Shield")
            {
                return (EnabledPath3 + "/shield.png");
            }
            else if ((string)value == "Staff")
            {
                return (EnabledPath2 + "/staff.png");
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == (EnabledPath1 + "/sword.png"))
            {
                return "Sword";
            }
            else if ((string)value == (EnabledPath3 + "/shield.png"))
            {
                return "Shield";
            }
            else if ((string)value == (EnabledPath2 + "/staff.png"))
            {
                return "Staff";
            }
            else
            {
                return "";
            }
        }
    }

    public class GrowthAbilityConverter : IValueConverter
    {
        //Redoing all this to have numbers 0-5 on growth.
        //I don't think there's much reason to have the icons be semi-transparent when at 0 or have no number when you have a 1 in the same way forms are handled
        //(at least on the main window)
        //redoing this AGAIN to handle custom image loading
        string NormalPath = "Images/Numbers/Kh2";
        string RaisinPath = "Images/Numbers/Raisin";
        string CustomPath = "pack://application:,,,/CustomImages";
        string EnabledPath;
        string BluePath;
        bool Raisinmode = Properties.Settings.Default.Alt;
        bool CustomMode = Properties.Settings.Default.CustomFolder;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            {
                if (MainWindow.CustomNumbersFound && CustomMode)
                {
                    EnabledPath = CustomPath;

                    if (MainWindow.CustomBlueNumbersFound)
                    {
                        BluePath = CustomPath;
                    }
                    else if (MainWindow.CustomBlueNumbersFound == false)
                    {
                        if (Raisinmode)
                            BluePath = RaisinPath;
                        else
                            BluePath = NormalPath;
                    }
                }
                else if (Raisinmode)
                {
                    EnabledPath = RaisinPath;
                    BluePath = RaisinPath;
                }
                else
                {
                    EnabledPath = NormalPath;
                    BluePath = NormalPath;
                }
            }

            //if ((int)value == 0)
            //{
            //    return (EnabledPath + "/numbers/0.png");
            //}
            if ((int)value == 1)
            {
                return (EnabledPath + "/numbers/1.png");
            }
            else if ((int)value == 2)
            {
                return (EnabledPath + "/numbers/2.png");
            }
            else if ((int)value == 3)
            {
                return (EnabledPath + "/numbers/3.png");
            }
            else if ((int)value == 4)
            {
                return (BluePath + "/numbers/4.png");
            }
            else if ((int)value >= 5)
            {
                return (EnabledPath + "/numbers/QuestionMark.png");
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if ((string)value == (EnabledPath + "/numbers/0.png"))
            //{
            //    return 0;
            //}
            if ((string)value == (EnabledPath + "/numbers/1.png"))
            {
                return 1;
            }
            else if ((string)value == (EnabledPath + "/numbers/2.png"))
            {
                return 2;
            }
            else if ((string)value == (EnabledPath + "/numbers/3.png"))
            {
                return 3;
            }
            else if ((string)value == (BluePath + "/numbers/4.png"))
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }
    }

    public class NumberConverter : IValueConverter
    {
        string NormalPath = "Images/Numbers/Kh2";
        string RaisinPath = "Images/Numbers/Raisin";
        string CustomPath = "pack://application:,,,/CustomImages";
        string EnabledPath;
        string BluePath;
        bool Raisinmode = Properties.Settings.Default.Alt;
        bool CustomMode = Properties.Settings.Default.CustomFolder;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //all this garbage to get the stat stuff to use the correct number images and to have the numbers change to blue when reaching 99
            {
                if (MainWindow.CustomNumbersFound && CustomMode)
                {
                    EnabledPath = CustomPath;

                    if (MainWindow.CustomBlueNumbersFound)
                    {
                        BluePath = CustomPath;
                    }
                    else if (MainWindow.CustomBlueNumbersFound == false)
                    {
                        if (Raisinmode)
                            BluePath = RaisinPath;
                        else
                            BluePath = NormalPath;
                    }
                }
                else if (Raisinmode)
                {
                    EnabledPath = RaisinPath;
                    BluePath = RaisinPath;
                }
                else
                {
                    EnabledPath = NormalPath;
                    BluePath = NormalPath;
                }
            }

            if ((int)value >= 0)
            {
                if ((int)value > 99)
                    value = 99;

                if ((int)value <= 98)
                    return EnabledPath + "/numbers/" + (value).ToString() + ".png";
                else
                    return BluePath + "/numbers/99.png";
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value != null)
            {
                string val = (string)value;
                val = val.Substring(val.LastIndexOf('/'));
                return int.Parse(val.Substring(0, val.IndexOf('.')));
            }
            else
            {
                return 1;
            }
        }
    }
}