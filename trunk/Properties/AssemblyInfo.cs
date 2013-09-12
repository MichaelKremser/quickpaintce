using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Allgemeine Informationen über eine Assembly werden über die folgenden
// Attribute gesteuert. Ändern Sie diese Attributwerte, um die Informationen zu ändern,
// die mit einer Assembly verknüpft sind.
[assembly: AssemblyTitle("QuickPaintCE")]
[assembly: AssemblyDescription("Small program for drawing objects for Windows® Pocket PC/Windows® CE platforms running .net Compact Framework 3.5 or better.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Michael Kremser Computer Services")]
[assembly: AssemblyProduct("QuickPaintCE")]
[assembly: AssemblyCopyright("Copyright © 2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Durch Festlegen von ComVisible auf "false" werden die Typen in dieser Assembly unsichtbar
// für COM-Komponenten. Wenn Sie auf einen Typ in dieser Assembly von
// COM zugreifen müssen, legen Sie das ComVisible-Attribut für diesen Typ auf "true" fest.
[assembly: ComVisible(false)]

// Die folgende GUID bestimmt die ID der Typbibliothek, wenn dieses Projekt für COM verfügbar gemacht wird
[assembly: Guid("8b5863a2-3148-45b0-ac31-aa3befa124b9")]

// Versionsinformationen für eine Assembly bestehen aus den folgenden vier Werten:
//
//      Hauptversion
//      Nebenversion
//      Buildnummer
//      Revision
//
[assembly: AssemblyVersion("0.2.0.0")]

// Mit dem nachstehenden Attribut wird die FxCop-Warnung "CA2232 : Microsoft.Usage : Fügen Sie ein STAThreadAttribute zu der Assembly hinzu" unterdrückt,
// da die Geräteanwendung keine STA-Threads unterstützt.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2232:MarkWindowsFormsEntryPointsWithStaThread")]
