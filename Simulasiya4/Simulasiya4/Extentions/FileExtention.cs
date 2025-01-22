namespace Simulasiya4.Extentions;

public static class FileExtention
{
    public static bool IsValid(this IFormFile file, string type, int size)
    {
        if(!file.ContentType.StartsWith(type))
            return false;

        if(file.Length > size * 1024 * 1024) 
            return false;
        
        return true;
    }

    public static async Task<string> UploadAsync(this IFormFile file, params string[] paths)
    {
        string uploadpath = Path.Combine(paths);

        if (!Path.Exists(uploadpath))
        {
            Directory.CreateDirectory(uploadpath);
        }

        string FileName = file.FileName + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day +
            DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + Path.GetExtension(file.FileName);

        using(Stream stream = File.Create(Path.Combine(uploadpath, FileName)))
        {
            await file.CopyToAsync(stream);
        }

        return FileName;
    }
}
