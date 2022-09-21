using FC.Codeflix.Catalog.Domain.Enum;
using FC.Codeflix.Catalog.Domain.Validation;

namespace FC.Codeflix.Catalog.Domain.Entity;

public class Media : SeedWork.Entity
{
    public string FilePath { get; private set; }
    public string? EncodedPath { get; private set; }
    public MediaStatus Status { get; private set; }

    public Media(string filePath)
    {
        FilePath = filePath;
        Status = MediaStatus.Pending;
        EncodedPath = null;
    }

    public void UpdateToSentToEncoding() => Status = MediaStatus.Processing;

    public void UpdateToEncoded(string path)
    {
        Status = MediaStatus.Complete;
        EncodedPath = path;
    }

    public void UpdateToError(string path) => Status = MediaStatus.Error;
}
