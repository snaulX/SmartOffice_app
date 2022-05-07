using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SmartOfficeApp
{
    public interface IDevice
    {
        string Name { get; }
        string Status { get; }
        string ImageStatus { get; }
        UserControl Menu { get; }
        void Update();
    }
}
