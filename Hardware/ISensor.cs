/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2012 Michael Möller <mmoeller@openhardwaremonitor.org>
	
*/

using System;
using System.Collections.Generic;
using OpenHardwareMonitor.Collections;

namespace OpenHardwareMonitor.Hardware
{
    public interface ISensor : IElement
    {
        int Index { get; }
        bool IsDefaultHidden { get; }
        string Name { get; set; }
        Identifier Identifier { get; }
        IHardware Hardware { get; }
        SensorType SensorType { get; }
        IEnumerable<SensorValue> Values { get; }
        IReadOnlyArray<IParameter> Parameters { get; }
        IControl Control { get; }
        float? Value { get; }
        float? Min { get; }
        float? Max { get; }
        void Poll();
        void ResetMin();
        void ResetMax();
        event ValueChangedEventHandler ValueChanged;
    }

    public enum SensorType
    {
        Voltage, // V
        Clock, // MHz
        Temperature, // °C
        Load, // %
        Fan, // RPM
        Flow, // L/h
        Control, // %
        Level, // %
        Factor, // 1
        Power, // W
        Data, // GB = 2^30 Bytes    
        SmallData, // MB = 2^20 Bytes
    }

    public struct SensorValue
    {
        public float Value { get; }
        public DateTime Time { get; }

        public SensorValue(float value, DateTime time)
        {
            this.Value = value;
            this.Time = time;
        }
    }
}
