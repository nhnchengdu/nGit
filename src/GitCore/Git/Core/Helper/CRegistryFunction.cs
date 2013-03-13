using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;
using Microsoft.Win32;


namespace Git.Core.Helper
{
    public static class CRegistryFunction
    {
        public static string GetRegistryValue(RegistryKey RootKey, string szSubKey, string szItem, out bool bIsSuccessful)
        {
            string value = string.Empty;
            try
            {
                RegistryKey registryKey = RootKey.OpenSubKey(szSubKey, false);
                if (registryKey != null)
                {
                    using (registryKey)
                    {
                        value = registryKey.GetValue(szItem) as string;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                bIsSuccessful = false;
            }
            bIsSuccessful = true;
            return value ;
        }

        public static bool SetRegistryValue(RegistryKey RootKey, string szSubKey, string szItem, string value)
        {
            bool bIsSuccessful = false;
            try
            {
                RegistryKey registryKey = RootKey.OpenSubKey(szSubKey, true);
                if (registryKey == null)
                {
                    registryKey = RootKey.CreateSubKey(szSubKey);
                }

                if (registryKey != null)
                {
                    using (registryKey)
                    {
                        registryKey.SetValue(szItem, value);
                        bIsSuccessful = true;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                return bIsSuccessful;
            }
            return bIsSuccessful;
        }
    }
}
