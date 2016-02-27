﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace TrinityCreator
{
    /// <summary>
    /// Interaction logic for ArmorWeaponPage.xaml
    /// </summary>
    public partial class ArmorWeaponPage : UserControl
    {
        public ArmorWeaponPage()
        {
            InitializeComponent();

            // load preview
            preview = new ItemPreview();
            previewBox.Content = preview;

            // load form data
            itemQualityCb.ItemsSource = ItemQuality.GetQualityList();
            itemQualityCb.SelectedIndex = 0;
            itemTypeCb.SelectedIndex = 0;

        }

        ItemPreview preview;

        #region Changed event handlers
        private void itemNameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            preview.itemNameLbl.Content = itemNameTxt.Text;
        }
        private void itemQuoteTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (itemQuoteTxt.Text == "")
                preview.itemQuoteLbl.Visibility = Visibility.Collapsed;
            else
            {
                preview.itemQuoteLbl.Visibility = Visibility.Visible;
                preview.itemQuoteLbl.Content = '"' + itemQuoteTxt.Text + '"';
            }
        }
        private void itemQualityCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemQuality q = (ItemQuality)itemQualityCb.SelectedValue;
            preview.itemNameLbl.Foreground = new SolidColorBrush(q.QualityColor);
        }

        private void itemTypeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (itemTypeCb.SelectedIndex == 0) // weapon
                {
                    weaponBox.Visibility = Visibility.Visible;
                    armorBox.Visibility = Visibility.Collapsed;
                }
                else if (itemTypeCb.SelectedIndex == 1) // armor
                {
                    weaponBox.Visibility = Visibility.Collapsed;
                    armorBox.Visibility = Visibility.Visible;
                }
            }
            catch (NullReferenceException)
            { /* Happens on load when not everything is initialized */ }
        }
        #endregion

        

        

       
    }
}
