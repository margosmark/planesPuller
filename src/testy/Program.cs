using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace testy
{
    public class Program
    {
        const string serverIp = "127.0.0.1";
        const int port = 30003;

        public static void Main(string[] args)
        {
            var db = new planeContext();
            while (true)
            {
                using (TcpClient client = new TcpClient())
                {
                    Task connectionResult = client.ConnectAsync(serverIp, port);
                    connectionResult.Wait();
                    using (System.Net.Sockets.NetworkStream stream = client.GetStream())
                    {
                        int i = 0;
                        StreamReader rdr = new StreamReader(stream);
                        foreach (string line in ReadLines(rdr))
                        {
                            planeInfo blah;
                            string[] response = line.Split(',');
                            if (response.Length == 22)
                            {
                                blah = new planeInfo(response);
                                i++;
                                db.planeInfos.Add(blah);
                                if (i == 500)
                                {
                                    db.SaveChanges();
                                    db = new planeContext();
                                    i = 0;
                                }
                                System.Console.WriteLine(i.ToString());
                            }
                            else
                                System.Console.WriteLine("WRONG");
                        }
                    }
                }
            }
        }
        private static IEnumerable<string> ReadLines(StreamReader stream)
        {
            StringBuilder sb = new StringBuilder();
            int symbol = stream.Peek();
            while (symbol != -1)
            {
                symbol = stream.Read();
                if (symbol == 13 && stream.Peek() == 10)
                {
                    stream.Read();

                    string line = sb.ToString();
                    sb.Clear();

                    yield return line;
                }
                else
                    sb.Append((char)symbol);
            }

            yield return sb.ToString();
        }
    }
}
