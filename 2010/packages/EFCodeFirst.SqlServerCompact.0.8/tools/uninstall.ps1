param($installPath, $toolsPath, $package, $project)
$project.Object.References.Find("System.Transactions").Remove();
$project.Object.References.Find("System.Data.Entity").Remove();
