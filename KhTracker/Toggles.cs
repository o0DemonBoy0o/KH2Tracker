using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Windows.Data;
using System.IO;

namespace KhTracker
{
    public partial class MainWindow : Window
    {
        private void HandleItemToggle(bool toggle, Item button, bool init)
        {
            if (toggle && button.IsEnabled == false)
            {
                button.IsEnabled = true;
                button.Visibility = Visibility.Visible;
                if (!init)
                {
                    IncrementTotal();
                }
            }
            else if (toggle == false && button.IsEnabled == true)
            {
                button.IsEnabled = false;
                button.Visibility = Visibility.Hidden;
                DecrementTotal();

                button.HandleItemReturn();
            }
        }

        private void HandleWorldToggle(bool toggle, Button button, UniformGrid grid)
        {
            //this chunk of garbage for using the correct vertical image
            bool RaisinMode = Properties.Settings.Default.Alt;
            bool CustomMode = Properties.Settings.Default.CustomFolder;
            BitmapImage BarW = data.VerticalBarW;
            {
                if (CustomMode)
                {
                    if (File.Exists("CustomImages/VerticalBarWhite.png"))
                        BarW = data.CustomnVerticalBarW;
                }
                else if (RaisinMode)
                {
                    BarW = data.RaisinVerticalBarW;
                }
            }



            if (toggle && button.IsEnabled == false)
            {
                var outerGrid = (((button.Parent as Grid).Parent as Grid).Parent as Grid);
                int row = (int)((button.Parent as Grid).Parent as Grid).GetValue(Grid.RowProperty);
                outerGrid.RowDefinitions[row].Height = new GridLength(1, GridUnitType.Star);
                button.IsEnabled = true;
                button.Visibility = Visibility.Visible;
            }
            else if (toggle == false && button.IsEnabled == true)
            {
                if (data.selected == button)
                {
                    data.WorldsData[button.Name].selectedBar.Source = BarW;
                    data.selected = null;
                }

                for (int i = grid.Children.Count - 1; i >= 0; --i)
                {
                    Item item = grid.Children[i] as Item;
                    item.HandleItemReturn();
                }

                var outerGrid = (((button.Parent as Grid).Parent as Grid).Parent as Grid);
                int row = (int)((button.Parent as Grid).Parent as Grid).GetValue(Grid.RowProperty);
                outerGrid.RowDefinitions[row].Height = new GridLength(0, GridUnitType.Star);
                button.IsEnabled = false;
                button.Visibility = Visibility.Collapsed;
            }
        }

        private void PromiseCharmToggle(object sender, RoutedEventArgs e)
        {
            PromiseCharmToggle(PromiseCharmOption.IsChecked);
        }

        private void PromiseCharmToggle(bool toggle)
        {
            Properties.Settings.Default.PromiseCharm = toggle;
            PromiseCharmOption.IsChecked = toggle;
            if (toggle)
                broadcast.PromiseCharm.Visibility = Visibility.Visible;
            else
                broadcast.PromiseCharm.Visibility = Visibility.Hidden;
            HandleItemToggle(toggle, PromiseCharm, false);
        }

        //TEST
        private void HadesTrophyToggle(object sender, RoutedEventArgs e)
        {
            HadesTrophyToggle(HadesTrophyOption.IsChecked);
        }

        private void HadesTrophyToggle(bool toggle)
        {
            Properties.Settings.Default.CupTrophy = toggle;
            HadesTrophyOption.IsChecked = toggle;
            if (toggle)
            {
                broadcast.HadesCup.Visibility = Visibility.Visible;
            }

            else
            {
                broadcast.HadesCup.Visibility = Visibility.Hidden;
            }

            HandleItemToggle(toggle, HadesCup, false);

            ExtraItemToggleCheck();

        }

        private void HBCardToggle(object sender, RoutedEventArgs e)
        {
            HBCardToggle(HBCardOption.IsChecked);
        }

        private void HBCardToggle(bool toggle)
        {
            Properties.Settings.Default.MemberCard = toggle;
            HBCardOption.IsChecked = toggle;
            if (toggle)
            {
                broadcast.MembershipCard.Visibility = Visibility.Visible;
            }

            else
            {
                broadcast.MembershipCard.Visibility = Visibility.Hidden;
            }

            HandleItemToggle(toggle, MembershipCard, false);

            ExtraItemToggleCheck();
        }

        private void OStoneToggle(object sender, RoutedEventArgs e)
        {
            OStoneToggle(OStoneOption.IsChecked);
        }

        private void OStoneToggle(bool toggle)
        {
            Properties.Settings.Default.Stone = toggle;
            OStoneOption.IsChecked = toggle;
            if (toggle)
            {
                broadcast.OlympusStone.Visibility = Visibility.Visible;
            }

            else
            {
                broadcast.OlympusStone.Visibility = Visibility.Hidden;
            }

            HandleItemToggle(toggle, OlympusStone, false);

            ExtraItemToggleCheck();
        }


        private void ReportsToggle(object sender, RoutedEventArgs e)
        {
            ReportsToggle(ReportsOption.IsChecked);
        }

        private void ReportsToggle(bool toggle)
        {
            Properties.Settings.Default.AnsemReports = toggle;
            ReportsOption.IsChecked = toggle;
            for (int i = 0; i < data.Reports.Count; ++i)
            {
                HandleItemToggle(toggle, data.Reports[i], false);
            }
        }

        private void AbilitiesToggle(object sender, RoutedEventArgs e)
        {
            AbilitiesToggle(AbilitiesOption.IsChecked);
        }

        private void AbilitiesToggle(bool toggle)
        {
            Properties.Settings.Default.Abilities = toggle;
            AbilitiesOption.IsChecked = toggle;
            HandleItemToggle(toggle, OnceMore, false);
            HandleItemToggle(toggle, SecondChance, false);
        }

        private void ComboMasterToggle(object sender, RoutedEventArgs e)
        {
            ComboMasterToggle(ComboMasterOption.IsChecked);
        }

        private void ComboMasterToggle(bool toggle)
        {
            Properties.Settings.Default.ComboMaster = toggle;
            ComboMasterOption.IsChecked = toggle;
            HandleItemToggle(toggle, ComboMaster, false);
        }

        private void TornPagesToggle(object sender, RoutedEventArgs e)
        {
            TornPagesToggle(TornPagesOption.IsChecked);
        }

        private void TornPagesToggle(bool toggle)
        {
            Properties.Settings.Default.TornPages = toggle;
            TornPagesOption.IsChecked = toggle;
            for (int i = 0; i < data.TornPages.Count; ++i)
            {
                HandleItemToggle(toggle, data.TornPages[i], false);
            }
        }

        private void CureToggle(object sender, RoutedEventArgs e)
        {
            CureToggle(CureOption.IsChecked);
        }

        private void CureToggle(bool toggle)
        {
            Properties.Settings.Default.Cure = toggle;
            CureOption.IsChecked = toggle;
            HandleItemToggle(toggle, Cure1, false);
            HandleItemToggle(toggle, Cure2, false);
            HandleItemToggle(toggle, Cure3, false);
        }

        private void FinalFormToggle(object sender, RoutedEventArgs e)
        {
            FinalFormToggle(FinalFormOption.IsChecked);
        }

        private void FinalFormToggle(bool toggle)
        {
            Properties.Settings.Default.FinalForm = toggle;
            FinalFormOption.IsChecked = toggle;
            HandleItemToggle(toggle, Final, false);
        }

        private void SoraHeartToggle(object sender, RoutedEventArgs e)
        {
            SoraHeartToggle(SoraHeartOption.IsChecked);
        }

        private void SoraHeartToggle(bool toggle)
        {
            Properties.Settings.Default.SoraHeart = toggle;
            SoraHeartOption.IsChecked = toggle;
            HandleWorldToggle(toggle, SorasHeart, SorasHeartGrid);
        }

        private void SimulatedToggle(object sender, RoutedEventArgs e)
        {
            SimulatedToggle(SimulatedOption.IsChecked);
        }

        private void SimulatedToggle(bool toggle)
        {
            Properties.Settings.Default.Simulated = toggle;
            SimulatedOption.IsChecked = toggle;
            HandleWorldToggle(toggle, SimulatedTwilightTown, SimulatedTwilightTownGrid);
        }

        private void HundredAcreWoodToggle(object sender, RoutedEventArgs e)
        {
            HundredAcreWoodToggle(HundredAcreWoodOption.IsChecked);
        }

        private void HundredAcreWoodToggle(bool toggle)
        {
            Properties.Settings.Default.HundredAcre = toggle;
            HundredAcreWoodOption.IsChecked = toggle;
            HandleWorldToggle(toggle, HundredAcreWood, HundredAcreWoodGrid);
        }

        private void AtlanticaToggle(object sender, RoutedEventArgs e)
        {
            AtlanticaToggle(AtlanticaOption.IsChecked);
        }

        private void AtlanticaToggle(bool toggle)
        {
            Properties.Settings.Default.Atlantica = toggle;
            AtlanticaOption.IsChecked = toggle;
            HandleWorldToggle(toggle, Atlantica, AtlanticaGrid);
        }

