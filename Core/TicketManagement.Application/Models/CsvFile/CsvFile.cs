namespace TicketManagement.Application.Models
{
    public record CsvFile
    {
        public CsvFile(string exportFileName, string contentType, byte[] data)
        {
            ExportFileName = exportFileName;
            ContentType = contentType;
            Data = data;
        }
        public string ExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}