using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace KhTracker
{
    /// <summary>
    /// Interaction logic for BroadcastWindow.xaml
    /// </summary>
    public partial class BroadcastWindow : Window
    {
        public bool canClose = false;
        Dictionary<string, int> worlds = new Dictionary<string, int>();
        Dictionary<string, int> totals = new Dictionary<string, int>();
        Dictionary<string, int> important = new Dictionary<string, int>();
        Dictionary<string, ContentControl> Progression = new Dictionary<string, ContentControl>();
        List<BitmapImage> Numbers = null;
        List<BitmapImage> RaisinNumbers = null;
        List<BitmapImage> CustomNumbers = null;
        Data data;

        public BroadcastWindow(Data dataIn)
        {
            InitializeComponent();
            //Item.UpdateTotal += new Item.TotalHandler(UpdateTotal);

            Numbers = dataIn.Numbers;
            RaisinNumbers = dataIn.RaisinNumbers;
            CustomNumbers = dataIn.CustomNumbers;

            worlds.Add("SorasHeart",0);
            worlds.Add("DriveForms", 0);
            worlds.Add("SimulatedTwilightTown",0);
            worlds.Add("TwilightTown",0);
            worlds.Add("HollowBastion",0);
            worlds.Add("BeastsCastle",0);
            worlds.Add("OlympusColiseum",0);
            worlds.Add("Agrabah",0);
            worlds.Add("LandofDragons",0);
            worlds.Add("HundredAcreWood",0);
            worlds.Add("PrideLands",0);
            worlds.Add("DisneyCastle",0);
            worlds.Add("HalloweenTown",0);
            worlds.Add("PortRoyal",0);
            worlds.Add("SpaceParanoids",0);
            worlds.Add("TWTNW",0);
            worlds.Add("GoA", 0);
            worlds.Add("Report", 0);
            worlds.Add("TornPage", 0);
            worlds.Add("Fire", 0);
            worlds.Add("Blizzard", 0);
            worlds.Add("Thunder", 0);
            worlds.Add("Cure", 0);
            worlds.Add("Reflect", 0);
            worlds.Add("Magnet", 0);
            worlds.Add("Atlantica", 0);

            totals.Add("SorasHeart", -1);
            totals.Add("DriveForms", -1);
            totals.Add("SimulatedTwilightTown", -1);
            totals.Add("TwilightTown", -1);
            totals.Add("HollowBastion", -1);
            totals.Add("BeastsCastle", -1);
            totals.Add("OlympusColiseum", -1);
            totals.Add("Agrabah", -1);
            totals.Add("LandofDragons", -1);
            totals.Add("HundredAcreWood", -1);
            totals.Add("PrideLands", -1);
            totals.Add("DisneyCastle", -1);
            totals.Add("HalloweenTown", -1);
            totals.Add("PortRoyal", -1);
            totals.Add("SpaceParanoids", -1);
            totals.Add("TWTNW", -1);
            totals.Add("Atlantica", -1);

            important.Add("Fire", 0);
            important.Add("Blizzard", 0);
            important.Add("Thunder", 0);
            important.Add("Cure", 0);
            important.Add("Reflect", 0);
            important.Add("Magnet", 0);
            important.Add("Valor", 0);
            important.Add("Wisdom", 0);
            important.Add("Limit", 0);
            important.Add("Master", 0);
            important.Add("Final", 0);
            important.Add("Nonexistence", 0);
            important.Add("Connection", 0);
            important.Add("Peace", 0);
            important.Add("PromiseCharm", 0);
            important.Add("Feather", 0);
            important.Add("Ukulele", 0);
            important.Add("Baseball", 0);
            important.Add("Lamp", 0);
            important.Add("Report", 0);
            important.Add("TornPage", 0);
            important.Add("SecondChance", 0);
            important.Add("OnceMore", 0);
            important.Add("HadesCup", 0);
            important.Add("MembershipCard", 0);
            important.Add("OlympusStone", 0);
            important.Add("ComboMaster", 0);

            Progression.Add("SimulatedTwilightTown", SimulatedTwilightTownProgression);
            Progression.Add("TwilightTown", TwilightTownProgression);
            Progression.Add("HollowBastion", HollowBastionProgression);
            Progression.Add("BeastsCastle", BeastsCastleProgression);
            Progression.Add("OlympusColiseum", OlympusColiseumProgression);
            Progression.Add("Agrabah", AgrabahProgression);
            Progression.Add("LandofDragons", LandofDragonsProgression);
            Progression.Add("HundredAcreWood", HundredAcreWoodProgression);
            Progression.Add("PrideLands", PrideLandsProgression);
            Progression.Add("DisneyCastle", DisneyCastleProgression);
            Progression.Add("HalloweenTown", HalloweenTownProgression);
            Progression.Add("PortRoyal", PortRoyalProgression);
            Progression.Add("SpaceParanoids", SpaceParanoidsProgression);
            Progression.Add("TWTNW", TWTNWProgression);

            data = dataIn;

            foreach (Item item in data.Items)
            {
                item.UpdateTotal += new Item.TotalHandler(UpdateTotal);
                item.UpdateFound += new Item.FoundHandler(UpdateFound);
            }

            Top = Properties.Settings.Default.BroadcastWindowY;
            Left = Properties.Settings.Default.BroadcastWindowX;

            Width = Properties.Settings.Default.BroadcastWindowWidth;
            Height = Properties.Settings.Default.BroadcastWindowHeight;
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.BroadcastWindowY = RestoreBounds.Top;
            Properties.Settings.Default.BroadcastWindowX = RestoreBounds.Left;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Properties.Settings.Default.BroadcastWindowWidth = RestoreBounds.Width;
            Properties.Settings.Default.BroadcastWindowHeight = RestoreBounds.Height;
        }

        public void UpdateFound(string item, string world, bool add)
        {
            string worldName = world;
            if (add) worlds[worldName]++; else worlds[worldName]--;
            //Console.WriteLine(worlds[worldName]);

            while (item.Any(char.IsDigit))
            {
                item = item.Remove(item.Length - 1, 1);
            }

            if (add) important[item]++; else important[item]--;
            worlds["Report"] = important["Report"];
            worlds["TornPage"] = important["TornPage"];
            worlds["Fire"] = important["Fire"];
            worlds["Blizzard"] = important["Blizzard"];
            worlds["Thunder"] = important["Thunder"];
            worlds["Cure"] = important["Cure"];
            worlds["Reflect"] = important["Reflect"];
            worlds["Magnet"] = important["Magnet"];

            //Console.WriteLine(item);

            UpdateNumbers();
            
        }

        public void UpdateNumbers()
        {
            //all this garbage to get the correct number images
            bool RaisinMode = Properties.Settings.Default.Alt;
            bool CustomMode = Properties.Settings.Default.CustomFolder;
            var NormalNum = data.Numbers;
            var BlueNum = data.BlueNumbers;
            var SingleNum = data.SingleNumbers;
            var BlueSingleNum = data.BlueSingleNumbers;
            BitmapImage NumberBarB = data.SlashBarB;
            BitmapImage NumberBarY = data.SlashBarY;
            {
                if (CustomMode)
                {
                    {
                        if (MainWindow.CustomNumbersFound)
                        {
                            NormalNum = data.CustomNumbers;
                            SingleNum = data.CustomSingleNumbers;
                        }
                        else if (RaisinMode && MainWindow.CustomNumbersFound == false)
                        {
                            NormalNum = data.RaisinNumbers;
                            SingleNum = data.RaisinSingleNumbers;
                        }
                    }

                    {
                        if (MainWindow.CustomBlueNumbersFound)
                        {
                            BlueNum = data.CustomBlueNumbers;
                            BlueSingleNum = data.CustomBlueSingleNumbers;
                        }
                        if (RaisinMode && MainWindow.CustomBlueNumbersFound == false)
                        {
                            BlueNum = data.RaisinBlueNumbers;
                            BlueSingleNum = data.RaisinBlueSingleNumbers;
                        }
                    }

                    if (File.Exists("CustomImages/BarBlue.png"))
                    {
                        NumberBarB = data.CustomnSlashBarB;
                    }

                    if (File.Exists("CustomImages/Bar.png"))
                    {
                        NumberBarY = data.CustomnSlashBarY;
                    }

                }
                else if (RaisinMode)
                {
                    NormalNum = data.RaisinNumbers;
                    BlueNum = data.RaisinBlueNumbers;
                    SingleNum = data.RaisinSingleNumbers;
                    BlueSingleNum = data.RaisinBlueSingleNumbers;
                    NumberBarB = data.RaisinSlashBarB;
                    NumberBarY = data.RaisinSlashBarY;
                }
            }

            foreach (KeyValuePair<string, int> world in worlds)
            {
                if (world.Value < 52)
                {
                    BitmapImage number = NormalNum[world.Value + 1];
                    if ((data.WorldsData.ContainsKey(world.Key) && world.Key != "GoA" && data.WorldsData[world.Key].hintedHint == false) || (data.WorldsData.ContainsKey(world.Key) && world.Key != "GoA" && data.WorldsData[world.Key].complete == false))
                    {
                        number = NormalNum[world.Value + 1];
                        Image bar = FindName(world.Key + "Bar") as Image;
                        bar.Source = NumberBarY;
                    }

                    //BitmapImage number = NormalNum[world.Value + 1];
                    if ((data.WorldsData.ContainsKey(world.Key) && world.Key != "GoA" && data.WorldsData[world.Key].hintedHint) || (data.WorldsData.ContainsKey(world.Key) && world.Key != "GoA" && data.WorldsData[world.Key].complete))
                    {
                        number = BlueNum[world.Value + 1];
                        Image bar = FindName(world.Key + "Bar") as Image;
                        bar.Source = NumberBarB;
                    }

                    if (world.Key == "TornPage" || world.Key == "Fire" || world.Key == "Blizzard"
                        || world.Key == "Thunder" || world.Key == "Cure" || world.Key == "Reflect" || world.Key == "Magnet")
                    {
                        number = SingleNum[world.Value + 1];
                    }

                    Image worldFound = this.FindName(world.Key + "Found") as Image;
                    worldFound.Source = number;

                    if (world.Key == "Fire" || world.Key == "Blizzard" || world.Key == "Thunder"
                        || world.Key == "Cure" || world.Key == "Reflect" || world.Key == "Magnet")
                    {
                        if (world.Value == 0)
                        {
                            worldFound.Source = null;
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, int> total in totals)
            {
                Image worldTotal = this.FindName(total.Key + "Total") as Image;
                if (total.Value == -1)
                {
                    worldTotal.Source = SingleNum[0];
                }
                else if ((data.WorldsData.ContainsKey(total.Key) && total.Key != "GoA" && data.WorldsData[total.Key].hintedHint)
                    || (data.WorldsData.ContainsKey(total.Key) && total.Key != "GoA" && data.WorldsData[total.Key].complete))
                {
                    if (total.Value <= 10)
                        worldTotal.Source = BlueSingleNum[total.Value];
                    else
                        worldTotal.Source = BlueNum[total.Value];
                }
                else
                {
                    if (total.Value <= 10)
                        worldTotal.Source = SingleNum[total.Value];
                    else
                        worldTotal.Source = NormalNum[total.Value];
                }

                // Format fixing for double digit numbers
                if (total.Key != "GoA" && total.Key != "Atlantica")
                //if (total.Key != "GoA")
                {
                    if (total.Value >= 11)
                    {
                        (worldTotal.Parent as Grid).ColumnDefinitions[3].Width = new GridLength(2, GridUnitType.Star);
                        (worldTotal.Parent as Grid).ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Star);
                    }
                    else
                    {
                        (worldTotal.Parent as Grid).ColumnDefinitions[3].Width = new GridLength(1, GridUnitType.Star);
                        (worldTotal.Parent as Grid).ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                    }
                }
            }

            foreach (KeyValuePair<string, int> impCheck in important)
            {
                ContentControl imp = this.FindName(impCheck.Key) as ContentControl;
                if (impCheck.Value > 0)
                {
                    imp.Opacity = 1;
                }
                else
                {
                    if (impCheck.Key != "Report" && impCheck.Key != "TornPage")
                        imp.Opacity = 0.25;
                }
            }

            //Collected.Source = NormalNum[collected + 1];
            //CheckTotal.Source = NormalNum[total + 1];
        }

        public void UpdateTotal(string world, int checks)
        {
            string worldName = world;
            totals[worldName] = checks + 1;

            UpdateNumbers();
        }

        void BroadcastWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            if (!canClose)
            {
                e.Cancel = true;
            }
        }

        public void OnResetHints()
        {
            //change this to load correct images
            //SorasHeartBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //DriveFormsBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //HollowBastionBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //TwilightTownBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //LandofDragonsBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //BeastsCastleBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //OlympusColiseumBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //SpaceParanoidsBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //HalloweenTownBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //PortRoyalBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //AgrabahBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //PrideLandsBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //DisneyCastleBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //HundredAcreWoodBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //SimulatedTwilightTownBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //TWTNWBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));
            //AtlanticaBar.Source = new BitmapImage(new Uri("Images/Bar.png", UriKind.Relative));

            bool RaisinMode = Properties.Settings.Default.Alt;
            bool CustomMode = Properties.Settings.Default.CustomFolder;
            BitmapImage NumberBar = data.SlashBarY;

            {
                if (CustomMode && File.Exists("CustomImages/Bar.png"))
                {
                    NumberBar = data.CustomnSlashBarY;
                }
                else if (RaisinMode)
                {
                    NumberBar = data.RaisinSlashBarY;
                }
            }

            SorasHeartBar.Source = NumberBar;
            DriveFormsBar.Source = NumberBar;
            HollowBastionBar.Source = NumberBar;
            TwilightTownBar.Source = NumberBar;
            LandofDragonsBar.Source = NumberBar;
            BeastsCastleBar.Source = NumberBar;
            OlympusColiseumBar.Source = NumberBar;
            SpaceParanoidsBar.Source = NumberBar;
            HalloweenTownBar.Source = NumberBar;
            PortRoyalBar.Source = NumberBar;
            AgrabahBar.Source = NumberBar;
            PrideLandsBar.Source = NumberBar;
            DisneyCastleBar.Source = NumberBar;
            HundredAcreWoodBar.Source = NumberBar;
            SimulatedTwilightTownBar.Source = NumberBar;
            TWTNWBar.Source = NumberBar;
            AtlanticaBar.Source = NumberBar;
        }

        public void OnReset()
        {
            worlds.Clear();
            worlds.Add("SorasHeart", 0);
            worlds.Add("DriveForms", 0);
            worlds.Add("SimulatedTwilightTown", 0);
            worlds.Add("TwilightTown", 0);
            worlds.Add("HollowBastion", 0);
            worlds.Add("BeastsCastle", 0);
            worlds.Add("OlympusColiseum", 0);
            worlds.Add("Agrabah", 0);
            worlds.Add("LandofDragons", 0);
            worlds.Add("HundredAcreWood", 0);
            worlds.Add("PrideLands", 0);
            worlds.Add("DisneyCastle", 0);
            worlds.Add("HalloweenTown", 0);
            worlds.Add("PortRoyal", 0);
            worlds.Add("SpaceParanoids", 0);
            worlds.Add("TWTNW", 0);
            worlds.Add("GoA", 0);
            worlds.Add("Report", 0);
            worlds.Add("TornPage", 0);
            worlds.Add("Fire", 0);
            worlds.Add("Blizzard", 0);
            worlds.Add("Thunder", 0);
            worlds.Add("Cure", 0);
            worlds.Add("Reflect", 0);
            worlds.Add("Magnet", 0);
            worlds.Add("Atlantica", 0);

            totals.Clear();
            totals.Add("SorasHeart", -1);
            totals.Add("DriveForms", -1);
            totals.Add("SimulatedTwilightTown", -1);
            totals.Add("TwilightTown", -1);
            totals.Add("HollowBastion", -1);
            totals.Add("BeastsCastle", -1);
            totals.Add("OlympusColiseum", -1);
            totals.Add("Agrabah", -1);
            totals.Add("LandofDragons", -1);
            totals.Add("HundredAcreWood", -1);
            totals.Add("PrideLands", -1);
            totals.Add("DisneyCastle", -1);
            totals.Add("HalloweenTown", -1);
            totals.Add("PortRoyal", -1);
            totals.Add("SpaceParanoids", -1);
            totals.Add("TWTNW", -1);
            totals.Add("Atlantica", -1);

            important.Clear();
            important.Add("Fire", 0);
            important.Add("Blizzard", 0);
            important.Add("Thunder", 0);
            important.Add("Cure", 0);
            important.Add("Reflect", 0);
            important.Add("Magnet", 0);
            important.Add("Valor", 0);
            important.Add("Wisdom", 0);
            important.Add("Limit", 0);
            important.Add("Master", 0);
            important.Add("Final", 0);
            important.Add("Nonexistence", 0);
            important.Add("Connection", 0);
            important.Add("Peace", 0);
            important.Add("PromiseCharm", 0);
            important.Add("Feather", 0);
            important.Add("Ukulele", 0);
            important.Add("Baseball", 0);
            important.Add("Lamp", 0);
            important.Add("Report", 0);
            important.Add("TornPage", 0);
            important.Add("SecondChance", 0);
            important.Add("OnceMore", 0);
            important.Add("HadesCup", 0);
            important.Add("MembershipCard", 0);
            important.Add("OlympusStone", 0);
            important.Add("ComboMaster", 0);

            //lazy way of doing things. not fully dynamic and such, but i ain't adding any new style options anymore anyway
            bool RaisinMode = Properties.Settings.Default.Alt;
            bool CustomMode = Properties.Settings.Default.CustomFolder;
            BitmapImage NumberBar = data.SlashBarY;

            {
                if (CustomMode && File.Exists("CustomImages/Bar.png"))
                {
                    NumberBar = data.CustomnSlashBarY;
                }
                else if (RaisinMode)
                {
                    NumberBar = data.RaisinSlashBarY;
                }
            }

            SorasHeartBar.Source = NumberBar;
            DriveFormsBar.Source = NumberBar;
            HollowBastionBar.Source = NumberBar;
            TwilightTownBar.Source = NumberBar;
            LandofDragonsBar.Source = NumberBar;
            BeastsCastleBar.Source = NumberBar;
            OlympusColiseumBar.Source = NumberBar;
            SpaceParanoidsBar.Source = NumberBar;
            HalloweenTownBar.Source = NumberBar;
            PortRoyalBar.Source = NumberBar;
            AgrabahBar.Source = NumberBar;
            PrideLandsBar.Source = NumberBar;
            DisneyCastleBar.Source = NumberBar;
            HundredAcreWoodBar.Source = NumberBar;
            SimulatedTwilightTownBar.Source = NumberBar;
            TWTNWBar.Source = NumberBar;
            AtlanticaBar.Source = NumberBar;


            //all this garbage to get the correct number images
            var NormalNum = data.Numbers;
            {
                if (CustomMode)
                {
                    if (MainWindow.CustomNumbersFound)
                        NormalNum = data.CustomNumbers;
                    else if (RaisinMode && MainWindow.CustomNumbersFound == false)
                        NormalNum = data.RaisinNumbers;
                }
                else if (RaisinMode)
                {
                    NormalNum = data.RaisinNumbers;
                }
            }

            Collected.Source = NormalNum[1];

            //Lazy but whatever
            //ValorLevel.Source = null;
            //WisdomLevel.Source = null;
            //LimitLevel.Source = null;
            //MasterLevel.Source = null;
            //FinalLevel.Source = null;
        }

        public void ToggleProgression(bool toggle)
        {
            if (toggle == true)
            {
                foreach (string key in Progression.Keys.ToList())
                {
                    Progression[key].Visibility = Visibility.Visible;
                }
            }
            else
            {
                foreach (string key in Progression.Keys.ToList())
                {
                    Progression[key].Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
