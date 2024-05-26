namespace DatVeXemPhim
{
    public static class Constants
    {
        public static readonly string CONNECTION_STRING = "Initial Catalog=CINEMA_PROJECT;Data Source=LAPTOP-P1DI0588\\SQLEXPRESS;TrustServerCertificate=True;Trusted_Connection=True";
        public static readonly string[] CATEGORIES = ["Hành động", "Tâm lý", "Kinh dị", "Lãng mạn", "Kỳ ảo"];
        public static readonly string[] RATINGS = [ "P", "K", "T13", "T16", "T18" ];
        public static readonly string[] TICKET_STATES = ["Hoàn tất", "Đã sử dụng", "Hết hạn"];
    }
}
