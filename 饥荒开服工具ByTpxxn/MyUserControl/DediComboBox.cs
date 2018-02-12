﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 饥荒开服工具ByTpxxn.MyUserControl
{
    public class DediComboBox : ComboBox
    {
        public DediComboBox()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(DediComboBox), new FrameworkPropertyMetadata(typeof(DediComboBox)));
        }

        public DediImageButton LeftButton;
        public DediImageButton RightButton;
         
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            LeftButton = GetTemplateChild("PART_LeftButton") as DediImageButton;
            RightButton = GetTemplateChild("PART_RightButton") as DediImageButton;
            if (LeftButton != null && RightButton != null)
            {
                LeftButton.Click += LeftButton_Click;
                RightButton.Click += RightButton_Click;
                SelectionChanged += ServerComboBox_SelectionChanged;
                if (SelectedIndex == 0)
                {
                    LeftButton.Visibility = Visibility.Collapsed;
                }
                if (Items.Count == 1)
                {
                    SelectedIndex = 0;
                    LeftButton.Visibility = Visibility.Collapsed;
                    RightButton.Visibility = Visibility.Collapsed;
                }
                if (SelectedIndex == Items.Count - 1)
                {
                    RightButton.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void ServerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == null || Items.Count <= 0)
            {
                return;
            }
            if (Items.Count == 1)
            {
                SelectedIndex = 0;
                LeftButton.Visibility = Visibility.Collapsed;
                RightButton.Visibility = Visibility.Collapsed;
            }
            if (Items.Count > 1)
            {
                if (SelectedIndex == 0)
                {
                    LeftButton.Visibility = Visibility.Collapsed;
                    RightButton.Visibility = Visibility.Visible;
                }
                else
                if (SelectedIndex == Items.Count - 1)
                {
                    RightButton.Visibility = Visibility.Collapsed;
                    LeftButton.Visibility = Visibility.Visible;
                }
                else
                {
                    RightButton.Visibility = Visibility.Visible;
                    LeftButton.Visibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// 点击右键
        /// </summary>
        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            // 空，返回
            if (Items.Count <= 0)
            {
                return;
            }
            if (SelectedIndex == -1 && Items.Count >= 1)
            {
                SelectedIndex = 0;
                return;
            }
            SelectedIndex += 1;
        }

        /// <summary>
        /// 点击左键
        /// </summary>
        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            // 空，返回
            if (Items.Count <= 0)
            {
                return;
            }
            if (SelectedIndex == -1 && Items.Count >= 1)
            {
                SelectedIndex = 0;
                return;
            }
            SelectedIndex -= 1;
        }
    }
}
