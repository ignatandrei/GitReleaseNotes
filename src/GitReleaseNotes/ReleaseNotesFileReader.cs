using System.IO;

namespace GitReleaseNotes
{
    public class ReleaseNotesFileReader
    {
        private readonly IFileSystem _fileSystem;
        private readonly string _repositoryRoot;

        public ReleaseNotesFileReader(IFileSystem fileSystem, string repositoryRoot)
        {
            _fileSystem = fileSystem;
            _repositoryRoot = repositoryRoot;
        }

        public SemanticReleaseNotes ReadPreviousReleaseNotes(string releaseNotesFileName)
        {
            var path = Path.Combine(_repositoryRoot, releaseNotesFileName);
            if (!_fileSystem.FileExists(path))
                return new SemanticReleaseNotes();
            var contents = _fileSystem.ReadAllText(path).Replace("\r", string.Empty);

            return SemanticReleaseNotes.Parse(contents);
        }
    }
}