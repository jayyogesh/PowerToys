﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows;
using FancyZonesEditor.Models;
using MahApps.Metro.Controls;

namespace FancyZonesEditor
{
    public class EditorWindow : MetroWindow
    {
        protected void OnSaveApplyTemplate(object sender, RoutedEventArgs e)
        {
            EditorOverlay mainEditor = EditorOverlay.Current;
            LayoutModel model = mainEditor.DataContext as LayoutModel;
            if (model != null)
            {
                model.Persist(mainEditor.GetZoneRects());
            }
            _choosing = true;
            this.Close();
            EditorOverlay.Current.Close();
        }

        protected void OnClosed(object sender, EventArgs e)
        {
            if (!_choosing)
            {
                EditorOverlay.Current.ShowLayoutPicker();
            }
        }

        protected void OnCancel(object sender, RoutedEventArgs e)
        {
            _choosing = true;
            this.Close();
            EditorOverlay.Current.ShowLayoutPicker();
        }

        private bool _choosing = false;
    }
}
