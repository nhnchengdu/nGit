using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;  

using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Collections;

namespace Nhn.Git.SourceControl.Provider
{

   public class EnumDescConverter : System.ComponentModel.EnumConverter
   {
       protected System.Type myVal;
       public override bool GetPropertiesSupported(ITypeDescriptorContext context)
       {
           return true;
       }
       public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
       {
           ArrayList values = new ArrayList();
           FieldInfo[] fis = myVal.GetFields();
           foreach (FieldInfo fi in fis)
           {
               DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);
               if (attributes.Length > 0)
                   values.Add(fi.GetValue(fi.Name));
           }
           return new TypeConverter.StandardValuesCollection(values);
       }
       public static string GetEnumDescription(Enum value)
      {
        FieldInfo fi= value.GetType().GetField(value.ToString()); 
       DescriptionAttribute[] attributes = 
          (DescriptionAttribute[])fi.GetCustomAttributes(
          typeof(DescriptionAttribute), false);
        return (attributes.Length>0)?attributes[0].Description:value.ToString();
     } 
       public static string GetEnumDescription(System.Type value, string name)
       {
            FieldInfo fi= value.GetField(name); 
            DescriptionAttribute[] attributes = 
            (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute), false);
            return (attributes.Length>0)?attributes[0].Description:name;
       }  
       public static object GetEnumValue(System.Type value, string description)
      {
        FieldInfo [] fis = value.GetFields();
       foreach(FieldInfo fi in fis) 
       {
        DescriptionAttribute[] attributes = 
            (DescriptionAttribute[])fi.GetCustomAttributes(
           typeof(DescriptionAttribute), false);
         if(attributes.Length>0) 
         {
           if(attributes[0].Description == description)
          {
            return fi.GetValue(fi.Name);
           }
         }
        if(fi.Name == description)
         {
           return fi.GetValue(fi.Name);
         }
       }
       return description;
     }
       public EnumDescConverter(System.Type type) : base(type.GetType())
    {
        myVal = type;
    }
       public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
       {
         if(value is Enum && destinationType == typeof(string)) 
         {
           return GetEnumDescription((Enum)value);
         }
         if(value is string && destinationType == typeof(string)) 
         {
           return GetEnumDescription(myVal, (string)value);
        }
        return base.ConvertTo (context, culture, value, destinationType);
      }
       public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
      {
        if(value is string) 
        {
          return GetEnumValue(myVal, (string)value);        
        }
        if(value is Enum) 
        {
          return GetEnumDescription((Enum)value);        
        }
        return base.ConvertFrom (context, culture, value);
      }
    }
    





    [DefaultPropertyAttribute("nGit Configuration")]  
    class SccProviderProperty
    {
       private string m_szGitInfo;  
       private string m_szGitExePath;  
       private string m_szMergTool;  
       private string m_szCompareTool;
       private SshType m_szSSH;
       private string m_szSSHPath; 

       private string m_szEmail;
       private string m_szUser;  

       private string m_szRepoPath;  
       private string m_szCurrBranch;
       private bool m_bIsIndexed;

       private string m_szFilePath;
       private string m_szFileStatus;

       private string m_szHelp;

       //public class FileNameConverter : StringConverter 
       //{

       //    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
       //    {
       //        return true;
       //    }  

       //    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
       //    {
       //        return new StandardValuesCollection(new string[] { "新文件", "文件1", "文档1" });
       //    } 
       
       //}


       public enum SshType
       {
           [Description("OpenSSH")]
           //[DisplayName("OpenSSH")]//自定义Attribute
           TYPE_OPEN=83,

           [Description("PuTTY")]
          // [DisplayName("PuTTY ")]//自定义Attribute
           TYPE_PUTTY=86,
           [Description("Other SSH Client")]
          // [DisplayName("Other SSH Client")]//自定义Attribute
           TYPE_OTHER=87
       } 


       [CategoryAttribute("nGit Configuration"), DescriptionAttribute("msysgit version which you are using"),
        DisplayName("Git Information"),
        ReadOnlyAttribute(true),
        DefaultValueAttribute("")] 
       public string GitInfomation   
       {
           get { return m_szGitInfo; }
           set { m_szGitInfo = value; }   
       }

       [CategoryAttribute("nGit Configuration"), DescriptionAttribute("select the git execute file"),
        DisplayName("Git Execution Path"),
        ReadOnlyAttribute(false),
        DefaultValueAttribute(""),
        Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))] 
       public string GitApplication
       {
           get { return m_szGitExePath; }
           set { m_szGitExePath = value; }
       }

       [CategoryAttribute("nGit Configuration"), DescriptionAttribute("configure the external merge tool"),
        ReadOnlyAttribute(false),
        DefaultValueAttribute(""),
        DisplayName("Merge Tool"),
        Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]  
       public string MergeTool   
       {
           get { return m_szMergTool; }
           set { m_szMergTool = value; }  
       }


       [CategoryAttribute("nGit Configuration"), DescriptionAttribute("configure the external compare tool"),
        ReadOnlyAttribute(false),
        DefaultValueAttribute(""),
        DisplayName("Compare Tool"),
        Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))] 
       public string CompareTool  
       {
           get { return m_szCompareTool; }
           set { m_szCompareTool = value; }  
       }

       [CategoryAttribute("nGit Configuration"), DescriptionAttribute("configure the external SSH Execution Path"),
        ReadOnlyAttribute(false),
        Browsable(false),
        DefaultValueAttribute(""),
        DisplayName("SSH Execution Path"),
        Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
       public string SSHPath
       {
           get { return m_szSSHPath; }
           set { m_szSSHPath = value; }
       }


       [TypeConverter(typeof(EnumDescConverter)), DefaultValueAttribute(SshType.TYPE_OPEN),
        CategoryAttribute("nGit Configuration"),
        DescriptionAttribute("configure the SSH"),
        DisplayName("SSH Setting")]
       public SshType SSH
       {
           get { return m_szSSH; }
           set { m_szSSH = value; }
       }

       
       
       //
       [CategoryAttribute("User Information"), DescriptionAttribute(@"Get/Set user name"),DisplayName("User Name")]
       public string UserName
       {
           get { return m_szUser; }
           set { m_szUser = value; }
       }

       [CategoryAttribute("User Information"), DescriptionAttribute(@"Get/Set user email"), DisplayName("User Email")]
       public string UserEmail
       {
           get { return m_szEmail; }
           set { m_szEmail = value; }
       }
       

       //
       [CategoryAttribute("Repository Information"), DescriptionAttribute(@"Get the current Repository Path"),
        ReadOnlyAttribute(true),
         DisplayName("Repository Path"),
        DefaultValueAttribute("")]
       public string RepositoryPath
       {
           get { return m_szRepoPath; }
           set { m_szRepoPath = value; }
       }

       [CategoryAttribute("Repository Information"), DescriptionAttribute(@"Get the current Repository Path"),
        ReadOnlyAttribute(true),
        DisplayName("Current Branch"),
        DefaultValueAttribute("")]
       public string WorkingBranch
       {
           get { return m_szCurrBranch; }
           set { m_szCurrBranch = value; }
       }

       [CategoryAttribute("Repository Information"), DescriptionAttribute(@"Is any change in index area"),
        ReadOnlyAttribute(true),
        DisplayName("Any Index Change"),
        DefaultValueAttribute("")] 
       public bool IsIndexed
       {
           get { return m_bIsIndexed; }
           set { m_bIsIndexed = value; }
       }


        //
       [CategoryAttribute("Selected File"), DescriptionAttribute(@"Get the selected file full path"),
        ReadOnlyAttribute(true),
        DisplayName("File Path"),
        DefaultValueAttribute("")] 
       public string FilePath
       {
           get { return m_szFilePath; }
           set { m_szFilePath = value; }
       }

       [CategoryAttribute("Selected File"), DescriptionAttribute(@"Get the selected file's git status"),
        ReadOnlyAttribute(true),
        DisplayName("File Status"),
        DefaultValueAttribute("")] 
       public string File_Status
       {
           get { return m_szFileStatus; }
           set { m_szFileStatus = value; }
       }

       [CategoryAttribute("Help"), DescriptionAttribute(@"Help Information"),
        ReadOnlyAttribute(true),
        DisplayName("Description"),
        DefaultValueAttribute("")] 
       public string Description
       {
           get { return "nGit demo version: 00-00-02"; }
           set { m_szHelp = "nGit demo version: 00-00-02"; }
       }  

       public SccProviderProperty()
       {
           m_szSSH = SshType.TYPE_OPEN;
       }

       void SetPropertyVisibility(object obj, string propertyName, bool visible)
       {
           Type type = typeof(BrowsableAttribute);
           PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
           AttributeCollection attrs = props[propertyName].Attributes;
           FieldInfo fld = type.GetField("browsable", BindingFlags.Instance | BindingFlags.NonPublic);
           fld.SetValue(attrs[type], visible);
       } 


   }  

}
