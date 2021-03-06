namespace Dexi {

    public class Dexi {
        private string accountId;
        private string apiKey;
        private string userAgent = "Dexi-NET/1.0";
        private int requestTimeout = 3600;
        private string endpoint = "https://api.dexi.io"

        public Dexi(string accountId, string apiKey) {
            this.accountId = accountId;
            this.apiKey = apiKey;
        }

        protected string CalculateAccessKey(string accountId, string apiKey) {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(accountId + apiKey);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            stringBuilder sb = new stringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].Tostring("X2"));
            }
            return sb.Tostring();
        }

        public RunsController runs() {
            return new RunsController(this, accountId, this.CalculateAccessKey(accountId, apiKey));
        }
        public ExecutionsController executions() {
            return new ExecutionsController(this, accountId, this.CalculateAccessKey(accountId, apiKey));
        }

    }
}