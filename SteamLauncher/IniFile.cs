// SteamLauncher: Copyright ©  2018 - Corey Harwell
using System.Text;
using System.Runtime.InteropServices;

namespace SteamLauncher
{
    class IniFile
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString( string section, string key, string val, string filePath );
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString( string section, string key, string def, StringBuilder value, int size, string filePath );

        public string FileName { get; private set; }
        private StringBuilder _readValue;

        public IniFile( string filePath )
        {
            FileName = filePath;
            _readValue = new StringBuilder(255);
        }
        public void WriteValue( string Section, string Key, string Value )
        {
            WritePrivateProfileString(Section, Key, Value, FileName);
        }
        public string ReadValue( string Section, string Key )
        {
            GetPrivateProfileString(Section, Key, "", _readValue, _readValue.Capacity, FileName);
            return _readValue.ToString();
        }
    }
}