        private void SimpleToggle(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (SimpleOption.IsChecked == false)
            {
                SimpleOption.IsChecked = true;
                return;
            }

            OrbOption.IsChecked = false;
            AltOption.IsChecked = false;
            Properties.Settings.Default.Simple = SimpleOption.IsChecked;
            Properties.Settings.Default.Orb = OrbOption.IsChecked;
            Properties.Settings.Default.Alt = AltOption.IsChecked;
            //Properties.Settings.Default.CustomFolder = CustomFolderOption.IsChecked;

            if (SimpleOption.IsChecked)
            {
                Report1.SetResourceReference(ContentProperty, "AnsemReport1");
                Report2.SetResourceReference(ContentProperty, "AnsemReport2");
                Report3.SetResourceReference(ContentProperty, "AnsemReport3");
                Report4.SetResourceReference(ContentProperty, "AnsemReport4");
                Report5.SetResourceReference(ContentProperty, "AnsemReport5");
                Report6.SetResourceReference(ContentProperty, "AnsemReport6");
                Report7.SetResourceReference(ContentProperty, "AnsemReport7");
                Report8.SetResourceReference(ContentProperty, "AnsemReport8");
                Report9.SetResourceReference(ContentProperty, "AnsemReport9");
                Report10.SetResourceReference(ContentProperty, "AnsemReport10");
                Report11.SetResourceReference(ContentProperty, "AnsemReport11");
                Report12.SetResourceReference(ContentProperty, "AnsemReport12");
                Report13.SetResourceReference(ContentProperty, "AnsemReport13");
                Fire1.SetResourceReference(ContentProperty, "Fire");
                Fire2.SetResourceReference(ContentProperty, "Fire");
                Fire3.SetResourceReference(ContentProperty, "Fire");
                Blizzard1.SetResourceReference(ContentProperty, "Blizzard");
                Blizzard2.SetResourceReference(ContentProperty, "Blizzard");
                Blizzard3.SetResourceReference(ContentProperty, "Blizzard");
                Thunder1.SetResourceReference(ContentProperty, "Thunder");
                Thunder2.SetResourceReference(ContentProperty, "Thunder");
                Thunder3.SetResourceReference(ContentProperty, "Thunder");
                Cure1.SetResourceReference(ContentProperty, "Cure");
                Cure2.SetResourceReference(ContentProperty, "Cure");
                Cure3.SetResourceReference(ContentProperty, "Cure");
                Reflect1.SetResourceReference(ContentProperty, "Reflect");
                Reflect2.SetResourceReference(ContentProperty, "Reflect");
                Reflect3.SetResourceReference(ContentProperty, "Reflect");
                Magnet1.SetResourceReference(ContentProperty, "Magnet");
                Magnet2.SetResourceReference(ContentProperty, "Magnet");
                Magnet3.SetResourceReference(ContentProperty, "Magnet");
                Valor.SetResourceReference(ContentProperty, "Valor");
                Wisdom.SetResourceReference(ContentProperty, "Wisdom");
                Limit.SetResourceReference(ContentProperty, "Limit");
                Master.SetResourceReference(ContentProperty, "Master");
                Final.SetResourceReference(ContentProperty, "Final");
                ValorM.SetResourceReference(ContentProperty, "Valor");
                WisdomM.SetResourceReference(ContentProperty, "Wisdom");
                LimitM.SetResourceReference(ContentProperty, "Limit");
                MasterM.SetResourceReference(ContentProperty, "Master");
                FinalM.SetResourceReference(ContentProperty, "Final");
                TornPage1.SetResourceReference(ContentProperty, "TornPage");
                TornPage2.SetResourceReference(ContentProperty, "TornPage");
                TornPage3.SetResourceReference(ContentProperty, "TornPage");
                TornPage4.SetResourceReference(ContentProperty, "TornPage");
                TornPage5.SetResourceReference(ContentProperty, "TornPage");
                Lamp.SetResourceReference(ContentProperty, "Genie");
                Ukulele.SetResourceReference(ContentProperty, "Stitch");
                Baseball.SetResourceReference(ContentProperty, "ChickenLittle");
                Feather.SetResourceReference(ContentProperty, "PeterPan");
                Nonexistence.SetResourceReference(ContentProperty, "ProofOfNonexistence");
                Connection.SetResourceReference(ContentProperty, "ProofOfConnection");
                Peace.SetResourceReference(ContentProperty, "ProofOfPeace");
                PromiseCharm.SetResourceReference(ContentProperty, "PromiseCharm");

                OnceMore.SetResourceReference(ContentProperty, "OnceMore");
                SecondChance.SetResourceReference(ContentProperty, "SecondChance");
                ComboMaster.SetResourceReference(ContentProperty, "ComboMaster");

                HighJump.SetResourceReference(ContentProperty, "HighJump");
                QuickRun.SetResourceReference(ContentProperty, "QuickRun");
                DodgeRoll.SetResourceReference(ContentProperty, "DodgeRoll");
                AerialDodge.SetResourceReference(ContentProperty, "AerialDodge");
                Glide.SetResourceReference(ContentProperty, "Glide");

                HadesCup.SetResourceReference(ContentProperty, "HadesCup");
                OlympusStone.SetResourceReference(ContentProperty, "OlympusStone");
                MembershipCard.SetResourceReference(ContentProperty, "MembershipCard");

                //NoValorM.SetResourceReference(ContentProperty, "NoValor");
                //NoWisdomM.SetResourceReference(ContentProperty, "NoWisdom");
                //NoLimitM.SetResourceReference(ContentProperty, "NoLimit");
                //NoMasterM.SetResourceReference(ContentProperty, "NoMaster");
                //NoFinalM.SetResourceReference(ContentProperty, "NoFinal");

                LevelIcon.SetResourceReference(ContentProperty, "LevelIcon");
                StrengthIcon.SetResourceReference(ContentProperty, "StrengthIcon");
                MagicIcon.SetResourceReference(ContentProperty, "MagicIcon");
                DefenseIcon.SetResourceReference(ContentProperty, "DefenseIcon");
                //CollectedBar.SetResourceReference(ContentProperty, "CollectedBarYellow");

                broadcast.Report.SetResourceReference(ContentProperty, "AnsemReport");
                broadcast.TornPage.SetResourceReference(ContentProperty, "TornPageB");
                broadcast.Peace.SetResourceReference(ContentProperty, "ProofOfPeace");
                broadcast.Nonexistence.SetResourceReference(ContentProperty, "ProofOfNonexistence");
                broadcast.Connection.SetResourceReference(ContentProperty, "ProofOfConnection");
                broadcast.PromiseCharm.SetResourceReference(ContentProperty, "PromiseCharm");
                broadcast.Fire.SetResourceReference(ContentProperty, "Fire");
                broadcast.Blizzard.SetResourceReference(ContentProperty, "Blizzard");
                broadcast.Thunder.SetResourceReference(ContentProperty, "Thunder");
                broadcast.Cure.SetResourceReference(ContentProperty, "Cure");
                broadcast.Reflect.SetResourceReference(ContentProperty, "Reflect");
                broadcast.Magnet.SetResourceReference(ContentProperty, "Magnet");
                broadcast.Valor.SetResourceReference(ContentProperty, "Valor");
                broadcast.Wisdom.SetResourceReference(ContentProperty, "Wisdom");
                broadcast.Limit.SetResourceReference(ContentProperty, "Limit");
                broadcast.Master.SetResourceReference(ContentProperty, "Master");
                broadcast.Final.SetResourceReference(ContentProperty, "Final");
                broadcast.Baseball.SetResourceReference(ContentProperty, "ChickenLittle");
                broadcast.Lamp.SetResourceReference(ContentProperty, "Genie");
                broadcast.Ukulele.SetResourceReference(ContentProperty, "Stitch");
                broadcast.Feather.SetResourceReference(ContentProperty, "PeterPan");
                broadcast.OnceMore.SetResourceReference(ContentProperty, "OnceMore");
                broadcast.SecondChance.SetResourceReference(ContentProperty, "SecondChance");
                broadcast.ComboMaster.SetResourceReference(ContentProperty, "ComboMaster");

                broadcast.HighJump.SetResourceReference(ContentProperty, "HighJump");
                broadcast.QuickRun.SetResourceReference(ContentProperty, "QuickRun");
                broadcast.DodgeRoll.SetResourceReference(ContentProperty, "DodgeRoll");
                broadcast.AerialDodge.SetResourceReference(ContentProperty, "AerialDodge");
                broadcast.Glide.SetResourceReference(ContentProperty, "Glide");

                broadcast.HadesCup.SetResourceReference(ContentProperty, "HadesCup");
                broadcast.OlympusStone.SetResourceReference(ContentProperty, "OlympusStone");
                broadcast.MembershipCard.SetResourceReference(ContentProperty, "MembershipCard");

                broadcast.ReportFoundBar.Source = data.SlashBarY;
                broadcast.TornPageBar.Source = data.SlashBarY;
                broadcast.CollectedBar.Source = data.SlashBarY;

                broadcast.ReportFoundTotal.Source = data.Numbers[14];
                broadcast.TornPageTotal.Source = data.SingleNumbers[6];


                ((Grid)((Grid)broadcast.Fire.Parent).Parent).RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                ((Grid)((Grid)broadcast.Fire.Parent).Parent).RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
                ((Grid)broadcast.Valor.Parent).RowDefinitions[1].Height = new GridLength(2.2, GridUnitType.Star);
                ((Grid)broadcast.Valor.Parent).RowDefinitions[2].Height = new GridLength(2.2, GridUnitType.Star);
                ((Grid)broadcast.Lamp.Parent).RowDefinitions[1].Height = new GridLength(4.4, GridUnitType.Star);
            }

            CustomChecksCheck();
            ReloadBindings();
        }

