namespace OpenActive.NET.Tool.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using OpenActive.NET.Tool.Models;

    public interface ISchemaRepository
    {
        Task<(List<SchemaClass> classes, List<SchemaProperty> properties, List<SchemaEnumerationValue> enumerationValues)> GetObjects();
    }
}
