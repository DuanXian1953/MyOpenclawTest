using System;
using System.Runtime.InteropServices;

public class Display {
    [DllImport("user32.dll")] 
    public static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);
    
    [DllImport("user32.dll")] 
    public static extern int ChangeDisplaySettings(ref DEVMODE devMode, int flags);
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)] 
    public struct DEVMODE {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] 
        public string dmDeviceName;
        public short dmSpecVersion;
        public short dmDriverVersion;
        public short dmSize;
        public short dmDriverExtra;
        public int dmFields;
        public int dmPositionX;
        public int dmPositionY;
        public int dmDisplayOrientation;
        public int dmDisplayFixedOutput;
        public short dmColor;
        public short dmDuplex;
        public short dmYResolution;
        public short dmTTOption;
        public short dmCollate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] 
        public string dmFormName;
        public short dmLogPixels;
        public short dmBitsPerPel;
        public int dmPelsWidth;
        public int dmPelsHeight;
        public int dmDisplayFlags;
        public int dmDisplayFrequency;
    }
    
    public static void Main(string[] args) {
        int width = int.Parse(args[0]);
        int height = int.Parse(args[1]);
        
        DEVMODE dm = new DEVMODE();
        dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
        EnumDisplaySettings(null, -1, ref dm);
        dm.dmPelsWidth = width;
        dm.dmPelsHeight = height;
        dm.dmFields = 0x00080000 | 0x00100000;
        int result = ChangeDisplaySettings(ref dm, 0);
        Console.WriteLine("ChangeDisplaySettings result: " + result);
    }
}