        private void OrbToggle(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (OrbOption.IsChecked == false)
            {
                OrbOption.IsChecked = true;
                return;
            }

            SimpleOption.IsChecked = false;
            AltOption.IsChecked = false;
            Properties.Settings.Default.Simple = SimpleOption.IsChecked;
            Properties.Settings.Default.Orb = OrbOption.IsChecked;
            Properties.Settings.Default.Alt = AltOption.IsChecked;

            if (OrbOption.IsChecked)
            {
                Report1.SetResourceReference(ContentProperty, "Orb-AnsemReport1");
                Report2.SetResourceReference(ContentProperty, "Orb-AnsemReport2");
                Report3.SetResourceReference(ContentProperty, "Orb-AnsemReport3");
                Report4.SetResourceReference(ContentProperty, "Orb-AnsemReport4");
                Report5.SetResourceReference(ContentProperty, "Orb-AnsemReport5");
                Report6.SetResourceReference(ContentProperty, "Orb-AnsemReport6");
                Report7.SetResourceReference(ContentProperty, "Orb-AnsemReport7");
                Report8.SetResourceReference(ContentProperty, "Orb-AnsemReport8");
                Report9.SetResourceReference(ContentProperty, "Orb-AnsemReport9");
                Report10.SetResourceReference(ContentProperty, "Orb-AnsemReport10");
                Report11.SetResourceReference(ContentProperty, "Orb-AnsemReport11");
                Report12.SetResourceReference(ContentProperty, "Orb-AnsemReport12");
                Report13.SetResourceReference(ContentProperty, "Orb-AnsemReport13");
                Fire1.SetResourceReference(ContentProperty, "Orb-Fire");
                Fire2.SetResourceReference(ContentProperty, "Orb-Fire");
                Fire3.SetResourceReference(ContentProperty, "Orb-Fire");
                Blizzard1.SetResourceReference(ContentProperty, "Orb-Blizzard");
                Blizzard2.SetResourceReference(ContentProperty, "Orb-Blizzard");
                Blizzard3.SetResourceReference(ContentProperty, "Orb-Blizzard");
                Thunder1.SetResourceReference(ContentProperty, "Orb-Thunder");
                Thunder2.SetResourceReference(ContentProperty, "Orb-Thunder");
                Thunder3.SetResourceReference(ContentProperty, "Orb-Thunder");
                Cure1.SetResourceReference(ContentProperty, "Orb-Cure");
                Cure2.SetResourceReference(ContentProperty, "Orb-Cure");
                Cure3.SetResourceReference(ContentProperty, "Orb-Cure");
                Reflect1.SetResourceReference(ContentProperty, "Orb-Reflect");
                Reflect2.SetResourceReference(ContentProperty, "Orb-Reflect");
                Reflect3.SetResourceReference(ContentProperty, "Orb-Reflect");
                Magnet1.SetResourceReference(ContentProperty, "Orb-Magnet");
                Magnet2.SetResourceReference(ContentProperty, "Orb-Magnet");
                Magnet3.SetResourceReference(ContentProperty, "Orb-Magnet");
                Valor.SetResourceReference(ContentProperty, "Orb-Valor");
                Wisdom.SetResourceReference(ContentProperty, "Orb-Wisdom");
                Limit.SetResourceReference(ContentProperty, "Orb-Limit");
                Master.SetResourceReference(ContentProperty, "Orb-Master");
                Final.SetResourceReference(ContentProperty, "Orb-Final");
                ValorM.SetResourceReference(ContentProperty, "Orb-Valor");
                WisdomM.SetResourceReference(ContentProperty, "Orb-Wisdom");
                LimitM.SetResourceReference(ContentProperty, "Orb-Limit");
                MasterM.SetResourceReference(ContentProperty, "Orb-Master");
                FinalM.SetResourceReference(ContentProperty, "Orb-Final");
                TornPage1.SetResourceReference(ContentProperty, "Orb-TornPage");
                TornPage2.SetResourceReference(ContentProperty, "Orb-TornPage");
                TornPage3.SetResourceReference(ContentProperty, "Orb-TornPage");
                TornPage4.SetResourceReference(ContentProperty, "Orb-TornPage");
                TornPage5.SetResourceReference(ContentProperty, "Orb-TornPage");
                Lamp.SetResourceReference(ContentProperty, "Orb-Genie");
                Ukulele.SetResourceReference(ContentProperty, "Orb-Stitch");
                Baseball.SetResourceReference(ContentProperty, "Orb-ChickenLittle");
                Feather.SetResourceReference(ContentProperty, "Orb-PeterPan");
                Nonexistence.SetResourceReference(ContentProperty, "Orb-ProofOfNonexistence");
                Connection.SetResourceReference(ContentProperty, "Orb-ProofOfConnection");
                Peace.SetResourceReference(ContentProperty, "Orb-ProofOfPeace");
                PromiseCharm.SetResourceReference(ContentProperty, "Orb-PromiseCharm");

                OnceMore.SetResourceReference(ContentProperty, "OnceMore");
                SecondChance.SetResourceReference(ContentProperty, "SecondChance");
                ComboMaster.SetResourceReference(ContentProperty, "ComboMaster");
                HighJump.SetResourceReference(ContentProperty, "HighJump");
                QuickRun.SetResourceReference(ContentProperty, "QuickRun");
                DodgeRoll.SetResourceReference(ContentProperty, "DodgeRoll");
                AerialDodge.SetResourceReference(ContentProperty, "AerialDodge");
                Glide.SetResourceReference(ContentProperty, "Glide");

                HadesCup.SetResourceReference(ContentProperty, "Orb-HadesCup");
                OlympusStone.SetResourceReference(ContentProperty, "Orb-OlympusStone");
                MembershipCard.SetResourceReference(ContentProperty, "Orb-MembershipCard");

                //NoValorM.SetResourceReference(ContentProperty, "Orb-NoValor");
                //NoWisdomM.SetResourceReference(ContentProperty, "Orb-NoWisdom");
                //NoLimitM.SetResourceReference(ContentProperty, "Orb-NoLimit");
                //NoMasterM.SetResourceReference(ContentProperty, "Orb-NoMaster");
                //NoFinalM.SetResourceReference(ContentProperty, "Orb-NoFinal");

                LevelIcon.SetResourceReference(ContentProperty, "LevelIcon");
                StrengthIcon.SetResourceReference(ContentProperty, "StrengthIcon");
                MagicIcon.SetResourceReference(ContentProperty, "MagicIcon");
                DefenseIcon.SetResourceReference(ContentProperty, "DefenseIcon");
                //CollectedBar.SetResourceReference(ContentProperty, "CollectedBarYellow");

                broadcast.Report.SetResourceReference(ContentProperty, "Orb-AnsemReport");
                broadcast.TornPage.SetResourceReference(ContentProperty, "Orb-TornPageB");
                broadcast.Peace.SetResourceReference(ContentProperty, "Orb-ProofOfPeace");
                broadcast.Nonexistence.SetResourceReference(ContentProperty, "Orb-ProofOfNonexistence");
                broadcast.Connection.SetResourceReference(ContentProperty, "Orb-ProofOfConnection");
                broadcast.PromiseCharm.SetResourceReference(ContentProperty, "Orb-PromiseCharm");
                broadcast.Fire.SetResourceReference(ContentProperty, "Orb-Fire");
                broadcast.Blizzard.SetResourceReference(ContentProperty, "Orb-Blizzard");
                broadcast.Thunder.SetResourceReference(ContentProperty, "Orb-Thunder");
                broadcast.Cure.SetResourceReference(ContentProperty, "Orb-Cure");
                broadcast.Reflect.SetResourceReference(ContentProperty, "Orb-Reflect");
                broadcast.Magnet.SetResourceReference(ContentProperty, "Orb-Magnet");
                broadcast.Valor.SetResourceReference(ContentProperty, "Orb-Valor");
                broadcast.Wisdom.SetResourceReference(ContentProperty, "Orb-Wisdom");
                broadcast.Limit.SetResourceReference(ContentProperty, "Orb-Limit");
                broadcast.Master.SetResourceReference(ContentProperty, "Orb-Master");
                broadcast.Final.SetResourceReference(ContentProperty, "Orb-Final");
                broadcast.Baseball.SetResourceReference(ContentProperty, "Orb-ChickenLittle");
                broadcast.Lamp.SetResourceReference(ContentProperty, "Orb-Genie");
                broadcast.Ukulele.SetResourceReference(ContentProperty, "Orb-Stitch");
                broadcast.Feather.SetResourceReference(ContentProperty, "Orb-PeterPan");
                broadcast.OnceMore.SetResourceReference(ContentProperty, "OnceMore");
                broadcast.SecondChance.SetResourceReference(ContentProperty, "SecondChance");
                broadcast.ComboMaster.SetResourceReference(ContentProperty, "ComboMaster");

                broadcast.HighJump.SetResourceReference(ContentProperty, "HighJump");
                broadcast.QuickRun.SetResourceReference(ContentProperty, "QuickRun");
                broadcast.DodgeRoll.SetResourceReference(ContentProperty, "DodgeRoll");
                broadcast.AerialDodge.SetResourceReference(ContentProperty, "AerialDodge");
                broadcast.Glide.SetResourceReference(ContentProperty, "Glide");

                broadcast.HadesCup.SetResourceReference(ContentProperty, "Orb-HadesCup");
                broadcast.OlympusStone.SetResourceReference(ContentProperty, "Orb-OlympusStone");
                broadcast.MembershipCard.SetResourceReference(ContentProperty, "Orb-MembershipCard");

                broadcast.ReportFoundBar.Source = data.SlashBarY;
                broadcast.TornPageBar.Source = data.SlashBarY;
                broadcast.CollectedBar.Source = data.SlashBarY;

                broadcast.ReportFoundTotal.Source = data.Numbers[14];
                broadcast.TornPageTotal.Source = data.SingleNumbers[6];

                ((Grid)((Grid)broadcast.Fire.Parent).Parent).RowDefinitions[0].Height = new GridLength(1, GridUnitType.Star);
                ((Grid)((Grid)broadcast.Fire.Parent).Parent).RowDefinitions[2].Height = new GridLength(1, GridUnitType.Star);
                ((Grid)broadcast.Valor.Parent).RowDefinitions[1].Height = new GridLength(2.2, GridUnitType.Star);
                ((Grid)broadcast.Valor.Parent).RowDefinitions[2].Height = new GridLength(2.2, GridUnitType.Star);
                ((Grid)broadcast.Lamp.Parent).RowDefinitions[1].Height = new GridLength(4.4, GridUnitType.Star);
            }

            CustomChecksCheck();
            ReloadBindings();
        }

