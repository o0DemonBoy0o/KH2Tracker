﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KhTracker
{
    /// <summary>
    /// Interaction logic for WorldGrid.xaml
    /// </summary>
    public partial class WorldGrid : UniformGrid
    {
        public WorldGrid()
        {
            InitializeComponent();
        }

        public void Handle_WorldGrid(Item button, bool add)
        {
            if (add)
            {
                try
                {
                    Children.Add(button);
                }
                catch (Exception)
                {
                    return;
                }
            }
            else
                Children.Remove(button);

            int gridremainder = 0;
            if (Children.Count % 5 != 0)
                gridremainder = 1;

            int gridnum = Math.Max((Children.Count / 5) + gridremainder, 1);

            Rows = gridnum;

            // default 1, add .5 for every row
            double length = 1 + ((Children.Count - 1) / 5) / 2.0;
            var outerGrid = ((Parent as Grid).Parent as Grid);
            int row = (int)Parent.GetValue(Grid.RowProperty);
            outerGrid.RowDefinitions[row].Height = new GridLength(length, GridUnitType.Star);

            if (MainWindow.data.mode == Mode.AltHints || MainWindow.data.mode == Mode.OpenKHAltHints)
            {
                WorldComplete();

                string worldName = Name.Substring(0, Name.Length - 4);
                if (MainWindow.data.WorldsData[worldName].hint != null)
                {
                    Image hint = MainWindow.data.WorldsData[worldName].hint;
                    ((MainWindow)App.Current.MainWindow).SetReportValue(hint, Children.Count + 1);
                }
            }
        }

        private void Item_Drop(Object sender, DragEventArgs e)
        {
            Data data = MainWindow.data;
            MainWindow window = ((MainWindow)Application.Current.MainWindow);
            if (e.Data.GetDataPresent(typeof(Item)))
            {

                Item item = e.Data.GetData(typeof(Item)) as Item;

                if (Handle_Report(item, window, data))
                    Add_Item(item, window);
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (System.IO.Path.GetExtension(files[0]).ToUpper() == ".TXT")
                    window.LoadHints(files[0]);
                else if (System.IO.Path.GetExtension(files[0]).ToUpper() == ".PNACH")
                    window.ParseSeed(files[0]);
            }
        }

        public void Add_Item(Item item, MainWindow window)
        {
            // move item to world
            window.ItemPool.Children.Remove(item);
            Handle_WorldGrid(item, true);

            // update collection count
            window.IncrementCollected();

            // update mouse actions
            if (MainWindow.data.dragDrop)
            {
                item.MouseDoubleClick -= item.Item_Click;
                item.MouseMove -= item.Item_MouseMove;
            }
            else
            {
                item.MouseDown -= item.Item_MouseDown;
                item.MouseUp -= item.Item_MouseUp;
            }
            item.MouseDown -= item.Item_Return;
            item.MouseDown += item.Item_Return;

            item.DragDropEventFire(item.Name, Name.Remove(Name.Length - 4, 4), true);
        }

        public bool Handle_Report(Item item, MainWindow window, Data data)
        {
            bool isreport = false;
            bool TEST = false;
            {
                if (data.reportLocations.Count == 16)
                    TEST = true;
            }



            // item is a report
            if (data.hintsLoaded && ((int)item.GetValue(Grid.RowProperty) == 0 || (TEST && (int)item.GetValue(Grid.RowProperty) == 3 && ((int)item.GetValue(Grid.ColumnProperty) == 9 || (int)item.GetValue(Grid.ColumnProperty) == 10 || (int)item.GetValue(Grid.ColumnProperty) == 11))))
            {
                int index = (int)item.GetValue(Grid.ColumnProperty);
                if (TEST)
                {
                    if (item.Name == "Nonexistence")
                        index = 13;
                    else if (item.Name == "Connection")
                        index = 14;
                    else if (item.Name == "Peace")
                        index = 15;
                }

                // out of report attempts
                if (data.reportAttempts[index] == 0)
                    return false;

                // check for correct report location
                if (data.reportLocations[index] == Name.Substring(0, Name.Length - 4))
                {
                    // hint text and resetting fail icons
                    window.SetHintText(Codes.GetHintTextName(data.reportInformation[index].Item1) + " has " + data.reportInformation[index].Item2 + " important checks");
                    data.ReportAttemptVisual[index].SetResourceReference(ContentControl.ContentProperty, "Fail0");
                    data.reportAttempts[index] = 3;
                    isreport = true;
                    item.DragDropEventFire(data.reportInformation[index].Item1, data.reportInformation[index].Item2);

                    // set world report hints to as hinted then checks if the report location was hinted to set if its a hinted hint
                    data.WorldsData[data.reportInformation[index].Item1].hinted = true;
                    if (data.WorldsData[data.reportLocations[index]].hinted == true)
                    {
                        data.WorldsData[data.reportInformation[index].Item1].hintedHint = true;
                    }

                    // loop through hinted world for reports to set their info as hinted hints
                    for (int i = 0; i < data.WorldsData[data.reportInformation[index].Item1].worldGrid.Children.Count; ++i)
                    {
                        Item gridItem = data.WorldsData[data.reportInformation[index].Item1].worldGrid.Children[i] as Item;
                        Console.WriteLine(gridItem.Name);
                        if (gridItem.Name.Contains("Report") || TEST && (gridItem.Name.Contains("Nonexistence") || gridItem.Name.Contains("Connection") || gridItem.Name.Contains("Peace")))
                        {
                            int reportIndex = 0;

                            if (gridItem.Name.Contains("Nonexistence"))
                                reportIndex = 13;
                            else if (gridItem.Name.Contains("Connection"))
                                reportIndex = 14;
                            else if (gridItem.Name.Contains("Peace"))
                                reportIndex = 15;
                            else
                                reportIndex = int.Parse(gridItem.Name.Substring(6)) - 1;


                            //int reportIndex = int.Parse(gridItem.Name.Substring(6)) - 1;
                            data.WorldsData[data.reportInformation[reportIndex].Item1].hintedHint = true;
                            window.SetReportValue(data.WorldsData[data.reportInformation[reportIndex].Item1].hint, data.reportInformation[reportIndex].Item2 + 1);
                        }
                    }

                    // auto update world important check number
                    window.SetReportValue(data.WorldsData[data.reportInformation[index].Item1].hint, data.reportInformation[index].Item2 + 1);
                }
                else
                {
                    // update fail icons when location is report location is wrong
                    AddFailIcon(index);
                    return false;
                }
            }

            // item is a proof
            //if (data.hintsLoaded && (TEST && (int)item.GetValue(Grid.RowProperty) == 3 && ((int)item.GetValue(Grid.ColumnProperty) == 9 || (int)item.GetValue(Grid.ColumnProperty) == 10 || (int)item.GetValue(Grid.ColumnProperty) == 11)))
            //{
            //    int index = 0;
            //    {
            //        if (item.Name == "Nonexistence")
            //            index = 13;
            //        if (item.Name == "Connection")
            //            index = 14;
            //        if (item.Name == "Peace")
            //            index = 15;
            //    }
            //
            //    Console.WriteLine(item.Name);
            //
            //    // out of report attempts
            //    //if (data.reportAttempts[index] == 0)
            //    //return false;
            //
            //    string whatthis = Name.Substring(0, Name.Length - 4);
            //    string what2 = data.reportLocations[index];
            //    Console.WriteLine("Location is - " + data.reportLocations[index]);
            //
            //    // check for correct report location
            //    if (data.reportLocations[index] == Name.Substring(0, Name.Length - 4))
            //    {
            //        // hint text and resetting fail icons
            //        window.SetHintText(Codes.GetHintTextName(data.reportInformation[index].Item1) + " has " + data.reportInformation[index].Item2 + " important checks");
            //        //data.ReportAttemptVisual[index].SetResourceReference(ContentControl.ContentProperty, "Fail0");
            //        //data.reportAttempts[index] = 3;
            //        isreport = true;
            //        item.DragDropEventFire(data.reportInformation[index].Item1, data.reportInformation[index].Item2);
            //
            //        // set world report hints to as hinted then checks if the report location was hinted to set if its a hinted hint
            //        data.WorldsData[data.reportInformation[index].Item1].hinted = true;
            //        if (data.WorldsData[data.reportLocations[index]].hinted == true)
            //        {
            //            data.WorldsData[data.reportInformation[index].Item1].hintedHint = true;
            //        }
            //
            //        // loop through hinted world for reports to set their info as hinted hints
            //        //for (int i = 0; i < data.WorldsData[data.reportInformation[index].Item1].worldGrid.Children.Count; ++i)
            //        //{
            //        //    Item gridItem = data.WorldsData[data.reportInformation[index].Item1].worldGrid.Children[i] as Item;
            //        //    if (gridItem.Name.Contains("Report") || gridItem.Name.Contains("Proof"))
            //        //    {
            //        //        int reportIndex = int.Parse(gridItem.Name.Substring(6)) - 1;
            //        //        data.WorldsData[data.reportInformation[reportIndex].Item1].hintedHint = true;
            //        //        window.SetReportValue(data.WorldsData[data.reportInformation[reportIndex].Item1].hint, data.reportInformation[reportIndex].Item2 + 1);
            //        //    }
            //        //}
            //
            //        // auto update world important check number
            //        window.SetReportValue(data.WorldsData[data.reportInformation[index].Item1].hint, data.reportInformation[index].Item2 + 1);
            //    }
            //    else
            //    {
            //        // update fail icons when location is report location is wrong
            //        //AddFailIcon(index);
            //       // return false;
            //    }
            //}


            if (isreport)
            {
                item.MouseEnter -= item.Report_Hover;
                item.MouseEnter += item.Report_Hover;
            }

            return true;
        }

        private void AddFailIcon(int index)
        {
            Data data = MainWindow.data;

            data.reportAttempts[index]--;
            if (data.reportAttempts[index] == 0)
                data.ReportAttemptVisual[index].SetResourceReference(ContentControl.ContentProperty, "Fail3");
            else if (data.reportAttempts[index] == 1)
                data.ReportAttemptVisual[index].SetResourceReference(ContentControl.ContentProperty, "Fail2");
            else if (data.reportAttempts[index] == 2)
                data.ReportAttemptVisual[index].SetResourceReference(ContentControl.ContentProperty, "Fail1");
        }

        public void WorldComplete()
        {
            string worldName = Name.Substring(0, Name.Length - 4);
            if (worldName == "GoA" || MainWindow.data.WorldsData[worldName].complete == true)
                return;

            List<string> items = new List<string>();
            items.AddRange(MainWindow.data.WorldsData[Name.Substring(0, Name.Length - 4)].checkCount);

            foreach (var child in Children)
            {
                Item item = child as Item;
                char[] numbers = { '1', '2', '3', '4', '5' };
                if (items.Contains(item.Name.TrimEnd(numbers)))
                {
                    items.Remove(item.Name.TrimEnd(numbers));
                }
            }

            if (items.Count == 0)
            {
                MainWindow.data.WorldsData[Name.Substring(0, Name.Length - 4)].complete = true;
            }
        }
    }
}
