using Anemonis.JsonRpc.ServiceClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Version = Idoit.API.Client.Idoit.Response.Version;
using Search = Idoit.API.Client.Idoit.Response.Search;
using Logout = Idoit.API.Client.Idoit.Response.Logout;
using Login = Idoit.API.Client.Idoit.Response.Login;
using System.Threading;
using System.Net;
using System.Net.Http;
using Anemonis.JsonRpc;
using System.Net.Http.Headers;
using Idoit.API.Client.ApiException;
using Newtonsoft.Json.Linq;

namespace Idoit.API.Client.Idoit
{
    public class Idoit
    {
        public Client client;
        List<Search[]> responseSearch;
        Logout responseLogout = new Logout();
        Login responseLogin = new Login();
        Version responseVersion;
        Dictionary<string, object> parameter;
        public Idoit(Client myClient)
        {
            client = myClient;
        }
        //Version
        public Version Version()
        {
            Task t = Task.Run(() => { version().Wait();}); t.Wait();
            return responseVersion;
        }
        //version
        async Task version()
        {
          responseVersion = await client.GetConnection().InvokeAsync<Version>("idoit.version", client.GetParameter());
        }

        //Search
        public List<Search[]> Search(string q)
        {
            Task t = Task.Run(() => { search(q).Wait(); }); t.Wait();
            return responseSearch;
        }
        //Search
        async Task search(string q)
        {
            parameter = client.GetParameter();
            parameter.Add("q", q);
            responseSearch = new List<Search[]>();
            responseSearch.Add(await client.GetConnection().InvokeAsync<Search[]>("idoit.search", parameter));
         }

        //Logout
        public Logout Logout()
        {
            Task t = Task.Run(() => { logout().Wait(); }); t.Wait();
            return responseLogout;
        }
        //logout
        async Task logout()
        {
            parameter = client.GetParameter();
            responseLogout = await client.GetConnection().InvokeAsync<Logout>("idoit.logout", parameter);
        }
        //Login
        public Login Login()
        {
            Task t = Task.Run(() => { login().Wait(); }); t.Wait();
            return responseLogin;
        }
        //login
        async Task login()
        {
            parameter = client.GetParameter();
            responseLogin = await client.GetConnection().InvokeAsync<Login>("idoit.login", parameter);
        }
    }
}