        private void AltToggle(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (AltOption.IsChecked == false)
            {
                AltOption.IsChecked = true;
                return;
            }

            SimpleOption.IsChecked = false;
            OrbOption.IsChecked = false;
            Properties.Settings.Default.Simple = SimpleOption.IsChecked;
            Properties.Settings.Default.Orb = OrbOption.IsChecked;
            Properties.Settings.Default.Alt = AltOption.IsChecked;

            if (AltOption.IsChecked)
            {
                Report1.SetResourceReference(ContentProperty, "BW-AnsemReport1");
                Report2.SetResourceReference(ContentProperty, "BW-AnsemReport2");
                Report3.SetResourceReference(ContentProperty, "BW-AnsemReport3");
                Report4.SetResourceReference(ContentProperty, "BW-AnsemReport4");
                Report5.SetResourceReference(ContentProperty, "BW-AnsemReport5");
                Report6.SetResourceReference(ContentProperty, "BW-AnsemReport6");
                Report7.SetResourceReference(ContentProperty, "BW-AnsemReport7");
                Report8.SetResourceReference(ContentProperty, "BW-AnsemReport8");
                Report9.SetResourceReference(ContentProperty, "BW-AnsemReport9");
                Report10.SetResourceReference(ContentProperty, "BW-AnsemReport10");
                Report11.SetResourceReference(ContentProperty, "BW-AnsemReport11");
                Report12.SetResourceReference(ContentProperty, "BW-AnsemReport12");
                Report13.SetResourceReference(ContentProperty, "BW-AnsemReport13");
                Fire1.SetResourceReference(ContentProperty, "BW-Fire");
                Fire2.SetResourceReference(ContentProperty, "BW-Fire");
                Fire3.SetResourceReference(ContentProperty, "BW-Fire");
                Blizzard1.SetResourceReference(ContentProperty, "BW-Blizzard");
                Blizzard2.SetResourceReference(ContentProperty, "BW-Blizzard");
                Blizzard3.SetResourceReference(ContentProperty, "BW-Blizzard");
                Thunder1.SetResourceReference(ContentProperty, "BW-Thunder");
                Thunder2.SetResourceReference(ContentProperty, "BW-Thunder");
                Thunder3.SetResourceReference(ContentProperty, "BW-Thunder");
                Cure1.SetResourceReference(ContentProperty, "BW-Cure");
                Cure2.SetResourceReference(ContentProperty, "BW-Cure");
                Cure3.SetResourceReference(ContentProperty, "BW-Cure");
                Reflect1.SetResourceReference(ContentProperty, "BW-Reflect");
                Reflect2.SetResourceReference(ContentProperty, "BW-Reflect");
                Reflect3.SetResourceReference(ContentProperty, "BW-Reflect");
                Magnet1.SetResourceReference(ContentProperty, "BW-Magnet");
                Magnet2.SetResourceReference(ContentProperty, "BW-Magnet");
                Magnet3.SetResourceReference(ContentProperty, "BW-Magnet");
                Valor.SetResourceReference(ContentProperty, "BW-Valor");
                Wisdom.SetResourceReference(ContentProperty, "BW-Wisdom");
                Limit.SetResourceReference(ContentProperty, "BW-Limit");
                Master.SetResourceReference(ContentProperty, "BW-Master");
                Final.SetResourceReference(ContentProperty, "BW-Final");
                ValorM.SetResourceReference(ContentProperty, "BW-Valor");
                WisdomM.SetResourceReference(ContentProperty, "BW-Wisdom");
                LimitM.SetResourceReference(ContentProperty, "BW-Limit");
                MasterM.SetResourceReference(ContentProperty, "BW-Master");
                FinalM.SetResourceReference(ContentProperty, "BW-Final");
                TornPage1.SetResourceReference(ContentProperty, "BW-TornPage");
                TornPage2.SetResourceReference(ContentProperty, "BW-TornPage");
                TornPage3.SetResourceReference(ContentProperty, "BW-TornPage");
                TornPage4.SetResourceReference(ContentProperty, "BW-TornPage");
                TornPage5.SetResourceReference(ContentProperty, "BW-TornPage");
                Lamp.SetResourceReference(ContentProperty, "BW-Genie");
                Ukulele.SetResourceReference(ContentProperty, "BW-Stitch");
                Baseball.SetResourceReference(ContentProperty, "BW-ChickenLittle");
                Feather.SetResourceReference(ContentProperty, "BW-PeterPan");
                Nonexistence.SetResourceReference(ContentProperty, "BW-ProofOfNonexistence");
                Connection.SetResourceReference(ContentProperty, "BW-ProofOfConnection");
                Peace.SetResourceReference(ContentProperty, "BW-ProofOfPeace");
                PromiseCharm.SetResourceReference(ContentProperty, "BW-PromiseCharm");

                OnceMore.SetResourceReference(ContentProperty, "BW-OnceMore");
                SecondChance.SetResourceReference(ContentProperty, "BW-SecondChance");
                ComboMaster.SetResourceReference(ContentProperty, "BW-ComboMaster");
                HighJump.SetResourceReference(ContentProperty, "BW-HighJump");
                QuickRun.SetResourceReference(ContentProperty, "BW-QuickRun");
                DodgeRoll.SetResourceReference(ContentProperty, "BW-DodgeRoll");
                AerialDodge.SetResourceReference(ContentProperty, "BW-AerialDodge");
                Glide.SetResourceReference(ContentProperty, "BW-Glide");

                HadesCup.SetResourceReference(ContentProperty, "BW-HadesCup");
                OlympusStone.SetResourceReference(ContentProperty, "BW-OlympusStone");
                MembershipCard.SetResourceReference(ContentProperty, "BW-MembershipCard");

                //NoValorM.SetResourceReference(ContentProperty, "BW-NoValor");
                //NoWisdomM.SetResourceReference(ContentProperty, "BW-NoWisdom");
                //NoLimitM.SetResourceReference(ContentProperty, "BW-NoLimit");
                //NoMasterM.SetResourceReference(ContentProperty, "BW-NoMaster");
                //NoFinalM.SetResourceReference(ContentProperty, "BW-NoFinal");

                LevelIcon.SetResourceReference(ContentProperty, "BW-LevelIcon");
                StrengthIcon.SetResourceReference(ContentProperty, "BW-StrengthIcon");
                MagicIcon.SetResourceReference(ContentProperty, "BW-MagicIcon");
                DefenseIcon.SetResourceReference(ContentProperty, "BW-DefenseIcon");
                //CollectedBar.SetResourceReference(ContentProperty, "BW-CollectedBarYellow");

                broadcast.Report.SetResourceReference(ContentProperty, "BW-AnsemReport");
                broadcast.TornPage.SetResourceReference(ContentProperty, "BW-TornPageB");
                broadcast.Peace.SetResourceReference(ContentProperty, "BW-ProofOfPeace");
                broadcast.Nonexistence.SetResourceReference(ContentProperty, "BW-ProofOfNonexistence");
                broadcast.Connection.SetResourceReference(ContentProperty, "BW-ProofOfConnection");
                broadcast.PromiseCharm.SetResourceReference(ContentProperty, "BW-PromiseCharm");
                broadcast.Fire.SetResourceReference(ContentProperty, "BW-Fire");
                broadcast.Blizzard.SetResourceReference(ContentProperty, "BW-Blizzard");
                broadcast.Thunder.SetResourceReference(ContentProperty, "BW-Thunder");
                broadcast.Cure.SetResourceReference(ContentProperty, "BW-Cure");
                broadcast.Reflect.SetResourceReference(ContentProperty, "BW-Reflect");
                broadcast.Magnet.SetResourceReference(ContentProperty, "BW-Magnet");
                broadcast.Valor.SetResourceReference(ContentProperty, "BW-Valor");
                broadcast.Wisdom.SetResourceReference(ContentProperty, "BW-Wisdom");
                broadcast.Limit.SetResourceReference(ContentProperty, "BW-Limit");
                broadcast.Master.SetResourceReference(ContentProperty, "BW-Master");
                broadcast.Final.SetResourceReference(ContentProperty, "BW-Final");
                broadcast.Baseball.SetResourceReference(ContentProperty, "BW-ChickenLittle");
                broadcast.Lamp.SetResourceReference(ContentProperty, "BW-Genie");
                broadcast.Ukulele.SetResourceReference(ContentProperty, "BW-Stitch");
                broadcast.Feather.SetResourceReference(ContentProperty, "BW-PeterPan");
                broadcast.OnceMore.SetResourceReference(ContentProperty, "BW-OnceMore");
                broadcast.SecondChance.SetResourceReference(ContentProperty, "BW-SecondChance");
                broadcast.ComboMaster.SetResourceReference(ContentProperty, "BW-ComboMaster");

                broadcast.HighJump.SetResourceReference(ContentProperty, "BW-HighJump");
                broadcast.QuickRun.SetResourceReference(ContentProperty, "BW-QuickRun");
                broadcast.DodgeRoll.SetResourceReference(ContentProperty, "BW-DodgeRoll");
                broadcast.AerialDodge.SetResourceReference(ContentProperty, "BW-AerialDodge");
                broadcast.Glide.SetResourceReference(ContentProperty, "BW-Glide");

                broadcast.HadesCup.SetResourceReference(ContentProperty, "BW-HadesCup");
                broadcast.OlympusStone.SetResourceReference(ContentProperty, "BW-OlympusStone");
                broadcast.MembershipCard.SetResourceReference(ContentProperty, "BW-MembershipCard");

                broadcast.ReportFoundBar.Source = data.RaisinSlashBarY;
                broadcast.TornPageBar.Source = data.RaisinSlashBarY;
                broadcast.CollectedBar.Source = data.RaisinSlashBarY;

                broadcast.ReportFoundTotal.Source = data.RaisinNumbers[14];
                broadcast.TornPageTotal.Source = data.RaisinSingleNumbers[6];

                ((Grid)((Grid)broadcast.Fire.Parent).Parent).RowDefinitions[0].Height = new GridLength(0, GridUnitType.Star);
                ((Grid)((Grid)broadcast.Fire.Parent).Parent).RowDefinitions[2].Height = new GridLength(0, GridUnitType.Star);
                ((Grid)broadcast.Valor.Parent).RowDefinitions[1].Height = new GridLength(5, GridUnitType.Star);
                ((Grid)broadcast.Valor.Parent).RowDefinitions[2].Height = new GridLength(5, GridUnitType.Star);
                ((Grid)broadcast.Lamp.Parent).RowDefinitions[1].Height = new GridLength(8, GridUnitType.Star);
            }

            CustomChecksCheck();
            ReloadBindings();
        }

