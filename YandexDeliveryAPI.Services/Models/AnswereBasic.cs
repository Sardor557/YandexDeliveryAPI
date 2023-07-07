namespace YandexDeliveryAPI.Services.Models
{
    public class AnswereBasic
    {
        public long AnswereId { get; set; }

        public string AnswereMessage { get; set; }

        public string AnswereComment { get; set; }

        public AnswereBasic()
        {
            AnswereId = 1L;
            AnswereMessage = "default";
            AnswereComment = "";
        }

        public AnswereBasic(long inAnswereId, string inAnswereMessage)
        {
            AnswereId = inAnswereId;
            AnswereMessage = (AnswereComment = inAnswereMessage);
        }

        public AnswereBasic(long inAnswereId, string inAnswereMessage, string inAnswereComment)
        {
            AnswereId = inAnswereId;
            AnswereMessage = inAnswereMessage;
            AnswereComment = inAnswereComment;
        }
    }
}
