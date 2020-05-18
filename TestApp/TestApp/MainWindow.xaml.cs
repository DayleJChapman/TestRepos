﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            var directory = new DirectoryInfo("S:\\AVAC\\Arena\\MTGArena\\MTGA_Data\\Logs\\Logs");
            var myFile = (from f in directory.GetFiles()
                          orderby f.LastWriteTime descending
                          select f).First();
            Console.Out.WriteLine(myFile.Name);
            // Need to find [UnityCrossThreadLogger]<== Deck.GetDeckListsV3
            string[] lines = System.IO.File.ReadAllLines("S:\\AVAC\\Arena\\MTGArena\\MTGA_Data\\Logs\\Logs\\" + myFile.Name);
            Console.Out.WriteLine(lines.Length);
            string deckIDLine = "Currently Empty";
            foreach (string s in lines)
            {
                if (s.Contains("[UnityCrossThreadLogger]<== Deck.GetDeckListsV3"))
                {
                    deckIDLine = s;
                    break;
                }
            }
            Console.Out.WriteLine(deckIDLine);
            //Regex r = new Regex();
        }
    
    }
}