        private void DefWorldToggle(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (DefWorldOption.IsChecked == false)
            {
                DefWorldOption.IsChecked = true;
                return;
            }

            OutWorldOption.IsChecked = false;
            GamWorldOption.IsChecked = false;
            BawWorldOption.IsChecked = false;
            Properties.Settings.Default.DefWorld = DefWorldOption.IsChecked;
            Properties.Settings.Default.OutWorld = OutWorldOption.IsChecked;
            Properties.Settings.Default.GamWorld = GamWorldOption.IsChecked;
            Properties.Settings.Default.BawWorld = BawWorldOption.IsChecked;

            if (DefWorldOption.IsChecked)
            {
                //main window worlds
                SorasHeart.SetResourceReference(ContentProperty, "SoraHeartImage");
                SimulatedTwilightTown.SetResourceReference(ContentProperty, "SimulatedImage");
                HollowBastion.SetResourceReference(ContentProperty, "HollowBastionImage");
                OlympusColiseum.SetResourceReference(ContentProperty, "OlympusImage");
                LandofDragons.SetResourceReference(ContentProperty, "LandofDragonsImage");
                PrideLands.SetResourceReference(ContentProperty, "PrideLandsImage");
                HalloweenTown.SetResourceReference(ContentProperty, "HalloweenTownImage");
                SpaceParanoids.SetResourceReference(ContentProperty, "SpaceParanoidsImage");
                GoA.SetResourceReference(ContentProperty, "GardenofAssemblageImage");
                DriveForms.SetResourceReference(ContentProperty, "DriveFormsImage");
                TwilightTown.SetResourceReference(ContentProperty, "TwilightTownImage");
                BeastsCastle.SetResourceReference(ContentProperty, "BeastCastleImage");
                Agrabah.SetResourceReference(ContentProperty, "AgrabahImage");
                HundredAcreWood.SetResourceReference(ContentProperty, "HundredAcreImage");
                DisneyCastle.SetResourceReference(ContentProperty, "DisneyCastleImage");
                PortRoyal.SetResourceReference(ContentProperty, "PortRoyalImage");
                TWTNW.SetResourceReference(ContentProperty, "TWTNWImage");
                Atlantica.SetResourceReference(ContentProperty, "AtlanticaImage");

                //broadcast window worlds
                broadcast.SorasHeart.SetResourceReference(ContentProperty, "SoraHeartImage");
                broadcast.SimulatedTwilightTown.SetResourceReference(ContentProperty, "SimulatedImage");
                broadcast.HollowBastion.SetResourceReference(ContentProperty, "HollowBastionImage");
                broadcast.OlympusColiseum.SetResourceReference(ContentProperty, "OlympusImage");
                broadcast.LandofDragons.SetResourceReference(ContentProperty, "LandofDragonsImage");
                broadcast.PrideLands.SetResourceReference(ContentProperty, "PrideLandsImage");
                broadcast.HalloweenTown.SetResourceReference(ContentProperty, "HalloweenTownImage");
                broadcast.SpaceParanoids.SetResourceReference(ContentProperty, "SpaceParanoidsImage");
                broadcast.DriveForms.SetResourceReference(ContentProperty, "DriveFormsImage");
                broadcast.TwilightTown.SetResourceReference(ContentProperty, "TwilightTownImage");
                broadcast.BeastsCastle.SetResourceReference(ContentProperty, "BeastCastleImage");
                broadcast.Agrabah.SetResourceReference(ContentProperty, "AgrabahImage");
                broadcast.HundredAcreWood.SetResourceReference(ContentProperty, "HundredAcreImage");
                broadcast.DisneyCastle.SetResourceReference(ContentProperty, "DisneyCastleImage");
                broadcast.PortRoyal.SetResourceReference(ContentProperty, "PortRoyalImage");
                broadcast.TWTNW.SetResourceReference(ContentProperty, "TWTNWImage");
                broadcast.Atlantica.SetResourceReference(ContentProperty, "AtlanticaImage");
            }
            
            CustomWorldCheck();
        }

        private void OutWorldToggle(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (OutWorldOption.IsChecked == false)
            {
                OutWorldOption.IsChecked = true;
                return;
            }

            DefWorldOption.IsChecked = false;
            GamWorldOption.IsChecked = false;
            BawWorldOption.IsChecked = false;
            Properties.Settings.Default.DefWorld = DefWorldOption.IsChecked;
            Properties.Settings.Default.OutWorld = OutWorldOption.IsChecked;
            Properties.Settings.Default.GamWorld = GamWorldOption.IsChecked;
            Properties.Settings.Default.BawWorld = BawWorldOption.IsChecked;

            if (OutWorldOption.IsChecked)
            {
                //main window worlds
                SorasHeart.SetResourceReference(ContentProperty, "Alt-SoraHeartImage");
                SimulatedTwilightTown.SetResourceReference(ContentProperty, "Alt-SimulatedImage");
                HollowBastion.SetResourceReference(ContentProperty, "Alt-HollowBastionImage");
                OlympusColiseum.SetResourceReference(ContentProperty, "Alt-OlympusImage");
                LandofDragons.SetResourceReference(ContentProperty, "Alt-LandofDragonsImage");
                PrideLands.SetResourceReference(ContentProperty, "Alt-PrideLandsImage");
                HalloweenTown.SetResourceReference(ContentProperty, "Alt-HalloweenTownImage");
                SpaceParanoids.SetResourceReference(ContentProperty, "Alt-SpaceParanoidsImage");
                GoA.SetResourceReference(ContentProperty, "Alt-GardenofAssemblageImage");
                DriveForms.SetResourceReference(ContentProperty, "Alt-DriveFormsImage");
                TwilightTown.SetResourceReference(ContentProperty, "Alt-TwilightTownImage");
                BeastsCastle.SetResourceReference(ContentProperty, "Alt-BeastCastleImage");
                Agrabah.SetResourceReference(ContentProperty, "Alt-AgrabahImage");
                HundredAcreWood.SetResourceReference(ContentProperty, "Alt-HundredAcreImage");
                DisneyCastle.SetResourceReference(ContentProperty, "Alt-DisneyCastleImage");
                PortRoyal.SetResourceReference(ContentProperty, "Alt-PortRoyalImage");
                TWTNW.SetResourceReference(ContentProperty, "Alt-TWTNWImage");
                Atlantica.SetResourceReference(ContentProperty, "Alt-AtlanticaImage");

                //broadcast window worlds
                broadcast.SorasHeart.SetResourceReference(ContentProperty, "Alt-SoraHeartImage");
                broadcast.SimulatedTwilightTown.SetResourceReference(ContentProperty, "Alt-SimulatedImage");
                broadcast.HollowBastion.SetResourceReference(ContentProperty, "Alt-HollowBastionImage");
                broadcast.OlympusColiseum.SetResourceReference(ContentProperty, "Alt-OlympusImage");
                broadcast.LandofDragons.SetResourceReference(ContentProperty, "Alt-LandofDragonsImage");
                broadcast.PrideLands.SetResourceReference(ContentProperty, "Alt-PrideLandsImage");
                broadcast.HalloweenTown.SetResourceReference(ContentProperty, "Alt-HalloweenTownImage");
                broadcast.SpaceParanoids.SetResourceReference(ContentProperty, "Alt-SpaceParanoidsImage");
                broadcast.DriveForms.SetResourceReference(ContentProperty, "Alt-DriveFormsImage");
                broadcast.TwilightTown.SetResourceReference(ContentProperty, "Alt-TwilightTownImage");
                broadcast.BeastsCastle.SetResourceReference(ContentProperty, "Alt-BeastCastleImage");
                broadcast.Agrabah.SetResourceReference(ContentProperty, "Alt-AgrabahImage");
                broadcast.HundredAcreWood.SetResourceReference(ContentProperty, "Alt-HundredAcreImage");
                broadcast.DisneyCastle.SetResourceReference(ContentProperty, "Alt-DisneyCastleImage");
                broadcast.PortRoyal.SetResourceReference(ContentProperty, "Alt-PortRoyalImage");
                broadcast.TWTNW.SetResourceReference(ContentProperty, "Alt-TWTNWImage");
                broadcast.Atlantica.SetResourceReference(ContentProperty, "Alt-AtlanticaImage");
            }

            CustomWorldCheck();
        }

        private void GamWorldToggle(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (GamWorldOption.IsChecked == false)
            {
                GamWorldOption.IsChecked = true;
                return;
            }

            DefWorldOption.IsChecked = false;
            OutWorldOption.IsChecked = false;
            BawWorldOption.IsChecked = false;
            Properties.Settings.Default.DefWorld = DefWorldOption.IsChecked;
            Properties.Settings.Default.OutWorld = OutWorldOption.IsChecked;
            Properties.Settings.Default.GamWorld = GamWorldOption.IsChecked;
            Properties.Settings.Default.BawWorld = BawWorldOption.IsChecked;

            if (GamWorldOption.IsChecked)
            {
                //main window worlds
                SorasHeart.SetResourceReference(ContentProperty, "Game-SoraHeartImage");
                SimulatedTwilightTown.SetResourceReference(ContentProperty, "Game-SimulatedImage");
                HollowBastion.SetResourceReference(ContentProperty, "Game-HollowBastionImage");
                OlympusColiseum.SetResourceReference(ContentProperty, "Game-OlympusImage");
                LandofDragons.SetResourceReference(ContentProperty, "Game-LandofDragonsImage");
                PrideLands.SetResourceReference(ContentProperty, "Game-PrideLandsImage");
                HalloweenTown.SetResourceReference(ContentProperty, "Game-HalloweenTownImage");
                SpaceParanoids.SetResourceReference(ContentProperty, "Game-SpaceParanoidsImage");
                GoA.SetResourceReference(ContentProperty, "Game-GardenofAssemblageImage");
                DriveForms.SetResourceReference(ContentProperty, "Game-DriveFormsImage");
                TwilightTown.SetResourceReference(ContentProperty, "Game-TwilightTownImage");
                BeastsCastle.SetResourceReference(ContentProperty, "Game-BeastCastleImage");
                Agrabah.SetResourceReference(ContentProperty, "Game-AgrabahImage");
                HundredAcreWood.SetResourceReference(ContentProperty, "Game-HundredAcreImage");
                DisneyCastle.SetResourceReference(ContentProperty, "Game-DisneyCastleImage");
                PortRoyal.SetResourceReference(ContentProperty, "Game-PortRoyalImage");
                TWTNW.SetResourceReference(ContentProperty, "Game-TWTNWImage");
                Atlantica.SetResourceReference(ContentProperty, "Game-AtlanticaImage");

                //broadcast window worlds
                broadcast.SorasHeart.SetResourceReference(ContentProperty, "Game-SoraHeartImage");
                broadcast.SimulatedTwilightTown.SetResourceReference(ContentProperty, "Game-SimulatedImage");
                broadcast.HollowBastion.SetResourceReference(ContentProperty, "Game-HollowBastionImage");
                broadcast.OlympusColiseum.SetResourceReference(ContentProperty, "Game-OlympusImage");
                broadcast.LandofDragons.SetResourceReference(ContentProperty, "Game-LandofDragonsImage");
                broadcast.PrideLands.SetResourceReference(ContentProperty, "Game-PrideLandsImage");
                broadcast.HalloweenTown.SetResourceReference(ContentProperty, "Game-HalloweenTownImage");
                broadcast.SpaceParanoids.SetResourceReference(ContentProperty, "Game-SpaceParanoidsImage");
                broadcast.DriveForms.SetResourceReference(ContentProperty, "Game-DriveFormsImage");
                broadcast.TwilightTown.SetResourceReference(ContentProperty, "Game-TwilightTownImage");
                broadcast.BeastsCastle.SetResourceReference(ContentProperty, "Game-BeastCastleImage");
                broadcast.Agrabah.SetResourceReference(ContentProperty, "Game-AgrabahImage");
                broadcast.HundredAcreWood.SetResourceReference(ContentProperty, "Game-HundredAcreImage");
                broadcast.DisneyCastle.SetResourceReference(ContentProperty, "Game-DisneyCastleImage");
                broadcast.PortRoyal.SetResourceReference(ContentProperty, "Game-PortRoyalImage");
                broadcast.TWTNW.SetResourceReference(ContentProperty, "Game-TWTNWImage");
                broadcast.Atlantica.SetResourceReference(ContentProperty, "Game-AtlanticaImage");
            }

            CustomWorldCheck();
        }

