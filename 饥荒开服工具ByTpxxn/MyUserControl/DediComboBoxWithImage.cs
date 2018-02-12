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

namespace 饥荒开服工具ByTpxxn.MyUserControl
{

    public class DediComboBoxWithImage : DediComboBox
    {

        private Image _image;
        private DediComboBox _dediComboBox;
        static DediComboBoxWithImage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DediComboBoxWithImage), new FrameworkPropertyMetadata(typeof(DediComboBoxWithImage)));
        }
        // 应用模板
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _image = GetTemplateChild("PART_Image") as Image;
            _dediComboBox = GetTemplateChild("PART_DediComboBox") as DediComboBox;
            SelectionChanged += DediComboBoxWithImage_SelectionChanged;

        }

        private void DediComboBoxWithImage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_dediComboBox != null)
            {
                SelectedIndex = _dediComboBox.SelectedIndex;
            }
        }

        // 图片uri
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(DediComboBoxWithImage)
            , new PropertyMetadata(new PropertyChangedCallback(OnImageSourceChanged)));

        private static void OnImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //DediComboBoxWithImage dediComboBoxWithImage = d as DediComboBoxWithImage;
            //if (dediComboBoxWithImage.image!=null)
            //{
            //    dediComboBoxWithImage.image.Source = (ImageSource)e.NewValue;
            //}
        }

        public ImageSource ImageSource
        {
            set => SetValue(ImageSourceProperty, value);
            get => (ImageSource)GetValue(ImageSourceProperty);
        }

        // ImageToolTip
        public static readonly DependencyProperty ImageToolTipProperty = DependencyProperty.Register("ImageToolTip", typeof(string), typeof(DediComboBoxWithImage));

        public string ImageToolTip
        {
            set => SetValue(ImageToolTipProperty, value);
            get => (string)GetValue(ImageToolTipProperty);
        }
    }
}
