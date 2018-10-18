using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using PCLStorage;
using System.Text;

namespace LFG.tools
{
    public class Serialization
    {
        public Serialization()
        {
        }

        public async Task Save<Profile>(Profile playerProfile)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Profile));
            js.WriteObject(ms, playerProfile);
            byte[] json = ms.ToArray();
            ms.Close();

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("MyProfile", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("MyPlayerProfile" + ".json", CreationCollisionOption.ReplaceExisting);

            StreamReader sr = new StreamReader(ms);
            await file.WriteAllTextAsync(sr.ReadToEnd());
        }

        public async Task Load<Profile>(Profile outputPlayerProfile) where Profile : class
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("MyProfile", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("MyPlayerProfile" + ".json", CreationCollisionOption.OpenIfExists);

            string jsonString = await file.ReadAllTextAsync();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Profile));
            outputPlayerProfile = js.ReadObject(ms) as Profile;
            ms.Close();
        }


    }
}
