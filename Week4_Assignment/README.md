# Week 4 - Library Management System (File System)

This is the Week 4 update of the Library Management System.
In this version, we added File I/O so items are saved to a JSON file (LibraryFile.json) and loaded again when the program runs.

## Folders
- Interface: ILibraryItem
- Abstraction: LibraryItemBase (abstract class)
- Model: Book, Magazine, Newspaper
- Service: LibraryService (SaveData / LoadData)
- CustomException: DuplicateItemException, InvalidItemDataException
- Utilities: Helper.cs

## Run (Mac)
dotnet restore
dotnet build
dotnet run
