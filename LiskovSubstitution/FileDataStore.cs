using System.IO;

namespace LiskovSubstitution;

public class FileDataStore : IDataStore
{
    private readonly string _tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

    public FileDataStore()
    {
        Directory.CreateDirectory(_tempDir);
    }

    /// <summary>
    /// Validates that the provided key is not null or empty. Throws an ArgumentException if the key is invalid.
    /// </summary>
    /// <param name="key">The key to validate.</param>
    /// <exception cref="ArgumentException">If the key is null or empty.</exception>
    private void ValidateKey(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));
        }
    }

    /// <summary>
    /// Sanitizes the given key to create a valid file name by replacing invalid characters with underscores.
    /// </summary>
    /// <param name="key">The key to sanitize.</param>
    /// <returns>The sanitized file name.</returns>
    private string SanitizeFileName(string key)
    {
        foreach (char c in System.IO.Path.GetInvalidFileNameChars())
        {
            key = key.Replace(c, '_');
        }
        return key;
    }

    /// <summary>
    /// Saves the value associated with the given key to a file in the temporary directory.
    /// </summary>
    /// <param name="key">The key associated with the value.</param>
    /// <param name="value">The value to save.</param>
    public void Save(string key, string value)
    {
        ValidateKey(key);
        key = SanitizeFileName(key);
        System.IO.StreamWriter sw = new(System.IO.Path.Combine(_tempDir, key));
        sw.Write(value);
        sw.Close();
    }

    /// <summary>
    /// Reads the value associated with the given key from a file in the temporary directory.
    /// If the file does not exist, it returns null.
    /// </summary>
    /// <param name="key">The key associated with the value.</param>
    /// <returns>The value associated with the key, or null if the file does not exist.</returns>
    public string? Read(string key)
    {
        ValidateKey(key);
        key = SanitizeFileName(key);

        if (System.IO.File.Exists(System.IO.Path.Combine(_tempDir, key)))
        {
            return System.IO.File.ReadAllText(System.IO.Path.Combine(_tempDir, key));
        }

        return null;
    }
}