        private void BawWorldToggle(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (BawWorldOption.IsChecked == false)
            {
                BawWorldOption.IsChecked = true;
                return;
            }

            DefWorldOption.IsChecked = false;
            OutWorldOption.IsChecked = false;
            GamWorldOption.IsChecked = false;
            Properties.Settings.Default.DefWorld = DefWorldOption.IsChecked;
            Properties.Settings.Default.OutWorld = OutWorldOption.IsChecked;
            Properties.Settings.Default.GamWorld = GamWorldOption.IsChecked;
            Properties.Settings.Default.BawWorld = BawWorldOption.IsChecked;

            if (BawWorldOption.IsChecked)
            {
                //main window worlds
                SorasHeart.SetResourceReference(ContentProperty, "BW-SoraHeartImage");
                SimulatedTwilightTown.SetResourceReference(ContentProperty, "BW-SimulatedImage");
                HollowBastion.SetResourceReference(ContentProperty, "BW-HollowBastionImage");
                OlympusColiseum.SetResourceReference(ContentProperty, "BW-OlympusImage");
                LandofDragons.SetResourceReference(ContentProperty, "BW-LandofDragonsImage");
                PrideLands.SetResourceReference(ContentProperty, "BW-PrideLandsImage");
                HalloweenTown.SetResourceReference(ContentProperty, "BW-HalloweenTownImage");
                SpaceParanoids.SetResourceReference(ContentProperty, "BW-SpaceParanoidsImage");
                GoA.SetResourceReference(ContentProperty, "BW-GardenofAssemblageImage");
                DriveForms.SetResourceReference(ContentProperty, "BW-DriveFormsImage");
                TwilightTown.SetResourceReference(ContentProperty, "BW-TwilightTownImage");
                BeastsCastle.SetResourceReference(ContentProperty, "BW-BeastCastleImage");
                Agrabah.SetResourceReference(ContentProperty, "BW-AgrabahImage");
                HundredAcreWood.SetResourceReference(ContentProperty, "BW-HundredAcreImage");
                DisneyCastle.SetResourceReference(ContentProperty, "BW-DisneyCastleImage");
                PortRoyal.SetResourceReference(ContentProperty, "BW-PortRoyalImage");
                TWTNW.SetResourceReference(ContentProperty, "BW-TWTNWImage");
                Atlantica.SetResourceReference(ContentProperty, "BW-AtlanticaImage");

                //broadcast window worlds
                broadcast.SorasHeart.SetResourceReference(ContentProperty, "BW-SoraHeartImage");
                broadcast.SimulatedTwilightTown.SetResourceReference(ContentProperty, "BW-SimulatedImage");
                broadcast.HollowBastion.SetResourceReference(ContentProperty, "BW-HollowBastionImage");
                broadcast.OlympusColiseum.SetResourceReference(ContentProperty, "BW-OlympusImage");
                broadcast.LandofDragons.SetResourceReference(ContentProperty, "BW-LandofDragonsImage");
                broadcast.PrideLands.SetResourceReference(ContentProperty, "BW-PrideLandsImage");
                broadcast.HalloweenTown.SetResourceReference(ContentProperty, "BW-HalloweenTownImage");
                broadcast.SpaceParanoids.SetResourceReference(ContentProperty, "BW-SpaceParanoidsImage");
                broadcast.DriveForms.SetResourceReference(ContentProperty, "BW-DriveFormsImage");
                broadcast.TwilightTown.SetResourceReference(ContentProperty, "BW-TwilightTownImage");
                broadcast.BeastsCastle.SetResourceReference(ContentProperty, "BW-BeastCastleImage");
                broadcast.Agrabah.SetResourceReference(ContentProperty, "BW-AgrabahImage");
                broadcast.HundredAcreWood.SetResourceReference(ContentProperty, "BW-HundredAcreImage");
                broadcast.DisneyCastle.SetResourceReference(ContentProperty, "BW-DisneyCastleImage");
                broadcast.PortRoyal.SetResourceReference(ContentProperty, "BW-PortRoyalImage");
                broadcast.TWTNW.SetResourceReference(ContentProperty, "BW-TWTNWImage");
                broadcast.Atlantica.SetResourceReference(ContentProperty, "BW-AtlanticaImage");
            }

            CustomWorldCheck();
        }

        private void CustomImageToggle(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.CustomFolder = CustomFolderOption.IsChecked;

            CustomChecksCheck();
            CustomWorldCheck();
            ReloadBindings();

            if (CustomFolderOption.IsChecked == false)
            {
                //reload check icons
                {
                    if (SimpleOption.IsChecked)
                    {
                        SimpleToggle(sender, e);
                    }
                    else if (OrbOption.IsChecked)
                    {
                        OrbToggle(sender, e);
                    }
                    else if (AltOption.IsChecked)
                    {
                        AltToggle(sender, e);
                    }
                }
                //reload world icons
                {
                    if (DefWorldOption.IsChecked)
                    {
                        DefWorldToggle(sender, e);
                    }
                    else if(OutWorldOption.IsChecked)
                    {
                        OutWorldToggle(sender, e);
                    }
                    else if (GamWorldOption.IsChecked)
                    {
                        GamWorldToggle(sender, e);
                    }
                    else if (BawWorldOption.IsChecked)
                    {
                        BawWorldToggle(sender, e);
                    }
                }
            }

        }

        private void DefProgToggle(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (DefProgOption.IsChecked == false)
            {
                DefProgOption.IsChecked = true;
                return;
            }

            OldProgOption.IsChecked = false;
            BaWProgOption.IsChecked = false;
            Properties.Settings.Default.DefProg = DefProgOption.IsChecked;
            Properties.Settings.Default.OldProg = OldProgOption.IsChecked;
            Properties.Settings.Default.BaWProg = BaWProgOption.IsChecked;

            if (DefProgOption.IsChecked)
            {
                //do this later....
            }
        }

        private void OldProgToggle(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (OldProgOption.IsChecked == false)
            {
                OldProgOption.IsChecked = true;
                return;
            }

            DefProgOption.IsChecked = false;
            BaWProgOption.IsChecked = false;
            Properties.Settings.Default.DefProg = DefProgOption.IsChecked;
            Properties.Settings.Default.OldProg = OldProgOption.IsChecked;
            Properties.Settings.Default.BaWProg = BaWProgOption.IsChecked;

            if (OldProgOption.IsChecked)
            {
                //do this later....
            }
        }

        private void BaWProgToggle(object sender, RoutedEventArgs e)
        {
            // Mimicing radio buttons so you cant toggle a button off
            if (BaWProgOption.IsChecked == false)
            {
                BaWProgOption.IsChecked = true;
                return;
            }

            DefProgOption.IsChecked = false;
            OldProgOption.IsChecked = false;
            Properties.Settings.Default.DefProg = DefProgOption.IsChecked;
            Properties.Settings.Default.OldProg = OldProgOption.IsChecked;
            Properties.Settings.Default.BaWProg = BaWProgOption.IsChecked;

            if (BaWProgOption.IsChecked)
            {
                //do this later....
            }
        }

        private void WorldProgressToggle(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.WorldProgress = WorldProgressOption.IsChecked;
            if (WorldProgressOption.IsChecked)
            {
                broadcast.ToggleProgression(true);

                foreach (string key in data.WorldsData.Keys.ToList())
                {
                    if (data.WorldsData[key].progression != null)
                        data.WorldsData[key].progression.Visibility = Visibility.Visible;

                    data.WorldsData[key].top.ColumnDefinitions[0].Width = new GridLength(1.5, GridUnitType.Star);
                    data.WorldsData[key].top.ColumnDefinitions[1].Width = new GridLength(3.3, GridUnitType.Star);

                    Grid grid = data.WorldsData[key].world.Parent as Grid;
                    grid.ColumnDefinitions[0].Width = new GridLength(3.5, GridUnitType.Star);
                    grid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
                    grid.ColumnDefinitions[2].Width = new GridLength(2, GridUnitType.Star);
                    Grid.SetColumnSpan(data.WorldsData[key].world, 2);
                }
            }
            else
            {
                broadcast.ToggleProgression(false);

                foreach (string key in data.WorldsData.Keys.ToList())
                {
                    if (data.WorldsData[key].progression != null)
                        data.WorldsData[key].progression.Visibility = Visibility.Hidden;

                    data.WorldsData[key].top.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                    data.WorldsData[key].top.ColumnDefinitions[1].Width = new GridLength(4, GridUnitType.Star);

                    Grid grid = data.WorldsData[key].world.Parent as Grid;
                    grid.ColumnDefinitions[0].Width = new GridLength(2, GridUnitType.Star);
                    grid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Star);
                    grid.ColumnDefinitions[2].Width = new GridLength(4, GridUnitType.Star);
                    Grid.SetColumnSpan(data.WorldsData[key].world, 3);
                }
            }
        }

        private void DragDropToggle(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.DragDrop = DragAndDropOption.IsChecked;
            data.dragDrop = DragAndDropOption.IsChecked;
            foreach (Item item in data.Items)
            {
                if (item.Parent == ItemPool)
                {
                    if (data.dragDrop == false)
                    {
                        item.MouseDoubleClick -= item.Item_Click;
                        item.MouseMove -= item.Item_MouseMove;

                        item.MouseDown -= item.Item_MouseDown;
                        item.MouseDown += item.Item_MouseDown;
                        item.MouseUp -= item.Item_MouseUp;
                        item.MouseUp += item.Item_MouseUp;
                    }
                    else
                    {
                        item.MouseDoubleClick -= item.Item_Click;
                        item.MouseDoubleClick += item.Item_Click;
                        item.MouseMove -= item.Item_MouseMove;
                        item.MouseMove += item.Item_MouseMove;

                        item.MouseDown -= item.Item_MouseDown;
                        item.MouseUp -= item.Item_MouseUp;
                    }
                }
            }
        }

