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
            //byte[] json = ms.ToArray();
            //ms.Close();

            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("MyProfile", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("MyPlayerProfile" + ".json", CreationCollisionOption.ReplaceExisting);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            await file.WriteAllTextAsync(sr.ReadToEnd());
            Console.WriteLine("Break");
            ms.Close();
        }

        public async Task<Profile> Load<Profile>() where Profile : models.Profile
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("MyProfile", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("MyPlayerProfile" + ".json", CreationCollisionOption.OpenIfExists);

            string jsonString = await file.ReadAllTextAsync();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Profile));
            ms.Position = 0;
            Profile outputPlayerProfile = js.ReadObject(ms) as Profile;
            ms.Close();
            return outputPlayerProfile;
        }


    }
}
