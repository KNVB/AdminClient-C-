namespace FtpAdminClient
{
    public class ItemObject
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
