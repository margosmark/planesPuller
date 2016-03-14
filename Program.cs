using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace planesPuller
{
    public class Program
    {
        const string serverIp = "192.168.1.114";
        const int port = 30003;

        public static void Main(string[] args)
        {
            using (var db = new planeContext())
            {
                using (TcpClient client = new TcpClient())
                {
                    Task connectionResult = client.ConnectAsync(serverIp, port);
                    connectionResult.Wait();
                    using (System.Net.Sockets.NetworkStream stream = client.GetStream())
                    {
                        StreamReader rdr = new StreamReader(stream);
                        foreach (string line in ReadLines(rdr))
                        {
                            planeInfo blah;
                            string[] response = line.Split(',');
                            if (response.Length == 22)
                            {
                                blah = new planeInfo(response);
                                db.planeInfos.Add(blah);
                                db.SaveChanges();
                                System.Console.WriteLine(blah.ToString());
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
