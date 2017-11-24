# How to Use Logger in WPF Application

## Steps to Follow
- Create a WPF application in Visual Studio.
  - Go to NuGet package manager.
  - Select Manage NuGet Packages for Solution.
  - Select log4net by Apache Software.
- Add a config file to project name it as “log4net.config”.
  - Select Application Configuration File from menu.
  - Rename file to “log4net.config”.
- Select log4net.config from solution explorer, see for options in properties :
  - Build Action → Change to “ Content”.
  - Copy to output directory → Change to “copy always”.

## Making appropriate changes in "log4net.config" File
```xml
<log4net>
    <root>
      <level value="ALL" />
      <appender-ref ref="console" />
      <appender-ref ref="file" />
    </root>
    <appender name="console" type="log4net.Appender.ConsoleAppender">
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date %level %logger - %message%newline" />
      </layout>
    </appender>
    <appender name="file" type="log4net.Appender.RollingFileAppender">
      <file value="DIRECTORY WHERE YOU WANT TO COPY THE LOG FILES\LOG_FILE_NAME.log" />
      <appendToFile value="true" />
      <rollingStyle value="Size" />
      <maxSizeRollBackups value="5" />
      <maximumFileSize value="2MB" />
      <staticLogFileName value="true" />
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date [%thread] %level %logger - %message%newline" />
      </layout>
    </appender>
  </log4net>
```
## Open AssemblyInfo.cs from solution explorer and add at the end
```cs
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
```

## Configure App.xaml.cs file
- Add 'using log4net;' reference.
- Add these codes inside “public partial class App : Application” :
```cs
private static readonly ILog log = LogManager.GetLogger(typeof(App));
        protected override void OnStartup(StartupEventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info("        =============  Started Logging  =============        ");
            base.OnStartup(e);
        }
```
## Open MainWindow.cs
- Add reference :
  ```cs
    using log4net;
  ```
- Add these codes inside “public partial class MainWindow”
  ```cs
  private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
  ```
- Inside public MainWindow() :
  ```cs
  log4net.Config.XmlConfigurator.Configure();
  ```
- Options available for logs :
  ```
    /*
    *  log.info
    *  log.error
    *  log.fatal
    *  log.debug
    */
  ```
 ## Start Logging by running the solution
 
For Tutorial visit https://medium.com/nerd-stuff/logger-for-wpf-application-570eb9cbe546