        private void TopMostToggle(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.TopMost = TopMostOption.IsChecked;
            Topmost = TopMostOption.IsChecked;
            broadcast.Topmost = TopMostOption.IsChecked;
        }

        private void BroadcastStartupToggle(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.BroadcastStartup = BroadcastStartupOption.IsChecked;
            if (BroadcastStartupOption.IsChecked)
                broadcast.Show();
        }

        private void FormsGrowthToggle(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.FormsGrowth = FormsGrowthOption.IsChecked;
            if (FormsGrowthOption.IsChecked)
                FormRow.Height = new GridLength(0.65, GridUnitType.Star);
            else
                FormRow.Height = new GridLength(0, GridUnitType.Star);
        }

        private void CustomChecksCheck()
        {
            if (CustomFolderOption.IsChecked == true)
            {
                //check if folders exists then start checking if each file exists in it
                if (Directory.Exists("CustomImages/Checks/"))
                {
                    //Main Window
                    if (File.Exists("CustomImages/Checks/ansem_report1.png"))
                        Report1.SetResourceReference(ContentProperty, "Custom-AnsemReport1");
                    if (File.Exists("CustomImages/Checks/ansem_report2.png"))
                        Report2.SetResourceReference(ContentProperty, "Custom-AnsemReport2");
                    if (File.Exists("CustomImages/Checks/ansem_report3.png"))
                        Report3.SetResourceReference(ContentProperty, "Custom-AnsemReport3");
                    if (File.Exists("CustomImages/Checks/ansem_report4.png"))
                        Report4.SetResourceReference(ContentProperty, "Custom-AnsemReport4");
                    if (File.Exists("CustomImages/Checks/ansem_report5.png"))
                        Report5.SetResourceReference(ContentProperty, "Custom-AnsemReport5");
                    if (File.Exists("CustomImages/Checks/ansem_report6.png"))
                        Report6.SetResourceReference(ContentProperty, "Custom-AnsemReport6");
                    if (File.Exists("CustomImages/Checks/ansem_report7.png"))
                        Report7.SetResourceReference(ContentProperty, "Custom-AnsemReport7");
                    if (File.Exists("CustomImages/Checks/ansem_report8.png"))
                        Report8.SetResourceReference(ContentProperty, "Custom-AnsemReport8");
                    if (File.Exists("CustomImages/Checks/ansem_report9.png"))
                        Report9.SetResourceReference(ContentProperty, "Custom-AnsemReport9");
                    if (File.Exists("CustomImages/Checks/ansem_report10.png"))
                        Report10.SetResourceReference(ContentProperty, "Custom-AnsemReport10");
                    if (File.Exists("CustomImages/Checks/ansem_report11.png"))
                        Report11.SetResourceReference(ContentProperty, "Custom-AnsemReport11");
                    if (File.Exists("CustomImages/Checks/ansem_report12.png"))
                        Report12.SetResourceReference(ContentProperty, "Custom-AnsemReport12");
                    if (File.Exists("CustomImages/Checks/ansem_report13.png"))
                        Report13.SetResourceReference(ContentProperty, "Custom-AnsemReport13");

                    if (File.Exists("CustomImages/Checks/jump.png"))
                    {
                        HighJump.SetResourceReference(ContentProperty, "Custom-HighJump");
                        broadcast.HighJump.SetResourceReference(ContentProperty, "Custom-HighJump");
                    }
                    if (File.Exists("CustomImages/Checks/quick.png"))
                    {
                        QuickRun.SetResourceReference(ContentProperty, "Custom-QuickRun");
                        broadcast.QuickRun.SetResourceReference(ContentProperty, "Custom-QuickRun");
                    }
                    if (File.Exists("CustomImages/Checks/dodge.png"))
                    {
                        DodgeRoll.SetResourceReference(ContentProperty, "Custom-DodgeRoll");
                        broadcast.DodgeRoll.SetResourceReference(ContentProperty, "Custom-DodgeRoll");

                    }
                    if (File.Exists("CustomImages/Checks/aerial.png"))
                    {
                        AerialDodge.SetResourceReference(ContentProperty, "Custom-AerialDodge");
                        broadcast.AerialDodge.SetResourceReference(ContentProperty, "Custom-AerialDodge");

                    }
                    if (File.Exists("CustomImages/Checks/glide.png"))
                    {
                        Glide.SetResourceReference(ContentProperty, "Custom-Glide");
                        broadcast.Glide.SetResourceReference(ContentProperty, "Custom-Glide");

                    }

                    if (File.Exists("CustomImages/Checks/fire.png"))
                    {
                        Fire1.SetResourceReference(ContentProperty, "Custom-Fire");
                        Fire2.SetResourceReference(ContentProperty, "Custom-Fire");
                        Fire3.SetResourceReference(ContentProperty, "Custom-Fire");
                        broadcast.Fire.SetResourceReference(ContentProperty, "Custom-Fire");
                    }
                    if (File.Exists("CustomImages/Checks/blizzard.png"))
                    {
                        Blizzard1.SetResourceReference(ContentProperty, "Custom-Blizzard");
                        Blizzard2.SetResourceReference(ContentProperty, "Custom-Blizzard");
                        Blizzard3.SetResourceReference(ContentProperty, "Custom-Blizzard");
                        broadcast.Blizzard.SetResourceReference(ContentProperty, "Custom-Blizzard");
                    }
                    if (File.Exists("CustomImages/Checks/thunder.png"))
                    {
                        Thunder1.SetResourceReference(ContentProperty, "Custom-Thunder");
                        Thunder2.SetResourceReference(ContentProperty, "Custom-Thunder");
                        Thunder3.SetResourceReference(ContentProperty, "Custom-Thunder");
                        broadcast.Thunder.SetResourceReference(ContentProperty, "Custom-Thunder");
                    }
                    if (File.Exists("CustomImages/Checks/cure.png"))
                    {
                        Cure1.SetResourceReference(ContentProperty, "Custom-Cure");
                        Cure2.SetResourceReference(ContentProperty, "Custom-Cure");
                        Cure3.SetResourceReference(ContentProperty, "Custom-Cure");
                        broadcast.Cure.SetResourceReference(ContentProperty, "Custom-Cure");
                    }
                    if (File.Exists("CustomImages/Checks/reflect.png"))
                    {
                        Reflect1.SetResourceReference(ContentProperty, "Custom-Reflect");
                        Reflect2.SetResourceReference(ContentProperty, "Custom-Reflect");
                        Reflect3.SetResourceReference(ContentProperty, "Custom-Reflect");
                        broadcast.Reflect.SetResourceReference(ContentProperty, "Custom-Reflect");
                    }
                    if (File.Exists("CustomImages/Checks/magnet.png"))
                    {
                        Magnet1.SetResourceReference(ContentProperty, "Custom-Magnet");
                        Magnet2.SetResourceReference(ContentProperty, "Custom-Magnet");
                        Magnet3.SetResourceReference(ContentProperty, "Custom-Magnet");
                        broadcast.Magnet.SetResourceReference(ContentProperty, "Custom-Magnet");
                    }

                    if (File.Exists("CustomImages/Checks/torn_pages.png"))
                    {
                        TornPage1.SetResourceReference(ContentProperty, "Custom-TornPage");
                        TornPage2.SetResourceReference(ContentProperty, "Custom-TornPage");
                        TornPage3.SetResourceReference(ContentProperty, "Custom-TornPage");
                        TornPage4.SetResourceReference(ContentProperty, "Custom-TornPage");
                        TornPage5.SetResourceReference(ContentProperty, "Custom-TornPage");
                    }

                    if (File.Exists("CustomImages/Checks/valor.png"))
                    {
                        Valor.SetResourceReference(ContentProperty, "Custom-Valor");
                        ValorM.SetResourceReference(ContentProperty, "Custom-Valor");
                        broadcast.Valor.SetResourceReference(ContentProperty, "Custom-Valor");
                    }
                    if (File.Exists("CustomImages/Checks/wisdom.png"))
                    {
                        Wisdom.SetResourceReference(ContentProperty, "Custom-Wisdom");
                        WisdomM.SetResourceReference(ContentProperty, "Custom-Wisdom");
                        broadcast.Wisdom.SetResourceReference(ContentProperty, "Custom-Wisdom");
                    }
                    if (File.Exists("CustomImages/Checks/limit.png"))
                    {
                        Limit.SetResourceReference(ContentProperty, "Custom-Limit");
                        LimitM.SetResourceReference(ContentProperty, "Custom-Limit");
                        broadcast.Limit.SetResourceReference(ContentProperty, "Custom-Limit");
                    }
                    if (File.Exists("CustomImages/Checks/master.png"))
                    {
                        Master.SetResourceReference(ContentProperty, "Custom-Master");
                        MasterM.SetResourceReference(ContentProperty, "Custom-Master");
                        broadcast.Master.SetResourceReference(ContentProperty, "Custom-Master");
                    }
                    if (File.Exists("CustomImages/Checks/final.png"))
                    {
                        Final.SetResourceReference(ContentProperty, "Custom-Final");
                        FinalM.SetResourceReference(ContentProperty, "Custom-Final");
                        broadcast.Final.SetResourceReference(ContentProperty, "Custom-Final");
                    }

                    if (File.Exists("CustomImages/Checks/genie.png"))
                    {
                        Lamp.SetResourceReference(ContentProperty, "Custom-Genie");
                        broadcast.Lamp.SetResourceReference(ContentProperty, "Custom-Genie");
                    }
                    if (File.Exists("CustomImages/Checks/stitch.png"))
                    {
                        Ukulele.SetResourceReference(ContentProperty, "Custom-Stitch");
                        broadcast.Ukulele.SetResourceReference(ContentProperty, "Custom-Stitch");
                    }
                    if (File.Exists("CustomImages/Checks/chicken_little.png"))
                    {
                        Baseball.SetResourceReference(ContentProperty, "Custom-ChickenLittle");
                        broadcast.Baseball.SetResourceReference(ContentProperty, "Custom-ChickenLittle");
                    }
                    if (File.Exists("CustomImages/Checks/peter_pan.png"))
                    {
                        Feather.SetResourceReference(ContentProperty, "Custom-PeterPan");
                        broadcast.Feather.SetResourceReference(ContentProperty, "Custom-PeterPan");
                    }

                    if (File.Exists("CustomImages/Checks/proof_of_nonexistence.png"))
                    {
                        Nonexistence.SetResourceReference(ContentProperty, "Custom-ProofOfNonexistence");
                        broadcast.Nonexistence.SetResourceReference(ContentProperty, "Custom-ProofOfNonexistence");
                    }
                    if (File.Exists("CustomImages/Checks/proof_of_connection.png"))
                    {
                        Connection.SetResourceReference(ContentProperty, "Custom-ProofOfConnection");
                        broadcast.Connection.SetResourceReference(ContentProperty, "Custom-ProofOfConnection");
                    }
                    if (File.Exists("CustomImages/Checks/proof_of_tranquility.png"))
                    {
                        Peace.SetResourceReference(ContentProperty, "Custom-ProofOfPeace");
                        broadcast.Peace.SetResourceReference(ContentProperty, "Custom-ProofOfPeace");
                    }
                    if (File.Exists("CustomImages/Checks/promise_charm.png"))
                    {
                        PromiseCharm.SetResourceReference(ContentProperty, "Custom-PromiseCharm");
                        broadcast.PromiseCharm.SetResourceReference(ContentProperty, "Custom-PromiseCharm");
                    }
                    if (File.Exists("CustomImages/Checks/once_more.png"))
                    {
                        OnceMore.SetResourceReference(ContentProperty, "Custom-OnceMore");
                        broadcast.OnceMore.SetResourceReference(ContentProperty, "Custom-OnceMore");
                    }
                    if (File.Exists("CustomImages/Checks/second_chance.png"))
                    {
                        SecondChance.SetResourceReference(ContentProperty, "Custom-SecondChance");
                        broadcast.SecondChance.SetResourceReference(ContentProperty, "Custom-SecondChance");
                    }             
                }

                //broadcast window specific
                if (File.Exists("CustomImages/Other/ansem_report.png"))
                {
                    broadcast.Report.SetResourceReference(ContentProperty, "AnsemReport");
                }
                if (File.Exists("CustomImages/Other/torn_pages.png"))
                {
                    broadcast.TornPage.SetResourceReference(ContentProperty, "TornPageB");
                }

                //for the question mark icon i layer over form level tracking
                if (File.Exists("CustomImages/question.png"))
                {
                    NoValorM.Source = data.CustomQuestion;
                    NoWisdomM.Source = data.CustomQuestion;
                    NoLimitM.Source = data.CustomQuestion;
                    NoMasterM.Source = data.CustomQuestion;
                    NoFinalM.Source = data.CustomQuestion;
                }

                if (CustomLevelFound)
                {
                    LevelIcon.SetResourceReference(ContentProperty, "Custom-LevelIcon");
                }

                if (CustomStrengthFound)
                {
                    StrengthIcon.SetResourceReference(ContentProperty, "Custom-StrengthIcon");
                }

                if (CustomMagicFound)
                {
                    MagicIcon.SetResourceReference(ContentProperty, "Custom-MagicIcon");
                }

                if (CustomDefenseFound)
                {
                    DefenseIcon.SetResourceReference(ContentProperty, "Custom-DefenseIcon");
                }

                if (File.Exists("CustomImages/Bar.png"))
                {
                    broadcast.ReportFoundBar.Source = data.CustomnSlashBarY;
                    broadcast.TornPageBar.Source = data.CustomnSlashBarY;
                    broadcast.CollectedBar.Source = data.CustomnSlashBarY;


                    broadcast.ReportFoundTotal.Source = data.CustomNumbers[14];
                    broadcast.TornPageTotal.Source = data.CustomSingleNumbers[6];
                }
            }
            //TODO later (maybe): set up the image to change with different check icon modes.
            //currently all of them just use the same image
            else
            {
                NoValorM.Source = data.Question;
                NoWisdomM.Source = data.Question;
                NoLimitM.Source = data.Question;
                NoMasterM.Source = data.Question;
                NoFinalM.Source = data.Question;
            }

        }

