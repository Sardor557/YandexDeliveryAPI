namespace YandexDeliveryAPI.Services.Models
{
    public class AnswereBasic
    {
        public long AnswerId { get; set; }

        public string AnswerMessage { get; set; }

        public string AnswerComment { get; set; }

        public AnswereBasic()
        {
            AnswerId = 1L;
            AnswerMessage = "default";
            AnswerComment = "";
        }

        public AnswereBasic(long inAnswereId, string inAnswereMessage)
        {
            AnswerId = inAnswereId;
            AnswerMessage = (AnswerComment = inAnswereMessage);
        }

        public AnswereBasic(long inAnswereId, string inAnswereMessage, string inAnswereComment)
        {
            AnswerId = inAnswereId;
            AnswerMessage = inAnswereMessage;
            AnswerComment = inAnswereComment;
        }
    }
}
