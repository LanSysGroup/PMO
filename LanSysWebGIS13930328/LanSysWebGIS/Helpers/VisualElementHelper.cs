using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LanSysWebGIS.Helpers
{
    public static class VisualElementHelper
    {
        //Image
        public static T FindImageName<T>(string name, DependencyObject reference) where T : FrameworkElement
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (reference == null)
            {
                throw new ArgumentNullException("reference");
            }

            return FindImageNameInternal<T>(name, reference);
        }

        public static T FindImageNameInternal<T>(string name, DependencyObject reference) where T : FrameworkElement
        {
            foreach (DependencyObject obj in GetChildren(reference))
            {
                T elem = obj as T;

                if (elem != null && elem.Name == name)
                {
                    return elem;
                }

                elem = FindImageNameInternal<T>(name, obj);

                if (elem != null)
                {
                    return elem;
                }
                else
                {
                    if (obj.GetType().FullName == "System.Windows.Controls.Image")
                        elem = (obj as Image) as T;

                    if (elem != null && elem.Name == name)
                        return elem;
                }
            }
            return null;
        }

        //esri Map
        public static T FindMapName<T>(string name, DependencyObject reference) where T : FrameworkElement
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (reference == null)
            {
                throw new ArgumentNullException("reference");
            }

            return FindMapNameInternal<T>(name, reference);
        }

        public static T FindMapNameInternal<T>(string name, DependencyObject reference) where T : FrameworkElement
        {
            foreach (DependencyObject obj in GetChildren(reference))
            {
                T elem = obj as T;

                if (elem != null && elem.Name == name)
                {
                    return elem;
                }

                elem = FindMapNameInternal<T>(name, obj);

                if (elem != null)
                {
                    return elem;
                }
                else
                {
                    if (obj.GetType().FullName == "ESRI.ArcGIS.Client.Map")
                        elem = (obj as ESRI.ArcGIS.Client.Map) as T;

                    if (elem != null && elem.Name == name)
                        return elem;
                }
            }
            return null;
        }

        //TextBlock
        public static T FindTextBlockName<T>(string name, DependencyObject reference) where T : FrameworkElement
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (reference == null)
            {
                throw new ArgumentNullException("reference");
            }

            return FindTextBlockNameInternal<T>(name, reference);
        }

        public static T FindTextBlockNameInternal<T>(string name, DependencyObject reference) where T : FrameworkElement
        {
            foreach (DependencyObject obj in GetChildren(reference))
            {
                T elem = obj as T;

                if (elem != null && elem.Name == name)
                {
                    return elem;
                }

                elem = FindTextBlockNameInternal<T>(name, obj);

                if (elem != null)
                {
                    return elem;
                }
                else
                {
                    if (obj.GetType().FullName == "System.Windows.Controls.TextBlock")
                        elem = (obj as System.Windows.Controls.TextBlock) as T;

                    if (elem != null && elem.Name == name)
                        return elem;
                }
            }
            return null;
        }

        //Esri Legend
        public static T FindLegendName<T>(string name, DependencyObject reference) where T : FrameworkElement
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (reference == null)
            {
                throw new ArgumentNullException("reference");
            }

            return FindLegendNameInternal<T>(name, reference);
        }

        public static T FindLegendNameInternal<T>(string name, DependencyObject reference) where T : FrameworkElement
        {
            foreach (DependencyObject obj in GetChildren(reference))
            {
                T elem = obj as T;

                if (elem != null && elem.Name == name)
                {
                    return elem;
                }

                elem = FindLegendNameInternal<T>(name, obj);

                if (elem != null)
                {
                    return elem;
                }
                else
                {
                    if (obj.GetType().FullName == "ESRI.ArcGIS.Client.Toolkit.Legend")
                        elem = (obj as ESRI.ArcGIS.Client.Toolkit.Legend) as T;

                    if (elem != null && elem.Name == name)
                        return elem;
                }
            }
            return null;
        }

        private static IEnumerable<DependencyObject> GetChildren(DependencyObject reference)
        {
            int childCount = VisualTreeHelper.GetChildrenCount(reference);

            for (int i = 0; i < childCount; i++)
            {
                yield return VisualTreeHelper.GetChild(reference, i);
            }
        }
    }
}