        private void CustomWorldCheck()
        {
            if (CustomFolderOption.IsChecked == true)
            {
                if (Directory.Exists("CustomImages/World/"))
                {
                    if (File.Exists("CustomImages/World/sora_heart.png"))
                    {
                        SorasHeart.SetResourceReference(ContentProperty, "Custom-SoraHeartImage");
                        broadcast.SorasHeart.SetResourceReference(ContentProperty, "Custom-SoraHeartImage");
                    }
                    if (File.Exists("CustomImages/World/simulated_twilight_town.png"))
                    {
                        SimulatedTwilightTown.SetResourceReference(ContentProperty, "Custom-SimulatedImage");
                        broadcast.SimulatedTwilightTown.SetResourceReference(ContentProperty, "Custom-SimulatedImage");
                    }
                    if (File.Exists("CustomImages/World/hollow_bastion.png"))
                    {
                        HollowBastion.SetResourceReference(ContentProperty, "Custom-HollowBastionImage");
                        broadcast.HollowBastion.SetResourceReference(ContentProperty, "Custom-HollowBastionImage");
                    }
                    if (File.Exists("CustomImages/World/olympus_coliseum.png"))
                    {
                        OlympusColiseum.SetResourceReference(ContentProperty, "Custom-OlympusImage");
                        broadcast.OlympusColiseum.SetResourceReference(ContentProperty, "Custom-OlympusImage");
                    }
                    if (File.Exists("CustomImages/World/land_of_dragons.png"))
                    {
                        LandofDragons.SetResourceReference(ContentProperty, "Custom-LandofDragonsImage");
                        broadcast.LandofDragons.SetResourceReference(ContentProperty, "Custom-LandofDragonsImage");
                    }
                    if (File.Exists("CustomImages/World/pride_land.png"))
                    {
                        PrideLands.SetResourceReference(ContentProperty, "Custom-PrideLandsImage");
                        broadcast.PrideLands.SetResourceReference(ContentProperty, "Custom-PrideLandsImage");
                    }
                    if (File.Exists("CustomImages/World/halloween_town.png"))
                    {
                        HalloweenTown.SetResourceReference(ContentProperty, "Custom-HalloweenTownImage");
                        broadcast.HalloweenTown.SetResourceReference(ContentProperty, "Custom-HalloweenTownImage");
                    }
                    if (File.Exists("CustomImages/World/space_paranoids.png"))
                    {
                        SpaceParanoids.SetResourceReference(ContentProperty, "Custom-SpaceParanoidsImage");
                        broadcast.SpaceParanoids.SetResourceReference(ContentProperty, "Custom-SpaceParanoidsImage");
                    }
                    if (File.Exists("CustomImages/World/drive_form.png"))
                    {
                        DriveForms.SetResourceReference(ContentProperty, "Custom-DriveFormsImage");
                        broadcast.DriveForms.SetResourceReference(ContentProperty, "Custom-DriveFormsImage");
                    }
                    if (File.Exists("CustomImages/World/twilight_town.png"))
                    {
                        TwilightTown.SetResourceReference(ContentProperty, "Custom-TwilightTownImage");
                        broadcast.TwilightTown.SetResourceReference(ContentProperty, "Custom-TwilightTownImage");
                    }
                    if (File.Exists("CustomImages/World/beast's_castle.png"))
                    {
                        BeastsCastle.SetResourceReference(ContentProperty, "Custom-BeastCastleImage");
                        broadcast.BeastsCastle.SetResourceReference(ContentProperty, "Custom-BeastCastleImage");
                    }
                    if (File.Exists("CustomImages/World/agrabah.png"))
                    {
                        Agrabah.SetResourceReference(ContentProperty, "Custom-AgrabahImage");
                        broadcast.Agrabah.SetResourceReference(ContentProperty, "Custom-AgrabahImage");
                    }
                    if (File.Exists("CustomImages/World/100_acre_wood.png"))
                    {
                        HundredAcreWood.SetResourceReference(ContentProperty, "Custom-HundredAcreImage");
                        broadcast.HundredAcreWood.SetResourceReference(ContentProperty, "Custom-HundredAcreImage");
                    }
                    if (File.Exists("CustomImages/World/disney_castle.png"))
                    {
                        DisneyCastle.SetResourceReference(ContentProperty, "Custom-DisneyCastleImage");
                        broadcast.DisneyCastle.SetResourceReference(ContentProperty, "Custom-DisneyCastleImage");
                    }
                    if (File.Exists("CustomImages/World/port_royal.png"))
                    {
                        PortRoyal.SetResourceReference(ContentProperty, "Custom-PortRoyalImage");
                        broadcast.PortRoyal.SetResourceReference(ContentProperty, "Custom-PortRoyalImage");
                    }
                    if (File.Exists("CustomImages/World/the_world_that_never_was.png"))
                    {
                        TWTNW.SetResourceReference(ContentProperty, "Custom-TWTNWImage");
                        broadcast.TWTNW.SetResourceReference(ContentProperty, "Custom-TWTNWImage");
                    }
                    if (File.Exists("CustomImages/World/atlantica.png"))
                    {
                        Atlantica.SetResourceReference(ContentProperty, "Custom-AtlanticaImage");
                        broadcast.Atlantica.SetResourceReference(ContentProperty, "Custom-AtlanticaImage");
                    }
                    if (File.Exists("CustomImages/World/replica_data.png"))
                    {
                        GoA.SetResourceReference(ContentProperty, "Custom-GardenofAssemblageImage");
                    }
                }
            }
        }

        //i use this to check if any one of the Hades cup, olympus stone, or membership card toggles are enabled.
        //if any of them are it shows the grid for for them on the broadcast window, else is hides it.
        //i just didn't want a big empty space in it if all of them were disabled
        private void ExtraItemToggleCheck()
        {
            bool HadesCupOn = HadesTrophyOption.IsChecked;
            bool MemberCardOn = HBCardOption.IsChecked;
            bool StoneOn = OStoneOption.IsChecked;

            if (HadesCupOn || MemberCardOn || StoneOn)
                broadcast.ExtraCheckRow.Height = new GridLength(1.0, GridUnitType.Star);
            else
                broadcast.ExtraCheckRow.Height = new GridLength(0, GridUnitType.Star);


        }
    }
}
