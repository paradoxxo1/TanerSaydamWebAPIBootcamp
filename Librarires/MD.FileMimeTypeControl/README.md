
# File Mime Type Control Nuget Package

With this NuGet package, you can perform type-checking on IFormFile files received in requests for jpg and png formats. It verifies the bytes of the file and returns false if it fails.

Features:
- Ability to perform type-checking on files in jpg and png formats received in requests.
- Ensures secure file uploads by performing byte-level verification.
- Simple and user-friendly API interface.

This package enhances the file uploading process of your application while increasing security and preventing the upload of unwanted file types. It is ideal for quick integration and easy use.


## Usage
```csharp
bool checkfileForJpg = file.CheckForJpg(); //returns false if it fails
bool checkfileForPng = file.CheckForPng(); //returns false if it fails
```


## Resource Code
```csharp
public static class ExtensionMethods
{
    public static bool CheckForJpg(this IFormFile file)
    {
        using (var stream = new MemoryStream())
        {
            file.CopyTo(stream);
            byte[] fileBytes = stream.ToArray();
            string jpgValue = fileBytes[0].ToString() + fileBytes[1].ToString() + fileBytes[2].ToString();


            if (jpgValue != "255216255")
            {
                return false;
            }
        }
        return true;
    }

    public static bool CheckForPng(this IFormFile file)
    {
        using (var stream = new MemoryStream())
        {
            file.CopyTo(stream);
            byte[] fileBytes = stream.ToArray();
            string jpgValue = 
                fileBytes[0].ToString() + 
                fileBytes[1].ToString() + 
                fileBytes[2].ToString() + 
                fileBytes[3].ToString();


            if (jpgValue != "137807871")
            {
                return false;
            }
        }
        return true;
    }
}

```


[Download the package now and ensure security in your file upload processes!](https://www.nuget.org)

Hope you like it!