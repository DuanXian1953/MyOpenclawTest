using System;
using System.Runtime.InteropServices;

public class DisplaySettings {
    [DllImport("user32.dll")] 
    public static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);
    
    [DllImport("user32.dll")] 
    public static extern int ChangeDisplaySettings(ref DEVMODE devMode, int flags);
    
    public const int ENUM_CURRENT_SETTINGS = -1;
    public const int CDS_UPDATEREGISTRY = 0x01;
    public const int CDS_TEST = 0x02;
    public const int DISP_CHANGE_SUCCESSFUL = 0;
    public const int DISP_CHANGE_RESTART = 1;
    public const int DISP_CHANGE_FAILED = -1;
    public const int DISP_CHANGE_BADMODE = -2;
    public const int DISP_CHANGE_NOTUPDATED = -3;
    public const int DISP_CHANGE_BADFLAGS = -4;
    public const int DISP_CHANGE_BADPARAM = -5;
    
    [StructLayout(LayoutKind.Sequential)] 
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
        public int dmICMMethod;
        public int dmICMIntent;
        public int dmMediaType;
        public int dmDitherType;
        public int dmReserved1;
        public int dmReserved2;
        public int dmPanningWidth;
        public int dmPanningHeight;
    }
    
    public static string SetResolution(int width, int height) {
        DEVMODE dm = new DEVMODE();
        dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
        
        if (!EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref dm)) {
            return "Failed to get current settings";
        }
        
        dm.dmPelsWidth = width;
        dm.dmPelsHeight = height;
        dm.dmFields = 0x00080000 | 0x00100000;
        
        int result = ChangeDisplaySettings(ref dm, CDS_TEST);
        
        if (result != DISP_CHANGE_SUCCESSFUL) {
            return "Test failed with code: " + result;
        }
        
        result = ChangeDisplaySettings(ref dm, CDS_UPDATEREGISTRY);
        
        switch (result) {
            case DISP_CHANGE_SUCCESSFUL: return "Success";
            case DISP_CHANGE_RESTART: return "Restart required";
            case DISP_CHANGE_FAILED: return "Failed";
            case DISP_CHANGE_BADMODE: return "Bad mode";
            case DISP_CHANGE_NOTUPDATED: return "Not updated";
            case DISP_CHANGE_BADFLAGS: return "Bad flags";
            case DISP_CHANGE_BADPARAM: return "Bad parameters";
            default: return "Unknown error: " + result;
        }
    }
    
    public static void Main(string[] args) {
        int width = int.Parse(args[0]);
        int height = int.Parse(args[1]);
        Console.WriteLine(SetResolution(width, height));
    }
}
